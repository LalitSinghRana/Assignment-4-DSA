using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    class TreeNode<T>
    {
        public void Insert(T value, TreeNode<T> parent)
        {
            TreeNode<T> node = new TreeNode<T>(value);
            parent.Children.Add(node);
        }

        public void Insert(TreeNode<T> node, TreeNode<T> parent)
        {
            parent.Children.Add(node);
        }

        public void Delete(TreeNode<T> node, TreeNode<T> parent)
        {
            if (parent !=  null && parent.Children.Contains(node)) parent.Children.Remove(node);
            else throw new Exception("No such child node exist under given parent node.");
        }

        public bool Contains(TreeNode<T> node)
        {
            if (this == node) return true;
            foreach (var child in this.Children)
            {
                if (child.Contains(node)) return true;
            }

            return false;
        }

        public bool Contains(T value)
        {
            if (this.Value.Equals(value)) return true;
            foreach (var child in this.Children) if (child.Contains(value)) return true;

            return false;
        }

        public List<TreeNode<T>> GetElementsByValue(T value)
        {
            List<TreeNode<T>> valueList = new();

            if (this.Value.Equals(value)) valueList.Add(this);
            foreach (var child in this.Children)
            {
                var tempList = child.GetElementsByValue(value);
                foreach (var element in tempList) valueList.Add(element);
            }

            return valueList;
        }

        public List<TreeNode<T>> GetElementsByLevel(int level)
        {
             
            List<TreeNode<T>> levelList = new();
            if (level == 0) levelList.Add(this);
            else
            {
                foreach (var child in this.Children)
                {
                    var tempList = child.GetElementsByLevel(level - 1);
                    foreach (var element in tempList) levelList.Add(element);
                }
            }
            return levelList;
        }

        public IEnumerator<TreeNode<T>> GetEnumeratorDFS()
        {
            foreach (var child in this.Children) child.GetEnumeratorDFS();
            yield return this;
        }

        public IEnumerator<TreeNode<T>> GetEnumeratorBFS()
        {
            var BFSQueue = new Queue<TreeNode<T>>();
            BFSQueue.Enqueue(this);

            while (BFSQueue.Size > 0)
            {
                int count = BFSQueue.Size;
                while (count > 0)
                {
                    var topNode = BFSQueue.Peek();
                    BFSQueue.Dequeue();
                    yield return topNode;
                    foreach (var child in topNode.Children) BFSQueue.Enqueue(child);
                    count--;
                }
            }
        }

        public void PrintDFS()
        {
            foreach (var child in this.Children) child.PrintDFS();
            Console.Write(this.Value);
        }

        public void PrintBFS()
        {
            var BFSQueue = new Queue<TreeNode<T>>();
            BFSQueue.Enqueue(this);

            while(BFSQueue.Size > 0)
            {
                int count = BFSQueue.Size;
                while(count > 0)
                {
                    var topNode = BFSQueue.Peek();
                    BFSQueue.Dequeue();
                    Console.Write(topNode.Value);
                    foreach(var child in topNode.Children) BFSQueue.Enqueue(child);
                    count--;
                }
            }
        }

        public TreeNode()
        {
            Value = default;
            Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value, List<TreeNode<T>> children)
        {
            Value = value;
            Children = children;
        }

        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }
    }
}
