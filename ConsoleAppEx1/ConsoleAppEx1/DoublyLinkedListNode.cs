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

        public void Delete(T value)
        {
            try
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Value.Equals(value))
                    {
                        if (current == Head)
                        {
                            Head = Head.NextNode;
                            Head.PreviousNode.NextNode = null;
                            Head.PreviousNode = null;
                        }
                        else if (current == Tail)
                        {
                            Tail = Tail.PreviousNode;
                            Tail.NextNode.PreviousNode = null;
                            Tail.NextNode = null;
                        }
                        else
                        {
                            DoublyLinkedListNode<T> previousNode = current.PreviousNode, nextNode = current.NextNode;
                            if (previousNode != null) previousNode.NextNode = nextNode;
                            if (nextNode != null) nextNode.PreviousNode = previousNode;
                        }

                        Size--;
                        return;
                    }
                    current = current.NextNode;
                }

                Console.WriteLine("No such value in the Linked List");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeleteAt(int index)
        {
            try
            {
                if (index >= Size || index < 0) Console.WriteLine("Error : Invalid index {0}", index);
                else
                {
                    if(index == 0)
                    {
                        Head = Head.NextNode;
                        Head.PreviousNode.NextNode = null;
                        Head.PreviousNode = null;
                    } 
                    else if (index == Size-1)
                    {
                        Tail = Tail.PreviousNode;
                        Tail.NextNode.PreviousNode = null;
                        Tail.NextNode = null;
                    } 
                    else
                    {
                        var current = Head;
                        int count = 0;
                        while (true)
                        {
                            if (index == count)
                            {
                                DoublyLinkedListNode<T> previousNode = current.PreviousNode, nextNode = current.NextNode;
                                if (previousNode != null) previousNode.NextNode = nextNode;
                                if (nextNode != null) nextNode.PreviousNode = previousNode;
                                break;
                            }
                            count++;
                            current = current.NextNode;
                        }
                    }

                    Size--;
                    return;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
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

        public IEnumerator<DoublyLinkedListNode<T>> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Print()
        {
            var current = Head;
            while(current != null)
            {
                Console.Write("{0} -> ", current.Value);
                current = current.NextNode;
            }
            Console.Write("null\n");
        }

        public DoublyLinkedListNode<T> Head { get; private set; }

        public DoublyLinkedListNode<T> Tail { get; private set; }

        public int Size { get; private set; }
    }
}
