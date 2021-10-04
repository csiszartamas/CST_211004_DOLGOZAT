using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_211004_DOLGOZAT
{
    enum marka
    {
        Audi,
        Opel,
        Lada,
        Ford,
        Skoda,
    }
    class auto
    {
        private float atlagFogyasztas;
        private bool isAtlagFogyasztasSet = false;
        private int tankMeret;
        private float aktualisBenzin;
        private marka Marka { get; set; }
        private bool matrica;
        private bool _isvanMatricaSet = false;
        private string rendszam;
        static Random rnd = new Random();
        

        public float atlagfogy
        {
            get => atlagFogyasztas;
            set
            {
                if (value < 3.0F) throw new Exception("hiba: túl kicsi az átlagfogyasztás");
                if (value > 20.0F) throw new Exception("hiba: túl nagy az átlagfogyasztás");
                atlagFogyasztas = value;
                isAtlagFogyasztasSet = true;
            }
        }

        public int tankm
        {
            get => tankMeret;
            set
            {
                if (value < 20) throw new Exception("hiba: túl kicsi a tank mérete");
                if (value > 100) throw new Exception("hiba: túl nagy a tank mérete");
                tankMeret = value;
            }
        }
        public float aktBenzin
        {
            get => aktualisBenzin;
            set
            {
                if (value < 0 && value > tankMeret) throw new Exception("hiba: Az aktuális benzinmennyiség ennyi nem lehet.");
                //if (value < 0 )
                //if (value > tankMeret)
                aktualisBenzin = value;
            }
        }

        public bool vanMatrica
        {
            get => matrica;
            set
            {
                if(_isvanMatricaSet) throw new Exception("hiba: már van matrica");
                vanMatrica = value;
                _isvanMatricaSet = true;
            }
        }

        public string miarendszam
        {
            get => rendszam;
            set
            {
                var betuk = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
                rendszam = "" + betuk[rnd.Next(0, betuk.Length)] + "" + betuk[rnd.Next(0, betuk.Length)] + "" + betuk[rnd.Next(0, betuk.Length)] + "-" + rnd.Next(0, 10) + rnd.Next(0, 10) + rnd.Next(0, 10);
            }   
        }

        public auto(float atlagF, int tankM, int aktBen, bool mat, string rendsz)
        {
            atlagFogyasztas = atlagF;
            tankMeret = tankM;
            aktualisBenzin = aktBen;
            matrica = mat;
            rendszam = rendsz;
        }
    }



    class Program
    {
        static Random rnd = new Random();
        static List<auto> Autok = new List<auto>();
        private static bool vanMatrica;
        private static string rendszam;

        static void Main(string[] args)
        {

            Autotoltes(30);
            melyikautokepes();
            //melyikbolvantobb();
        }

        private static void rendszam_a()
        {
            var betuk = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            rendszam = "" + betuk[rnd.Next(0, betuk.Length)] + "" + betuk[rnd.Next(0, betuk.Length)] + "" + betuk[rnd.Next(0, betuk.Length)] + "-" + rnd.Next(0, 10) + rnd.Next(0, 10) + rnd.Next(0, 10);

        }

        private static void Autotoltes(int autokszama)
        {
            for (int i = 0; i < autokszama; i++)
            {
                Autok.Add(new auto(12.1F, 80, 60, true, rendszam)
                {

                }); ;
            }
        }
        private static void melyikautokepes()
        {
            int maxIndex = 0;
            for (int i = 1; i < Autok.Count; i++)
                if (Autok[i].atlagfogy > Autok[maxIndex].atlagfogy && Autok[i].aktBenzin > Autok[maxIndex].aktBenzin) maxIndex = i;
            //Console.WriteLine($"A legtöbb kilométert ez az autó tudja megtenni:  {Autok[maxIndex].marka}");
            Console.WriteLine("-------------------");
        }
        private static void DbAutok()
        {
            int db = 0;
            foreach (var h in Autok) if (vanMatrica) db++;
            Console.WriteLine($"Összesen {db} db ugyan olyan autó van amin van matrica");
            Console.WriteLine("-------------------");
        }
    }
}
