using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace algorithms
{
    public class Stack
    {
        public int length = 0;
        private Element? head;

        public Stack()
        {
            head = null;
        }

        public void Push(int value)
        {
            Element new_elem = new Element(value, head);
            head = new_elem;
            this.length++;
        }

        public Element? Pop()
        {
            if (head != null)
            {
                Element result = head;
                head = head.Next;
                length--;
                return result;
            }
            else
            {
                throw new Exception("Stack is empty.");
            }
        }

        public string Show()
        {
            string result = "HEAD -> { ";
            if (head != null)
            {
                Element current_element = head;
                do
                {
                    result += current_element.Value.ToString() + ", ";
                    current_element = current_element.Next;
                }
                while (current_element != null);
                return result.Substring(0, result.Length - 2) + " }";
            }
            return result + " }";

        }
    }
}
