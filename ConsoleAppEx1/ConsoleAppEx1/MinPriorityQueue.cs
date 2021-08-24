using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    class MinPriorityQueue<T> : IEnumerable<T> where T : IComparable, IComparable<T>
    {
        readonly List<T> minPriorityQueueList = new();

        public void Enqueue(T value)
        {
            minPriorityQueueList.Add(value);
            Size = minPriorityQueueList.Count;

            int currentIndex = Size - 1;
            int parentIndex = (currentIndex - 1) / 2;

            while (currentIndex > 0 && minPriorityQueueList[currentIndex].CompareTo(minPriorityQueueList[parentIndex]) < 0)
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }
        }

        public T Dequeue()
        {
            var value = Peek();
            minPriorityQueueList[0] = minPriorityQueueList[Size - 1];
            minPriorityQueueList.RemoveAt(Size - 1);
            Size = minPriorityQueueList.Count;


            int currentIndex = 0, leftChildIndex = 1, rightChildIndex = 2;

            while (leftChildIndex < Size)
            {
                if (rightChildIndex < Size && minPriorityQueueList[rightChildIndex].CompareTo(minPriorityQueueList[leftChildIndex]) < 0)
                {
                    Swap(currentIndex, rightChildIndex);
                    currentIndex = rightChildIndex;
                }
                else if (minPriorityQueueList[leftChildIndex].CompareTo(minPriorityQueueList[currentIndex]) < 0)
                {
                    Swap(currentIndex, leftChildIndex);
                    currentIndex = leftChildIndex;
                }

                if (currentIndex < leftChildIndex) break;

                leftChildIndex = 2 * currentIndex + 1;
                rightChildIndex = 2 * currentIndex + 2;
            }

            return value;
        }

        public T Peek()
        {
            if (Size <= 0) throw new Exception("Priority Queue is empty.");
            else
            {
                return minPriorityQueueList[0];
            }
        }

        public bool Contains(T value)
        {
            return minPriorityQueueList.Contains(value);
        }

        public MaxPriorityQueue<T> Reverse()
        {
            MaxPriorityQueue<T> newPriorityQueueInstance = new();
            foreach (var x in minPriorityQueueList) newPriorityQueueInstance.Enqueue(x);
            return newPriorityQueueInstance;
        }

        public int Size { get; private set; }

        public void Swap(int a, int b)
        {
            var temporaryValueHolder = minPriorityQueueList[a];
            minPriorityQueueList[a] = minPriorityQueueList[b];
            minPriorityQueueList[b] = temporaryValueHolder;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return minPriorityQueueList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
