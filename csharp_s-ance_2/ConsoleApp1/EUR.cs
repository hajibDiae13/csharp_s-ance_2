using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class EUR
    {
        private double montant;

        public EUR(double montant)
        {
            this.montant = montant;
        }

        public string Afficher()
        {
            return this.montant + " EUR";
        }

        public string CovertToUSD()
        {
            return new USD(montant * 1.19).Afficher();
        }
        public string CovertToMAD()
        {
            return new MAD(montant * 10.69).Afficher();
        }
        public string CovertToJPY()
        {
            return new JPY(montant * 129.77).Afficher();
        }
        public string CovertToEUR()
        {
            return this.Afficher();
        }
    }
}
