using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class Queue<T>
    {
        T[] items;
        int size;

        public Queue()
        {
            items = new T[0];
        }

        public void Enqueue(T value)
        {
            size++;

            T[] newItems = new T[size];
            items.CopyTo(newItems, 0);
            items = newItems;
            items[size-1] = value;
        }

        public T Dequeue()
        {
            if (size == 0)
                throw new IndexOutOfRangeException();

            size--;
            var result = items[0];
            T[] newItems = new T[size];
            Array.Copy(items, 1, newItems, 0, size);
            items = newItems;

            return result;
        }

        public int Count()
        {
            return items.Length;
        }
    }
}
