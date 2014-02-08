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


        public Directory()
        {
            mFiles = new List<Item>();
            mDirectories = new List<Item>();
        }

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
                    Directory dir = new Directory();
                    dir.Load(entry);
                    dir.setName(entry);
                    mDirectories.Add(dir);
                }
                //if it is a file
                else
                {
                    File file = new File();
                    file.Load(entry);
                    file.setName(entry);
                    mFiles.Add(file);
                }
            }
        }


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
    }
}
