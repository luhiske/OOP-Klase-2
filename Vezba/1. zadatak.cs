using System;

namespace Vezba
{
    public class Tacka
    {
        private double x;
        private double y;
        
        public Tacka()
        {
            this.x = 0;
            this.y = 0;
        }
        public Tacka(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public Tacka(double x)
        {
            this.x = x;
            this.y = 0;
        }
        public void Postavi(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double Rastojanje()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public double Rastojanje(Tacka t)
        {
            double dx = x - t.x;
            double dy = y - t.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public void Ucitaj()
        {
            Console.Write("Unesite x koordinatu: ");
            this.x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Unesite y koordinatu: ");
            this.y = Convert.ToDouble(Console.ReadLine());
        }
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Tacka a = new Tacka(2, 3);
            Tacka b = new Tacka();
            Tacka c = new Tacka(4);
            Console.WriteLine("Tacke na pocetku:");
            Console.WriteLine("Tacka A: " + a);
            Console.WriteLine("Tacka B: " + b);
            Console.WriteLine("Tacka C: " + c);
            b.Postavi(5, 5);
            Console.WriteLine("Nakon ovoga je tacka B: " + b);
            Console.WriteLine("Rastojanaj od koordinatnog pocetka:");
            Console.WriteLine("Rastojanje A od (0,0): " + a.Rastojanje());
            Console.WriteLine("Rastojanje B od (0,0): " + b.Rastojanje());
            Console.WriteLine("Rastojanje C od (0,0): " + c.Rastojanje());
            Console.WriteLine("Medjusobna rastojanja:");
            Console.WriteLine("Rastojanje A od B: " + a.Rastojanje(b));
            Console.WriteLine("Rastojanje B od C: " + b.Rastojanje(c));
            Console.WriteLine("Rastojanje C od A: " + c.Rastojanje(a));
            Tacka d = a;
            Console.WriteLine("Ucitavanje tacke D");
            d.Ucitaj();
            Console.WriteLine("Tacka A: " + a);
            Console.WriteLine("Tacka D: " + d);
            Console.WriteLine("Nova rastojanja:");
            Console.WriteLine("Rastojanje A od B: " + a.Rastojanje(b));
            Console.WriteLine("Rastojanje B od C: " + b.Rastojanje(c));
            Console.WriteLine("Rastojanje C od A: " + c.Rastojanje(a));
            Console.WriteLine("Rastojanje A od D: " + a.Rastojanje(d));
        }
    }
}
