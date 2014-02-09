//=======================================================================================================================|
// Created 2014.02.08 by Daniel L. Watkins
//
// Copyright (C) 2014 Daniel L. Watkins
// This file is licensed under the MIT License.
//=======================================================================================================================|

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStatistics
{
    class Directory : Item
    {
        private List<Item> mFiles, mDirectories;
        private List<String> mPermittedFileExtensions;

        public Directory(List<String> permittedFileExtensions)
        {
            mFiles = new List<Item>();
            mDirectories = new List<Item>();

            mPermittedFileExtensions = permittedFileExtensions;
        }


        /**
         * Loads this directory and every directory and file beneath it.
         * Directores are added to @mDirectories and files are added to @mFiles.
         */
        public override void Load(String filepath)
        {
            if (!System.IO.Directory.Exists(filepath))
            {
                Console.WriteLine("Filepath does not exist");
                Console.WriteLine(filepath);

                return;
            }

            List<String> entries = System.IO.Directory.GetFileSystemEntries(filepath).ToList();
            mFiles.Clear();
            mDirectories.Clear();

            foreach (String entry in entries)
            {
                //if it is a directory
                if (System.IO.Directory.Exists(entry))
                {
                    Directory dir = new Directory(mPermittedFileExtensions);
                    dir.Load(entry);
                    dir.setName(entry);
                    mDirectories.Add(dir);
                }
                //if it is a file
                else
                {
                    //only load the file if it has an acceptable extension
                    String extension = ExtensionForPath(entry);
                    bool permitted = false;

                    foreach (String ext in mPermittedFileExtensions)
                    {
                        if (ext.Equals(extension))
                        {
                            permitted = true;
                            break;
                        }
                    }

                    if (true)
                    {
                        File file = new File();
                        file.Load(entry);
                        file.setName(entry);
                        mFiles.Add(file);
                    }
                }
            }
        }


        private bool PathContainsPermittedExtension(String path)
        {


            return false;
        }


        /*
         * Returns the size in bytes of everything below this directory
         */
        public override long CalculateSize()
        {
            long size = 0;

            foreach (Directory dir in mDirectories)
            {
                size += dir.CalculateSize();
            }


            foreach (File file in mFiles)
            {
                size += file.CalculateSize();
            }

            return size;
        }


        /*
         * Returns the number of lines of text in all files and sub-directories
         */
        public override long CalculateLineCount()
        {
            long count = 0;

            foreach (Directory dir in mDirectories)
            {
                count += dir.CalculateLineCount();
            }


            foreach (File file in mFiles)
            {
                count += file.CalculateLineCount();
            }

            return count;
        }


        /*
         * Returns the item name including a file extension if there is one.
         */
        public String LastPathComponent(String path)
        {
            path.Replace("\\", "/");
            List<String> pathComponents = path.Split('/').ToList<String>();

            if (pathComponents.Count > 0)
                return pathComponents.ElementAt<String>(pathComponents.Count-1);

            return "";
        }


        /*
         * Returns the extension of the path if it is to a file.
         * Extension does not include the "."
         */
        public String ExtensionForPath(String path)
        {
            //return blank if this is a directory
            if (System.IO.Directory.Exists(path))
                return "";

            List<String> components = path.Split('.').ToList<String>();
            if (components.Count > 0)
                return components.ElementAt<String>(components.Count - 1);

            return "";
        }
    }
}
