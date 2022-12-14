using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string reg = "^(a|b)(0)([0-2][0-9][0-9])";

            Regex r = new Regex(reg);
            Match m = r.Match("a0255wkk");
            Console.WriteLine(m.Groups);
            //string partToken = ".part_";
            //string FileName = "C:\\AnormalyModelUpload\\FileUpload\\SideCamDataSet1.zip.part_1.640";

            //int idxOf = FileName.IndexOf(partToken);
            //string baseFileName = FileName.Substring(0, idxOf);
            //string trailingTokens = FileName.Substring(idxOf + partToken.Length);


            //FileName = "C:\\AnormalyModelUpload\\FileUpload\\SideCamDataSet1.zip";
            //string ext = Path.GetExtension(FileName);
            //string fnames = Path.GetFileName(FileName);

            string path = @"G:\AnormalyModelUpload\DLModel\TEST-152-001\Model\front_model.hdl";
            var splitPath = path.Split('\\');
            var newpath = Path.Combine(splitPath[3], splitPath[4], splitPath[5]);
            var splitPath2 = path.Split('/');


            string aaa = @"G:\AnormalyModelUpload\DLModel\TEST-152-001\Model\result\front";
            var splitPath3 = aaa.Split('\\');
            var newpath2 = Path.Combine(splitPath3[3], splitPath3[4], splitPath3[5], splitPath3[6]);

            //var a = GetMaximumDrivePath();
            //var a = findNetworkPath();
            //Console.WriteLine(a);
            Console.ReadLine();
        }

        private static string findBestFolderlocationPath()
        {
            string dir = "";
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach (DriveInfo drive in driveInfo)
            {
                dir = Path.Combine(drive.Name, "Anormaly_configuration");
                if(Directory.Exists(dir))
                {
                    return dir;
                }
            }

            var a = (from b in driveInfo
                     where b.DriveType == DriveType.Fixed
                     orderby b.TotalSize descending
                     select b).Take(1);

            dir = Path.Combine(a.ToArray()[0].Name, "Anormaly_configuration");

            return dir;
        }
        private static string findNetworkPath()
        {
            string dir = "";
            DriveInfo[] driveInfo = DriveInfo.GetDrives();

            bool have_b = false;
            long maxNetworkDriveSize = 0;
            string driveName = "";
            foreach(var b in driveInfo)
            {
                try
                {
                    if (b.DriveType == DriveType.Network)
                    {
                        if (b.Name == @"B:\")
                            have_b = true;
                        dir = Path.Combine(b.Name, "Anormaly_ModelUpload");
                        if (Directory.Exists(dir))
                        {
                            return dir;
                        }
                        if (b.TotalSize > maxNetworkDriveSize)
                        {
                            maxNetworkDriveSize = b.TotalSize;
                            driveName = b.Name;
                        }

                    }
                }
                catch
                {

                }
            }
            if (driveName == "" || maxNetworkDriveSize == 0)
                throw new Exception("Not found network drive");
            if (!have_b)
                dir = Path.Combine(driveName, "Anormaly_configuration");
            else
                dir = Path.Combine(@"B:\", "Anormaly_configuration");
            return dir;
        }
    }
}
