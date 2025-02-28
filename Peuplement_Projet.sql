-- Insertion Client
INSERT INTO `PSI`.`client` (`Code_Client`, `Nom`, `Prenom`, `Rue`, `Numero`, `CodePostal`, `Ville`, `Tel`, `Email`, `Metro`) VALUES (1, 'Durand', 'Medhy', 'Cardinet', 15, 75017, 'Paris', 1234567890, 'Mdurand@gmail.com', 'Cardinet');
INSERT INTO `PSI`.`client` (`Code_Client`, `Nom`, `Prenom`, `Rue`, `Numero`, `CodePostal`, `Ville`, `Tel`, `Email`, `Metro`) VALUES (2, 'Dupond', 'Marie', 'République', 30, 75011, 'Paris', 1234567890, 'Mdupond@gmail.com', 'République');
INSERT INTO Cuisinier (Code_Cuisinier) SELECT Code_Client FROM Client WHERE Code_Client = 2;
INSERT INTO Cuisinier (Code_Cuisinier) VALUES ('1');
UPDATE Client SET Code_Cuisinier = '1' WHERE Code_Client = 2;

INSERT INTO Plat (Nom_P, Prix, Type, Date_Fabrication, Date_péremption, Régime, Nature) VALUES ('Raclette', '10', 'Plat', '10/01/2025', '15/01/2025', NULL, 'Française');
INSERT INTO Plat (Nom_P, Prix, Type, Date_Fabrication, Date_péremption, Régime, Nature) VALUES('Salade de fruit', '5', 'Dessert', '10/01/2025', '15/01/2025', 'Végétarien', 'Indifférent');
INSERT INTO Ingrédient (Nom_I) VALUES ('raclette fromage');
INSERT INTO Ingrédient (Nom_I) VALUES ('pommes_de_terre');
INSERT INTO Ingrédient (Nom_I) VALUES ('jambon');
INSERT INTO Ingrédient (Nom_I) VALUES ('cornichon');
INSERT INTO Ingrédient (Nom_I) VALUES ('fraise');
INSERT INTO Ingrédient (Nom_I) VALUES ('kiwi'); 
INSERT INTO Ingrédient (Nom_I) VALUES('sucre');

INSERT INTO est_composé (Nom_P, Nom_I, Quantité) VALUES ('Raclette', 'raclette fromage', '250g');
INSERT INTO est_composé (Nom_P, Nom_I, Quantité) VALUES ('Raclette', 'pommes_de_terre', '200g');
INSERT INTO est_composé (Nom_P, Nom_I, Quantité) VALUES ('Raclette', 'jambon', '200g');
INSERT INTO est_composé (Nom_P, Nom_I, Quantité) VALUES ('Raclette', 'cornichon', '3p');
INSERT INTO est_composé (Nom_P, Nom_I, Quantité) VALUES ('Salade de fruit', 'fraise', '100g');
INSERT INTO est_composé (Nom_P, Nom_I, Quantité) VALUES ('Salade de fruit', 'kiwi', '100g');
INSERT INTO est_composé (Nom_P, Nom_I, Quantité) VALUES ('Salade de fruit', 'sucre', '10g');

-- Insertion pour les commandes
INSERT INTO est_commandé (Nom_P, Code_Client, ID_Commande, Quantité) VALUES ('Raclette', 1, '1', 6);
INSERT INTO est_commandé (Nom_P, Code_Client, ID_Commande, Quantité) VALUES ('Salade de fruit', 1, '2', 6);

-- Insertion de quel cuisinier a préparé quel plat
INSERT INTO est_cuisiné (Nom_P, Code_Cuisinier) VALUES ('Raclette', '1');
INSERT INTO est_cuisiné (Nom_P, Code_Cuisinier) VALUES ('Salade de fruit', '1');

SELECT Nom, Prenom FROM Client WHERE Rue = 'Cardinet';
SELECT Metro FROM Client WHERE Code_Cuisinier = '1';
SELECT Nom_P FROM Plat WHERE Régime = 'Végétarien';
SELECT * FROM est_composé WHERE Nom_P = 'Salade de fruit';
SELECT Nom_P, Quantité, ID_Commande FROM est_commandé WHERE Code_Client = 1;
SELECT Nom_P FROM est_cuisiné WHERE Code_Cuisinier = '1';




