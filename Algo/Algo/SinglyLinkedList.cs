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
    public class SinglyLinkedList<T>
    {
        public Node<T> head;
        public int size;

        public class Node<T>
        {
            public Node(T data)
            {
                this.data = data;
            }

            public T data;
            public Node<T> next;
        }

        public void AddAt(int index, T data)
        {
            Node<T> newNode = new Node<T>(data);
            Node<T> current = head;

            if(size == 0)
            {
                head = newNode;
                size++;
                return;
            }

            if (index <= 0)
            {
                AddFirst(data);
                return;
            }
            
            if (index >= size - 1)
            {
                AddLast(data);
                return;
            }

            while (--index != 0)
                current = current.next;

            newNode.next = current.next;
            current.next = newNode;
            size++;
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if(size == 0)
            {
                head = newNode;
                size++;
                return;
            }

            newNode.next = head;
            head = newNode;
            size++;
        }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            Node<T> current = head;

            if (size == 0)
            {
                head = newNode;
                size++;
                return;
            }

            while (current.next != null)
                current = current.next;

            current.next = newNode;
            size++;
        }

        //public Node<T> AddLastRecursive(T data, Node<T> head)
        //{
        //    if (size == 0)
        //    {
        //        head = new Node<T>(data);
        //        return head;
        //    }

        //    head.next = AddLastRecursive(data, head.next);
        //    return head;
        //}

        public void RemoveAt(int index)
        {
            Node<T> current = head;

            if (size == 0)
                return;

            if (size == 1)
            {
                head = null;
                size--;
                return;
            }

            if (index <= 0)
            {
                RemoveFirst();
                return;
            }
            
            if (index >= size)
            {
                RemoveLast();
                return;
            }

            while(--index != 0)
                current = current.next;

            current.next = current.next.next;
            size--;
        }

        public void RemoveFirst()
        {
            Node<T> current = head;
            Node<T> temp = current.next;
            current = null;
            head = temp;
            size--;
        }

        public void RemoveLast()
        {
            Node<T> current = head;

            while(current.next.next != null)
                current = current.next;

            current.next = null;
            size--;
        }

        public void PrintAll()
        {
            Node<T> current = head;

            if (size == 0)
                Console.WriteLine("Empty");

            for(int i=0; i<size; i++)
            {
                Console.WriteLine(current.data);

                if (current.next != null)
                    current = current.next;
            }
        }
    }
}
