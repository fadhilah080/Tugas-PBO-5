using System;
namespace Inheritance
{
    class Values //class induk
    {
        protected int p, l;
        public void Nilai(int a, int b)
        {
            p = a;
            l = b;
        }
    }
    class luasPersegiPanjang : Values //class turunan
    {
        public int area()
        {
            return (p * l);
        }
    }
    class kelilingPersegiPanjang : Values //class turunan
    {
        public int area()
        {
            return ((p + l) * 2);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            luasPersegiPanjang a = new luasPersegiPanjang();
            kelilingPersegiPanjang b = new kelilingPersegiPanjang();
            a.Nilai(8, 12);
            b.Nilai(8, 12);
            Console.WriteLine("Luas Persegi Panjang = " + a.area());
            Console.WriteLine("Keliling Persegi Panjang = " + b.area());
            Console.ReadKey();
        }
    }
}
