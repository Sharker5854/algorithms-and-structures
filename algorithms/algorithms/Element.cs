﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms
{
    public class Element
    {
        public int Value = 0;
        public Element? Next = null;

        public Element(int value, Element? next = null) 
        {
            this.Value = value;
            this.Next = next;
        }
    }
}