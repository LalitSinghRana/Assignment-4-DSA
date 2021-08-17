using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    class Queue<T> : IEnumerable<Node<T>>
    {
        readonly Deque<T> myQueue = new Deque<T>();

        public void Enqueue(T value)
        {
            myQueue.EnqueueTail(value);
        }

        public void Dequeue()
        {
            myQueue.DequeueHead();
        }

        public T Peek()
        {
            return myQueue.PeekHead();
        }

        public bool Contains(T value)
        {
            return myQueue.Contains(value);
        }

        public void Reverse()
        {
            myQueue.Reverse();
        }

        public void Print()
        {
            myQueue.Print();
        }


        public IEnumerator<Node<T>> GetEnumerator()
        {
            return myQueue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Size { get { return myQueue.Size; } }
    }
}
