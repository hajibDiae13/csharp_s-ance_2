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
            Client client1 = new Client("diae", "hajib", "test 404");
            Client client2 = new Client("anas", "fartas", "test 369");
            Compte c1 = new Compte(client1);
            Compte c2 = new Compte(client2);

            c1.Crediter(new MAD(3000.5));
            c1.Verser(new MAD(1950.75), c2);
            c2.Debiter(new MAD(900));

            Epargne ep = new Epargne(client1, 1.2);
            ep.Crediter(new MAD(7500.75));
            
            Courant cr = new Courant(client2);
            Courant cr1 = new Courant(client1);

            cr.Crediter(new MAD(3000));
            cr1.Crediter(new MAD(4000));
            ep.Verser(new MAD(2000),cr );
            c1.Consulter();

            Console.WriteLine("------------------------------");
            c2.Consulter();
            Console.WriteLine("------------------------------");
            ep.Consulter();
            Console.WriteLine("------------------------------");
            cr.Consulter();
            Console.WriteLine("------------------------------");
            cr1.Consulter();
            Console.ReadKey();
        }
    }
}
