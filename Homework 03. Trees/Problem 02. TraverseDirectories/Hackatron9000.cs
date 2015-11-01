namespace Problem_02.TraverseDirectories
{
    using System;
    using System.IO;

   public class Hackatron9000
   {
       private static int deniedAccessDirsCount = 0;

       private static int exeFilesCount = 0;

        static void Main()
        {
            var root = "C:/WINDOWS";
            var pattern = "*.exe";
            PrintFileSystemEntries(root, pattern);
            Console.WriteLine("DOA files: " + deniedAccessDirsCount);
            Console.WriteLine("Deleted " + exeFilesCount + " exe files");
            Console.WriteLine("FATAL ERROR. The system is crashing!");

            //Uncomment for happy fun times!!!
            //Shutdown.Restart(); 
        }

       static void PrintFileSystemEntries(string path, string pattern) //Shout-out to MDSN
        {
           try
           {
               // Obtain the file system entries in the directory
               // path that match the pattern.
               string[] directoryEntries =
                   Directory.GetFileSystemEntries(path, pattern);

               foreach (string str in directoryEntries)
               {
                   Console.WriteLine(str);
                   exeFilesCount++;
               }
               var dirs = Directory.GetDirectories(path);
               foreach (var dir in dirs)
               {
                   PrintFileSystemEntries(dir, pattern);
               }
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
               Console.WriteLine("Bad touch, BAD TOUCH!!! I'm telling Bill about this!");
               deniedAccessDirsCount++;
           }
        }
    }
}
