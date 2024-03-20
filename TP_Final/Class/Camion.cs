using JsonSubTypes;
using Newtonsoft.Json;
using NJsonSchema.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TP_Final.Class
{
    [JsonDerivedType(typeof(Camion), typeDiscriminator: "TP_Final.Class.Voiture")]
    public class Camion : Vehicule
    {
        private int poids;

        public int Poids
        {
            get { return poids; }
            set { poids = value; }
        }

        public Camion(string marque, string modele, int numero, int poids)
        {
            Marque = marque;
            Modele = modele;
            Numero = numero;
            Poids = poids;
        }

        public override string VehiculeType()
        {
            return "Camion";
        }

        public override string ToString()
        {
            return $"Camion - Marque: {Marque}, Modèle: {Modele}, Numéro: {Numero}, Poids: {Poids} kg";
        }

        public override void Deserialize(object data)
        {
            var camion = (dynamic)data;
            Marque = camion.Marque;
            Modele = camion.Modele;
            Poids = camion.Poids;
            Numero = camion.Numero;
        }
    }
}
