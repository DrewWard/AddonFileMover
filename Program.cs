using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;

namespace AddonFileMover
{
    class Program
    {
        //This is a program that moves files for elvui
        //This will pull down changes from github
        //then move those files from a specified folder to the addons folder
        //it will do a check on the date then 2 days from the checked date it will move the files 
        //this is a process that will poll that folder everyday around 5 AM 
        //and check between the git folder and the addons folder for what date the last update was

        static void Main(string[] args)
        {
            SearchFolders(@"c:\");
            //    var p = new Program();
            //    string start = p.SearchFolders();

            //string path = @"c:\";
            //p.ApplyAllFiles(path, SearchF);

        }

        public static void SearchFolders(string root)
        {
            Stack<string> dirs = new Stack<string>(20);
            string[] files = null;

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    //return e.Message;
                    continue;
                }

                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    //return e.Message;
                    continue;
                }

                foreach (string file in subDirs)
                {
                    try
                    {
                        //string searchDir = @"c:\";
                        string searchPattern = "ElvUI*";

                        //subDirs.SkipWhile(subDirs = @"ms");

                        DirectoryInfo di = new DirectoryInfo(file);

                        DirectoryInfo[] directories = di.GetDirectories(searchPattern);
                        FileInfo[] fi = di.GetFiles(searchPattern);

                        Console.WriteLine("The number of directories " + files.Length);

                        foreach (DirectoryInfo dir in directories)
                        {
                            Console.WriteLine(dir.FullName, dir.LastWriteTime);
                        }
                        //Console.ReadLine();
                        //return file;
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        //return e.Message;
                        continue;
                    }
                }

                foreach (string str in subDirs)
                {
                    dirs.Push(str);
                }

            }

            //search file system to find the addon folder in the World of Warcraft folder.


        }


        // Console.ReadLine();
        //return Console.ReadLine();
        //if I can't find the folder then ask for the file path.
        //pass the file path to GetGitFiles


        static void GetGitFiles()
        {
            //check to make sure the folder that git downloads files into exists
            //if the folder does exist do git command to get the newest files for ElvUI
            //if the folder doesn't exist create the folder and tell the user to make sure that they have downloaded git and that git is pointing to the correct folder, present to them the file path that git should be looking at.
            //give options to exit program
            //if the files are downloaded then 
            //date check to see when the last file in the addons folder was updated.
            //if the date from the files in the addons folder is older than the files from the git folder then do the search
            //if the date is the same then exit the application.
            //move on to move files to the World of Warcraft addons folder.
            //call the MoveFiles() method and pass the git file path and the addons file path.
        }

        static void MoveFiles()
        {
            //move the files from the git file path to the addons file path.
            //if the move executes without fail then exit the application.
            //if the move doesn't execute then tell the user.
        }
    }
}
