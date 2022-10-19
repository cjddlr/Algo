using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3 };
            ListNode head = null;
            ListNode current = null;

            sample(0, list);
        }

        static void sample(int limit, List<int> targetList)
        {
            if (limit == targetList.Count)
            {
                return;
            }

            Console.WriteLine(targetList[limit]);
            limit++;

            sample(limit, targetList);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
