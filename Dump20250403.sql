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
INSERT INTO `avis` VALUES ('1','5','1',1,'1'),('10','4','6',11,'5'),('11','5','7',13,'6'),('12','3','6',14,'5'),('13','4','7',16,'6'),('2','4','1',2,'2'),('3','3','2',3,'1'),('4','5','3',4,'2'),('5','2','2',5,'1'),('6','4','4',3,'3'),('7','5','5',6,'4'),('8','3','4',8,'3'),('9','4','5',9,'4');
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
INSERT INTO `client` VALUES (1,'Durand','Medhy','Cardinet',146,15,75017,'Paris',1234567890,'Mdurand@gmail.com',NULL,0),(2,'Dupond','Marie','République',160,30,75011,'Paris',1234567890,'Mdupond@gmail.com','1',0),(3,'Bernard','Luc','Saint-Lazare',36,12,75008,'Paris',1234567890,'Lbernard@gmail.com',NULL,0),(4,'Lemoine','Chloé','Opéra',329,25,75009,'Paris',1234567890,'Clemoine@gmail.com',NULL,0),(5,'Moreau','Thomas','Bastille',158,5,75004,'Paris',1234567890,'Tmoreau@gmail.com',NULL,0),(6,'Garcia','Emma','Châtelet',94,50,75001,'Paris',1234567890,'Egarcia@gmail.com',NULL,0),(7,'Martinez','Hugo','Nation',300,22,75012,'Paris',1234567890,'Hmartinez@gmail.com','2',0),(8,'Dubois','Léa','Trocadéro',233,8,75016,'Paris',1234567890,'Ldubois@gmail.com',NULL,0),(9,'Robin','Louis','Montmartre',96,18,75018,'Paris',1234567890,'Lrobin@gmail.com',NULL,0),(10,'Fournier','Camille','Père-Lachaise',201,35,75020,'Paris',1234567890,'Cfournier@gmail.com',NULL,0),(11,'Lefevre','Noah','Denfert-Rochereau',12,3,75014,'Paris',1234567890,'Nlefevre@gmail.com',NULL,0),(12,'Fontaine','Alice','La Défense',185,10,75092,'Paris',1234567890,'Afontaine@gmail.com','3',0),(13,'Reynaud','Nathan','Gare de Lyon',47,20,75012,'Paris',1234567890,'Nreynaud@gmail.com',NULL,0),(14,'Rousseau','Sophie','Odéon',209,14,75006,'Paris',1234567890,'Srousseau@gmail.com',NULL,0),(15,'Petit','Paul','Belleville',287,21,75020,'Paris',1234567890,'Ppetit@gmail.com','4',0),(16,'Roux','Julie','Ménilmontant',213,19,75020,'Paris',1234567890,'Jroux@gmail.com',NULL,0),(17,'Blanc','Antoine','Pigalle',291,23,75009,'Paris',1234567890,'Ablanc@gmail.com',NULL,0),(18,'Leclerc','Élodie','Voltaire',92,17,75011,'Paris',1234567890,'Eleclerc@gmail.com','5',0),(19,'Chevalier','Victor','Gambetta',117,12,75020,'Paris',1234567890,'Vchevalier@gmail.com',NULL,0),(20,'Marchand','Clara','Jaurès',245,25,75019,'Paris',1234567890,'Cmarchand@gmail.com',NULL,0),(21,'Dumont','Alexandre','Crimée',313,16,75019,'Paris',1234567890,'Adumont@gmail.com','6',0),(22,'Guillaume','Sarah','Laumière',331,13,75019,'Paris',1234567890,'Sguillaume@gmail.com',NULL,0),(23,'Henry','Lucas','Ourcq',85,18,75019,'Paris',1234567890,'Lhenry@gmail.com',NULL,0),(24,'Muller','Jeanne','Stalingrad',145,20,75019,'Paris',1234567890,'Jmuller@gmail.com','7',0),(25,'Simon','Martin','Riquet',237,15,75019,'Paris',1234567890,'Msimon@gmail.com',NULL,0),(26,'Leroy','Sophie','Marx Dormoy',124,11,75018,'Paris',1234567890,'Sleroy@gmail.com',NULL,0),(27,'David','Paul','Marcadet',260,14,75018,'Paris',1234567890,'Pdavid@gmail.com',NULL,0),(28,'Perrin','Marie','Porte de Clignancourt',281,17,75018,'Paris',1234567890,'Mperrin@gmail.com',NULL,0),(29,'Morel','Julien','Porte de Saint-Ouen',19,13,75018,'Paris',1234567890,'Jmorel@gmail.com',NULL,0),(30,'Gauthier','Laura','Guy Môquet',268,16,75017,'Paris',1234567890,'Lgauthier@gmail.com',NULL,0);
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
INSERT INTO `cuisinier` VALUES ('1'),('2'),('3'),('4'),('5'),('6'),('7');
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
INSERT INTO `entreprise_local` VALUES ('1','Ferme Bio'),('2','Boucherie Artisanale'),('3','Boulangerie Traditionnelle'),('4','Marché Local'),('5','Fromagerie Artisanale'),('6','Épicerie Fine'),('7','Pâtisserie Gourmande');
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
INSERT INTO `est_approvisioné` VALUES ('Boeuf Bourguignon','3','35kg'),('Couscous Royal','1','40kg'),('Crème Brûlée','4','10kg'),('Flan Pâtissier','4','15kg'),('Mousse au Chocolat','6','10kg'),('Paella Valenciana','5','25kg'),('Pizza Margherita','5','25kg'),('Quiche Lorraine','3','30kg'),('Raclette','1','50kg'),('Salade de fruit','1','20kg'),('Salade Niçoise','2','20kg'),('Sushi Assortiment','7','20kg'),('Tajine d\'Agneau','2','20kg'),('Tarte aux pommes','4','15kg'),('Tiramisu','6','15kg');
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
INSERT INTO `est_commandé` VALUES ('Boeuf Bourguignon',10,'9',2),('Couscous Royal',8,'7',2),('Crème Brûlée',11,'10',4),('Flan Pâtissier',15,'14',3),('Mousse au Chocolat',13,'12',5),('Paella Valenciana',14,'13',2),('Pizza Margherita',6,'5',3),('Quiche Lorraine',4,'3',5),('Raclette',1,'1',6),('Raclette',6,'105',5),('Salade de fruit',1,'2',6),('Salade Niçoise',9,'8',3),('Sushi Assortiment',12,'11',3),('Tajine d\'Agneau',16,'15',2),('Tarte aux pommes',5,'4',4),('Tiramisu',7,'6',4);
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
INSERT INTO `est_composé` VALUES ('Boeuf Bourguignon','boeuf','300g'),('Boeuf Bourguignon','carottes','100g'),('Couscous Royal','légumes','300g'),('Couscous Royal','semoule','200g'),('Couscous Royal','viande','200g'),('Crème Brûlée','crème fraîche','200g'),('Crème Brûlée','sucre','50g'),('Flan Pâtissier','oeufs','3p'),('Flan Pâtissier','sucre','100g'),('Mousse au Chocolat','chocolat','100g'),('Mousse au Chocolat','oeufs','2p'),('Paella Valenciana','poulet','200g'),('Paella Valenciana','riz','300g'),('Paella Valenciana','safran','1g'),('Pizza Margherita','basilic','5g'),('Pizza Margherita','mozzarella','150g'),('Pizza Margherita','tomates','100g'),('Quiche Lorraine','crème fraîche','200g'),('Quiche Lorraine','lardons','100g'),('Quiche Lorraine','oeufs','3p'),('Raclette','cornichon','3p'),('Raclette','jambon','200g'),('Raclette','pommes_de_terre','200g'),('Raclette','raclette fromage','250g'),('Salade de fruit','fraise','100g'),('Salade de fruit','kiwi','100g'),('Salade de fruit','sucre','10g'),('Salade Niçoise','haricots verts','100g'),('Salade Niçoise','olives','50g'),('Salade Niçoise','thon','100g'),('Sushi Assortiment','algues','20g'),('Sushi Assortiment','poisson','150g'),('Sushi Assortiment','riz','200g'),('Tajine d\'Agneau','agneau','300g'),('Tajine d\'Agneau','amandes','50g'),('Tajine d\'Agneau','pruneaux','100g'),('Tarte aux pommes','cannelle','1p'),('Tarte aux pommes','pommes','300g'),('Tarte aux pommes','sucre','50g'),('Tiramisu','café','50ml'),('Tiramisu','mascarpone','250g'),('Tiramisu','sucre','50g');
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
INSERT INTO `est_cuisiné` VALUES ('Boeuf Bourguignon','1',2),('Couscous Royal','7',2),('Crème Brûlée','1',4),('Flan Pâtissier','3',3),('Mousse au Chocolat','2',5),('Paella Valenciana','3',2),('Pizza Margherita','6',3),('Quiche Lorraine','4',5),('Raclette','1',6),('Salade de fruit','1',6),('Salade Niçoise','7',3),('Sushi Assortiment','2',3),('Tajine d\'Agneau','4',2),('Tarte aux pommes','5',4),('Tiramisu','6',4);
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
INSERT INTO `est_livré` VALUES ('Boeuf Bourguignon','1','18/01/2025'),('Couscous Royal','7','16/01/2025'),('Crème Brûlée','1','18/01/2025'),('Flan Pâtissier','3','22/01/2025'),('Mousse au Chocolat','2','20/01/2025'),('Paella Valenciana','3','22/01/2025'),('Pizza Margherita','6','14/01/2025'),('Quiche Lorraine','4','13/01/2025'),('Quiche Lorraine','5','12/01/2025'),('Raclette','1','11/01/2025'),('Raclette','2','10/01/2025'),('Raclette','3','08/01/2025'),('Salade de fruit','1','11/01/2025'),('Salade de fruit','2','09/01/2025'),('Salade Niçoise','7','16/01/2025'),('Sushi Assortiment','2','20/01/2025'),('Tajine d\'Agneau','4','24/01/2025'),('Tarte aux pommes','4','13/01/2025'),('Tarte aux pommes','5','11/01/2025'),('Tiramisu','6','14/01/2025');
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
INSERT INTO `ingrédient` VALUES ('agneau'),('algues'),('amandes'),('basilic'),('boeuf'),('café'),('cannelle'),('carottes'),('chocolat'),('cornichon'),('crème fraîche'),('fraise'),('haricots verts'),('jambon'),('kiwi'),('lardons'),('légumes'),('mascarpone'),('mozzarella'),('oeufs'),('olives'),('poisson'),('pommes'),('pommes_de_terre'),('poulet'),('pruneaux'),('raclette fromage'),('riz'),('safran'),('semoule'),('sucre'),('thon'),('tomates'),('viande');
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
INSERT INTO `plat` VALUES ('Boeuf Bourguignon',NULL,'18/01/2025','Plat','23/01/2025','11',NULL,'Française'),('Couscous Royal',NULL,'16/01/2025','Plat','21/01/2025','12',NULL,'Maghrébine'),('Crème Brûlée',NULL,'18/01/2025','Dessert','23/01/2025','6',NULL,'Française'),('Flan Pâtissier',NULL,'22/01/2025','Dessert','27/01/2025','4',NULL,'Française'),('Mousse au Chocolat',NULL,'20/01/2025','Dessert','25/01/2025','5',NULL,'Française'),('Paella Valenciana',NULL,'22/01/2025','Plat','27/01/2025','14',NULL,'Espagnole'),('Pizza Margherita',NULL,'14/01/2025','Plat','19/01/2025','9',NULL,'Italienne'),('Quiche Lorraine',NULL,'12/01/2025','Plat','17/01/2025','8',NULL,'Française'),('Raclette',NULL,'10/01/2025','Plat','15/01/2025','10',NULL,'Française'),('Salade de fruit',NULL,'10/01/2025','Dessert','15/01/2025','5','Végétarien','Indifférent'),('Salade Niçoise',NULL,'16/01/2025','Entrée','21/01/2025','6',NULL,'Française'),('Sushi Assortiment',NULL,'20/01/2025','Plat','25/01/2025','15',NULL,'Japonaise'),('Tajine d\'Agneau',NULL,'24/01/2025','Plat','29/01/2025','13',NULL,'Marocaine'),('Tarte aux pommes',NULL,'12/01/2025','Dessert','17/01/2025','6','Végétarien','Indifférent'),('Tiramisu',NULL,'14/01/2025','Dessert','19/01/2025','7',NULL,'Italienne');
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
INSERT INTO `platdujour` VALUES ('Pizza Margherita');
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
INSERT INTO `radié` VALUES ('10'),('19'),('25'),('7');
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

-- Dump completed on 2025-04-03 22:25:53
