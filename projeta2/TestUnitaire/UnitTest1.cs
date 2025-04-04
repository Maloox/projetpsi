using Microsoft.VisualStudio.TestTools.UnitTesting;
using projeta2;
using System;

namespace TestUnitaire
{
    [TestClass]
    public class LienTests
    {
        [TestMethod]
        public void Lien_ConstructeurAvecValeurs_CreeLienCorrectement()
        {
            // Arrange
            string valeur1 = "A";
            string valeur2 = "B";
            int temps = 5;

            // Act
            var lien = new Lien<string>(valeur1, valeur2, temps);

            // Assert
            Assert.AreEqual(valeur1, lien.Sommet1.Valeur);
            Assert.AreEqual(valeur2, lien.Sommet2.Valeur);
            Assert.AreEqual(temps, lien.Temps);
        }
    }
}
