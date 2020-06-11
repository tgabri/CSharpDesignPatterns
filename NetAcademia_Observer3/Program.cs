using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Observer3
{
    /// <summary>
    /// Feladat: Egy olyan program irasa, ami hosszan dolgozik es 
    /// idorol idore jelez hogy hol tart
    /// a .NET IObserver es esemenyek(Events) hasznalataval
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var b = new BetoltoProgram();
            var f = new FelhasznaloiFelulet();
            var n = new NaplozoModul();

            //Feliratkozasok
            ////anonymous delegate-el, Igy ossze nem kapcsolato fuggvenyekkel tudok jatszani
            //b.AllapotValtozasTortent += (object o, AllapotUzenet e) => { f.Uzenet(o, e); };
            //b.AllapotValtozasTortent += (object o, AllapotUzenet e) => { n.Uzenet(o, e); };

            b.AllapotValtozasTortent += f.Uzenet;
            b.AllapotValtozasTortent += n.Uzenet;

            b.Start();

            b.AllapotValtozasTortent -= f.Uzenet;
            b.AllapotValtozasTortent -= n.Uzenet;


            Console.ReadLine();
        }

    }

    internal class NaplozoModul
    {
        internal void Uzenet(object o, AllapotUzenet e)
        {
            Console.WriteLine("NaplozoModul: {0}", e.Allapot);
        }
    }

    internal class FelhasznaloiFelulet
    {
        internal void Uzenet(object o, AllapotUzenet e)
        {
            Console.WriteLine("FelhasznaloiFelulet: {0}", e.Allapot);
        }
    }

    internal class BetoltoProgram
    {
        public event EventHandler<AllapotUzenet> AllapotValtozasTortent;
        private void OnAllapotValtozas(int allapot)
        {
            AllapotValtozasTortent?.Invoke(this, new AllapotUzenet(allapot));
        }

        internal void Start()
        {
            Ertesites(20);
            Ertesites(40);
            //Hiba(new Exception("Valamilyen hiba tortent"));
            Ertesites(60);
            Ertesites(100);
            //Vege();
        }

        private void Ertesites(int allapot)
        {
            OnAllapotValtozas(allapot);
        }
    }

    public class AllapotUzenet : EventArgs
    {
        private int allapot;
        public int Allapot { get => allapot; }

        public AllapotUzenet(int allapot)
        {
            this.allapot = allapot;
        }
    }
}
