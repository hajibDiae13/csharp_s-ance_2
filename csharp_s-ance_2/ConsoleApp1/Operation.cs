using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Operation
    {
        private readonly DateTime dateOperation = DateTime.Now;
        private readonly string libele;
        private readonly MAD montant;
        private readonly uint ID;
        private static uint id_counter = 0; 


        public Operation(string libele, MAD montant)
        {
            this.libele = libele;
            this.montant = montant;
            this.ID = ++(Operation.id_counter);
        }

        public void Afficher()
        {
            Console.WriteLine("\tID: "+this.ID+"  date: " + this.dateOperation.ToString()+"  libele: "+this.libele+ "  montant: " + this.montant.Afficher());
        }
    }
}
