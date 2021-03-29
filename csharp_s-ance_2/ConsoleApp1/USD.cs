using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class USD
    {

        private double montant;

        public USD(double montant)
        {
            this.montant = montant;
        }

        public string Afficher()
        {
            return this.montant + " USD";
        }

        public string CovertToMAD()
        {
            return new MAD(montant * 8.96).Afficher();
        }
        public string CovertToEUR()
        {
            return new EUR(montant * 0.84).Afficher();
        }
        public string CovertToJPY()
        {
            return new JPY(montant * 108.77).Afficher();
        }
        public string CovertToUSD()
        {
            return this.Afficher();
        }
    }
}
