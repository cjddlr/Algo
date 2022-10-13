using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class LinkedStack
    {
        SinglyLinkedList list;

        public LinkedStack()
        {
            list = new SinglyLinkedList();
        }

        public void Push(int data)
        {
            list.AddLast(data);
        }

        public int Pop()
        {
            try
            {
                int result = list.tail.data;

                list.RemoveLast();

                return result;
            }
            catch
            {
                return -1;
            }

            //하나 남았을떄 removeLast 돌리면 에러남
        }

        public void Clear()
        {
            list.head = null;
            list.tail = null;
        }

        public bool isEmpty()
        {
            return list.head == null ? true : false;
        }
    }
}
