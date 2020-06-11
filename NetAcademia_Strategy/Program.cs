using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Strategy
{
    /// <summary>
    /// A feladat: Kulonbozo algoritmusok beepitese a rendszerbe
    /// - elkuldott emailek szama
    /// - atlag hany emailt kuldtunk egy egy cimzetnek
    /// - email kuldes csak egy meghatarozott csoportnak
    /// - az uzenet szovege plain text legyen
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region NEM JO megoldas
            var service = new DataService(new AddressStrategyTestRepo());

            var count = service.GetSumEmailCount();
            Console.WriteLine($"Email-ek szama: {count}");

            var average = service.GetAverageEmailCount();
            Console.WriteLine($"Email-ek atlagos szama: {average}");

            Console.WriteLine();

            count = service.Report(ReportType.Sum);
            Console.WriteLine($"Email-ek szama: {count}");

            average = service.Report(ReportType.Average);
            Console.WriteLine($"Email-ek atlagos szama: {average}");
            #endregion NEM JO megoldas


            #region JO megoldas
            var service2 = new DataService(new AddressStrategyTestRepo(), new SumStrategy());
            //service2.SetStrategy(new SumStrategy());

            count = service2.ReportWithStrategy();

            Console.WriteLine($"Email-ek szama: {count}");
            //count = service2.ReportWithStrategy(new AvgStrategy());

            var service3 = new DataService(new AddressStrategyTestRepo(), new AvgStrategy());
            Console.WriteLine($"Email-ek atlagos szama: {service3.ReportWithStrategy()}");

            Console.WriteLine();

            ////////////////////////////////////////////////////////////////////////////////
            ///                         .NET megoldasa                                   ///
            ////////////////////////////////////////////////////////////////////////////////
            //delegate

            Console.WriteLine("Delegate-s megoldas");
            Console.WriteLine("Email-ek szama: {0}", service.ReportWithDelegate((list) =>
            {
                var sum = 0;
                foreach (var address in list)
                {
                    sum += address.EmailCount;
                }
                return sum;
            }));
            Console.WriteLine($"Email-ek atlagos szama: {service.ReportWithDelegate(list => (int)list.Average(x => x.EmailCount))}");



            #endregion JO megoldas


            Console.ReadLine();
        }
    }
}
