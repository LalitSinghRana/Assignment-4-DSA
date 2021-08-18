using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    class PriorityQueue<T> : IEnumerable<T>  where T : IComparable, IComparable<T>
    {
        readonly List<T> maxPQ = new();

        public void Enqueue(T value)
        {
            maxPQ.Add(value);
            Size = maxPQ.Count;

            int index = Size - 1;
            int pIndex = (index - 1) / 2;

            while (index > 0 && maxPQ[index].CompareTo(maxPQ[pIndex]) > 0)
            {
                Swap(index, pIndex);
                index = pIndex;
                pIndex = (index - 1) / 2;
            }
        }

        public T Dequeue()
        {
            var value = Peek();
            maxPQ[0] = maxPQ[Size - 1];
            maxPQ.RemoveAt(Size - 1);
            Size = maxPQ.Count;


            int index = 0, lChild = 1, rChild = 2;

            while(lChild < Size)
            {
                if(rChild < Size && maxPQ[rChild].CompareTo(maxPQ[lChild]) > 0)
                {
                    Swap(index, rChild);
                    index = rChild;
                }
                else if(maxPQ[lChild].CompareTo(maxPQ[index]) > 0)
                {
                    Swap(index, lChild);
                    index = lChild;
                }

                if (index < lChild) break;

                lChild = 2 * index + 1;
                rChild = 2 * index + 2;
            }

            return value;
        }

        public T Peek()
        {
            if (Size <= 0) throw new Exception("Priority Queue is empty.");
            else
            {
                return maxPQ[0];
            }
        }

        public bool Contains(T value)
        {
            return maxPQ.Contains(value);
        }

        public MinPriorityQueue<T> Reverse()
        {
            MinPriorityQueue<T> newPQ = new();
            foreach (var x in maxPQ) newPQ.Enqueue(x);
            return newPQ;
        }

        public int Size { get; private set; }

        public void Swap(int a, int b)
        {
            var temp = maxPQ[a];
            maxPQ[a] = maxPQ[b];
            maxPQ[b] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return maxPQ.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class MinPriorityQueue<T> : IEnumerable<T> where T : IComparable, IComparable<T>
    {
        readonly List<T> minPQ = new();

        public void Enqueue(T value)
        {
            minPQ.Add(value);
            Size = minPQ.Count;

            int index = Size - 1;
            int pIndex = (index - 1) / 2;

            while (index > 0 && minPQ[index].CompareTo(minPQ[pIndex]) < 0)
            {
                Swap(index, pIndex);
                index = pIndex;
                pIndex = (index - 1) / 2;
            }
        }

        public T Dequeue()
        {
            var value = Peek();
            minPQ[0] = minPQ[Size - 1];
            minPQ.RemoveAt(Size - 1);
            Size = minPQ.Count;


            int index = 0, lChild = 1, rChild = 2;

            while (lChild < Size)
            {
                if (rChild < Size && minPQ[rChild].CompareTo(minPQ[lChild]) < 0)
                {
                    Swap(index, rChild);
                    index = rChild;
                }
                else if (minPQ[lChild].CompareTo(minPQ[index]) < 0)
                {
                    Swap(index, lChild);
                    index = lChild;
                }

                if (index < lChild) break;

                lChild = 2 * index + 1;
                rChild = 2 * index + 2;
            }

            return value;
        }

        public T Peek()
        {
            if (Size <= 0) throw new Exception("Priority Queue is empty.");
            else
            {
                return minPQ[0];
            }
        }

        public bool Contains(T value)
        {
            return minPQ.Contains(value);
        }

        public PriorityQueue<T> Reverse()
        {
            PriorityQueue<T> newPQ = new();
            foreach (var x in minPQ) newPQ.Enqueue(x);
            return newPQ;
        }

        public int Size { get; private set; }

        public void Swap(int a, int b)
        {
            var temp = minPQ[a];
            minPQ[a] = minPQ[b];
            minPQ[b] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return minPQ.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
