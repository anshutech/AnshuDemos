using System;
using System.Threading;
namespace warningcpu
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            int counter;//it counts that how many times the loop runs
            counter=1;//value of the counter
            while(counter<=100000)
            {
                Console.WriteLine(Convert.ToString(counter));
                counter++;
            }
            Thread.Sleep(50000);
          goto start;
        }
    }
}
