DROP DATABASE IF EXISTS PSI;
CREATE DATABASE PSI;
USE PSI;

CREATE TABLE Plat(
   Nom_P VARCHAR(50),
   Nb_personnes VARCHAR(50),
   Date_Fabrication VARCHAR(50),
   Type VARCHAR(50),
   Date_péremption VARCHAR(50),
   Prix VARCHAR(50),
   Régime VARCHAR(50),
   Nature VARCHAR(50),
   PRIMARY KEY(Nom_P)
);

CREATE TABLE PlatDuJour (
    Nom_P VARCHAR(50) PRIMARY KEY
);


CREATE TABLE Cuisinier(
   Code_Cuisinier VARCHAR(50),
   PRIMARY KEY(Code_Cuisinier)
);

CREATE TABLE Client(
   Code_Client INT,
   Nom VARCHAR(50),
   Prenom VARCHAR(50),
   Rue VARCHAR(50),
   Id_Metro INT,
   Numero INT,
   CodePostal INT,
   Ville VARCHAR(50),
   Tel INT,
   Email VARCHAR(50),
   Code_Cuisinier VARCHAR(50),
   MontantAchats INTEGER DEFAULT 0,
   PRIMARY KEY(Code_Client),
   FOREIGN KEY(Code_Cuisinier) REFERENCES Cuisinier(Code_Cuisinier)
);


CREATE TABLE Entreprise_local(
   Référence VARCHAR(50),
   Nom VARCHAR(50),
   PRIMARY KEY(Référence)
);

CREATE TABLE Ingrédient(
   Nom_I VARCHAR(50),
   PRIMARY KEY(Nom_I)
);

CREATE TABLE Radié(
   Code_Cl VARCHAR(50),
   PRIMARY KEY(Code_Cl)
);

CREATE TABLE Avis(
   ID_Retour VARCHAR(50),
   Note VARCHAR(50),
   Code_Cuisinier VARCHAR(50) NOT NULL,
   Code_Client INT NOT NULL,
   Référence VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Retour),
   FOREIGN KEY(Code_Cuisinier) REFERENCES Cuisinier(Code_Cuisinier),
   FOREIGN KEY(Code_Client) REFERENCES Client(Code_Client),
   FOREIGN KEY(Référence) REFERENCES Entreprise_local(Référence)
);

CREATE TABLE est_cuisiné(
   Nom_P VARCHAR(50),
   Code_Cuisinier VARCHAR(50),
   Quantité INT,  -- Nouvelle colonne pour la quantité de plats cuisinés
   PRIMARY KEY(Nom_P, Code_Cuisinier),
   FOREIGN KEY(Nom_P) REFERENCES Plat(Nom_P),
   FOREIGN KEY(Code_Cuisinier) REFERENCES Cuisinier(Code_Cuisinier)
);


CREATE TABLE est_commandé(
   Nom_P VARCHAR(50),
   Code_Client INT,
   ID_Commande VARCHAR(50),
   Quantité INT,
   PRIMARY KEY(Nom_P, Code_Client),
   FOREIGN KEY(Nom_P) REFERENCES Plat(Nom_P),
   FOREIGN KEY(Code_Client) REFERENCES Client(Code_Client)
);

CREATE TABLE est_approvisioné(
   Nom_P VARCHAR(50),
   Référence VARCHAR(50),
   Quantité VARCHAR(50),
   PRIMARY KEY(Nom_P, Référence),
   FOREIGN KEY(Nom_P) REFERENCES Plat(Nom_P),
   FOREIGN KEY(Référence) REFERENCES Entreprise_local(Référence)
);

CREATE TABLE est_composé(
   Nom_P VARCHAR(50),
   Nom_I VARCHAR(50),
   Quantité VARCHAR(50),
   PRIMARY KEY(Nom_P, Nom_I),
   FOREIGN KEY(Nom_P) REFERENCES Plat(Nom_P),
   FOREIGN KEY(Nom_I) REFERENCES Ingrédient(Nom_I)
);

CREATE TABLE est_livré(
   Nom_P VARCHAR(50),
   Code_Cuisinier VARCHAR(50),
   Date_Livraison VARCHAR(50),
   PRIMARY KEY(Nom_P, Code_Cuisinier),
   FOREIGN KEY(Nom_P) REFERENCES Plat(Nom_P),
   FOREIGN KEY(Code_Cuisinier) REFERENCES Cuisinier(Code_Cuisinier)
);

CREATE TABLE est_radié(
   Code_Client INT,
   Référence VARCHAR(50),
   Code_Cl VARCHAR(50),
   PRIMARY KEY(Code_Client, Référence, Code_Cl),
   FOREIGN KEY(Code_Client) REFERENCES Client(Code_Client),
   FOREIGN KEY(Référence) REFERENCES Entreprise_local(Référence),
   FOREIGN KEY(Code_Cl) REFERENCES Radié(Code_Cl)
);

DROP USER IF EXISTS 'client_user'@'localhost';
CREATE USER 'client_user'@'localhost' IDENTIFIED BY 'client_password';

GRANT SELECT, INSERT, UPDATE, DELETE ON PSI.Client TO 'client_user'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON PSI.est_commandé TO 'client_user'@'localhost';

DROP USER IF EXISTS 'cuisinier_user'@'localhost';
CREATE USER 'cuisinier_user'@'localhost' IDENTIFIED BY 'cuisinier_password';

GRANT SELECT, INSERT, UPDATE, DELETE ON PSI.Cuisinier TO 'cuisinier_user'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON PSI.est_cuisiné TO 'cuisinier_user'@'localhost';
