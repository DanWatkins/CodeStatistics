using System;

namespace CodeStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeStatistics.File file = new File();
            file.Load("default.txt");
        }
    }
}