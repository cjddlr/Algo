using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class CircularArray
    {
        int[] arr;
        int count;
        int sizeLimit = 8;

        public CircularArray()
        {
            arr = new int[sizeLimit];
            count = 0;
        }

        public void Add(int data)
        {
            if (count >= sizeLimit)
            {
                arr[count - 8] = data;
                return;
            }

            arr[count] = data;
            count++;
        }

        public void PrintAll()
        {
            foreach (var each in arr)
            {
                Console.WriteLine(each);
            }
        }
    }
}
