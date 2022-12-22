using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T data)
        {
            this.data = data;
        }

        public T data { get; set; }
        public BinaryTreeNode<T> left { get; set; }
        public BinaryTreeNode<T> right { get; set; }
    }

    public class BinaryTree<T>
    {
        public BinaryTree(T root)
        {
            Root = new BinaryTreeNode<T>(root);
        }

        public BinaryTreeNode<T> Root { get; private set; }

        public void PreorderTraversal()
        {
            PreorderTraversal(Root);
        }

        private void PreorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;

            Console.WriteLine("{0}", node.data);

            PreorderTraversal(node.left);
            PreorderTraversal(node.right);
        }

        public void InorderTraversal()
        {
            InorderTraversal(Root);
        }

        private void InorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;

            InorderTraversal(node.left);
            Console.WriteLine(node.data);
            InorderTraversal(node.right);
        }

        public void PostorderTraversal()
        {
            PostorderTraversal(Root);
        }

        private void PostorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;

            PostorderTraversal(node.left);
            PostorderTraversal(node.right);
            Console.WriteLine(node.data);
        }

        public void IterativePreorder()
        {
            if (Root == null)
                return;

            var stack = new Stack<BinaryTreeNode<T>>();

            stack.Push(Root);

            while(stack.Count > 0)
            {
                var node = stack.Pop();

                Console.WriteLine(node.data);

                if (node.right != null)
                    stack.Push(node.right);

                if (node.left != null)
                    stack.Push(node.left);
            }
        }
    }
}
