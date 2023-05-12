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
                Console.WriteLine(x + "   " + stack.Show());
                min_index = x;
                for (y = x + 1; y < stack.length; y++)
                {
                    if (stack[y] < stack[min_index])
                    {
                        min_index = y;
                    }
                }
                (stack[x], stack[min_index]) = (stack[min_index], stack[x]);
            }
            return stack;
        }
    }
}
