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
    /**
     * Base class used to represent either a Directory or File
     */
    abstract class Item
    {
        private String mName;

        public Item()
        {
            mName = "";
        }

        public void setName(String name) { mName = name; }
        public String getName() { return mName; }

        public abstract void Load(String filepath);
        public abstract long CalculateSize();
        public abstract long CalculateLineCount();
    }
}