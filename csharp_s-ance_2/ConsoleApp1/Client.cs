using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Client
    {
        private readonly string nom;
        private readonly string prenom;
        private string adresse;

        public Client(string nom, string prenom, string adresse)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
        }

        public void Afficher()
        {
            Console.WriteLine("nom                 : " + this.nom);
            Console.WriteLine("prenom              : " + this.prenom);
            Console.WriteLine("adresse             : " + this.adresse);
        }

        public bool isClient(string nom,string prenom)
        {
             return this.nom == nom && this.prenom == prenom ? true : false;
        }

    }
}
