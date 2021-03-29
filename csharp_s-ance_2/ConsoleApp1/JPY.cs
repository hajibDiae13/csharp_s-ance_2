using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class JPY
    {
        private double montant;

        public JPY(double montant)
        {
            this.montant = montant;
        }

        public string Afficher()
        {
            return this.montant + " JPY";
        }

        public string CovertToUSD()
        {
            return new USD(montant * 0.0092).Afficher();
        }
        public string CovertToEUR()
        {
            return new EUR(montant * 0.0077).Afficher();
        }
        public string CovertToMAD()
        {
            return new MAD(montant * 0.082).Afficher();
        }
        public string CovertToJPY()
        {
            return this.Afficher();
        }
    }
}
