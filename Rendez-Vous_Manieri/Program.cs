using System;
using System.Threading;

namespace Rendez_Vous_Manieri
{
    class Program
    {

        static SemaphoreSlim s1 = new SemaphoreSlim(0);
        static SemaphoreSlim s2 = new SemaphoreSlim(1);
        static void Main(string[] args)
        {
            int[] v = new int[1000];
            int[] w = new int[1000];

            Thread t1 = new Thread(() => Minimo(v));
            Thread t2 = new Thread(() => Media(v,w));


            t1.Start();
            t2.Start();
            while (t1.IsAlive) { }
            while (t2.IsAlive) { }

            Console.ReadLine();


        }
        static void Minimo(int[]v)
        {
            Random r = new Random();
            for(int i=0; i < v.Length; i++)
            {
                v[i] = r.Next(0, 1000);
            }
        }

        static void Media(int[]v, int[] w)
        {
            Random r = new Random();
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = r.Next(0, 1000);
            }
        }
    }
}
