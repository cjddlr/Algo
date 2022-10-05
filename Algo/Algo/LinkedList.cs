using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class LinkedList
    {
        Node head;
        Node tail;

        class Node
        {
            public Node(int data)
            {
                this.data = data;
            }

            public int data;
            public Node next;
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                tail = head;
                return;
            }

            newNode.next = head;
            head = newNode;
        }

        public void AddLast(int data)
        {
            Node newNode = new Node(data);
            Node current = head;

            if (head == null)
            {
                head = newNode;
                return;
            }

            while (current.next != null)
            {
                current = current.next;
            }

            current.next = newNode;
        }

        public void AddAt(int index, int data)
        {
            Node newNode = new Node(data);
            Node temp1 = head;

            index -= 1;
            while (index > 0)
            {
                temp1 = temp1.next;
                index--;
            }

            Node temp2 = temp1.next;

            newNode.next = temp2;
            temp1.next = newNode;

            //index가 0일때와 마지막일때가 처리 안 됐음
        }

        public void RemoveFirst()
        {
            Node temp = head.next;
            head = null;
            head = temp;
        }

        public void RemoveLast()
        {
            Node current = head;

            while (current.next != null)
                current = current.next;

            current.next = null;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            Node temp1 = head;

            index--;
            while (index > 0)
            {
                temp1 = temp1.next;
                index--;
            }

            Node temp2 = temp1.next.next;
            temp1.next = null;
            temp1.next = temp2;
        }

        public void PrintAll()
        {
            Node current;

            if (head != null && tail != null)
            {
                current = head;

                do
                {
                    Console.WriteLine(current.data);
                    current = current.next;
                }
                while (current.next != null);

                Console.WriteLine(current.data);
            }
        }
    }
}
