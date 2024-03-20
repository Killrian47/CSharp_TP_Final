using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Final.Class;

namespace TP_Final.Methods
{
    internal class Tris
    {
        public static string OrderByVehicules()
        {
            while (true)
            {
                Console.WriteLine("=== Menu sens d'order ===");
                Console.WriteLine("1. Ascendant");
                Console.WriteLine("2. Descendant");
                Console.WriteLine("3. Retour au menu de tri");
                Console.Write("Entrez votre choix : ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        return "ASC";
                    case "2":
                        return "DESC";
                    case "3":
                        return "A bientot";
                    default:
                        Console.WriteLine("Votre choix n'est pas pris en compte");
                        break;
                }
            }
        }

        public static void TriVehicules(List<Vehicule> vehicules)
        {
            while (true)
            {
                Console.WriteLine("=== Menu de tri ===");
                Console.WriteLine("1. Trier par marques");
                Console.WriteLine("2. Trier par modele");
                Console.WriteLine("3. Trier par numéro");
                Console.WriteLine("4. Trier par puissance");
                Console.WriteLine("5. Trier par poids");
                Console.WriteLine("6. Quitter le menu de tri");
                Console.Write("Entrez votre choix : ");

                string choixTri = Console.ReadLine();
                List<Vehicule> vehiculesTries = [];

                switch (choixTri)
                {
                    case "1":
                        string resultOrder = OrderByVehicules();
                        if (resultOrder == "ASC")
                        {
                            var vehiculesSorted = vehicules.OrderBy(v => v.Marque);
                            foreach (var vehicule in vehiculesSorted)
                            {
                                Console.WriteLine(vehicule.ToString());
                            }
                        }
                        else if (resultOrder == "DESC")
                        {
                            var vehiculesSorted = vehicules.OrderByDescending(v => v.Marque);
                            foreach (var vehicule in vehiculesSorted)
                            {
                                Console.WriteLine(vehicule.ToString());
                            }
                        }
                        break;
                    case "2":
                        string resultOrder2 = OrderByVehicules();
                        if (resultOrder2 == "ASC")
                        {
                            var vehiculesSorted = vehicules.OrderBy(v => v.Modele);
                            foreach (var vehicule in vehiculesSorted)
                            {
                                Console.WriteLine(vehicule.ToString());
                            }
                        }
                        else if (resultOrder2 == "DESC")
                        {
                            var vehiculesSorted = vehicules.OrderByDescending(v => v.Modele);
                            foreach (var vehicule in vehiculesSorted)
                            {
                                Console.WriteLine(vehicule.ToString());
                            }
                        }
                        break;
                    case "3":
                        string resultOrder3 = OrderByVehicules();
                        if (resultOrder3 == "ASC")
                        {
                            var vehiculesSorted = vehicules.OrderBy(v => v.Numero);
                            foreach (var vehicule in vehiculesSorted)
                            {
                                Console.WriteLine(vehicule.ToString());
                            }
                        }
                        else if (resultOrder3 == "DESC")
                        {
                            var vehiculesSorted = vehicules.OrderByDescending(v => v.Numero);
                            foreach (var vehicule in vehiculesSorted)
                            {
                                Console.WriteLine(vehicule.ToString());
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("Work in progress");
                        break;
                    case "5":
                        Console.WriteLine("Work in progress");
                        break;
                    case "6":
                        Console.WriteLine("Au revoir !");
                        return;
                    default:
                        Console.WriteLine("Votre saisi n'est pas bonne");
                        break;
                }
            }
        }
    }
}
