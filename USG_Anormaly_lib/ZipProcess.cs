using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USG_Anormaly_lib
{
    public class ZipProcess
    {
        public bool unZip(string zipPath, string destinationPath)
        {

            if (!File.Exists(zipPath))
                return false;
            if (!Directory.Exists(destinationPath))
                return false;

            var fileList = Directory.GetFiles(destinationPath, "*", SearchOption.AllDirectories);
            foreach (var file in fileList)
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {

                }
            }

            ZipFile.ExtractToDirectory(zipPath, destinationPath);
            Console.WriteLine("Extracted Successfully");
            return true;
        }
        public bool deleteZip(string zipPath)
        {
            if (!File.Exists(zipPath))
            {
                return false;
            }
            File.Delete(zipPath);
            return true;
        }
    }
}
