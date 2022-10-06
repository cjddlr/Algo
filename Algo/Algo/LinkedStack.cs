using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class LinkedStack
    {
        Node head;
        Node tail;
        int size;

        class Node
        {
            public Node(int data)
            {
                this.data = data;
            }

            public int data;
            public Node next;
        }

        public void Push(int data)
        {
            Node newNode = new Node(data);

            if (size == 0)
            {
                head = newNode;
                tail = head;
                return;
            }

            tail.next = newNode;
            tail = newNode;

            size++;
        }

        public int Pop()
        {
            Node current = head;

            while (current.next.next != null)
            {
                current = current.next;
            }

            int result = current.next.data;

            Node toBeDeleted = current.next;
        }

        public void Clear()
        {

        }

        public bool isEmpty()
        {

        }
    }
}
