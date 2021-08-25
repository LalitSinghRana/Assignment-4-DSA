using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    public class DoublyLinkedList<T> :
        IEnumerable<Node<T>>
    {
        public void Insert(T value)
        {
            var newNode = new Node<T>(value);
            if (Size == 0)
            {
                Head = newNode;
            }
            else
            {
                Tail.NextNode = newNode;
                newNode.PreviousNode = Tail;
            }
            Tail = newNode;
            Size++;
        }

        public void InsertAt(T value, int index)
        {
            var newNode = new Node<T>(value);

            if (index >= Size)
            {
                Insert(value);
                return;
            }
            else if (index <= 0)
            {
                newNode.NextNode = Head;
                Head.PreviousNode = newNode;
                Head = newNode;
            }
            else
            {
                int tempCount = 0;
                var currentNode = Head;

                while (tempCount < index)
                {
                    currentNode = currentNode.NextNode;
                    tempCount++;
                }

                var previous = currentNode.PreviousNode;

                previous.NextNode = newNode;
                newNode.PreviousNode = previous;

                currentNode.PreviousNode = newNode;
                newNode.NextNode = currentNode;
            }

            Size++;
        }

        public void Delete(T value)
        {
            try
            {
                var currentNode = Head;
                while (currentNode != null)
                {
                    if (currentNode.Value.Equals(value))
                    {
                        if (currentNode == Head)
                        {
                            Head = Head.NextNode;
                            Head.PreviousNode.NextNode = null;
                            Head.PreviousNode = null;
                        }
                        else if (currentNode == Tail)
                        {
                            Tail = Tail.PreviousNode;
                            Tail.NextNode.PreviousNode = null;
                            Tail.NextNode = null;
                        }
                        else
                        {
                            Node<T> previousNode = currentNode.PreviousNode, nextNode = currentNode.NextNode;
                            if (previousNode != null) previousNode.NextNode = nextNode;
                            if (nextNode != null) nextNode.PreviousNode = previousNode;
                        }

                        Size--;
                        return;
                    }
                    currentNode = currentNode.NextNode;
                }

                Console.WriteLine("No such value in the Linked List");
            }
            catch (Exception e)
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
                    if (index == 0)
                    {
                        if(Size == 1)
                        {
                            Head.NextNode = null;
                            Head.PreviousNode = null;
                            Head = null;
                            Tail = Head;
                        }
                        else
                        {
                            Head = Head.NextNode;
                            Head.PreviousNode.NextNode = null;
                            Head.PreviousNode = null;
                        }
                    }
                    else if (index == Size - 1)
                    {
                        Tail = Tail.PreviousNode;
                        Tail.NextNode.PreviousNode = null;
                        Tail.NextNode = null;
                    }
                    else
                    {
                        var currentNode = Head;
                        int count = 0;
                        while (true)
                        {
                            if (index == count)
                            {
                                Node<T> previousNode = currentNode.PreviousNode, nextNode = currentNode.NextNode;
                                if (previousNode != null) previousNode.NextNode = nextNode;
                                if (nextNode != null) nextNode.PreviousNode = previousNode;
                                break;
                            }
                            count++;
                            currentNode = currentNode.NextNode;
                        }
                    }

                    Size--;
                    return;
                }
            }
            catch (Exception e)
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

            while (forwardIterator != backwardIterator)
            {
                var tempValueHolder = forwardIterator.Value;
                forwardIterator.Value = backwardIterator.Value;
                backwardIterator.Value = tempValueHolder;

                if (forwardIterator.NextNode == backwardIterator) break;

                forwardIterator = forwardIterator.NextNode;
                backwardIterator = backwardIterator.PreviousNode;
            }
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Print()
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                Console.Write("{0} -> ", currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            Console.Write("null\n\n");
        }

        public Node<T> Head { get; private set; }

        public Node<T> Tail { get; private set; }

        public int Size { get; private set; }
    }
}
