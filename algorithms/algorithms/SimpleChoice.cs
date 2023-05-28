using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms
{
    public class SimpleChoice
    {
        public Stack stack;

        public SimpleChoice(Stack stack)  // 1
        {
            this.stack = stack;  // 1
            Application.N_OP += 1;
        }

        public Stack Sort()  // 54n^3 + 194n^2 + 90n + 6
        {
            int x = 0;  // 1
            int y = 0;  // 1
            int min_index = 0;  // 1

            Application.N_OP += 6;

            for (x = 0; x < stack.length - 1; x++)  // 3 + ∑_(y=1)^n▒〖1 + 54n^2+30n+3 + 2 + 27n+13 + 27n+13 + 2 + 15n+3 + 7 + 14n+2 + 2 + 15n+3 + 7 + 14n+2 + 26n+15 + 26n+15 + 4〗 =  54n^3 + 194n^2 + 94n + 3
            {
                min_index = x;  // 1
                Application.N_OP += 4;
                // В этом цикле мы находим индекс минимального элемента на отрезке от stack[x+1] до stack[stack.length - 1]
                for (y = x + 1; y < stack.length; y++)  // 3 + ∑_(y=1)^n▒〖54n+30〗 =  54n^2 + 30n + 3 
                {
                    Application.N_OP += 3;
                    if (stack[y].Value < stack[min_index].Value)  // 3 + 2*(27n+12)
                    {
                        min_index = y;  // 1
                        Application.N_OP += 1;
                    }
                    Application.N_OP += 3;
                }
                // если элемент уже и так стоит на своём месте, то перепрыгиваем на следующую итерацию
                Application.N_OP += 1;
                if (min_index == x)  // 1
                {
                    Application.N_OP += 1;
                    continue; // 1
                }
                Element current_x = stack[x];  // 27n+12+1 = 27n+13
                Element current_min = stack[min_index];  // 27n+12+1 = 27n+13
                Application.N_OP += 2;
                /* Удаляем из стека stack[min_index] (чтобы далее на его место вставить значение stack[x]) */
                Stack tmp_stack = new Stack();  // 2
                Application.N_OP += 5;
                // Добираемся до элемента stack[min_index] сквозь предшествующие ему элементы (записывая все значения во временный стек, чтоб не потерять)
                for (int i = 0; i < min_index+1; i++)   // 3 + ∑_(i=1)^n▒〖15〗 =  15n+3
                {
                    tmp_stack.Push(stack.Pop());  // 12
                    Application.N_OP += 15;
                }
                // избавляемся от головы временного стека, то бишь элемента stack[min_index]
                tmp_stack.Pop();  // 7
                Application.N_OP += 9;
                // и возвращаем всё остальное в сортируемый стек
                while (tmp_stack.length != 0)   // 2 + ∑_(i=1)^n▒〖14〗 =  14n+2
                {
                    stack.Push(tmp_stack.Pop());  // 12
                    Application.N_OP += 14;
                }
                /* Удаляем из стека stack[x] (чтобы далее на его место вставить значение stack[min_index]) */
                tmp_stack = new Stack();  // 2
                Application.N_OP += 5;
                // Добираемся до элемента stack[x] сквозь предшествующие ему элементы (записывая все значения во временный стек, чтоб не потерять)
                for (int i = 0; i < x+1; i++)   // 3 + ∑_(i=1)^n▒〖15〗 =  15n+3
                {
                    tmp_stack.Push(stack.Pop());  // 12
                    Application.N_OP += 15;
                }
                // избавляемся от головы временного стека, то бишь элемента stack[x]
                tmp_stack.Pop();  // 7
                Application.N_OP += 9;
                // и возвращаем всё остальное в сортируемый стек
                while (tmp_stack.length != 0)  // 2 + ∑_(i=1)^n▒〖14〗 =  14n+2 
                {
                    stack.Push(tmp_stack.Pop());  // 12
                    Application.N_OP += 14;
                }
                /* Вставляем stack[min_index] на бывшее место stack[x] 
                   И stack[x] на бывшее место stack[min_index]         */
                // ПРИСВАИВАЕМ ИМЕННО В ТАКОМ ПОРЯДКЕ, В ИНОМ СЛУЧАЕ current_x ВСТАНЕТ НЕ НА ТО МЕСТО И ВСЁ СЛОМАЕТСЯ НАФИГ :)
                stack[x] = current_min;  // 26n+15    
                stack[min_index] = current_x;  // 26n+15
                /* Таким образом мы свапнули местами stack[x] и stack[min_index] 
                   В этом и состоит суть простой сортировки вставкой :)          */
                Application.N_OP += 4;
            }
            return stack;
        }
    }
}
