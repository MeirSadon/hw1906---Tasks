using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw1906___Exception.Handle_Exrice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() =>
            {
                List<int> numbers = new List<int>(3);
                Console.WriteLine(numbers[4]);
            });
            Thread.Sleep(2000);
            if (t.IsFaulted)
            {
                t.Exception.Handle((e) =>
                {
                    Console.WriteLine(e);
                    return true;
                });
            }
        }
    }
}
