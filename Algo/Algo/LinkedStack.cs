using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class LinkedStack<T>
    {
        SinglyLinkedList<T> list;

        public LinkedStack()
        {
            list = new SinglyLinkedList<T>();
        }

        public void Push(T data)
        {
            list.AddLast(data);
        }



        public void Clear()
        {
            list.head = null;
        }

        public bool isEmpty()
        {
            return list.head == null ? true : false;
        }
    }
}
