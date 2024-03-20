using Newtonsoft.Json;
using System.Drawing;
using TP_Final.Class;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TP_Final.Methods
{
    public class LoadAJsonFile
    {
        public static void LoadAFile(string cheminFichier, List<Vehicule> vehicules)
        {
            string json = File.ReadAllText(cheminFichier);
            
            if (File.Exists(cheminFichier))
            {
                List<object> deserializeList = JsonConvert.DeserializeObject<List<object>>(json);
                foreach (var vehiculesJson in deserializeList)
                {
                    if (vehiculesJson.ToString().Contains("Puissance"))
                    {
                        Voiture voiture = new Voiture("", "", 0000, 1);
                        voiture.Deserialize(vehiculesJson);
                        vehicules.Add(voiture);
                    } else if (vehiculesJson.ToString().Contains("Poids"))
                    {
                        Camion camion = new Camion("", "", 0000, 1);
                        camion.Deserialize(vehiculesJson);
                        vehicules.Add(camion);
                    }
                }
                Console.WriteLine("Toutes les données ont été chargées");
                Console.WriteLine("Voici ce que vous avez chargé : ");
                foreach (var item in vehicules)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("Le fichier spécifié n'existe pas.");
            }
            
        }
    }
}
