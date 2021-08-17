using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    class Stack<T> : IEnumerable<Node<T>>
    {
        readonly Deque<T> myStack = new Deque<T>();

        public void Push(T value)
        {
            myStack.EnqueueHead(value);
        }

        public void Pop()
        {
            myStack.DequeueHead();
        }

        public T Peek()
        {
            return myStack.PeekHead();
        }

        public bool Contains(T value)
        {
            return myStack.Contains(value);
        }

        public void Reverse()
        {
            myStack.Reverse();
        }

        public void Print()
        {
            myStack.Print();
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return myStack.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Size { get { return myStack.Size; } }
    }
}
