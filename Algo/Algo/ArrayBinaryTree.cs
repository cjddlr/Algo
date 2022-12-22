using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class ArrayBinaryTree
    {
        public ArrayBinaryTree(int capacity = 15)
        {
            arr = new object[capacity];
        }

        private object[] arr;

        public object Root
        {
            get { return arr[0]; }
            set { arr[0] = value; }
        }

        public void SetLeft(int parentIndex, object data)
        {
            int leftIndex = parentIndex * 2 + 1;

            if (arr[parentIndex] == null || leftIndex >= arr.Length)
                throw new ApplicationException("Error");

            arr[leftIndex] = data;
        }

        public void SetRight(int parentIndex, object data)
        {
            int rightIndex = parentIndex * 2 + 2;

            if (arr[parentIndex] == null || rightIndex >= arr.Length)
                throw new ApplicationException("Error");

            arr[rightIndex] = data;
        }

        public object GetParent(int childIndex)
        {
            if (childIndex == 0)
                return null;

            int parentIndex = (childIndex - 1) / 2;
            return arr[parentIndex];
        }

        public object GetLeft(int parentIndex)
        {
            int leftIndex = parentIndex * 2 + 1;
            return arr[leftIndex];
        }

        public object GetRight(int parentIndex)
        {
            int rightIndex = parentIndex * 2 + 2;
            return arr[rightIndex];
        }

        public void PrintTree()
        {
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine("{0}", arr[i] ?? "-");
        }
    }
}
