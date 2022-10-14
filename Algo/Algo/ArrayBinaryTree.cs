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

        public object root
        {
            get { return arr[0]; }
            set { arr[0] = value; }
        }


    }
}
