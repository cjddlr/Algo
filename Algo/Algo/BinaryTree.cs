using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class BinaryTree<T>
    {
        public BinaryTree(T rootData)
        {
            root = new BinaryTreeNode<T>(rootData);
        }

        public BinaryTreeNode<T> root;

        public void PreorderTraversal(BinaryTreeNode<T> rootNode)
        {
            if (rootNode == null)
            {
                Console.WriteLine("\n");
                return;
            }

            Console.WriteLine("{0}", rootNode.data);

            PreorderTraversal(rootNode.left);
            PreorderTraversal(rootNode.right);
        }

        public void InorderTraversal(BinaryTreeNode<T> rootNode)
        {
            if (rootNode == null)
            {
                return;
            }

            InorderTraversal(rootNode.left);
            Console.WriteLine("{0}", rootNode.data);
            InorderTraversal(rootNode.right);
        }

        public void PostorderTraversal(BinaryTreeNode<T> rootNode)
        {
            if (rootNode == null)
            {
                Console.WriteLine("\n\n");
                return;
            }

            PostorderTraversal(rootNode.left);
            PostorderTraversal(rootNode.right);
            Console.WriteLine("{0}", rootNode.data);
        }

        public void PreorderIterative()
        {
            if (root == null)
            {
                Console.WriteLine("\n\n");
                return;
            }

            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                Console.WriteLine(node.data);

                if (node.right != null)
                {
                    stack.Push(node.right);
                }

                if(node.left != null)
                {
                    stack.Push(node.left);
                }
            }
        }

        public void InorderIterative()
        {
            #region Un-optimized
            //if (root == null)
            //{
            //    Console.WriteLine("\n\n");
            //    return;
            //}

            //var stack = new Stack<BinaryTreeNode<T>>();
            //var node = root;

            //while (node != null)
            //{
            //    stack.Push(node);
            //    node = node.left;
            //}

            //while (stack.Count > 0)
            //{
            //    node = stack.Pop();

            //    Console.WriteLine(node.data);

            //    if (node.right != null)
            //    {
            //        node = node.right;

            //        while (node != null)
            //        {
            //            stack.Push(node);
            //            node = node.left;
            //        }
            //    }
            //}
            #endregion

            #region optimized
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }

                node = stack.Pop();
                Console.WriteLine(node.data);

                node = node.right;
            }
            #endregion
        }

        public void PostorderIterative()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = root;


            while (node != null)
            {
                stack.Push(node);
                node = node.right;
            }

            node = stack.Pop();
            Console.WriteLine(node.data);


            var temp = stack.Pop();
            node = temp.left;

            Console.WriteLine(node.data);
            Console.WriteLine(temp.data);

            temp = stack.Pop();

            while (node != null)
            {
                stack.Push(node);
                node = node.right;
            }
        }
    }

    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T data)
        {
            this.data = data;
        }

        public T data;
        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;
    }
}
