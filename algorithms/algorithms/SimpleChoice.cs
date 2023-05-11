using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms
{
    public class SimpleChoice
    {
        public int[] array;

        public SimpleChoice(int[] array)
        {
            this.array = array;
        }

        public int[] Sort()
        {
            int x, y, min_index;
            for (x = 0; x < array.Length - 1; x++)
            {
                min_index = x;
                for (y = x + 1; y < array.Length; y++)
                {
                    if (array[y] < array[min_index])
                    {
                        min_index = y;
                    }
                }
                (array[x], array[min_index]) = (array[min_index], array[x]);
            }
            return array;
        }
    }
}
