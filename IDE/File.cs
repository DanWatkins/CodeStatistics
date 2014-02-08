//=======================================================================================================================|
// Created 2014.02.08 by Daniel L. Watkins
//
// Copyright (C) 2014 Daniel L. Watkins
// This file is licensed under the MIT License.
//=======================================================================================================================|

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CodeStatistics
{
    /**
     * Represents a text file as a List<String> containing an entry for each line of the file.
     */
    class File : Item
    {
        private List<String> mLines;

        public int getLineCount() { return mLines.Count(); }


        public File()
        {
            mLines = new List<String>();
        }


        /**
         * Reads and returns the entire file as a String.
         */
        private String ReadFile(String filepath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    String content = sr.ReadToEnd();
                    return content;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file " + filepath + " could not be read");
                Console.WriteLine(e.Message);
            }

            return "";
        }


        /**
         * Handles loading the file. After loading, statistics can be determined
         */
        public override void Load(String filepath)
        {
            String content = ReadFile(filepath);
            mLines = content.Split('\n').ToList();
        }



        public override long CalculateSize()
        {
            FileInfo fi = new FileInfo(getName());
            return fi.Length;
        }


        public override long CalculateLineCount()
        {
            if (mLines != null)
                return mLines.Count;

            return 0;
        }
    }
}
