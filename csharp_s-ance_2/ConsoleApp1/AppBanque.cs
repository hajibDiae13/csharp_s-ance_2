using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class AppBanque
    {
        public static string devise = "MAD";
        private static Client[] listeClients = new Client[0];
        private static Compte[] listeCompte = new Compte[0];
        private static int[] availableChoices = new int[10];
        public static void addClient()
        {
            Console.WriteLine("entrer le nom du client: ");
            string nom=Console.ReadLine();
            Console.WriteLine("entrer le prenom du client: ");
            string prenom= Console.ReadLine();
            Console.WriteLine("entrer l'adresse du client: ");
            string adresse= Console.ReadLine();
            Array.Resize(ref listeClients, listeClients.Length + 1);
            listeClients[listeClients.GetUpperBound(0)] = new Client(nom, prenom, adresse);
        }

        public static string AfficherConvertion(MAD montant)
        {
            if (AppBanque.devise == "MAD")
            {
                return montant.Afficher();
            }
            else if (AppBanque.devise == "EUR")
            {
                return montant.CovertToEUR();
            }
            else if (AppBanque.devise == "USD")
            {
                return montant.CovertToUSD();
            }
            else
            {
                return montant.CovertToJPY();
            }
        }

        public static Client SearchClient(string nom, string prenom)
        {
            for(int i=0; i< listeClients.Length;i++)
            {
                if (listeClients[i].isClient(nom, prenom)) return listeClients[i];
            }
            return null;
        }

        public static Compte SearchCompte(uint id)
        {
            for (int i = 0; i < listeCompte.Length; i++)
            {
                if (listeCompte[i].isCompte(id)) return listeCompte[i];
            }
            return null;
        }

        public static void addCompte()
        {
            string adresse, nom, prenom;
            Client c;
            Console.WriteLine("entrer le type du compte: (courant : 0 / epargne : 1)");
            int type = Int32.Parse(Console.ReadLine());
            if (listeClients.Length != 0)
            {     
                Console.WriteLine("entrer le nom du client: ");
                nom = Console.ReadLine();
                Console.WriteLine("entrer le prenom du client: ");
                prenom = Console.ReadLine();
                c = SearchClient(nom, prenom);
            }
            else
            {
                Console.WriteLine("\nAucun client existe, créer un nouvel client:\n");

                Console.WriteLine("entrer le nom du client: ");
                nom = Console.ReadLine();

                Console.WriteLine("entrer le prenom du client: ");
                prenom = Console.ReadLine();

                Console.WriteLine("entrer l'adresse du client: ");
                adresse = Console.ReadLine();

                Array.Resize(ref listeClients, listeClients.Length + 1);
                c = listeClients[listeClients.GetUpperBound(0)] = new Client(nom, prenom, adresse);
            }

            if (c == null)
            {
                Console.WriteLine("\nle client specifié n'éxiste pas. il sera donc créé\n");
                Console.WriteLine("entrer l'adresse du client: ");
                 adresse = Console.ReadLine();
                Array.Resize(ref listeClients, listeClients.Length + 1);
                c=listeClients[listeClients.GetUpperBound(0)] = new Client(nom, prenom, adresse);
            }

            if (type == 0)
            {
                Array.Resize(ref listeCompte, listeCompte.Length + 1);
                listeCompte[listeCompte.GetUpperBound(0)] = new Courant(c);
            }

            if (type == 1)
            {
                int taux;
                do
                {
                    Console.WriteLine("entrer le taux d'interest:");
                    taux = Int32.Parse(Console.ReadLine());
                    if(!(taux >= 0 && taux <= 100)) Console.WriteLine("taux invalide!");
                } while (!(taux >= 0 && taux <= 100));
                
                Array.Resize(ref listeCompte, listeCompte.Length + 1);
                listeCompte[listeCompte.GetUpperBound(0)] = new Epargne(c,taux);
            }
        }

        public static void afficherClients()
        {
            Console.Clear();
            for (int i = 0; i < listeClients.Length; i++)
            {
                Console.WriteLine("\n--------------------------\n");
                listeClients[i].Afficher();
                
            }
        }


        public static void afficherComptes()
        {
            Console.Clear();
            for (int i = 0; i < listeCompte.Length; i++)
            {
                Console.WriteLine("\n--------------------------\n");
                listeCompte[i].Consulter();
            }
        }

        public static void Menu()
        {

            // 1- creation client
            // 2- creation compte
            // 3- affichage clients
            // 4- affichage Comptes
            // 5- verser
            // 6- debiter
            // 7- crediter
            // 8- changement de devise
            // 9- quitter
            int i =1;

            Console.WriteLine("numbre de comptes: " + listeCompte.Length+"  numbre de comptes: "+ listeClients.Length+"  Devise actuel: "+devise);
            Console.WriteLine("\n---------MENU---------");
            availableChoices[i] = 1;
            Console.WriteLine((i++)+"-Crée client");
            availableChoices[i] = 2;
            Console.WriteLine((i++)+"-Crée Compte"); 
            if (listeClients.Length != 0)
            {
                availableChoices[i] = 3;
                Console.WriteLine((i++) + "-Afficher clients");
            }
            
            if (listeCompte.Length != 0)
            {
                availableChoices[i] = 4;
                Console.WriteLine((i++) + "-Afficher Comptes");
                availableChoices[i] = 5;
                Console.WriteLine((i++) + "-verser");
                availableChoices[i] = 6;
                Console.WriteLine((i++) + "-debiter");
                availableChoices[i] = 7;
                Console.WriteLine((i++) + "-crediter");
            }

            availableChoices[i] = 8;
            Console.WriteLine((i++) + "-changement de devise");

            availableChoices[i] = 9;
            Console.WriteLine((i++) + "-quitter");




        }

        public static void translateChoice(int choix)
        {
            if(availableChoices[choix] == 1) 
            {
                AppBanque.addClient();
            }
            else if (availableChoices[choix] == 2)
            {
                AppBanque.addCompte();
            }
            else if(availableChoices[choix] == 3)
            {
                AppBanque.afficherClients();
            }
            else if (availableChoices[choix] == 4)
            {
                AppBanque.afficherComptes();
            }
            else if (availableChoices[choix] == 5)
            {
                if (listeCompte.Length > 1)
                {
                    uint c1, c2;
                    Console.WriteLine("entrer le numero du compte source:");
                    c1 = uint.Parse(Console.ReadLine());
                    Console.WriteLine("entrer le numero du compte destination:");
                    c2 = uint.Parse(Console.ReadLine());
                    Console.WriteLine("entrer le montant en MAD:");
                    verser(c1, c2, new MAD(Int32.Parse(Console.ReadLine())));
                }
                else
                {
                    Console.WriteLine("compte source introuvable.");
                }
                
            }
            else if (availableChoices[choix] == 6)
            {
                Console.WriteLine("entrer le numero du compte a debiter en MAD::");
                uint c1 = uint.Parse(Console.ReadLine());
                Console.WriteLine("entrer le montant");
                debiter(c1, new MAD(Int32.Parse(Console.ReadLine())));
            }
            else if (availableChoices[choix] == 7)
            {
                Console.WriteLine("entrer le numero du compte a crediter en MAD::");
                uint c1 = uint.Parse(Console.ReadLine());
                Console.WriteLine("entrer le montant");
                crediter(c1, new MAD(Int32.Parse(Console.ReadLine())));
            }
            else if (availableChoices[choix] == 8)
            {
                int dev;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1- MAD");
                    Console.WriteLine("2- USD");
                    Console.WriteLine("3- EUR");
                    Console.WriteLine("4- JPY");
                    Console.Write("\n > "); dev = Int32.Parse(Console.ReadLine());
                    if(dev < 1 || dev > 4)
                    {
                        Console.WriteLine("choix invalide");
                        Console.ReadKey();
                    }
                } while (dev < 1 || dev > 4);

                if (dev == 1)
                {
                    devise = "MAD";
                }
                else if (dev == 2)
                {
                    devise = "USD";
                }
                else if (dev == 3)
                {
                    devise = "EUR";
                }
                else if (dev == 4)
                {
                    devise = "JPY";
                }


            }
            else if (availableChoices[choix] == 9)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("choix invalide");  
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void verser(uint source_id, uint dest_id,MAD amount)
        {
            Compte c_source, c_dest;

                if ((c_source = SearchCompte(source_id)) != null)
                {
                    if ((c_dest = SearchCompte(dest_id)) != null)
                    {
                        Compte.Verser(amount, c_source, c_dest);
                    }
                    else
                    {
                        Console.WriteLine("compte destination introuvable.");
                    }
                }
                else
                {
                    Console.WriteLine("compte source introuvable.");
                }
            
        }

        public static void debiter(uint source_id, MAD amount)
        {
            Compte c_dest;
            if ((c_dest = SearchCompte(source_id)) != null)
            {
                c_dest.Debiter(amount);
            }
            else
            {
                Console.WriteLine("compte introuvable.");
            }
        }

        public static void crediter(uint source_id, MAD amount)
        {
            Compte c_dest;
            if ((c_dest = SearchCompte(source_id)) != null)
            {
                c_dest.Crediter(amount);
            }
            else
            {
                Console.WriteLine("compte introuvable.");
            }
        }
    }
}
