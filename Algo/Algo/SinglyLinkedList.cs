using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Advanced;

namespace Algo
{
    public class SinglyLinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public class Node
        {
            public Node(int data)
            {
                this.data = data;
            }

            public int data;
            public Node next;
        }

        public void AddAt(int index, int data)
        {
            Node newNode = new Node(data);
            Node current = head;

            if(head == null)
            {
                head = newNode;
                tail = head;
                size++;
                return;
            }

            if (index == 0)
                AddFirst(data);
            else if (index >= size - 1)
                AddLast(data);


            while(--index != 0)
            {
                current = current.next;
            }

            newNode.next = current.next;
            current.next = newNode;
            size++;
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);

            if(head == null)
            {
                head = newNode;
                tail = head;
                size++;
                return;
            }
            newNode.next = head;
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

            current.next = newNode;
            tail = newNode;
            size++;
        }

        public void RemoveAt(int index)
        {
            Node current = head;

            if (head == null)
                return;

            if (index == 0)
            {
                RemoveFirst();
                return;
            }
            else if (index == size - 1)
            {
                RemoveLast();
                return;
            }

            while(--index != 0)
                current = current.next;

            var temp1 = current.next.next;
            current.next = null;
            current.next = temp1;
            size--;
        }

        public void RemoveFirst()
        {
            if (head == null)
                return;

            Node temp1 = head.next;
            head = null;
            head = temp1;
            size--;
        }

        public void RemoveLast()
        {
            Node current = head;

            if (head == null)
                return;

            while(current.next.next != null)
                current = current.next;

            current.next = null;
            tail = current;
            size--;
        }

        public void PrintAll()
        {
            Node current = head;

            if(head == null)
            {
                Console.WriteLine("No nodes");
                return;
            }

            if (size == 1)
            {
                Console.WriteLine(current.data);
                return;
            }

            do
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
            while (current != null);
        }
    }
}
