using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in BejarhatoFuggveny())
            {
                Console.WriteLine($"Eredmeny: {item}");
            }

            var bejarhatoOsztaly = new BejarhatoOsztaly();
            bejarhatoOsztaly.Add("Elso elem");
            bejarhatoOsztaly.Add("Masodik elem");
            bejarhatoOsztaly.Add("Harmadik elem");
            bejarhatoOsztaly.Add("Negyedik elem");
            foreach (var item in bejarhatoOsztaly)
            {
                Console.WriteLine("FOREACH {0}", item);
            }

            Console.ReadLine();
        }

        private static IEnumerable<string> BejarhatoFuggveny()
        {
            yield return "Egy";
            yield return "Ketto";
            yield return "Harom";
        }
    }

    /// <summary>
    /// Ezen az osztalyon lehet ciklussal vegigmenni, vagyis bejarhato!
    /// </summary>
    class BejarhatoOsztaly : IEnumerable
    {
        //a bejarhato osztalynak kell adatot tartalmaznia amin vegig lehet menni
        List<string> list = new List<string>();

        public IEnumerator GetEnumerator()
        {
            // return new BejaroOsztaly(list);
            return new VisszafeleBejaroOsztaly(list);
        }

        public void Add(string item)
        {
            list.Add(item);
        }
    }

    /// <summary>
    /// Bejaro definicio, ami a bejarhato osztaly egyes elemein fog vegiglepkedni
    /// </summary>
    class BejaroOsztaly : IEnumerator
    {
        private List<string> list;
        private int index = -1;

        public BejaroOsztaly(List<string> list)
        {
            this.list = list;
        }

        public bool MoveNext()
        {
            index++;
            Console.WriteLine("Move Next - BejaroOsztaly: Index: {0}, {1}", index, index < list.Count);
            return index < list.Count;
        }

        public object Current
        {
            get
            {
                if (index == -1) throw new ArgumentOutOfRangeException("A bejarashoz elobb leptetni kell");
                if (index > list.Count - 1) throw new ArgumentOutOfRangeException("Tulmentunk a lehetseges elemeken");

                var current = list[index];
                Console.WriteLine("Current - BejaroOsztaly: Index: {0}, Current: {1}", index, current);
                return current;
            }
        }

        public void Reset()
        {
            Console.WriteLine("Reset - BejaroOsztaly");
            index = -1;
        }
    }

    class VisszafeleBejaroOsztaly : IEnumerator
    {
        private List<string> list;
        private int index = -1;

        public VisszafeleBejaroOsztaly(List<string> list)
        {
            this.list = list.OrderByDescending(i => i).ToList();
        }

        public bool MoveNext()
        {
            index++;
            Console.WriteLine("Move Next - VisszafeleBejaroOsztaly: Index: {0}, {1}", index, index < list.Count);
            return index < list.Count;
        }

        public object Current
        {
            get
            {
                if (index == -1) throw new ArgumentOutOfRangeException("A bejarashoz elobb leptetni kell");
                if (index > list.Count - 1) throw new ArgumentOutOfRangeException("Tulmentunk a lehetseges elemeken");

                var current = list[index];
                Console.WriteLine("Current - VisszafeleBejaroOsztaly: Index: {0}, Current: {1}", index, current);
                return current;
            }
        }

        public void Reset()
        {
            Console.WriteLine("Reset - VisszafeleBejaroOsztaly");
            index = -1;
        }
    }
}
