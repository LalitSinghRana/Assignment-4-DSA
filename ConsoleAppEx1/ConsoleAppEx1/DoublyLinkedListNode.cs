using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    public class DoublyLinkedListNode<T>
    {
        /*
         * [x] value
         * [x] next 
         * [x] previous
         * 
         * [x] Constructor
         */
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public DoublyLinkedListNode<T> NextNode { get; set; }
        public DoublyLinkedListNode<T> PreviousNode { get; set; }
    }

    public class DoublyLinkedList<T> :
        IEnumerable<DoublyLinkedListNode<T>>
    {
        /*
         * [x] head
         * [x] tail
         * [x] insert : insert after last node
         * [x] insert at position
         * [ ] delete : ???
         * [ ] delete at position 
         * [x] center
         * [x] reverse
         * [x] size
         * [x] iterator 
         * [ ] traverse/print
         */
        
        public void Insert(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if (Size == 0)
            {
                Head = newNode;
            }else
            {
                Tail.NextNode = newNode;
                newNode.PreviousNode = Tail;
            }
            Tail = newNode;
            Size++;
        }

        public void InsertAt(T value, int index)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (index >= Size) {
                Insert(value);
                return;
            }
            else if (index <= 0)
            {
                newNode.NextNode = Head;
                Head.PreviousNode = newNode;
                Head = newNode;
            }else
            {
                int tempCount = 0;
                var current = Head;

                while(tempCount < index)
                {
                    current = current.NextNode;
                    tempCount++;
                }

                var previous = current.PreviousNode;

                previous.NextNode = newNode;
                newNode.PreviousNode = previous;

                current.PreviousNode = newNode;
                newNode.NextNode = current;
            }

            Size++;
        }

        public T Center() 
        {
            var forwardIterator = Head;
            var backwardIterator = Tail;

            while (true)
            {
                if (forwardIterator.NextNode == backwardIterator ||
                    forwardIterator == backwardIterator) return forwardIterator.Value;

                forwardIterator = forwardIterator.NextNode;
                backwardIterator = backwardIterator.PreviousNode;
            }
        }

        public void Reverse()
        {
            var forwardIterator = Head;
            var backwardIterator = Tail;

            while(forwardIterator != backwardIterator)
            {
                var tempValueHolder = forwardIterator.Value;
                forwardIterator.Value = backwardIterator.Value;
                backwardIterator.Value = tempValueHolder;

                if (forwardIterator.NextNode == backwardIterator) break;

                forwardIterator = forwardIterator.NextNode;
                backwardIterator = backwardIterator.PreviousNode;
            }
        }
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }
        public int Size { get; private set; }

        public IEnumerator<DoublyLinkedListNode<T>> GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
