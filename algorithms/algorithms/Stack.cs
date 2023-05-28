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
        public int length;
        private Element? head;

        public Stack()  // 1
        {
            // изначально голова стека равняется null
            head = null;  // 1
            Application.N_OP += 1;
        }

        public bool isEmpty()  // 1
        {
            Application.N_OP += 1;
            return length == 0;  // 1
        }

        // если передан сразу экземпляр класса Element
        public void Push(Element elem)  // 4
        {
            elem.Next = head;  // 2
            head = elem;  // 1
            length++;  // 1
            Application.N_OP += 4;
        }

        /* Выталкиваем верхний элемент из стека, со стороны головы  */
        public Element? Pop()  // 6
        {
            // если стек не пустой
            Application.N_OP += 2;
            if (!isEmpty())  // 2
            {
                // сохраняем выталкиваемый элемент 
                Element result = head;  // 1
                // головой теперь становится тот элемент, который хранился в head.Next
                head = head.Next;  // 2
                // уменьшаем счетчик длины стека
                length--; // 1
                Application.N_OP += 4;
                return result;
            }
            else
            {
                // если стек пустой, то кидаем исключение в юзера
                throw new Exception("Stack is empty.");   
            }
        }

        /* Получение элемента стека по индексу */
        public Element Get(int index)  // 27n + 12
        {
            // если индекс попадает в диапазон стека
            Application.N_OP += 4;
            if ((length - 1 >= index) && (index >= 0))  // 4  
            {
                Stack tmp_stack = new Stack();  // 2
                Application.N_OP += 4;
                // записываем все элементы стека до искомого индекса (не включая) во временный стек
                for (int cnt = 0; cnt < index; cnt++)   // 2 + ∑_(cnt=1)^n▒〖13〗 =  13n+2
                {
                    tmp_stack.Push(Pop());  // 1 + 4 + 6 = 11
                    Application.N_OP += 13;
                }
                // сохраняем искомый элемент
                Element result = head;  // 1
                Application.N_OP += 4;
                // возвращаем всё как было
                while (!tmp_stack.isEmpty())  // 3 + ∑_(i=1)^n▒〖14〗 =  14n+3
                {
                    Push(tmp_stack.Pop());  // 4 + 1 + 6 = 11
                    Application.N_OP += 14;
                }
                return result;
            }
            throw new Exception("Index out of range.");  
        }

        // вставка, если передан сразу экземпляр класса Element
        public void Set(int index, Element value)   // 26n + 15
        {
            Application.N_OP += 3;
            if ((index >= 0) && (index <= length))  // 3
            {
                Stack tmp_stack = new Stack();  // 2
                Application.N_OP += 4;
                for (int cnt = 0; cnt < index; cnt++)  // 2 + ∑_(cnt=1)^n▒〖13〗 =  13n+2
                {
                    tmp_stack.Push(Pop());  // 1 + 6 + 4 = 11
                    Application.N_OP += 13;
                }
                value.Next = head;  // 2
                Push(value);  // 4
                Application.N_OP += 8;
                while (tmp_stack.length != 0)  // 2 + ∑_(i=1)^n▒〖13〗 =  13n+2
                {
                    Push(tmp_stack.Pop());  // 4 + 1 + 6 = 11
                    Application.N_OP += 13;
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
        public Element this[int index]
        {
            get 
            {
                Application.N_OP += 2;
                return Get(index);  // 27n+12+2 = 27n+14
            }
            set
            {
                Application.N_OP += 3;
                Set(index, value);  // 26n+15+3 = 26n+18
            }  
        }
    }
}
