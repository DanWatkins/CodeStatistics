﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CodeStatistics
{
    class File
    {
        private List<String> mLines;


        public int getLineCount() { return mLines.Count(); }


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
        public void Load(String filepath)
        {
            String content = ReadFile(filepath);
            mLines = content.Split('\n').ToList();
        }
    }
}