using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MAD
    {
        private double montant;

        public MAD(double montant)
        {
            this.montant = montant;
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
