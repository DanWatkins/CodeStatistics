//=======================================================================================================================|
// Created 2014.02.08 by Daniel L. Watkins
//
// Copyright (C) 2014 Daniel L. Watkins
// This file is licensed under the MIT License.
//=======================================================================================================================|

using System;

namespace CodeStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = Console.ReadLine();

            Directory dir = new Directory();
            dir.Load(input);

            Console.WriteLine("Size is " + dir.CalculateSize()/1024 + " KiB");
            Console.WriteLine("LOC is " + dir.CalculateLineCount());
        }
    }
}