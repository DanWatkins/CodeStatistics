using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStatistics
{
    /**
     * Base class used to represent either a Directory or File
     */
    abstract class Item
    {
        private String mName;

        public void setName(String name) { mName = name; }
        public String getName() { return mName; }

        public abstract void Load(String filepath);
    }
}
