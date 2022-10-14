using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class ArrayStack<T>
    {
        public ArrayStack()
        {
            items = new T[0];
            top = 0;
        }

        int top;
        int maxSize = 10;
        T[] items;

        public void Push(T value)
        {
            T[] newItems = new T[top+1];
            items.CopyTo(newItems, 0);
            items = newItems;

            items[top] = value;
            top++;
        }

        public T Pop()
        {
            if (top == 0)
                throw new InvalidOperationException();

            top--;
            return items[top];
        }
    }
}
