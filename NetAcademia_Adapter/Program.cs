using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Adapter
{
    /// <summary>
    /// Feladat: Koruzenet kuldese ugyfeleknek
    /// Szukseg lesz egy adatbazisra es egy uzenetkuldo szolgaltatasra(email, sms, chat stb.)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var adapter = new AdapterExample();
            adapter.Start();
        }
    }
}
