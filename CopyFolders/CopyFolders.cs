using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMTRepoCollector
{
    public class CopyFolders
    {
        public void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }


            // Get the files in the directory and copy them to the new location.
            //FileInfo[] files = dir.GetFiles();

            //foreach (FileInfo file in files)
            //{
            //    string temppath = Path.Combine(destDirName, file.Name);
            //    file.CopyTo(temppath, false);
            //}
        }
    }
}
