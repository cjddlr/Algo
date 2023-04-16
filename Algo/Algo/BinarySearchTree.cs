using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private class Node<P>
        {
            public Node(P data)
            {
                this.data = data;
            }

            public P data;
            public Node<P> left;
            public Node<P> right;
        }

        private Node<T> root;

        public void Add(T data)
        {
            if(root == null)
            {
                root = new Node<T>(data);
                return;
            }

            var node = root;

            while(node != null)
            {
                int cmp = data.CompareTo(node.data);

                if (cmp == 0)
                {
                    throw new ApplicationException("Same");
                }
                else if (cmp < 0)
                {
                    if(node.left == null)
                    {
                        node.left = new Node<T>(data);
                        break;
                    }
                    else
                    {
                        node = node.left;
                    }
                }
                else
                {
                    if (node.right == null)
                    {
                        node.right = new Node<T>(data);
                        break;
                    }
                    else
                    {
                        node = node.right;
                    }
                }
            }
        }

        public bool Search(T data)
        {
            var node = root;

            while(node != null)
            {
                int cmp = data.CompareTo(node.data);

                if (cmp == 0)
                    return true;
                else if (cmp < 0)
                    node = node.left;
                else
                    node = node.right;
            }
            return false;
        }

        public bool SearchRecursive(T data)
        {
            return SearchRecursive(root, data);
        }

        private bool SearchRecursive(Node<T> root, T data)
        {
            if (root == null) return false;

            int cmp = data.CompareTo(root.data);

            if (cmp == 0)
                return true;

            return SearchRecursive(root.left, data) || SearchRecursive(root.right, data);
        }

        public bool Remove(T data)
        {
            var node = root;
            Node<T> prev = null;

            while(node != null)
            {
                int cmp = data.CompareTo(node.data);

                if(cmp == 0)
                {
                    break;
                }    
                else if(cmp < 0)
                {
                    prev = node;
                    node = node.left;
                }
                else
                {
                    prev = node;
                    node = node.right;
                }
            }

            if (node == null) return false;

            if (node.left == null && node.right == null)            //case : 자식노드 0개
            {
                node = null;
                prev.left = null;
                prev.right = null;
            }
            else if(node.left == null || node.right == null)        //case : 자식노드 1개
            {
                var child = node.left != null ? node.left : node.right;

                if (prev.left == node)
                    prev.left = child;
                else
                    prev.right = child;

                node = null;
            }
            else                                                    //case : 자식노드 2개
            {
                var min = node.right;

                while (min.left != null)    //입력노드의 오른쪽 노드의 가장 왼쪽 노드 탐색
                {
                    prev = min;
                    min = min.left;
                }

                node.data = min.data;

                if (prev.left == min)
                {
                    prev.left = min.right;
                }
                else
                {
                    prev.right = min.right;

                }
            }
            return true;
        }
    }
}
