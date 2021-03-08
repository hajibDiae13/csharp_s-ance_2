using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    class Epargne : Compte
    {
        private readonly double taux;
        public Epargne(Client c1, double taux) : base(c1)
        {
            this.solde = new MAD(0);
            this.taux = taux;
            this.typeCompte = "Epargne";
        }

        public MAD CalculeTaux()
        {
            return this.solde * (this.taux/100);
        }

        public void AjouterTaux()
        {
            this.solde += CalculeTaux();
        }

        public void Consulter()
        {
            Console.WriteLine("Date d'ouverture    : " + dateOuverture.ToString());
            Console.WriteLine("Date de d'expiration: " + dateExpiration.ToString());
            Console.WriteLine("Type du compte      : " + typeCompte);
            Console.WriteLine("Numero du compte    : " + numCompte);
            titulaire.Afficher();
            Console.WriteLine("Solde               : " + solde.Afficher());
            Console.WriteLine("Plafond             : " + plafond.Afficher());
            Console.WriteLine("taux                : " + this.taux);
            Console.WriteLine("Interest            : "+CalculeTaux().Afficher());
            Console.WriteLine("Operations          :\n");

            for (int i = 0; i < ops.Length; i++)
            {
                ops[i].Afficher();
            }
        }
    }
}
