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
        public Node tail;
        int size;

        public class Node
        {
            public Node(int data)
            {
                this.data = data;
            }

            public int data;
            public Node prev;
            public Node next;
        }

        public void AddAt(int index, int data)
        {
            Node newNode = new Node(data);
            Node current;

            if(head == null)
            {
                head = newNode;
                tail = head;
                size++;
                return;
            }

            if (index == 0)
            {
                AddFirst(data);
                return;
            }
            else if (index >= size - 1)
            {
                AddLast(data);
                return;
            }

            if (index > size/2) //Tail에서 접근하는 게 이득
            {
                current = tail;

                var count = size - index;

                while (--index != 0)
                    current = current.prev;

                Node temp1 = current.prev;
                Node temp2 = current;

                temp1.next = newNode;
                newNode.next = temp2;
                temp2.prev = newNode;
                newNode.prev = temp1;

                size++;
            }
            else                //Head에서 접근하는 게 이득
            {
                current = head;

                while (--index != 0)
                    current = current.next;

                Node temp1 = current;
                Node temp2 = current.next;

                temp1.next = newNode;
                newNode.next = temp2;
                temp2.prev = newNode;
                newNode.prev = temp1;

                size++;
            }
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
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
            Node current = head;

            if (head == null)
            {
                head = newNode;
                tail = head;
                size++;
                return;
            }

            while (current.next != null)
                current = current.next;

            //Tail 없을 때
            current.next = newNode;
            newNode.prev = current;
            tail = newNode;
            size++;

            //Tail 있을 때
            //tail.next = newNode;
            //newNode.prev = tail;
            //tail = newNode;
            //size++;
        }

        public void RemoveAt()
        {
            
        }

        public void RemoveFirst()
        {
            if (head == null)
                return;

            Node temp = head;
            head = head.next;
            temp = null;
            size--;
        }

        public void RemoveLast()
        {
            Node current = head;

            if (head == null)
                return;

            //Tail 없을 때
            //while (current.next.next != null)
            //    current = current.next;

            //Node temp = current.next;
            //temp.prev = null;
            //current.next = null;
            //tail = current;
            //size--;


            //Tail 있을 때
            Node temp = tail.prev;
            temp.next = null;
            tail.prev = null;
            tail = null;
            tail = temp;
            size--;
        }

        public void PrintAll()
        {
            Node current = head;

            if (head == null)
            {
                Console.WriteLine("No nodes");
                return;
            }

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
