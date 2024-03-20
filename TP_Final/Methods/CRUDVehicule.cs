using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TP_Final.Class;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TP_Final.Methods
{
    public class CRUD
    {
        
        public static void AddVehicule(List<Vehicule> vehicules)
        {
            Console.WriteLine("Ajouter un véhicule");

            Console.WriteLine("Marque :");
            string marque = Console.ReadLine();

            bool errorOnModele = true;
            Console.WriteLine("Modele (SANS CHIFFRES) : ");
            string modele = Console.ReadLine();

            // tant qu'il y a une erreure sur l'entrée de l'utilisateur on lui demande de réécrire
            while (errorOnModele)
            {
                // boucler sur l'entrée utilisateur pour vérifier si il y a un chiffre
                for (int i = 0; i < modele.Length; i++)
                {
                    if (Char.IsDigit(modele[i]))
                    {
                        Console.WriteLine("Votre modele ne doit pas avoir de chiffres");
                        Console.WriteLine("Modele (SANS CHIFFRES) : ");
                        modele = Console.ReadLine();
                        errorOnModele = true;
                    }
                    else
                    {
                        errorOnModele = false;
                    }
                }
            }


            Console.WriteLine("Numéro :");
            string numeroString = Console.ReadLine();
            int numero = 0;
            bool errorOnNumero = true;

            // tant qu'il y a une erreure sur l'entrée de l'utilisateur on lui demande de réécrire
            while (errorOnNumero)
            {
                // boucler sur l'entrée utilisateur pour vérifier si il y a un chiffre
                for (int i = 0; i < numeroString.Length; i++)
                {
                    // on vérifie qu'il n'y a pas de lettre et que tout les charactères sont des chiffres
                    if (!Char.IsDigit(numeroString[i]))
                    {
                        Console.WriteLine("Votre numero doit avoir que des chiffres");
                        Console.WriteLine("Numero :");
                        numeroString = Console.ReadLine();
                        errorOnNumero = true;
                    } 
                    else
                    {
                        // vérifier si l'entrée utilisateur est comprise entre 4 et 6 charactères
                        if (numeroString.Length < 4 || numeroString.Length > 6)
                        {
                            Console.WriteLine("Le numero du véhicule doit être compris entre 4 et 6 chiffres");
                            Console.WriteLine("Numero :");
                            numeroString = Console.ReadLine();
                            errorOnNumero = true;
                        } 
                        else
                        {
                            numero = int.Parse(numeroString);
                            errorOnNumero = false;
                        }
                    }
                }                
            }

            Console.Write("Type de véhicule (1: Voiture, 2: Camion) : ");
            int type = int.Parse(Console.ReadLine());

            switch (type)
            {
                case 1:
                    Console.Write("Puissance : ");
                    int puissance = int.Parse(Console.ReadLine());

                    Voiture voiture = new Voiture(marque, modele, numero, puissance);

                    vehicules.Add(voiture);
                    Console.WriteLine("Votre nouveau véhicule a été ajouté avec succès.");
                    break;
                case 2:
                    Console.Write("Poids : ");
                    int poids = int.Parse(Console.ReadLine());

                    Camion camion = new Camion(marque, modele, numero, poids);

                    vehicules.Add(camion);
                    Console.WriteLine("Votre nouveau véhicule a été ajouté avec succès.");
                    break;
                default:
                    Console.WriteLine("Type de véhicule non valide");
                    break;
            }
        }

        public static void ShowVehicules(List<Vehicule> vehicules)
        {
            Console.WriteLine("Liste des véhicules :");
            if (vehicules.Any())
            {
                foreach (var vehicule in vehicules)
                {
                    Console.WriteLine(vehicule.ToString());
                }
            } else
            {
                Console.WriteLine("Il n'y a pas de véhicules dans votre liste pour l'instant");
            }
            
        }

        public static void EditVehicule(List<Vehicule> vehicules)
        {
            Console.WriteLine("Pour changer un véhicule chercher d'abord un numéro : ");
            int searchNumero = int.Parse(Console.ReadLine());

            var vehiculeToEdit = vehicules.Find(v =>  v.Numero == searchNumero);
            if (vehiculeToEdit != null)
            {
                Console.WriteLine("La marque actuelle du véhicule est : " + vehiculeToEdit.Marque);
                Console.WriteLine("Vous voulez la changer ? 1 : Oui 2 : Non");
                int yesOrNoMarque = int.Parse(Console.ReadLine());
                if (yesOrNoMarque == 1)
                {
                    Console.WriteLine("Veuillez écrire la nouvelle marque :");
                    string newMarque = Console.ReadLine();
                    vehiculeToEdit.Marque = newMarque;
                } else
                {
                    Console.WriteLine("Très bien passons au reste !");
                } 

                Console.WriteLine("Le modele actuel du vehicule est : " + vehiculeToEdit.Modele);
                Console.WriteLine("Vous voulez la changer ? 1 : Oui 2 : Non");
                int yesOrNoModele = int.Parse(Console.ReadLine());
                if (yesOrNoModele == 1)
                {
                    Console.WriteLine("Veuillez écrire le noveau modele (SANS CHIFFRES) :");
                    string newModele = Console.ReadLine();
                    vehiculeToEdit.Modele = newModele;
                }
                else
                {
                    Console.WriteLine("Très bien passons au reste !");
                }

                Console.WriteLine("Le numéro actuel du vehicule est : " + vehiculeToEdit.Numero);
                Console.WriteLine("Vous voulez la changer ? 1 : Oui 2 : Non");
                int yesOrNoNumero = int.Parse(Console.ReadLine());
                if (yesOrNoNumero == 1)
                {
                    Console.WriteLine("Veuillez écrire le noveau numero (QU'AVEC DES CHIFFRES) :");
                    string newNumeroString = Console.ReadLine();
                    int newNumero = 0;
                    bool noErrorOnNumero;

                    // vérifier si l'entrée utilisateur est comprise entre 4 et 6 charactères
                    if (newNumeroString.Length < 4 || newNumeroString.Length > 6)
                    {
                        Console.WriteLine("Le numero du véhicule doit être compris entre 4 et 6 chiffres");
                        noErrorOnNumero = false;
                    }
                    else
                    {
                        noErrorOnNumero = true;
                    }

                    // boucler sur l'entrée utilisateur pour vérifier si il y a un chiffre
                    for (int i = 0; i < newNumeroString.Length; i++)
                    {
                        // on vérifie qu'il n'y a pas de lettre et que tout les charactères sont des chiffres
                        if (!Char.IsDigit(newNumeroString[i]))
                        {
                            Console.WriteLine("Votre numero doit avoir que des chiffres");
                            noErrorOnNumero = false;
                            break;
                        }
                        else
                        {
                            newNumero = int.Parse(newNumeroString);
                            vehiculeToEdit.Numero = newNumero;
                            noErrorOnNumero = true;
                        }
                    }

                    // tant qu'il y a une erreure sur l'entrée de l'utilisateur on lui demande de réécrire
                    while (noErrorOnNumero == false)
                    {
                        Console.WriteLine("Numero :");
                        newNumeroString = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Très bien passons au reste !");
                }

                // si c'est une voiture on va demander de modifier la puissance
                if (vehiculeToEdit is Voiture)
                {
                    Console.WriteLine("Vous voulez changer la puissance ? 1 : Oui 2 : Non");
                    int yesOrNoPuissance = int.Parse(Console.ReadLine());
                    if (yesOrNoPuissance == 1)
                    {
                        Console.WriteLine("Veuillez écrire le noveau modele :");
                        int newPuissance = int.Parse(Console.ReadLine());
                        ((Voiture)vehiculeToEdit).Puissance = newPuissance;
                    }
                    else
                    {
                        Console.WriteLine("Très bien passons au reste !");
                    }

                }
                // si c'est un camion on va demander de modifier le poids
                else if (vehiculeToEdit is Camion)
                {
                    Console.WriteLine("Vous voulez changer le poids ? 1 : Oui 2 : Non");
                    int yesOrNoPoids = int.Parse(Console.ReadLine());
                    if (yesOrNoPoids == 1)
                    {
                        Console.WriteLine("Veuillez écrire le noveau modele :");
                        int newPoids = int.Parse(Console.ReadLine());
                        ((Camion)vehiculeToEdit).Poids = newPoids;
                    }
                    else
                    {
                        Console.WriteLine("Très bien passons au reste !");
                    }
                }
            } else
            {
                Console.WriteLine("Il n'y a pas de véhicule avec ce numéro");
            }
        }

        public static void DeleteVehicule(List<Vehicule> vehicules)
        {
            Console.WriteLine("Vous voulez supprimer un véhicule ? Chercher son numéro : ");
            int numero = int.Parse(Console.ReadLine());
            Vehicule vehiculeToDelete = vehicules.Find(v => v.Numero == numero);
            if (vehiculeToDelete != null)
            {
                Console.WriteLine("Voici le véhicule que vous voulez supprimer " + vehiculeToDelete.ToString() );
                Console.WriteLine("Vous êtes sûr ? 1. Oui 2. Non");
                int yesOrNo = int.Parse(Console.ReadLine());
                if (yesOrNo == 1)
                {
                    vehicules.Remove(vehiculeToDelete);
                    Console.WriteLine("Le véhicule a été supprimé avec succès");
                } else if (yesOrNo == 2)
                {
                    Console.WriteLine("Très bien, à la prochaine");
                }
            } else
            {
                Console.WriteLine("Véhicule non trouvé");
            }
        }

        public static void ReadByNum(List<Vehicule> vehicules)
        {
            Console.WriteLine("Afficher un véhicule selon son numéro : ");
            int numero = int.Parse(Console.ReadLine());
            var findVehicule = vehicules.Find(v => v.Numero == numero);
            if(findVehicule != null)
            {
                Console.WriteLine("Voici le véhicule lié à ce numéro");
                Console.WriteLine(findVehicule.ToString());
            } else
            {
                Console.WriteLine("Il n'y a pas de véhicules avec ce numéro");
            }

        }

        
    }
}
