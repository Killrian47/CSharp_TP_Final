// See https://aka.ms/new-console-template for more information
using TP_Final.Class;
using TP_Final.Methods;


List<Vehicule> vehicules = [];

while (true)
{
    Console.WriteLine("=== Menu ===");
    Console.WriteLine("1. Ajouter un véhicule");
    Console.WriteLine("2. Afficher tous les véhicules");
    Console.WriteLine("3. Supprimer un véhicule");
    Console.WriteLine("4. Modifier un véhicule");
    Console.WriteLine("5. Trouver un véhicule par  un numéro");
    Console.WriteLine("6. Trier les véhicules");
    Console.WriteLine("7. Sauvegarder mes véhicules");
    Console.WriteLine("8. Charger un fichier json");
    Console.WriteLine("9. Quitter");
    Console.Write("Entrez votre choix : ");

    string choix = Console.ReadLine();

    
    switch (choix)
    {
        case "1":
            CRUD.AddVehicule(vehicules);
            break;
        case "2":
            CRUD.ShowVehicules(vehicules);
            break;
        case "3":
            CRUD.DeleteVehicule(vehicules);
            break;
        case "4":
            CRUD.EditVehicule(vehicules);
            break;
        case "5":
            CRUD.ReadByNum(vehicules);
            break;
        case "6":
            Tris.TriVehicules(vehicules);
            break;
        case "7":
            SaveInFile.SaveVehicules(vehicules, "C:/json/jsonVehicle.json");
            break;
        case "8":
            LoadAJsonFile.LoadAFile("C:/json/jsonVehicle.json", vehicules);
            break;
        case "9":
            Console.WriteLine("Au revoir !");
            return;
        default:
            Console.WriteLine("Choix invalide, veuillez réessayer.");
            break;
    }
}