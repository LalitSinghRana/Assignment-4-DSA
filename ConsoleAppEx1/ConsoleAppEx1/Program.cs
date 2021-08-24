using System;

namespace ConsoleAppEx1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!\n");
            //LinkedListFuncCall();

            //PriorityQueueFuncCall();
            //HashTableFuncCall();
        }

        static void LinkedListFuncCall()
        {
            var myLinkedList = new DoublyLinkedList<int>();

            for (int index = 1; index <= 10; index++)
            {
                myLinkedList.Insert(index * 10);
            }

            myLinkedList.InsertAt(22, -2);
            myLinkedList.InsertAt(33, 0);
            myLinkedList.InsertAt(22, 100);

            Console.WriteLine("After all insert and insert at statements :");
            foreach (var node in myLinkedList) Console.Write(node.Value + ", ");
            Console.WriteLine("\n");

            myLinkedList.Delete(22);
            Console.WriteLine("After delete 22 :");
            myLinkedList.Print();

            myLinkedList.DeleteAt(6);
            Console.WriteLine("After delete at index 6 :");
            myLinkedList.Print();

            myLinkedList.Reverse();
            Console.WriteLine("After reversing the linked list :");
            myLinkedList.Print();

            Console.WriteLine("Center is {0}", myLinkedList.Center());
            Console.WriteLine("Size is " + myLinkedList.Size);
        }

        static void HashTableFuncCall()
        {
            var myHashTable = new HashTable<string, int>();
            
            for (int index=1; index<=12; index++)
            {
                myHashTable.Insert(index.ToString(), index * 10);
            }

            Console.WriteLine(myHashTable.Size);
            
            myHashTable.Delete(2.ToString());
            myHashTable.Delete(800.ToString());

            Console.WriteLine();

            foreach (var node in myHashTable)
            {
                var currentNode = node;
                while(currentNode != null)
                {
                    Console.Write(currentNode.Value + "; ");
                    currentNode = currentNode.Next;
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine(myHashTable.GetValueByKey("1"));
            Console.WriteLine(myHashTable.GetValueByKey("0"));

            Console.WriteLine();

            myHashTable.Print();
        }

        static void PriorityQueueFuncCall()
        {
            var myMinPriorityQueue = new MinPriorityQueue<int>();

            for (int index = 10; index > 0; index--)
            {
                myMinPriorityQueue.Enqueue(index);
            }

            // Reversing PQ
            var myMaxPriorityQueue = myMinPriorityQueue.Reverse();

            // Checking for iterator working or not in both PQ
            foreach (var number in myMinPriorityQueue) Console.Write(number + ", ");
            Console.WriteLine('\n');
            foreach (var number in myMaxPriorityQueue) Console.Write(number + ", ");
            Console.WriteLine('\n');

            Console.WriteLine("Contains -1 : {0}", myMinPriorityQueue.Contains(-1));
            Console.WriteLine("Contains 10 : {0}\n", myMinPriorityQueue.Contains(10));

            // Dequeing both PQ
            while (myMinPriorityQueue.Size > 0)
            {
                Console.Write(myMinPriorityQueue.Dequeue() + ", ");
            }
            Console.WriteLine('\n');

            while (myMaxPriorityQueue.Size > 0)
            {
                Console.Write(myMaxPriorityQueue.Dequeue() + ", ");
            }
            Console.WriteLine('\n');
        }
    }
}
