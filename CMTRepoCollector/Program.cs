using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Microsoft.VisualBasic;


namespace CMTRepoCollector
{
    class Program
    {
        public static object FileSystem { get; private set; }

        static void Main(string[] args)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Craneware\ACMPT\NetworkConfig\");
            string sourcePath = (string)registryKey.GetValue("SharedPath");

            string targetPath = @"C:\TEST";
            string targetDatabase = targetPath + @"\Databases";
            string targetRepo = targetPath + @"\Repository";

            Directory.CreateDirectory(targetPath);
            Directory.CreateDirectory(targetDatabase);
            Directory.CreateDirectory(targetRepo);

            var extensions = new[] { ".dat", ".loc", ".info" };

            var files = (from file in Directory.EnumerateFiles(sourcePath)
                         where extensions.Contains(Path.GetExtension(file), StringComparer.InvariantCultureIgnoreCase)
                         select new
                         {
                             Source = file,
                             Destination = Path.Combine(targetPath, Path.GetFileName(file))
                         });

            foreach (var file in files)
            {
                File.Copy(file.Source, file.Destination);
            }

            string sourceDatabase = sourcePath + @"\Databases";
            string sourceRepo = sourcePath + @"\Repository";


            DirectoryInfo dir = new DirectoryInfo(sourceDatabase);
            FileInfo[] folder = dir.GetFiles();
            foreach (FileInfo file in folder)
                {
                    string pathTo = targetDatabase + @"\" + file;
                    file.CopyTo(pathTo);
                }

            new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(sourceRepo, targetRepo);

            //FileSystem.CopyDirectory(srce, dest,)
            //Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
            //Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);

        }
    }
}
