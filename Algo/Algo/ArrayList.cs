using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class ArrayList<T>
    {
        public ArrayList()
        {
            size = 0;
            arr = new T[] { };
        }

        public int size;
        T[] arr;

        public void AddAt(int index, T data)
        {
            if (size == 0)
            {
                AddFirstTime(data);
                return;
            }

            if (index <= 0)
            {
                AddFirst(data);
                return;
            }

            if(index >= arr.Length - 1)
            {
                AddLast(data);
                return;
            }

            T[] tempArr = new T[++size];
            Array.Copy(arr, 0, tempArr, 0, index);
            Array.Copy(arr, index ,tempArr, index+1, arr.Length-index);
            arr = tempArr;
            arr[index] = data;
        }

        private void AddFirstTime(T data)
        {
            arr = new T[++size];
            arr[0] = data;
        }

        private void AddFirst(T data)
        {
            T[] tempArr = new T[++size];
            Array.Copy(arr, 0, tempArr, 1, arr.Length);
            arr = tempArr;
            arr[0] = data;
        }

        private void AddLast(T data)
        {
            T[] tempArr = new T[++size];
            Array.Copy(arr, 0, tempArr, 0, arr.Length);
            arr = tempArr;
            arr[arr.Length - 1] = data;
        }

        public void RemoveAt(int index)
        {
            if(size == 0)
            {
                Console.WriteLine("No data stored");
                return;
            }

            if(size == 1)
            {
                arr = new T[--size];
                return;
            }

            if(index <= 0)
            {
                RemoveFirst();
                return;
            }

            if (index >= arr.Length - 1)
            {
                RemoveLast();
                return;
            }

            T[] tempArr = new T[--size];
            Array.Copy(arr, 0, tempArr, 0, index);
            Array.Copy(arr, index+1, tempArr, index, arr.Length-1);
            arr = tempArr;
        }

        private void RemoveFirst()
        {
            T[] tempArr = new T[--size];
            Array.Copy(arr, 1, tempArr, 0, arr.Length-1);
            arr = tempArr;
        }

        private void RemoveLast()
        {
            T[] tempArr = new T[--size];
            Array.Copy(arr, 0, tempArr, 0, arr.Length-1);
            arr = tempArr;
        }

        public T Get(int index)
        {
            if(index < 0 || index > arr.Length - 1)
            {
                Console.WriteLine("Index error");
            }

            return arr[index];
        }

        public int Count()
        {
            return size;
        }

        public int IndexOf(T data)
        {
            for(int i=0; i<arr.Length-1; i++)
            {
                if (arr[i].Equals(data))
                    return i;
            }

            return -1;
        }
    }
}
