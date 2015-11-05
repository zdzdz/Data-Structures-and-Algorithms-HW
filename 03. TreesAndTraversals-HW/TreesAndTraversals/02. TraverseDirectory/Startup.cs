//  Write a program to traverse the directory C:\WINDOWS and all its subdirectories 
//  recursively and to display all files matching the mask *.exe. Use the class System.IO.Directory.

namespace TraverseDirectory
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            var rootPath = @"C:\Windows";
            PrintAllExeFiles(rootPath);
        }

        private static void PrintAllExeFiles(string rootPath)
        {

            var subFolders = Directory.GetDirectories(rootPath);
            var containedFiles = Directory.GetFiles(rootPath);

            foreach (var file in containedFiles)
            {
                if (file.EndsWith(".exe"))
                {
                    Console.WriteLine(file);
                }
            }


            try
            {
                foreach (var folder in subFolders)
                {
                    PrintAllExeFiles(folder);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
