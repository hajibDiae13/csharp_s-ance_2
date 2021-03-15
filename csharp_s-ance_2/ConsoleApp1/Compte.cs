using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Compte
    {
        protected readonly DateTime dateOuverture = DateTime.Now;
        protected readonly DateTime dateExpiration = DateTime.Now.AddYears(3);
        protected readonly uint numCompte;
        protected static uint cpt = 0 ;
        protected readonly Client titulaire;
        protected MAD solde;
        protected readonly static MAD plafond = new MAD(5000);
        protected Operation[] ops= new Operation[0];
        protected string typeCompte;

        public Compte(Client c1)
        {
            this.titulaire = c1;
            this.numCompte = ++Compte.cpt;
            this.solde = new MAD(0);
            this.typeCompte = "Génerique";
        }

        public virtual bool Crediter(MAD montant)
        {
            if(montant>=0)
            {
                this.solde += montant;
                Array.Resize(ref ops, ops.Length + 1);
                ops[ops.Length-1] = new Operation("Credité  ", montant);
                return true;
            }
            return false;
        }

        public virtual bool Debiter(MAD montant)
        {
            if (montant >= 0)
            {
                this.solde -= montant;
                Array.Resize(ref ops, ops.Length + 1);
                ops[ops.GetUpperBound(0)] = new Operation("Débité   ", montant);
                return true;
            }
            return false;
        }

        public virtual bool Verser(MAD montant,Compte cible)
        {
            if (montant <= Compte.plafond && montant<=this.solde && montant >= 0) 
            {
                this.Debiter(montant);
                cible.Crediter(montant);
                return true;
            }
            return false;
        }

        public virtual void Consulter()
        {

            Console.WriteLine("Date d'ouverture    : " + dateOuverture.ToString());
            Console.WriteLine("Date de d'expiration: " + dateExpiration.ToString());
            Console.WriteLine("Type du compte      : " + typeCompte);
            Console.WriteLine("Numero du compte    : "+ numCompte);
            titulaire.Afficher();
            Console.WriteLine("Solde               : "+solde.Afficher());
            Console.WriteLine("Plafond             : " + plafond.Afficher());
            Console.WriteLine("Operations          :\n");

            for (int i=0;i<ops.Length;i++)
            {
                ops[i].Afficher();
            }

        }
    }
}
