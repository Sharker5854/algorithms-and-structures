using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms
{
    public class Element
    {
        public int Value = 0;
        public Element? Next;

        public Element(int value, Element? next = null) 
        {
            this.Value = value;
            this.Next = next;   // указатель на следующий элемент в стеке
        }
    }
}
