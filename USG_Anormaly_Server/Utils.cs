//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.IO;

namespace Shared
{
    class Utils
    {
        public string FileName { get; set; }
        public string TempFolder { get; set; }
        public int MaxFileSizeMB { get; set; }
        public List<String> FileParts { get; set; }

        public Utils()
        {
            FileParts = new List<string>();
        }

        //public bool IsDatasetUpload { get; set; } = false;


        /// <summary>
        /// original name + ".part_N.X" (N = file part number, X = total files)
        /// Objective = enumerate files in folder, look for all matching parts of split file. If found, merge and return true.
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool MergeFile(string FileName,out bool MergeFileFinished,out string baseFname)
        { 
            MergeFileFinished = false;
            bool rslt = false;
            // parse out the different tokens from the filename according to the convention
            string partToken = ".part_";

            //string f_name = Path.GetFileName(FileName);
            string f_dir = Path.GetDirectoryName(FileName);


            //int idxOf = f_name.IndexOf(partToken);

            string fnameReplace = FileName.Replace(".part_", "?");
            var fileNameSplit = fnameReplace.Split('?');


            string baseFileName = fileNameSplit[0];
            string trailingTokens = fileNameSplit[1];
            int FileIndex = 0;
            int FileCount = 0;
            baseFname = baseFileName;
            var dataSplit = trailingTokens.Split(".");

            int.TryParse(dataSplit[0], out FileIndex);
            int.TryParse(dataSplit[1], out FileCount);
            // get a list of all file parts in the temp folder
            string Searchpattern = Path.GetFileName(baseFileName) + partToken + "*";
            string[] FilesList = Directory.GetFiles(f_dir, Searchpattern);
            //  merge .. improvement would be to confirm individual parts are there / correctly in sequence, a security check would also be important
            // only proceed if we have received all the file chunks
            if (FilesList.Count() == FileCount) 
            {
                // use a singleton to stop overlapping processes
                if (!MergeFileManager.Instance.InUse(baseFileName))
                {
                    MergeFileManager.Instance.AddFile(baseFileName);
                    if (File.Exists(baseFileName))
                        File.Delete(baseFileName);
                    // add each file located to a list so we can get them into 
                    // the correct order for rebuilding the file
                    List<SortedFile> MergeList = new List<SortedFile>();
                    foreach (string File in FilesList)
                    {



                        fnameReplace = File.Replace(".part_", "?");
                        fileNameSplit = fnameReplace.Split('?');

                        //baseFileName = fileNameSplit[0];
                        trailingTokens = fileNameSplit[1];

                        dataSplit = trailingTokens.Split(".");
                        int.TryParse(dataSplit[0], out FileIndex);

                        SortedFile sFile = new SortedFile();
                        sFile.FileName = File;
                        sFile.FileOrder = FileIndex;
                        MergeList.Add(sFile);
                    }
                    // sort by the file-part number to ensure we merge back in the correct order
                    var MergeOrder = MergeList.OrderBy(s => s.FileOrder).ToList();

                    using (FileStream FS = new FileStream(baseFileName, FileMode.Create))
                    {
                        // merge each file chunk back into one contiguous file stream
                        foreach (var chunk in MergeOrder)
                        {
                            try
                            {
                                using (FileStream fileChunk = new FileStream(chunk.FileName, FileMode.Open))
                                {
                                    fileChunk.CopyTo(FS);
                                }
                            }
                            catch (IOException ex)
                            {
                                // handle                                
                            }
                        }
                    }
                    rslt = true;
                    // unlock the file from singleton
                    MergeFileManager.Instance.RemoveFile(baseFileName);
                    foreach (var tmpFile in FilesList)
                    {
                        try
                        {
                            File.Delete(tmpFile);
                        }
                        catch
                        {

                        }
                    }
                    MergeFileFinished = true;
                }
            }
            return rslt;
        }


    }

    public struct SortedFile
    {
        public int FileOrder { get; set; }
        public String FileName { get; set; }
    }

    public class MergeFileManager
    {
        private static MergeFileManager instance;
        private List<string> MergeFileList;

        private MergeFileManager()
        {
            try
            {
                MergeFileList = new List<string>();
            }
            catch { }
        }

        public static MergeFileManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new MergeFileManager();
                return instance;
            }
        }

        public void AddFile(string BaseFileName)
        {
            MergeFileList.Add(BaseFileName);
        }

        public bool InUse(string BaseFileName)
        {
            return MergeFileList.Contains(BaseFileName);
        }

        public bool RemoveFile(string BaseFileName)
        {
            return MergeFileList.Remove(BaseFileName);
        }
    }

}



