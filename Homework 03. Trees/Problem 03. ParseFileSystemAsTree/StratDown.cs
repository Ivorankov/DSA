namespace Problem_03.ParseFileSystemAsTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StratDown
    {
        static void Main()
        {
            var path = "C:/WINDOWS";
            var rootFolder = new Folder("Windows");
            ReadDirContentAndPopulateFolderObject(path, rootFolder);

            var resultSizes = Traverse(rootFolder);

            Console.WriteLine("Total size(bytes) : " + resultSizes.Sum());
            Console.WriteLine("Total size(GB) : " + (resultSizes.Sum() / 1000000000));

            Console.ReadKey();
        }

        public static List<long> Traverse(Folder folder)
        {
            var resultSizes = new List<long>();
            var fileCount = folder.Files.Length;
            for (int j = 0; j < fileCount; j++)
            {
                resultSizes.Add(folder.Files[j].FileSize);
            }

            var folderCount = folder.ChildFolders.Length;
            for (int i = 0; i < folderCount; i++)
            {
                resultSizes.AddRange(Traverse(folder.ChildFolders[i]));
            }
            return resultSizes;
        }

        private static void ReadDirContentAndPopulateFolderObject(string path, Folder rootFolder)
        {
            // Adding all files to the File[]  for the root folder
            rootFolder.AddFiles(GetAllFiles(path));

            //Adding all folders to the ChildFolders[]
            rootFolder.AddChildFolders(GetAllFolders(path));
        }

        private static File[] GetAllFiles(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] directoryEntries = dirInfo.GetFiles();
            var filesArray = new File[directoryEntries.Length];
            for (int i = 0; i < directoryEntries.Length; i++)
            {
                var file = new File(directoryEntries[i].Name, directoryEntries[i].Length);
                if (!file.Equals(null))
                {
                    filesArray[i] = file;
                }
            }

            return filesArray;
        }

        private static Folder[] GetAllFolders(string path)
        {
            var dirs = Directory.GetDirectories(path);

            var foldersArray = new Folder[dirs.Length];
            for (int i = 0; i < dirs.Length; i++)
            {
                try
                {
                    foldersArray[i] = new Folder(dirs[i], GetAllFiles(dirs[i]), GetAllFolders(dirs[i]));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Path is a null reference.");
                }
                catch (System.Security.SecurityException)
                {
                    Console.WriteLine("The caller does not have the " +
                                      "required permission.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Path is an empty string, " +
                                      "contains only white spaces, " +
                                      "or contains invalid characters.");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("The path encapsulated in the " +
                                      "Directory object does not exist.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Cannot access directory");
                    foldersArray[i] = new Folder("Access denied", new File[0], new Folder[0]);
                }

            }

            return foldersArray;
        }
    }
}
