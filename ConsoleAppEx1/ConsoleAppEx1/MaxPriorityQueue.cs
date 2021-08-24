using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    class MaxPriorityQueue<T> : IEnumerable<T>  where T : IComparable, IComparable<T>
    {
        readonly List<T> maxPriorityQueueList = new();

        public void Enqueue(T value)
        {
            maxPriorityQueueList.Add(value);
            Size = maxPriorityQueueList.Count;

            int currentIndex = Size - 1;
            int parentIndex = (currentIndex - 1) / 2;

            while (currentIndex > 0 && maxPriorityQueueList[currentIndex].CompareTo(maxPriorityQueueList[parentIndex]) > 0)
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }
        }

        public T Dequeue()
        {
            var value = Peek();
            maxPriorityQueueList[0] = maxPriorityQueueList[Size - 1];
            maxPriorityQueueList.RemoveAt(Size - 1);
            Size = maxPriorityQueueList.Count;


            int currentIndex = 0, leftChildIndex = 1, rightChildIndex = 2;

            while(leftChildIndex < Size)
            {
                if(rightChildIndex < Size && maxPriorityQueueList[rightChildIndex].CompareTo(maxPriorityQueueList[leftChildIndex]) > 0)
                {
                    Swap(currentIndex, rightChildIndex);
                    currentIndex = rightChildIndex;
                }
                else if(maxPriorityQueueList[leftChildIndex].CompareTo(maxPriorityQueueList[currentIndex]) > 0)
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
                return maxPriorityQueueList[0];
            }
        }

        public bool Contains(T value)
        {
            return maxPriorityQueueList.Contains(value);
        }

        public MinPriorityQueue<T> Reverse()
        {
            MinPriorityQueue<T> newPriorityQueueInstance = new();
            foreach (var x in maxPriorityQueueList) newPriorityQueueInstance.Enqueue(x);
            return newPriorityQueueInstance;
        }

        public int Size { get; private set; }

        public void Swap(int a, int b)
        {
            var temporaryValueHolder = maxPriorityQueueList[a];
            maxPriorityQueueList[a] = maxPriorityQueueList[b];
            maxPriorityQueueList[b] = temporaryValueHolder;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return maxPriorityQueueList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
