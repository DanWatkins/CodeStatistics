using System;

namespace CodeStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeStatistics.File file = new File();
            file.Load("default.txt");


            Directory dir = new Directory();
            dir.Load("../../");

            Console.WriteLine("Size is " + dir.CalculateSize()/1024/1024 + " MiB");
        }
    }
}