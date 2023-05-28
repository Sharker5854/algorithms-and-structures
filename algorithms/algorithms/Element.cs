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

        public Element(int value, Element? next = null)  // 2
        {
            this.Value = value;  // 1
            // указатель на следующий элемент в стеке
            this.Next = next;  // 1
        }
    }
}
