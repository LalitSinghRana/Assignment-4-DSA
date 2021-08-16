using System;

namespace ConsoleAppEx1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            var myList = new DoublyLinkedList<int>();

            for(int i=1; i<=10; i++)
            {
                myList.Insert(i * 10);
            }

            //myList.InsertAt(777, 90);
            myList.DeleteAt(9);
            myList.DeleteAt(5);
            myList.DeleteAt(0);

            myList.Print();

            foreach (var x in myList)
            {
                Console.WriteLine(x.Value);
            }

            Console.WriteLine("\n\n\t"+myList.Size);
        }
    }
}
