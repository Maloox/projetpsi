CREATE DATABASE  IF NOT EXISTS `psi` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `psi`;
-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: psi
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `avis`
--

DROP TABLE IF EXISTS `avis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avis` (
  `ID_Retour` varchar(50) NOT NULL,
  `Note` varchar(50) DEFAULT NULL,
  `Code_Cuisinier` varchar(50) NOT NULL,
  `Code_Client` int NOT NULL,
  `Référence` varchar(50) NOT NULL,
  PRIMARY KEY (`ID_Retour`),
  KEY `Code_Cuisinier` (`Code_Cuisinier`),
  KEY `Code_Client` (`Code_Client`),
  KEY `Référence` (`Référence`),
  CONSTRAINT `avis_ibfk_1` FOREIGN KEY (`Code_Cuisinier`) REFERENCES `cuisinier` (`Code_Cuisinier`),
  CONSTRAINT `avis_ibfk_2` FOREIGN KEY (`Code_Client`) REFERENCES `client` (`Code_Client`),
  CONSTRAINT `avis_ibfk_3` FOREIGN KEY (`Référence`) REFERENCES `entreprise_local` (`Référence`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avis`
--

LOCK TABLES `avis` WRITE;
/*!40000 ALTER TABLE `avis` DISABLE KEYS */;
/*!40000 ALTER TABLE `avis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `Code_Client` int NOT NULL,
  `Nom` varchar(50) DEFAULT NULL,
  `Prenom` varchar(50) DEFAULT NULL,
  `Rue` varchar(50) DEFAULT NULL,
  `Id_Metro` int DEFAULT NULL,
  `Numero` int DEFAULT NULL,
  `CodePostal` int DEFAULT NULL,
  `Ville` varchar(50) DEFAULT NULL,
  `Tel` int DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Code_Cuisinier` varchar(50) DEFAULT NULL,
  `MontantAchats` int DEFAULT '0',
  PRIMARY KEY (`Code_Client`),
  KEY `Code_Cuisinier` (`Code_Cuisinier`),
  CONSTRAINT `client_ibfk_1` FOREIGN KEY (`Code_Cuisinier`) REFERENCES `cuisinier` (`Code_Cuisinier`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuisinier`
--

DROP TABLE IF EXISTS `cuisinier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuisinier` (
  `Code_Cuisinier` varchar(50) NOT NULL,
  PRIMARY KEY (`Code_Cuisinier`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuisinier`
--

LOCK TABLES `cuisinier` WRITE;
/*!40000 ALTER TABLE `cuisinier` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuisinier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entreprise_local`
--

DROP TABLE IF EXISTS `entreprise_local`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entreprise_local` (
  `Référence` varchar(50) NOT NULL,
  `Nom` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Référence`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entreprise_local`
--

LOCK TABLES `entreprise_local` WRITE;
/*!40000 ALTER TABLE `entreprise_local` DISABLE KEYS */;
/*!40000 ALTER TABLE `entreprise_local` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `est_approvisioné`
--

DROP TABLE IF EXISTS `est_approvisioné`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `est_approvisioné` (
  `Nom_P` varchar(50) NOT NULL,
  `Référence` varchar(50) NOT NULL,
  `Quantité` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Nom_P`,`Référence`),
  KEY `Référence` (`Référence`),
  CONSTRAINT `est_approvisioné_ibfk_1` FOREIGN KEY (`Nom_P`) REFERENCES `plat` (`Nom_P`),
  CONSTRAINT `est_approvisioné_ibfk_2` FOREIGN KEY (`Référence`) REFERENCES `entreprise_local` (`Référence`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `est_approvisioné`
--

LOCK TABLES `est_approvisioné` WRITE;
/*!40000 ALTER TABLE `est_approvisioné` DISABLE KEYS */;
/*!40000 ALTER TABLE `est_approvisioné` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `est_commandé`
--

DROP TABLE IF EXISTS `est_commandé`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `est_commandé` (
  `Nom_P` varchar(50) NOT NULL,
  `Code_Client` int NOT NULL,
  `ID_Commande` varchar(50) DEFAULT NULL,
  `Quantité` int DEFAULT NULL,
  PRIMARY KEY (`Nom_P`,`Code_Client`),
  KEY `Code_Client` (`Code_Client`),
  CONSTRAINT `est_commandé_ibfk_1` FOREIGN KEY (`Nom_P`) REFERENCES `plat` (`Nom_P`),
  CONSTRAINT `est_commandé_ibfk_2` FOREIGN KEY (`Code_Client`) REFERENCES `client` (`Code_Client`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `est_commandé`
--

LOCK TABLES `est_commandé` WRITE;
/*!40000 ALTER TABLE `est_commandé` DISABLE KEYS */;
/*!40000 ALTER TABLE `est_commandé` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `est_composé`
--

DROP TABLE IF EXISTS `est_composé`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `est_composé` (
  `Nom_P` varchar(50) NOT NULL,
  `Nom_I` varchar(50) NOT NULL,
  `Quantité` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Nom_P`,`Nom_I`),
  KEY `Nom_I` (`Nom_I`),
  CONSTRAINT `est_composé_ibfk_1` FOREIGN KEY (`Nom_P`) REFERENCES `plat` (`Nom_P`),
  CONSTRAINT `est_composé_ibfk_2` FOREIGN KEY (`Nom_I`) REFERENCES `ingrédient` (`Nom_I`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `est_composé`
--

LOCK TABLES `est_composé` WRITE;
/*!40000 ALTER TABLE `est_composé` DISABLE KEYS */;
/*!40000 ALTER TABLE `est_composé` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `est_cuisiné`
--

DROP TABLE IF EXISTS `est_cuisiné`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `est_cuisiné` (
  `Nom_P` varchar(50) NOT NULL,
  `Code_Cuisinier` varchar(50) NOT NULL,
  `Quantité` int DEFAULT NULL,
  PRIMARY KEY (`Nom_P`,`Code_Cuisinier`),
  KEY `Code_Cuisinier` (`Code_Cuisinier`),
  CONSTRAINT `est_cuisiné_ibfk_1` FOREIGN KEY (`Nom_P`) REFERENCES `plat` (`Nom_P`),
  CONSTRAINT `est_cuisiné_ibfk_2` FOREIGN KEY (`Code_Cuisinier`) REFERENCES `cuisinier` (`Code_Cuisinier`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `est_cuisiné`
--

LOCK TABLES `est_cuisiné` WRITE;
/*!40000 ALTER TABLE `est_cuisiné` DISABLE KEYS */;
/*!40000 ALTER TABLE `est_cuisiné` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `est_livré`
--

DROP TABLE IF EXISTS `est_livré`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `est_livré` (
  `Nom_P` varchar(50) NOT NULL,
  `Code_Cuisinier` varchar(50) NOT NULL,
  `Date_Livraison` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Nom_P`,`Code_Cuisinier`),
  KEY `Code_Cuisinier` (`Code_Cuisinier`),
  CONSTRAINT `est_livré_ibfk_1` FOREIGN KEY (`Nom_P`) REFERENCES `plat` (`Nom_P`),
  CONSTRAINT `est_livré_ibfk_2` FOREIGN KEY (`Code_Cuisinier`) REFERENCES `cuisinier` (`Code_Cuisinier`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `est_livré`
--

LOCK TABLES `est_livré` WRITE;
/*!40000 ALTER TABLE `est_livré` DISABLE KEYS */;
/*!40000 ALTER TABLE `est_livré` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `est_radié`
--

DROP TABLE IF EXISTS `est_radié`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `est_radié` (
  `Code_Client` int NOT NULL,
  `Référence` varchar(50) NOT NULL,
  `Code_Cl` varchar(50) NOT NULL,
  PRIMARY KEY (`Code_Client`,`Référence`,`Code_Cl`),
  KEY `Référence` (`Référence`),
  KEY `Code_Cl` (`Code_Cl`),
  CONSTRAINT `est_radié_ibfk_1` FOREIGN KEY (`Code_Client`) REFERENCES `client` (`Code_Client`),
  CONSTRAINT `est_radié_ibfk_2` FOREIGN KEY (`Référence`) REFERENCES `entreprise_local` (`Référence`),
  CONSTRAINT `est_radié_ibfk_3` FOREIGN KEY (`Code_Cl`) REFERENCES `radié` (`Code_Cl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `est_radié`
--

LOCK TABLES `est_radié` WRITE;
/*!40000 ALTER TABLE `est_radié` DISABLE KEYS */;
/*!40000 ALTER TABLE `est_radié` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingrédient`
--

DROP TABLE IF EXISTS `ingrédient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingrédient` (
  `Nom_I` varchar(50) NOT NULL,
  PRIMARY KEY (`Nom_I`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingrédient`
--

LOCK TABLES `ingrédient` WRITE;
/*!40000 ALTER TABLE `ingrédient` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingrédient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plat`
--

DROP TABLE IF EXISTS `plat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plat` (
  `Nom_P` varchar(50) NOT NULL,
  `Nb_personnes` varchar(50) DEFAULT NULL,
  `Date_Fabrication` varchar(50) DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL,
  `Date_péremption` varchar(50) DEFAULT NULL,
  `Prix` varchar(50) DEFAULT NULL,
  `Régime` varchar(50) DEFAULT NULL,
  `Nature` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Nom_P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plat`
--

LOCK TABLES `plat` WRITE;
/*!40000 ALTER TABLE `plat` DISABLE KEYS */;
/*!40000 ALTER TABLE `plat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `platdujour`
--

DROP TABLE IF EXISTS `platdujour`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `platdujour` (
  `Nom_P` varchar(50) NOT NULL,
  PRIMARY KEY (`Nom_P`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `platdujour`
--

LOCK TABLES `platdujour` WRITE;
/*!40000 ALTER TABLE `platdujour` DISABLE KEYS */;
/*!40000 ALTER TABLE `platdujour` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `radié`
--

DROP TABLE IF EXISTS `radié`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `radié` (
  `Code_Cl` varchar(50) NOT NULL,
  PRIMARY KEY (`Code_Cl`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `radié`
--

LOCK TABLES `radié` WRITE;
/*!40000 ALTER TABLE `radié` DISABLE KEYS */;
/*!40000 ALTER TABLE `radié` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-04 17:25:15
