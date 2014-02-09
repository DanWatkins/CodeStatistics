//=======================================================================================================================|
// Created 2014.02.08 by Daniel L. Watkins
//
// Copyright (C) 2014 Daniel L. Watkins
// This file is licensed under the MIT License.
//=======================================================================================================================|

using System;
using System.Collections.Generic;

namespace CodeStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = Console.ReadLine();

            List<String> permittedFileExtentions = new List<String>();
            permittedFileExtentions.Add("cs");
            permittedFileExtentions.Add("c");
            permittedFileExtentions.Add("h");
            permittedFileExtentions.Add("cpp");
            permittedFileExtentions.Add("hpp");
            permittedFileExtentions.Add("m");
            permittedFileExtentions.Add("java");
            permittedFileExtentions.Add("html");
            permittedFileExtentions.Add("htm");
            permittedFileExtentions.Add("php");

            Directory dir = new Directory(permittedFileExtentions);
            dir.Load(input);

            Console.WriteLine("Size is " + dir.CalculateSize()/1024 + " KiB");
            Console.WriteLine("LOC is " + dir.CalculateLineCount());
        }
    }
}