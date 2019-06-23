using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw1906___CalculateTask_Exrice_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 1;
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            Task t = Task.Factory.StartNew(() =>
            {
                int i = 1;
                while (i < 5 && !tokenSource.IsCancellationRequested)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"For Now The Result Is: {sum += i}");
                    i++;
                }
                tokenSource.Token.ThrowIfCancellationRequested();
            }, tokenSource.Token)

            .ContinueWith((Task antecedent) =>
            {
                Console.WriteLine("now!!!");
                Thread.Sleep(2000);
                tokenSource.Token.ThrowIfCancellationRequested();

                Console.WriteLine($"The Result Is: {sum}");
            }, tokenSource.Token);
            Console.ReadLine();
            //tokenSource.Token.ThrowIfCancellationRequested();
            tokenSource.Cancel();
            Console.ReadLine();

            Thread.Sleep(3000);
            Console.WriteLine($"Canceled? {t.IsCanceled} + Faulted? {t.IsFaulted} + Completed? {t.IsCompleted}");
        }
    }
}
