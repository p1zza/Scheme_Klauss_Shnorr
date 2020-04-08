using System;


namespace Scheme_Klauss_Shnorr
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Stage 1 \n KeyGeneration \n");
            Console.WriteLine("Type P");
            double p = double.Parse(Console.ReadLine());

            double q = 0;
            for(double i  = 3 ; i < 100000; i++)
            {
                if((p-1)%i==0)
                {
                    q = i;
                    break;
                }
            }
            Console.WriteLine("Q is {0}, P is {1}", q, p);

            double x = rnd.Next() % (q - 1) ;
            Console.WriteLine("X is {0}",x);

            double g = 0;
            for (double i = 3; i < 100000; i++)
            {
                if (Math.Pow(i,q)%p==1)
                {
                    g = i;
                    break;
                }
            }

            Console.WriteLine("G is {0}", g);
            double y = 0;
            for (double i = 3; i < 100000; i++)
            {
                if ((Math.Pow(g,x)*i)%p==1)
                {
                    y = i;
                    break;
                }
            }

            Console.WriteLine("Y is {0}", y);

            Console.WriteLine("Stage 2 \n Authentification \n");

            double k = rnd.Next()%(q - 1);

            double r = Math.Pow(g, k) % p;

            Console.WriteLine("K is {0}, R is {1}. \n Sending to person B....",k,r);

            double e = rnd.Next(0, 31);

            Console.WriteLine("E is {0}. \n Sending to person A....", e);

            double s = (k + x * e) % q;

            Console.WriteLine("S is {0}. \n Sending to person B....", s);

            if(Math.Pow(g,s)* Math.Pow(y, e)%p == r)
            {
                Console.WriteLine("Approved");
            }
            else
            {
                Console.WriteLine("Disapproved");
            }

        }
    }
}
