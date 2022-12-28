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

            public P data { get; set; }
            public Node<P> left { get; set; }
            public Node<P> right { get; set; }
        }

        private Node<T> root;

        public void Add(T data)
        {
            if (root == null)
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
                    throw new ApplicationException("Duplicate");
                }
                else if(cmp < 1)
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
                    if(node.right == null)
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

            while (node != null)
            {
                int cmp = data.CompareTo(node.data);

                if (cmp == 0)
                {
                    return true;
                }
                else if (cmp < 0)
                {
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }
            }

            return false;
        }

        public bool SearchRecursive(T data)
        {
            return SearchRecursive(root, data);
        }

        private bool SearchRecursive(Node<T> node, T data)
        {
            if (node == null)
                return false;

            int cmp = data.CompareTo(node.data);

            if (cmp == 0)
                return true;

            return SearchRecursive(node.left, data) || SearchRecursive(node.right, data);
        }

        public bool Remove(T data)
        {
            var node = root;
            Node<T> prev = null;

            while(node != null)
            {
                int cmp = data.CompareTo(node.data);

                if (cmp == 0)
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

            if(node == null)
                return false;

            if(node.left == null && node.right == null)         //자식노드가 0개인 경우
            {
                if(prev.left == node)
                {
                    prev.left = null;
                }
                else
                {
                    prev.right = null;
                }

                node = null;
            }
            else if(node.left == null || node.right == null)    //자식노드가 1개인 경우
            {
                var child = (node.left != null) ? node.left : node.right;

                if(prev.left == node)
                {
                    prev.left = child;
                }
                else
                {
                    prev.right = child;
                }
                node = null;
            }
            else                                                //자식노드가 2개인 경우
            {
                var pre = node;
                var min = node.right;

                while (min.left != null)
                {
                    pre = min;
                    min = min.left;
                }

                node.data = min.data;

                if(min.right != null)
                {
                    if (pre.left == min)
                    {
                        pre.left = min.right;
                    }
                    else
                    {
                        pre.right = min.right;
                    }
                }
            }
            return true;
        }

        public void PreorderTraversal()
        {
            PreorderTraversal(this.root);
        }

        private void PreorderTraversal(Node<T> root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.data);
            PreorderTraversal(root.left);
            PreorderTraversal(root.right);
        }

        private void InorderTraversal(Node<T> root)
        {
            if (root == null)
                return;

            InorderTraversal(root.left);
            Console.WriteLine(root);
            InorderTraversal(root.right);
        }

        private void PostorderTraversal(Node<T> root)
        {
            if (root == null)
                return;

            PostorderTraversal(root.left);
            PostorderTraversal(root.right);
            Console.WriteLine(root);
        }
    }
}
