using System;

namespace ConsoleAppEx1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            var myList = new Stack<int>();

            for(int i=1; i<=10; i++)
            {
                myList.Push(i * 10);
            }

            myList.Print();

            Console.WriteLine(myList.Peek());
            myList.Pop();
            Console.WriteLine(myList.Peek());
            myList.Pop();
            Console.WriteLine(myList.Peek());
            myList.Pop();


            Console.WriteLine("50 : " + myList.Contains(50));
            Console.WriteLine("100 : " + myList.Contains(100));

            
            myList.Reverse();
            myList.Print();

            foreach (var x in myList)
            {
                Console.WriteLine(x.Value);
            }

            Console.WriteLine("\n\n\t"+myList.Size);
        }
    }
}
