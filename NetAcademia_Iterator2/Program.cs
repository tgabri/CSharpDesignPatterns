using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Iterator2
{
    class Program
    {
        static void Main(string[] args)
        {
            var bejarhatoOsztaly = new BejarhatoOsztaly<SajatOsztaly>();
            bejarhatoOsztaly.Add(new SajatOsztaly("első bejegyzés"));
            bejarhatoOsztaly.Add(new SajatOsztaly("második bejegyzés"));
            bejarhatoOsztaly.Add(new SajatOsztaly("harmadik bejegyzés"));
            bejarhatoOsztaly.Add(new SajatOsztaly("negyedik bejegyzés"));

            foreach (var item in bejarhatoOsztaly)
            {
                bejarhatoOsztaly.Remove(item);
                //Console.WriteLine("elem: {0}", item);
            }

            //using (var bejaro = bejarhatoOsztaly.GetEnumerator())
            //{
            //    var leszKovetkezo = true;

            //    do
            //    {
            //        leszKovetkezo = bejaro.MoveNext();
            //        var item = bejaro.Current;

            //    } while (leszKovetkezo);
            //}

            Console.ReadLine();
        }
    }

    class SajatOsztaly
    {
        public SajatOsztaly(string uzenet)
        {
            Uzenet = uzenet;
        }

        public string Uzenet { get; set; }
        public int Id { get; set; }
        public DateTime Created { get; set; }

        /// <summary>
        /// Ezzel elérhetjük, hogy ha ToString()-gel kiiratunk,
        /// akkor az Uzenet property-t adja vissza
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Uzenet;
        }
    }

    class BejarhatoOsztaly<T> : IEnumerable<T>
    {
        List<T> list = new List<T>();


        internal void Add(T item)
        {
            list.Add(item);
        }

        public void Remove(T item)
        {
            list.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BejaroOsztaly<T>(list);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    class BejaroOsztaly<T> : IEnumerator<T>
    {
        private List<T> list;
        private int position = -1;

        public BejaroOsztaly(List<T> list)
        {
            this.list = list;
        }

        public T Current => list[position];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }


        //~BejaroOsztaly()
        //{
        //    Dispose(false);
        //}

        //private void Dispose(bool isManagedDispose)
        //{
        //    if (isManagedDispose)
        //    {
        //        if (list != null) list = null;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);

        //    GC.SuppressFinalize(this);
        //}

        public bool MoveNext()
        {
            return ++position < list.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}

