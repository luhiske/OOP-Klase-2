using System;

namespace Vezba
{
    public class Transakcija
    {
        private static int nextId = 100;
        private int id;
        private string vrsta;
        private double iznos;
        public Transakcija(string vrsta, double iznos)
        {
            this.id = nextId++;
            this.vrsta = vrsta;
            this.iznos = iznos;
        }
        public double Iznos()
        {
            return iznos;
        }
        public string Vrsta()
        {
            return vrsta;
        }
        public double Efektivno()
        {
            if (vrsta.ToLower() == "isplata")
            {
                return -iznos;
            }
            return iznos;
        }
        public override string ToString()
        {
            return $"ID: {id} | Vrsta: {vrsta,-7} | Iznos: {iznos,8:F2} din. | Efektivno: {Efektivno(),9:F2} din.";
        }
    }

    public class AutomatNovca
    {
        private readonly double pocetno;
        private double stanje;

        public AutomatNovca(double pocetno)
        {
            this.pocetno = pocetno;
            this.stanje = pocetno;
        }
        public Transakcija PodigniIznos(double iznos)
        {
            if (iznos <= 0)
            {
                Console.WriteLine("Greska: Iznos za podizanje mora biti pozitivan!");
                return null;
            }
            if (iznos > stanje)
            {
                Console.WriteLine("Greska: Nema dovoljno sredstava na automatu!");
                return null;
            }
            stanje -= iznos;
            return new Transakcija("isplata", iznos);
        }
        public Transakcija UloziIznos(double iznos)
        {
            if (iznos <= 0)
            {
                Console.WriteLine("Greska: Iznos za uplatu mora biti pozitivan!");
                return null;
            }

            stanje += iznos;
            return new Transakcija("uplata", iznos);
        }
        public void VratiStanje()
        {
            stanje = pocetno;
        }
        public void IspisiStanje()
        {
            Console.WriteLine($"Trenutno stanje u automatu: {stanje:F2} din.");
        }
    }

    internal class AutomatNovcaTest
    {
        private static Transakcija[] transakcije = new Transakcija[10];
        private static int brojacTransakcija = 0;
        private static void DodajTransakciju(Transakcija t)
        {
            if (t == null) return;
            if (brojacTransakcija == transakcije.Length)
            {
                Transakcija[] noviNiz = new Transakcija[transakcije.Length * 2];
                Array.Copy(transakcije, noviNiz, transakcije.Length);
                transakcije = noviNiz;
                Console.WriteLine($"Kapacitet niza transakcija prosiren na: {transakcije.Length}");
            }
            transakcije[brojacTransakcija++] = t;
        }
        private static void IspisiSveTransakcije()
        {
            Console.WriteLine("HRONOLOSKI PREGLED SVIH TRANSAKCIJA");
            if (brojacTransakcija == 0)
            {
                Console.WriteLine("Nema zabelezenih transakcija.");
                return;
            }

            for (int i = 0; i < brojacTransakcija; i++)
            {
                Console.WriteLine(transakcije[i]);
            }
        }

        static void Main(string[] args)
        {
            AutomatNovca automat1 = new AutomatNovca(10000.00);
            AutomatNovca automat2 = new AutomatNovca(10000.00);
            Console.WriteLine("Automat 1");
            automat1.IspisiStanje();
            Transakcija t1 = automat1.UloziIznos(1002.03);
            DodajTransakciju(t1);
            automat1.IspisiStanje();
            Console.WriteLine("Automat 2");
            automat2.IspisiStanje();
            Transakcija t2 = automat2.PodigniIznos(234.55);
            DodajTransakciju(t2);
            automat2.IspisiStanje();
            IspisiSveTransakcije();
            AutomatNovca izabraniAutomat = automat1;
            int brojIzabranog = 1;
            int opcija = -1;
            while (opcija != 0)
            {
                Console.WriteLine($"Meni (Trenutno izabran: Automat {brojIzabranog})");
                Console.WriteLine("1. Izabrati automat (1 ili 2)");
                Console.WriteLine("2. Uplata");
                Console.WriteLine("3. Isplata");
                Console.WriteLine("4. Ispis stanja");
                Console.WriteLine("5. Ispis transakcija");
                Console.WriteLine("0. Kraj");
                Console.Write("Izaberite opciju: ");
                if (!int.TryParse(Console.ReadLine(), out opcija))
                {
                    Console.WriteLine("Nevažeći unos! Pokušajte ponovo.");
                    continue;
                }
                switch (opcija)
                {
                    case 1:
                        Console.Write("Unesite broj automata (1 ili 2): ");
                        if (int.TryParse(Console.ReadLine(), out int br) && (br == 1 || br == 2))
                        {
                            brojIzabranog = br;
                            izabraniAutomat = (br == 1) ? automat1 : automat2;
                            Console.WriteLine($"Uspesno izabran Automat {brojIzabranog}.");
                        }
                        else
                        {
                            Console.WriteLine("Nepostojeci automat!");
                        }
                        break;

                    case 2:
                        Console.Write("Unesite iznos za uplatu: ");
                        if (double.TryParse(Console.ReadLine(), out double iznosUplate))
                        {
                            Transakcija t = izabraniAutomat.UloziIznos(iznosUplate);
                            DodajTransakciju(t);
                        }
                        else
                        {
                            Console.WriteLine("Nevažeći uneti iznos!");
                        }
                        break;

                    case 3:
                        Console.Write("Unesite iznos za isplatu: ");
                        if (double.TryParse(Console.ReadLine(), out double iznosIsplate))
                        {
                            Transakcija t = izabraniAutomat.PodigniIznos(iznosIsplate);
                            DodajTransakciju(t);
                        }
                        else
                        {
                            Console.WriteLine("Nevažeći uneti iznos!");
                        }
                        break;

                    case 4:
                        Console.WriteLine($"\nStanje na Automatu {brojIzabranog}:");
                        izabraniAutomat.IspisiStanje();
                        break;

                    case 5:
                        IspisiSveTransakcije();
                        break;

                    case 0:
                        Console.WriteLine("Program je zavrsen.");
                        break;

                    default:
                        Console.WriteLine("Nepostojeca opcija!");
                        break;
                }
            }
        }
    }
}