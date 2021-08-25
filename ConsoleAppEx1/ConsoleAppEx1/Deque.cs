using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    class Deque<T> : IEnumerable<Node<T>>
    {
        readonly DoublyLinkedList<T> myDequeList = new DoublyLinkedList<T>();

        public void EnqueueHead(T value)
        {
            myDequeList.InsertAt(value, 0);
        }

        public void EnqueueTail(T value)
        {
            myDequeList.Insert(value);
        }

        public T PeekHead()
        {
            return myDequeList.Head.Value;
        }

        public T PeekTail()
        {
            return myDequeList.Tail.Value;
        }

        public void DequeueHead()
        {
            myDequeList.DeleteAt(0);
        }

        public void DequeueTail()
        {
            myDequeList.DeleteAt(Size - 1);
        }

        public bool Contains(T value)
        {
            foreach (var tempNode in myDequeList) if (tempNode.Value.Equals(value)) return true;

            return false;
        }

        public void Reverse()
        {
            myDequeList.Reverse();
        }

        public void Print()
        {
            myDequeList.Print();
        }

        public int Size
        {
            get { return myDequeList.Size; }
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return myDequeList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
