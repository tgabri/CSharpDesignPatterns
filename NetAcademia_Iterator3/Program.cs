using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Iterator3
{
    class Program
    {
        static void Main(string[] args)
        {
            var szamla = new BankSzamla();
            szamla.Atutalas(1, 200);
            szamla.Atutalas(2, 134);
            szamla.Atutalas(3, 300);
            szamla.Atutalas(4, 89);
            szamla.Atutalas(5, 125);


            foreach (var item in szamla.Atutalasok)
            {
                Console.WriteLine($"{item.Id}. Osszeg: {item.Osszeg}");
            }

            Console.WriteLine($"Egyenleg: {szamla.Egyenleg}");
            Console.WriteLine();

            //Mivel az Atutalasok propertym IEnumerable ezert a remove fuggveny nem elerheto, ezzel kikuszobolheto h menet kozben valamit eltavolitsak
            //a listarol de a vegeredmeny nem valtozik
            //szamla.Atutalasok.Remove(szamla.Atutalasok[0]);

            foreach (var item in szamla.Atutalasok)
            {
                Console.WriteLine($"{item.Id}. Osszeg: {item.Osszeg}");
            }

            Console.WriteLine($"Egyenleg: {szamla.Egyenleg}");

            Console.ReadLine();
        }

    }
    class BankSzamla
    {
        //public int Id { get; set; }
        private List<Atutalas> atutalasok = new List<Atutalas>();
        public IEnumerable<Atutalas> Atutalasok { get => new ReadOnlyCollection<Atutalas>(atutalasok); }

        private decimal egyenleg = 0;

        public decimal Egyenleg { get => egyenleg; }

        public void Atutalas(int id, decimal osszeg)
        {
            atutalasok.Add(new Atutalas(id, osszeg));
            egyenleg += osszeg;
        }
    }

    class Atutalas
    {
        public Atutalas(int id, decimal osszeg)
        {
            Id = id;
            Osszeg = osszeg;
        }

        public int Id { get; }
        public decimal Osszeg { get; }
    }
}
