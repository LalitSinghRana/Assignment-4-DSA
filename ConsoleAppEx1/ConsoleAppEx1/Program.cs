using System;

namespace ConsoleAppEx1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            //PQCall();
            //HTCall();
        }

        private static void HTCall()
        {
            var myHT = new HashTable<string, int>();
            for(int i=1; i<=12; i++)
            {
                myHT.Insert(i.ToString(), i * 10);
            }

            Console.WriteLine(myHT.Size);

            myHT.Delete(2.ToString());
            myHT.Delete(800.ToString());

            Console.WriteLine();

            foreach (var x in myHT)
            {
                var c = x;
                while(c != null)
                {
                    Console.Write(c.Value + "; ");
                    c = c.Next;
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine(myHT.GetValueByKey("1"));
            Console.WriteLine(myHT.GetValueByKey("0"));

            Console.WriteLine();

            myHT.Print();
        }

        static void PQCall()
        {
            var myList = new MinPriorityQueue<int>();

            for (int i = 20; i > 0; i--)
            {
                myList.Enqueue(i);
            }

            var newList = myList.Reverse();

            foreach (var x in myList) Console.Write(x + ", ");
            Console.WriteLine('\n');
            foreach (var x in newList) Console.Write(x + ", ");
            Console.WriteLine('\n');

            Console.WriteLine("10 : {0}", myList.Contains(-1));
            Console.WriteLine("100 : {0}", myList.Contains(100));

            while (myList.Size > 0)
            {
                Console.Write(myList.Dequeue() + ", ");
            }
            Console.WriteLine('\n');

            while (newList.Size > 0)
            {
                Console.Write(newList.Dequeue() + ", ");
            }
            Console.WriteLine('\n');
        }
    }
}
