using JsonSubTypes;
using Newtonsoft.Json;
using NJsonSchema.Converters;
using System.Drawing;
using System.Text.Json.Serialization;

namespace TP_Final.Class
{
    [JsonDerivedType(typeof(Voiture), typeDiscriminator: "TP_Final.Class.Voiture")]
    public class Voiture : Vehicule
    {
        private int puissance;

        public int Puissance
        {
            get { return puissance; }
            set { puissance = value; }
        }

        public Voiture(string marque, string modele, int numero, int puissance)
        {
            Marque = marque;
            Modele = modele;
            Numero = numero;
            Puissance = puissance;
        }

        public override string VehiculeType()
        {
            return "Voiture";
        }

        public override string ToString()
        {
            return $"Voiture - Marque: {Marque}, Modèle: {Modele}, Numéro: {Numero}, Puissance: {Puissance} chevaux"; ;
        }

        public override void Deserialize(object data)
        {
            var voiture = (dynamic)data;
            Marque = voiture.Marque;
            Modele = voiture.Modele;
            Puissance = voiture.Puissance;
            Numero= voiture.Numero;
        }
    }
}
