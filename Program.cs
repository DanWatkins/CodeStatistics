using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a directory to get stats:");
        string rootPath = Console.ReadLine();

        if (rootPath.EndsWith("/"))
            rootPath = rootPath.Substring(0, rootPath.Length - 1);

        if (!Directory.Exists(rootPath))
        {
            Console.WriteLine("Error: Directory does not exist");
            return;
        }

        var nodes = GetNodesForDirectory(rootPath).OrderByDescending(n => n.LineCount);
        int maxCharacterWidth = nodes.Max(n => n.Name.Length) + 2;

        foreach (var node in nodes)
        {
            Console.WriteLine($"{node.Name.PadRight(maxCharacterWidth, ' ')} - {node.LineCount} LOC");
        }

        Console.WriteLine();
        Console.WriteLine($"{"Total".PadRight(maxCharacterWidth, ' ')} - {nodes.Sum(n => n.LineCount)} LOC");
    }

    static List<Node> GetNodesForDirectory(string directory)
    {
        var nodes = new List<Node>();

        foreach (var d in Directory.GetDirectories(directory))
        {
            var subNodes = GetNodesForDirectory(d);
            nodes.Add(new Node(new DirectoryInfo(d).Name, subNodes.Sum(n => n.LineCount)));
        }

        foreach (var f in Directory.GetFiles(directory))
        {
            nodes.Add(new Node(new FileInfo(f).Name, GetLineCountOfFile(f)));
        }

        return nodes;
    }

    static int GetLineCountOfFile(string filepath)
    {
        return File.ReadLines(filepath).Count();
    }
}

class Node
{
    public Node(string name, int lineCount)
    {
        Name = name;
        LineCount = lineCount;
    }

    public string Name { get; }

    public int LineCount { get; }
}