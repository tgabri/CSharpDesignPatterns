using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Observer2
{
    /// <summary>
    /// Feladat: Egy olyan program irasa, ami hosszan dolgozik es 
    /// idorol idore jelez hogy hol tart
    /// a .NET IObserver hasznalataval
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var b = new BetoltoProgram();
            var f = new FelhasznaloiFelulet();
            var n = new NaplozoModul();

            using (var s1 = b.Subscribe(f))
            {
                using (var s2 = b.Subscribe(n))
                {
                    b.Start();
                }
            }


            Console.ReadLine();
        }
    }

    internal class FelhasznaloiFelulet : IObserver<AllapotUzenet>
    {
        public void OnCompleted()
        {
            Console.WriteLine("FelhasznaloiFelulet.OnCompleted");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("FelhasznaloiFelulet.OnError {0}", error.Message);
        }

        public void OnNext(AllapotUzenet allapot)
        {
            Console.WriteLine("FelhasznaloiFelulet.OnNext {0}", allapot.Allapot);
        }
    }

    internal class NaplozoModul : IObserver<AllapotUzenet>
    {
        public void OnCompleted()
        {
            Console.WriteLine("NaplozoModul.OnCompleted");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("NaplozoModul.OnError {0}", error.Message);
        }

        public void OnNext(AllapotUzenet allapot)
        {
            Console.WriteLine("NaplozoModul.OnNext {0}", allapot.Allapot);
        }
    }

    internal class AllapotUzenet
    {
        private int allapot;
        public int Allapot { get => allapot; }

        public AllapotUzenet(int allapot)
        {
            this.allapot = allapot;
        }
    }

    internal class BetoltoProgram : IObservable<AllapotUzenet>
    {
        private List<IObserver<AllapotUzenet>> megfigyelok = new List<IObserver<AllapotUzenet>>();
        public IDisposable Subscribe(IObserver<AllapotUzenet> megfigyelo)
        {
            if (!megfigyelok.Contains(megfigyelo))
            {
                megfigyelok.Add(megfigyelo);
            }

            return new Feliratkozas(megfigyelok, megfigyelo);

        }

        internal void Start()
        {
            Ertesites(20);
            Ertesites(40);
            Hiba(new Exception("Valamilyen hiba tortent"));
            Ertesites(60);
            Ertesites(100);
            Vege();
        }

        private void Hiba(Exception exception)
        {
            foreach (var megfigyelo in megfigyelok)
            {
                megfigyelo.OnError(exception);
            }
        }

        private void Vege()
        {
            foreach (var megfigyelo in megfigyelok)
            {
                megfigyelo.OnCompleted();
            }
        }

        private void Ertesites(int allapot)
        {
            foreach (var megfigyelo in megfigyelok)
            {
                megfigyelo.OnNext(new AllapotUzenet(allapot: allapot));
            }
        }
    }


    //Ez az osztaly becsomagolja a leiratkozashoz szukseges informaciokat
    //ez egy feliratkozas peldany, amig el addig a feliratkozAs is el, amikor megszunik
    //az o felelossegi kore a feliratkozas megszuntetese
    internal class Feliratkozas : IDisposable
    {
        private List<IObserver<AllapotUzenet>> megfigyelok;
        private IObserver<AllapotUzenet> megfigyelo;

        public Feliratkozas(List<IObserver<AllapotUzenet>> megfigyelok, IObserver<AllapotUzenet> megfigyelo)
        {
            this.megfigyelok = megfigyelok;
            this.megfigyelo = megfigyelo;
        }

        public void Dispose()
        {
            Console.WriteLine("Feliratkozas.Dispose");
            if (megfigyelok.Contains(megfigyelo))
            {
                megfigyelok.Remove(megfigyelo);
            }
            else
            {
                throw new ObjectDisposedException("Ezt mar leszedtuk a feliratkozottak listajarol");
            }
        }
    }
}
