using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MAD : Devise
    {
        private double montant;

        public MAD(double montant)
        {
            this.montant = montant;
        }

        public string CovertToUSD()
        {
            return new USD(montant * 0.11).Afficher();
        }
        public string CovertToEUR()
        {
            return new EUR(montant * 0.093).Afficher();
        }
        public string CovertToJPY()
        {
            return new JPY(montant * 12.12).Afficher();
        }
        public string CovertToMAD()
        {
            return this.Afficher() ;
        }
    
        public string Afficher()
        {
            return this.montant + " MAD";
        }

        public static MAD operator +(MAD a,MAD b)
        {
            MAD result = new MAD(a.montant + b.montant);
            return result;
        }

        public static MAD operator -(MAD a, MAD b)
        {
            MAD result = new MAD(a.montant - b.montant);
            return result;
        }


        public static MAD operator *(MAD a, double b)
        {
            MAD result = new MAD(a.montant * b);
            return result;
        }

        public MAD half()
        {
            return new MAD(this.montant / 2);
        }



        public static bool operator <=(MAD a, MAD b)
        {
            if (a.montant <= b.montant) return true;
            return false;
        }

        public static bool operator >=(MAD a, MAD b)
        {
            if (a.montant >= b.montant) return true;
            return false;
        }

        public static bool operator >=(MAD a, int b)
        {
            if (a.montant >= b) return true;
            return false;
        }

        public static bool operator <=(MAD a, int b)
        {
            if (a.montant <= b) return true;
            return false;
        }





    }

}
