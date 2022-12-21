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
    }
}
