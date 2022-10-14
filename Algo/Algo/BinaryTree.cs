using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class BinaryTree<T>
    {
        public BinaryTree(T root)
        {
            this.root = new BinaryTreeNode<T>(root);
        }

        public BinaryTreeNode<T> root;



        public void PreorderTraversal()
        {
            PreorderTraversal(root);
        }

        private void PreorderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;

            Console.WriteLine("{0}", node.data);

            PreorderTraversal(node.left);
            PreorderTraversal(node.right);
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
