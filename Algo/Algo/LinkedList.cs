using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Advanced;

namespace Algo
{
    public class LinkedList
    {
        public LinkedList()
        {
            head = new Node();
        }

        Node head;
        Node tail;
        int size = 0;

        public class Node
        {
            public Node()
            {
            }

            public Node(int data)
            {
                this.data = data;
            }

            public int data;
            public Node next;
        }

        public void AddAt(int index, int data)
        {
            Node current = head;

            Node newNode = new Node(data);

            if(size == 0)
            {
                head = newNode;
                tail = head;
                size++;
                return;
            }

            while(index > 0)
            {
                current = current.next;
                index--;
            }

            var temp1 = current.next;
            newNode.next = temp1;
            current.next = newNode;
            tail = newNode;
            size++;
        }

        public void AddFirst(int data)
        {
            AddAt(0, data);
        }

        public void AddLast(int data)
        {
            AddAt(size - 1, data);
        }

        public void RemoveAt()
        {

        }

        public void RemoveFirst()
        {

        }

        public void RemoveLast()
        {

        }

        public void PrintAll()
        {
            Node current = head;

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
