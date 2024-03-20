using Newtonsoft.Json;
using NJsonSchema.Converters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TP_Final.Class
{
    [JsonDerivedType(typeof(Camion), typeDiscriminator: "TP_Final.Class.Camion")]
    [JsonDerivedType(typeof(Voiture), typeDiscriminator: "TP_Final.Class.Voiture")]
    public abstract class Vehicule
    {
        private string marque;
        private string modele;
        private int numero;

        public string Marque
        {
            get { return marque; }
            set { marque = value; }
        }

        public string Modele
        {
            get { return modele; }
            set { modele = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public override string ToString()
        {
            return $"Marque : {marque}, Modèle : {modele}, Numéro : {numero}";
        }

        public abstract string VehiculeType();

        public abstract void Deserialize(object data);
        
    }
}
