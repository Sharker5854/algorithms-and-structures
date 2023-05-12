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

        public SimpleChoice(Stack stack)
        {
            this.stack = stack;
        }

        public Stack Sort()
        {
            int x, y, min_index;
            
            for (x = 0; x < stack.length - 1; x++)
            {
                min_index = x;
                for (y = x + 1; y < stack.length; y++) // В этом цикле мы находим индекс минимального элемента на отрезке от stack[x+1] до stack[stack.length - 1]
                {
                    if (stack[y] < stack[min_index])
                    {
                        min_index = y;
                    }
                }
                if (min_index == x) // если элемент уже и так стоит на своём месте, то перепрыгиваем на следующую итерацию
                {
                    continue;
                }
                int current_x = stack[x];
                int current_min = stack[min_index];
                /* Удаляем из стека stack[min_index] (чтобы далее на его место вставить значение stack[x]) */
                Stack tmp_stack = new Stack();
                for (int i = 0; i < min_index+1; i++)   // Добираемся до элемента stack[min_index] сквозь предшествующие ему элементы (записывая все значения во временный стек, чтоб не потерять)
                {
                    tmp_stack.Push(stack.Pop());
                }
                tmp_stack.Pop();   // избавляемся от головы временного стека, то бишь элемента stack[min_index]
                while (tmp_stack.length != 0)   // и возвращаем всё остальное в сортируемый стек
                {
                    stack.Push(tmp_stack.Pop());
                }
                /* Удаляем из стека stack[x] (чтобы далее на его место вставить значение stack[min_index]) */
                tmp_stack = new Stack();
                for (int i = 0; i < x+1; i++)   // Добираемся до элемента stack[x] сквозь предшествующие ему элементы (записывая все значения во временный стек, чтоб не потерять)
                {
                    tmp_stack.Push(stack.Pop());
                }
                tmp_stack.Pop();   // избавляемся от головы временного стека, то бишь элемента stack[x]
                while (tmp_stack.length != 0)   // и возвращаем всё остальное в сортируемый стек
                {
                    stack.Push(tmp_stack.Pop());
                }
                /* Вставляем stack[min_index] на бывшее место stack[x] 
                   И stack[x] на бывшее место stack[min_index]         */
                stack[x] = current_min;         // ПРИСВАИВАЕМ ИМЕННО В ТАКОМ ПОРЯДКЕ, В ИНОМ СЛУЧАЕ current_x ВСТАНЕТ НЕ НА ТО МЕСТО И ВСЁ СЛОМАЕТСЯ НАФИГ :)
                stack[min_index] = current_x;
                /* Таким образом мы свапнули местами stack[x] и stack[min_index] 
                   В этом и состоит суть простой сортировки вставкой :)          */
            }
            return stack;
        }
    }
}
