using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TP_Final.Class;

namespace TP_Final.Methods
{
    internal class SaveInFile
    {
        public static void SaveVehicules(List<Vehicule> vehicules, string cheminFichier)
        {
            string json = JsonConvert.SerializeObject(vehicules, Formatting.Indented);
            File.WriteAllText(cheminFichier, json);
            Console.WriteLine("Données sauvegardées avec succès.");
        }
    }
}
