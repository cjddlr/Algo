using System;
using System.Collections.Generic;
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

        public void PreorderTraversal()
        {
            PreorderTraversal(root);
        }

        public void PreorderTraversal(BinaryTreeNode<T> node)
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
