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
            head = null; // изначально голова стека равняется null
        }

        /* Вталкиваем элемент в стек, со стороны головы */
        public void Push(int value) // если передано просто число
        {
            Element new_elem = new Element(value, head);   // создаём новый элемент с переданным value, поле Next которого ссылается на предыдущую голову
            head = new_elem;   // этот новый элемент теперь становитя головой
            this.length++;   // увеличиваем счетчик длины стека
        }

        public void Push(Element elem) // если передан сразу экземпляр класса Element
        {
            elem.Next = head;
            head = elem;
            this.length++;
        }

        /* Выталкиваем верхний элемент из стека, со стороны головы  */
        public Element? Pop()
        {
            if (head != null)   // если стек не пустой
            {
                Element result = head;   // сохраняем выталкиваемый элемент 
                head = head.Next;   // головой теперь становится тот элемент, который хранился в head.Next
                length--;   // уменьшаем счетчик длины стека
                return result;
            }
            else
            {
                throw new Exception("Stack is empty.");   // если стек пустой, то кидаем исключение в юзера
            }
        }

        /* Получение элемента стека по индексу */
        public int Get(int index)
        {
            if ((this.length - 1 >= index) && (index >= 0))   // если индекс попадает в диапазон стека
            {
                Stack tmp_stack = new Stack();
                for (int cnt = 0; cnt < index; cnt++)   // записываем все элементы стека до искомого индекса (не включая) во временный стек
                {
                    tmp_stack.Push(this.Pop());
                }
                int result = this.head.Value;   // сохраняем искомый элемент
                while (tmp_stack.length != 0)   // возвращаем всё как было
                {
                    this.Push(tmp_stack.Pop());
                }
                return result;
            }
            throw new Exception("Index out of range.");  
        }

        /* Вставка элемента в стек по переданному индексу */
        public void Set(int index, int value)   // вставка, если передано просто число
        {
            if ((index >= 0) && (index <= this.length))   // если индекс попадает в диапазон стека
            {
                Stack tmp_stack = new Stack();
                for (int cnt = 0; cnt < index; cnt++)   // записываем все элементы стека до искомого индекса (не включая) во временный стек
                {
                    tmp_stack.Push(this.Pop());
                }
                this.Push(new Element(value, this.head));   // вталкиваем новый элемент, поле Next которого будет ссылаться на бывший this[index] элемент
                while (tmp_stack.length != 0)   // возвращаем элементы из временного стека
                {
                    this.Push(tmp_stack.Pop());
                }
                return;
            }
            throw new Exception("Index out of range.");
        }

        public void Set(int index, Element value)   // вставка, если передан сразу экземпляр класса Element
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

        /* Красивый вывод стека с указанием головы */
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

        /* Перегрузка оператора индексации */
        public int this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }
    }
}
