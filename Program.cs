using System;
using System.Collections.Generic;

namespace Algo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Node tree = new Node(3);

            tree.Insert(1);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(15);
            tree.Insert(9);

            tree.PrintInOrder();
        }

        static void QuickSort(int[] arr, int L, int R) 
        {
            int left = L;
            int right = R;
            int pivot = arr[(L+R)/2];

            do
            {
                while (arr[left] < pivot)
                    left++;

                while (arr[right] > pivot)
                    right--;

                if (left <= right) //포인터 두 개가 지나치지 않았는지 확인
                {
                    Swap(arr, left, right);
                    left++;
                    right--;
                }
            }
            while (left <= right);

            if(L < right)
            {
                QuickSort(arr, L, right);
            }

            if (left < R)
            {
                QuickSort(arr, left, R);
            }
        }
          
        static void Swap(int[] arr, int a, int b)
        {
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        static void SelectionSort(int[] arr)
        {
            int minimumPos = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                minimumPos = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[minimumPos] > arr[j])
                    {
                        minimumPos = j;
                    }
                }

                var temp = arr[i];
                arr[i] = arr[minimumPos];
                arr[minimumPos] = temp;
            }

            foreach (var each in arr)
            {
                Console.WriteLine(each);
            }
        }

        static void PrintAll(int[] arr)
        {
            foreach(var each in arr)
            {
                Console.WriteLine(each);
            }
        }

        static int[] arr = new int[] { 9, 4, 1, 5, 7, 2, 8, 11, 50, 81, 100, 92, 53, 78, 41, 111 };
    }

    class ArrayStack<T>
    {
        public ArrayStack()
        {
            items = new T[0];
        }

        int top;
        int maxSize = 10;
        T[] items;

        public void Push(T value)
        {
            T[] newItems = new T[top + 1];
            items.CopyTo(newItems, 0);
            items = newItems;

            items[top] = value;
            top++;
        }

        public T Pop()
        {
            if (top == 0)
            {
                throw new InvalidOperationException("Empty");
            }

            top--;
            return items[top];
        }

        public void Clear()
        {
            top = 0;
        }

        public bool isEmpty()
        {
            return items.Length == 0 ? true : false;
        }
    }

    class LinkedStack<T>
    {
        public LinkedStack()
        {
            list = new LinkedList<T>();
        }

        LinkedList<T> list;

        public void Push(T value)
        {
            list.AddFirst(value);
        }

        public T Pop()
        {
            var result = list.First.Value;
            list.RemoveFirst();

            return result;
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool isEmpty()
        {
            return list.Count == 0 ? true : false;
        }
    }

    class Queue<T>
    {
        public Queue()
        {
            items = new T[0];
        }

        T[] items;
        int size;

        public void Enqueue(T value)
        {
            size++;
            T[] newItems = new T[size];
            items.CopyTo(newItems, 0);
            items = newItems;
            items[size - 1] = value;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                Console.WriteLine("Empty");
            }

            size--;
            var result = items[0];
            T[] newItems = new T[size];
            //items.CopyTo(newItems, 0);
            Array.Copy(items, 1, newItems, 0, size);
            items = newItems;

            return result;
        }
    }

    class HashTable
    {
        public HashTable()
        {
            this.size = INITIAL_SIZE;
            this.buckets = new Node[size];
        }

        public HashTable(int capacity)
        {
            this.size = capacity;
            this.buckets = new Node[size];
        }

        public void Put(object key, object value)
        {
            int hash = HashCode(key);
            int index = ConvertToIndex(hash);

            if (buckets[index] == null)
            {
                buckets[index] = new Node(key, value);
                return;
            }

            //새 노드를 기존 첫 노드 앞에 집어넣음
            Node newNode = new Node(key, value);
            newNode.Next = buckets[index];
            buckets[index] = newNode;
        }

        public object Get(object key)
        {
            int hash = HashCode(key);
            int index = ConvertToIndex(hash);

            if (buckets[index] != null)
            {
                for(Node n = buckets[index]; n != null; n = n.Next)
                {
                    if(n.Key == key)
                    {
                        return n.Value;
                    }
                }
            }
            return null;
        }

        public bool Contains(object key)
        {
            int hash = HashCode(key);
            int index = ConvertToIndex(hash);

            if (buckets[index] != null)
            {
                while(buckets[index].Next != null)
                {
                    if (buckets[index].Key == key)
                    {
                        return true;
                    }

                    buckets[index] = buckets[index].Next;
                }
            }
            return false;
        }

        public int HashCode(object key)
        {
            int hashcode = 0;
            string stringKey = (string)key;

            foreach(var each in stringKey.ToCharArray())
            {
                hashcode += each;
            }
            return hashcode;
        }

        public int ConvertToIndex(int hashcode)
        {
            return hashcode % buckets.Length;
        }

        class Node
        {
            public Node(object key, object value)
            {
                this.Key = key;
                this.Value = value;
            }

            public object Key;
            public object Value;
            public Node Next;
        }

        private const int INITIAL_SIZE = 16;
        private int size;
        private Node[] buckets;
    }

    class LinkedList
    {
        Node head;

        class Node
        {
            public Node(int data)
            {
                this.data = data;
            }
            public Node Next;   //For linear probing
            public int data;
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                return;
            }

            newNode.Next = head;
            head = newNode;
        }

        public void AddLast(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node current = head;

            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }

        public int Find(int data)
        {
            Node current = head;
            
            while(current.data != data)
            {
                current = current.Next;
            }

            return current.data;
        }

        public void PrintAll()
        {
            Node current = head;

            while(current.Next != null)
            {
                Console.WriteLine(current.data);
                current = current.Next;
            }
            Console.WriteLine(current.data);
        }
    }


    public class Node
    {
        public Node(int data)
        {
            this.data = data;
        }

        Node left;
        Node right;
        int data;

        public void Insert(int value)
        {
            if(value <= data)   //왼쪽 먼저 갔다가 아니면 오른쪽으로 감
            {
                if (left == null)
                {
                    left = new Node(value);
                }
                else
                {
                    left.Insert(value);
                }
            }
            else
            {
                if(right == null)
                {
                    right = new Node(value);
                }
                else
                {
                    right.Insert(value);
                }
            }
        }

        public bool Contains(int value)
        {
            if(value == data)
            {
                return true;
            }
            else if(value < data)
            {
                if(left == null)
                {
                    return false;
                }
                else
                {
                    return left.Contains(value);
                }
            }
            else
            {
                if(right == null)
                {
                    return false;
                }
                else
                {
                    return right.Contains(value);
                }
            }
        }

        public void PrintInOrder()
        {
            if (left != null)
            {
                left.PrintInOrder();
            }

            Console.WriteLine(data);

            if (right != null)
            {
                right.PrintInOrder();
            }
        }
    }
}
