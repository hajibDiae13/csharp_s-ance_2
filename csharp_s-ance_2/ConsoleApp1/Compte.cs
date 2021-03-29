using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Compte
    {
        private readonly DateTime dateOuverture = DateTime.Now;
        private readonly DateTime dateExpiration = DateTime.Now.AddYears(3);
        private readonly uint numCompte;
        private static uint cpt = 0 ;
        private readonly Client titulaire;
        private MAD solde;
        private readonly static MAD plafond = new MAD(5000);
        private Operation[] ops= new Operation[0];

        public Compte(Client c1)
        {
            this.titulaire = c1;
            this.numCompte = ++Compte.cpt;
            this.solde = new MAD(0);
        }

        public virtual bool Crediter(MAD montant)
        {
            if(montant>=0)
            {
                this.solde += montant;
                addOperation("Credité  ", montant);
                return true;
            }
            else
            {
                Console.WriteLine("Operation impossible, montant négative");
            }
            return false;
        }

        public bool isCompte(uint id)
        {
            return this.numCompte == id;
        }

        public virtual bool Debiter(MAD montant)
        {
            if (montant >= 0)
            {
                if((this.solde - montant)>=0)
                {
                    this.solde -= montant;
                    addOperation("Débité   ", montant);
                    return true;
                }
                else
                {
                    Console.WriteLine("Operation impossible, nouveau solde négative");
                }
                
                
            }
            else
            {
                Console.WriteLine("Operation impossible, montant négative");
            }
            return false;
        }

        

        public void addOperation(string libele, MAD montant)
        {
            Array.Resize(ref ops, ops.Length + 1);
            ops[ops.GetUpperBound(0)] = new Operation(libele, montant);
        }

        public static bool Verser(MAD montant,Compte source, Compte dest)
        {
            if (montant <= Compte.plafond && montant<= source.solde && montant >= 0) 
            {
                if(source.Debiter(montant)) dest.Crediter(montant);
                return true;
            }
            return false;
        }

        public MAD calculeTaux(double taux)
        {
            return this.solde * (taux*100);
        }

        public void addTaux(double taux)
        {
            this.solde+= calculeTaux(taux);
        }

        public bool decouverTest(MAD montant,MAD decouver)
        {
            return (this.solde - montant >= decouver);
        }

        public bool Epargne_Debit_Test(MAD montant)
        {
            return (this.solde - montant <= this.solde.half());
        }

        public virtual void Consulter()
        {

            Console.WriteLine("Date d'ouverture    : " + dateOuverture.ToString());
            Console.WriteLine("Date de d'expiration: " + dateExpiration.ToString());
            Console.WriteLine("Numero du compte    : "+ numCompte);
            titulaire.Afficher();
            Console.WriteLine("Solde               : " + AppBanque.AfficherConvertion(this.solde));
            Console.WriteLine("Plafond             : " + AppBanque.AfficherConvertion(plafond));
            Console.WriteLine("Operations          :\n");

            for (int i=0;i<ops.Length;i++)
            {
                ops[i].Afficher();
            }
      

        }
    }
}
