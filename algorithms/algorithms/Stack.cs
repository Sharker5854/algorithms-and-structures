using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public void Push(Element elem)
        {
            elem.Next = head;
            head = elem;
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

        public int Get(int index)
        {
            if ((this.length - 1 >= index) && (index >= 0))
            {
                Stack tmp_stack = new Stack();
                for (int cnt = 0; cnt < index; cnt++)
                {
                    tmp_stack.Push(this.Pop());
                }
                int result = this.head.Value;
                while (tmp_stack.length != 0)
                {
                    this.Push(tmp_stack.Pop());
                }
                return result;
            }
            throw new Exception("Index out of range.");  
        }

        public void Set(int index, int value)
        {
            if ((index >= 0) && (index <= this.length))
            {
                Stack tmp_stack = new Stack();
                for (int cnt = 0; cnt < index; cnt++)
                {
                    tmp_stack.Push(this.Pop());
                }
                this.Push(new Element(value, this.head));
                while (tmp_stack.length != 0)
                {
                    this.Push(tmp_stack.Pop());
                }
                return;
            }
            throw new Exception("Index out of range.");
        }

        public void Set(int index, Element value)
        {
            if ((index >= 0) && (index <= this.length))
            {
                Stack tmp_stack = new Stack();
                for (int cnt = 0; cnt < index; cnt++)
                {
                    tmp_stack.Push(this.Pop());
                }
                value.Next = this.head;
                this.Push(value);
                while (tmp_stack.length != 0)
                {
                    this.Push(tmp_stack.Pop());
                }
                return;
            }
            throw new Exception("Index out of range.");
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

        public int this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }
    }
}
