using Microsoft.VisualStudio.TestTools.UnitTesting;
using projeta2;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace projeta2
{
    public class LienTests
    {
        [TestMethod]
        public void Lien()
        {
            string valeur1 = "A";
            string valeur2 = "B";
            int temps = 10;

            var lien = new Lien<string>(valeur1, valeur2, temps);

            Assert.AreEqual(valeur1, lien.Sommet1.Nom);
            Assert.AreEqual(valeur2, lien.Sommet2.Nom);
            Assert.AreEqual(temps, lien.Temps);
        }

        [TestMethod]
        public void Sommets()
        {
            // Arrange
            var s1 = new Sommet<string>("X");
            var s2 = new Sommet<string>("Y");
            int temps = 7;

            // Act
            var lien = new Lien<string>(s1, s2, temps);

            // Assert
            Assert.AreEqual("X", lien.Sommet1.Nom);
            Assert.AreEqual("Y", lien.Sommet2.Nom);
            Assert.AreEqual(temps, lien.Temps);
        }
    }

    [TestClass]
    public class SommetTests
    {
        [TestMethod]
        public void Sommet_2()
        {
            // Arrange
            string nom = "A";

            // Act
            var sommet = new Sommet<string>(nom);

            // Assert
            Assert.AreEqual(nom, sommet.Nom);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sommet_Constructeur_LanceExceptionPourValeurNulle()
        {
            // Act & Assert
            var sommet = new Sommet<string>(null);
        }
    }

    [TestClass]
    public class GrapheTests
    {
        [TestMethod]
        public void Graphe_BFS()
        {
            // Arrange
            var liens = new List<Lien<string>>
            {
                new Lien<string>("A", "B", 1),
                new Lien<string>("A", "C", 1),
                new Lien<string>("B", "D", 1),
                new Lien<string>("C", "D", 1)
            };

            var graphe = new Graphe<string>(liens);

            // Act
            int[] visitOrder = graphe.BFS(0);

            // Assert
            CollectionAssert.AreEqual(new int[] { 2, 1, 1, 2 }, visitOrder);
        }

        [TestMethod]
        public void Graphe_Connexite()
        {
            // Arrange
            var liens = new List<Lien<string>>
            {
                new Lien<string>("A", "B", 1),
                new Lien<string>("B", "C", 1),
                new Lien<string>("C", "A", 1)
            };

            var graphe = new Graphe<string>(liens);

            // Act
            bool isConnected = graphe.Connexite();

            // Assert
            Assert.IsTrue(isConnected);
        }
    }
}
