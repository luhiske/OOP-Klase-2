using System;
using System.Runtime.InteropServices;
using System.Text;

namespace _2.zadatak
{
    public class Autobus
    {
        private bool[] sedista;
        public Autobus()
        {
            sedista = new bool[50];
            for (int i = 0; i < sedista.Length; i++)
            {
                sedista[i] = true;
            }
        }
        public void Uvedi(int brojSedista)
        {
            if (brojSedista <0 || brojSedista >= sedista.Length)
            {
                Console.WriteLine($"Greska: Sediste broj {brojSedista} ne postoji.");
                return;
            }
            if (sedista[brojSedista])
            {
                sedista[brojSedista] = false;
            }
            else
            {
                Console.WriteLine($"Greska: Sediste broj {brojSedista} je vec zauzeto.");
            }
        }
        public bool ImaSlobodnih()
        {
            foreach(bool slobodno in sedista)
            {
                if (slobodno) return true;
            }
            return false;
        }
        public int BrojSlobodnih()
        {
            int br = 0;
            foreach(bool slobodno in sedista)
            {
                if (slobodno) br++;
            }
            return br;
        }
        public int BrojZauzetih()
        {
            return sedista.Length - BrojSlobodnih();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sedista.Length; i++)
            {
                string status = sedista[i] ? "slobodno" : "zauzeto";
                sb.AppendLine($"Sediste broj {i} je {status}.");
            }
            return sb.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Autobus autobus = new Autobus();
            autobus.Uvedi(0);
            autobus.Uvedi(19);
            autobus.Uvedi(49);
            Console.WriteLine(autobus.ToString());
        }
    }
}
