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
            this.solde = new MAD(0);
            this.typeCompte = "Curant";
        }

        public bool Debiter(MAD montant)
        {
            if (montant >= 0 && this.solde- montant<= decouver)
            {
                this.solde -= montant;
                Array.Resize(ref ops, ops.Length + 1);
                ops[ops.GetUpperBound(0)] = new Operation("Débité ", montant);
                return true;
            }
            return false;
        }

        public void Consulter()
        {

            Console.WriteLine("Date d'ouverture    : " + dateOuverture.ToString());
            Console.WriteLine("Date de d'expiration: " + dateExpiration.ToString());
            Console.WriteLine("Type du compte      : " + typeCompte);
            Console.WriteLine("Numero du compte    : " + numCompte);
            titulaire.Afficher();
            Console.WriteLine("Solde               : " + solde.Afficher());
            Console.WriteLine("decouver            : " + decouver.Afficher());
            Console.WriteLine("Plafond             : " + plafond.Afficher());
            Console.WriteLine("Operations          :\n");

            for (int i = 0; i < ops.Length; i++)
            {
                ops[i].Afficher();
            }

        }
    }
}
