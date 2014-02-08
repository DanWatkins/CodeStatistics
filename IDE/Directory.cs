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

        public override void Load(String filepath)
        {
            List<String> entries = System.IO.Directory.GetFileSystemEntries(filepath).ToList();
            mFiles = new List<Item>();
            mDirectories = new List<Item>();

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
    }
}
