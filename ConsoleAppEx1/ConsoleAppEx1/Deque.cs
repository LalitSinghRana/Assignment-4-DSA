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
        readonly DoublyLinkedList<T> myDeque = new DoublyLinkedList<T>();

        public void EnqueueHead(T value)
        {
            myDeque.InsertAt(value, 0);
        }

        public void EnqueueTail(T value)
        {
            myDeque.Insert(value);
        }

        public T PeekHead()
        {
            return myDeque.Head.Value;
        }

        public T PeekTail()
        {
            return myDeque.Tail.Value;
        }

        public void DequeueHead()
        {
            myDeque.DeleteAt(0);
        }

        public void DequeueTail()
        {
            myDeque.DeleteAt(Size - 1);
        }

        public bool Contains(T value)
        {
            foreach (var tempNode in myDeque) if (tempNode.Value.Equals(value)) return true;

            return false;
        }

        public void Reverse()
        {
            myDeque.Reverse();
        }

        public void Print()
        {
            myDeque.Print();
        }

        public int Size
        {
            get { return myDeque.Size; }
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return myDeque.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
