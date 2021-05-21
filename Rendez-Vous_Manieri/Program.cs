using System;
using System.Threading;

namespace Rendez_Vous_Manieri
{
    class Program
    {
        static int[] v = new int[1000];
        static int[] w = new int[1000];
        static int minimo = int.MaxValue;
        static double media = 0;
        static SemaphoreSlim s1 = new SemaphoreSlim(0);
        static SemaphoreSlim s2 = new SemaphoreSlim(1);
        static void Main(string[] args)
        {


            Thread t1 = new Thread(() => Minimo(v));
            Thread t2 = new Thread(() => Media(v,w)); 


            t1.Start();
            t2.Start();
            while (t1.IsAlive) { }
            while (t2.IsAlive) { }

            Console.WriteLine($"La media è {media}");
            Console.WriteLine($"Il minimo è {minimo}");

            Console.ReadLine();


        }
        static void Minimo(int[]v)
        {
            Random r = new Random();
            for(int i=0; i < v.Length; i++)
            {
                v[i] = r.Next(0, 1000);
                if (v[i] < minimo)
                    minimo = v[i];
            }
            s2.Release();
            s1.Wait();
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] < minimo)
                    minimo = w[i];
            }
        }

        static void Media(int[]v, int[] w)
        {
            Random r = new Random();
            for (int i = 0; i < w.Length; i++)
            {
                w[i] = r.Next(0, 1000);
                media += w[i];
            }
            s1.Release();
            s2.Wait();
            for (int i = 0; i < v.Length; i++)
            {
                media += v[i];
            }
            media = media / v.Length+w.Length;
        }
    }
}
