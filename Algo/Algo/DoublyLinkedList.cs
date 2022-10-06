using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class DoublyLinkedList
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
            public Node prev;
            public Node next;
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);

            if (size == 0)
            {
                head = newNode;
                tail = head;
                size++;
                return;
            }

            newNode.next = head;
            head.prev = newNode;
            head = newNode;
            size++;
        }

        public void AddLast(int data)
        {
            Node newNode = new Node(data);

            if (size == 0)
            {
                AddFirst(data);
                return;
            }

            Node temp1 = tail;

            tail.next = newNode;
            tail = newNode;
            tail.prev = temp1;

            size++;
        }

        public void AddAt(int index, int data)
        {
            if(size == 0)
            {
                AddFirst(data);
                return;
            }

            if (index == 0)
            {
                AddFirst(data);
                return;
            }
            else if (index == size-1 || index > size-1)
            {
                AddLast(data);
                return;
            }

            Node newNode = new Node(data);

            Node current;

            if (index > size/2)
            {
                current = tail;

                int step = (size - 1) - index;

                while(step != 0)
                {
                    current = current.prev;
                    step--;
                }
            }
            else
            {
                current = head;

                while (index != 0)
                {
                    current = current.next;
                    index--;
                }
            }

            Node temp1 = current.prev;
            Node temp2 = current.next;

            temp1.next = newNode;
            newNode.prev = temp1;
            temp2.prev = newNode;
            newNode.next = temp2;

            size++;
        }

        public void RemoveFirst()
        {
            if(size == 0)
            {
                Console.WriteLine("Size is 0");
                return;
            }

            Node temp = head.next;
            head = null;
            head = temp;
            size--;
        }

        public void RemoveLast()
        {
            if(size == 0)
            {
                Console.WriteLine("Size is 0");
                return;
            }

            Node temp1 = tail.prev;
            tail = null;
            tail = temp1;
            tail.next = null;
            size--;
        }

        public void RemoveAt(int index)
        {
            if(index == 0)
            {
                RemoveFirst();
                return;
            }
            else if(index == size - 1)
            {
                RemoveLast();
                return;
            }
            else if (index > size-1)
            {
                Console.WriteLine("Index out of range");
                return;
            }

            if (size == 0)
            {
                Console.WriteLine("Size is 0");
                return;
            }

            Node current;

            if (index > size/2)
            {
                current = tail;

                int step = (size - 1) - index;

                while(step != 0)
                {
                    current = current.prev;
                    step--;
                }
            }
            else
            {
                current = head;

                while (index != 0)
                {
                    current = current.next;
                    index--;
                }
            }

            Node temp1 = current.prev;
            Node temp2 = current.next;

            temp1.next = temp1.next.next;
            temp2.prev = temp2.prev.prev;

            current = null;

            size--;
        }

        public void PrintAll()
        {
            Node current = head;

            while (size != 0)
            {
                Console.WriteLine(current.data);
                current = current.next;
                size--;
            }
        }
    }
}
