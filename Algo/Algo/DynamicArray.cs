using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class DynamicArray
    {
        int count;
        int sizeLimit = 5;
        private int[] arr;

        public DynamicArray()
        {
            arr = new int[sizeLimit];
            count = 0;
        }

        public void Add(int data)
        {
            if (count == sizeLimit)
            {
                sizeLimit += 5;

                int[] tempArr = new int[sizeLimit];
                Array.Copy(arr, tempArr, count);

                arr = tempArr;
            }

            arr[count] = data;
            count++;
        }

        public void Remove(int index)
        {
            count--;
            sizeLimit = count;
            arr[index] = 0;

            int[] tempArr = new int[count];

            Array.Copy(arr, 0, tempArr, 0, index);
            Array.Copy(arr, index+1, tempArr, index, count-index);

            arr = tempArr;
        }

        public int Get(int index)
        {
            if (index > count - 1)
                throw new ApplicationException("not found");

            return arr[index];
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
