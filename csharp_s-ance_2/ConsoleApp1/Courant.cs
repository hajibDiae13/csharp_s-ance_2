using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Courant : Compte 
    {
        private static MAD decouver = new MAD(200);
     
        public Courant(Client c1) : base(c1)
        {
        }

        public override bool Debiter(MAD montant)
        {
            if(decouverTest(montant, decouver))
            {
                base.Debiter(montant);
                return true;
            }
            Console.WriteLine("Operation impossible, decouvert depassé.");
            return false;
        }

        public override void Consulter()
        {
            base.Consulter();
            Console.WriteLine("decouver            : "+AppBanque.AfficherConvertion(decouver));
            Console.WriteLine("type de compte      : Courant");


        }
    }
}
