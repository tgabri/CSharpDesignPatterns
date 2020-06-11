using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Observer
{
    /// <summary>
    /// Feladat: Egy olyan program irasa, ami hosszan dolgozik es 
    /// idorol idore jelez hogy hol tart
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            var felhasznaloiFelulet = new FelhasznaloiFelulet();
            var naplozo = new NaplozoModul();

            //var betolto = new BetoltoProgram(felhasznaloiFelulet, naplozo);
            var betolto = new BetoltoProgram();

            betolto.Feliratkozas(felhasznaloiFelulet);
            betolto.Feliratkozas(naplozo);

            betolto.Start();


            Console.WriteLine("Program vege");

            betolto.Leiratkozas(felhasznaloiFelulet);
            betolto.Leiratkozas(naplozo);


            Console.ReadLine();
        }
    }

    public interface IUzenet
    {
        void Uzenet(IAllapot allapot);
    }

    class NaplozoModul : IUzenet
    {
        public void Uzenet(IAllapot allapot)
        {
            Console.WriteLine($"NaplozoModul.Uzenet {allapot.Allapot}%");
        }
    }

    class FelhasznaloiFelulet : IUzenet
    {
        public void Uzenet(IAllapot allapot)
        {
            Console.WriteLine($"FelhasznaloiFelulet.Uzenet {allapot.Allapot}%");
        }
    }


    public interface IAllapot
    {
        int Allapot { get; }
    }

    class BetoltoProgram : IAllapot
    {
        private List<IUzenet> megfigyelok = new List<IUzenet>();
        private int allapot;

        public int Allapot { get => allapot; }


        //Ez tulsagosan statikus megoldas, dinamikusabb megoldas lehet egy fel es egy leiratkozas fuggveny letrehozasa 
        //ahol hozza adhatjuk vagy eltavolithatjuk a listankhoz
        //public BetoltoProgram(params IUzenet[] megfigyelok)
        //{
        //    foreach (var megfigyelo in megfigyelok)
        //    {
        //        this.megfigyelok.Add(megfigyelo);
        //    }
        //}

        public void Feliratkozas(IUzenet megfigyelo)
        {
            if (!megfigyelok.Contains(megfigyelo))
            {
                megfigyelok.Add(megfigyelo);
            }

        }

        public void Leiratkozas(IUzenet megfigyelo)
        {
            if (megfigyelok.Contains(megfigyelo))
            {
                megfigyelok.Remove(megfigyelo);
            }

        }

        internal void Start()
        {
            Ertesites(20);
            Ertesites(40);
            Ertesites(80);
            Ertesites(100);
        }

        private void Ertesites(int allapot)
        {
            this.allapot = allapot;
            foreach (var megfigyelo in megfigyelok)
            {
                megfigyelo.Uzenet(this);
            }
        }
    }

}
