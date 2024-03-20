using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_Final.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Final.Class;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace TP_Final.Methods.Tests
{
    [TestClass()]
    public class CRUDTests
    {
        [TestMethod()]
        public void ShowVehicules_WithVehiculesInList()
        {
            List<Vehicule> vehicules = new List<Vehicule>
            {
                new Voiture("Tesla", "Model Trois", 1000, 200),
                new Camion("Test", "Toto", 1000, 2000)
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);


                CRUD.ShowVehicules(vehicules);


                string expectedOutput = "Liste des véhicules :\r\nVoiture - Marque: Tesla, Modèle: Model Trois, Numéro: 1000, Puissance: 200 chevaux" +
                    "\r\nCamion - Marque: Test, Modèle: Toto, Numéro: 1000, Poids: 2000 kg\r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [TestMethod()]
        public void ShowVehicules_WithEmptyList()
        {

            List<Vehicule> vehicules = new List<Vehicule>();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);


                CRUD.ShowVehicules(vehicules);


                string expectedOutput = "Liste des véhicules :\r\nIl n'y a pas de véhicules dans votre liste pour l'instant\r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }

        [TestMethod()]
        public void DeleteVehicule_VehicleDoesNotExist_ShouldDisplayErrorMessage()
        {
            List<Vehicule> vehicules = new List<Vehicule>
            {
                new Voiture("Tesla", "Model Trois", 1000, 200),
                new Camion("Test", "Toto", 1000, 2000)
            };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Console.SetIn(new StringReader("3\n"));

                CRUD.DeleteVehicule(vehicules);

                StringAssert.Contains("Vous voulez supprimer un véhicule ? Chercher son numéro : \r\nVéhicule non trouvé\r\n", sw.ToString(), "Error message should be displayed for non-existing vehicle");
            }
        }
    }
}