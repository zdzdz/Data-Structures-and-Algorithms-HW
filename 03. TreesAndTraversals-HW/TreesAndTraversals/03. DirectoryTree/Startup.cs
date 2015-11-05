namespace DirectoryTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            string rootPath = @"C:\Windows";
            var rootFolder = new Folder(rootPath);
            
            try
            {
                CreateFolderTree(rootFolder);
                var size = CalculateSize(rootFolder);
                Console.WriteLine(@"The size of C:\Windows is {0} Mb", size);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private static void CreateFolderTree(Folder folder)
        {
            var folderInfo = new DirectoryInfo(folder.Name);
            var subFilesToAdd = new List<File>();
            var subFoldersToAdd = new List<Folder>();

            FileInfo[] containedFilesInfo = folderInfo.GetFiles();
            foreach (var file in containedFilesInfo)
            {
                var fileToAdd = new File(file.Name, (int)file.Length);
                subFilesToAdd.Add(fileToAdd);
            }

            folder.Files = subFilesToAdd.ToArray();

            foreach (var subfolder in Directory.GetDirectories(folder.Name))
            {
                var folderToAdd = new Folder(subfolder);
                subFoldersToAdd.Add(folderToAdd);
                CreateFolderTree(folderToAdd);
            }

            folder.Folders = subFoldersToAdd.ToArray();
        }

        private static int CalculateSize(Folder folder, int size = 0)
        {
            foreach (var file in folder.Files)
            {
                size += file.Size;
            }

            foreach (var subfolder in folder.Folders)
            {
                size += CalculateSize(subfolder);
            }

            return size;
        }
    }
}
