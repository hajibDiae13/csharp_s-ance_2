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
           // this.solde = new MAD(0);
            this.taux = taux >= 0 && taux <= 100 ? taux : 0 ;
        }

        public MAD CalculeTaux()
        {
            return calculeTaux(this.taux);
        }

        public void AjouterTaux()
        {
            addTaux(this.taux);
            base.addOperation("Interest", CalculeTaux());
        }

        public override bool Debiter(MAD montant)
        {
            if (Epargne_Debit_Test(montant))
            {
                base.Debiter(montant);
                return true;
            }
            Console.WriteLine("Operation impossible, montant a debiter plus que la moitier.");
            return false;
        }

        public override void Consulter()
        {
            base.Consulter();
            Console.WriteLine("taux                : " + this.taux);
            Console.WriteLine("Interest            : "+AppBanque.AfficherConvertion(CalculeTaux()));
            Console.WriteLine("Type du compte      : epargne");

        }
    }
}
