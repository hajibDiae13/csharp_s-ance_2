using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix;

            do {
                AppBanque.Menu();
                Console.Write("\n > "); choix = Int32.Parse(Console.ReadLine());
                Console.Clear();
                AppBanque.translateChoice(choix);
            } while (true);


        }
    }
}
