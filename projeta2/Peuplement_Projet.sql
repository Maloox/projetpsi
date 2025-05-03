-- Insertion Client
INSERT INTO `PSI`.`client` (`Code_Client`, `Nom`, `Prenom`, `Rue`, `Numero`, `CodePostal`, `Ville`, `Tel`, `Email`, `Id_Metro`) VALUES
(1, 'Durand', 'Medhy', 'Cardinet', 15, 75017, 'Paris', 1234567890, 'Mdurand@gmail.com', 146),
(2, 'Dupond', 'Marie', 'République', 30, 75011, 'Paris', 1234567890, 'Mdupond@gmail.com', 160),
(3, 'Bernard', 'Luc', 'Saint-Lazare', 12, 75008, 'Paris', 1234567890, 'Lbernard@gmail.com', 36),
(4, 'Lemoine', 'Chloé', 'Opéra', 25, 75009, 'Paris', 1234567890, 'Clemoine@gmail.com', 329),
(5, 'Moreau', 'Thomas', 'Bastille', 5, 75004, 'Paris', 1234567890, 'Tmoreau@gmail.com', 158),
(6, 'Garcia', 'Emma', 'Châtelet', 50, 75001, 'Paris', 1234567890, 'Egarcia@gmail.com', 94),
(7, 'Martinez', 'Hugo', 'Nation', 22, 75012, 'Paris', 1234567890, 'Hmartinez@gmail.com', 300),
(8, 'Dubois', 'Léa', 'Trocadéro', 8, 75016, 'Paris', 1234567890, 'Ldubois@gmail.com', 233),
(9, 'Robin', 'Louis', 'Montmartre', 18, 75018, 'Paris', 1234567890, 'Lrobin@gmail.com', 96),
(10, 'Fournier', 'Camille', 'Père-Lachaise', 35, 75020, 'Paris', 1234567890, 'Cfournier@gmail.com', 201),
(11, 'Lefevre', 'Noah', 'Denfert-Rochereau', 3, 75014, 'Paris', 1234567890, 'Nlefevre@gmail.com', 12),
(12, 'Fontaine', 'Alice', 'La Défense', 10, 75092, 'Paris', 1234567890, 'Afontaine@gmail.com', 185),
(13, 'Reynaud', 'Nathan', 'Gare de Lyon', 20, 75012, 'Paris', 1234567890, 'Nreynaud@gmail.com', 47),
(14, 'Rousseau', 'Sophie', 'Odéon', 14, 75006, 'Paris', 1234567890, 'Srousseau@gmail.com', 209),
(15, 'Petit', 'Paul', 'Belleville', 21, 75020, 'Paris', 1234567890, 'Ppetit@gmail.com', 287),
(16, 'Roux', 'Julie', 'Ménilmontant', 19, 75020, 'Paris', 1234567890, 'Jroux@gmail.com', 213),
(17, 'Blanc', 'Antoine', 'Pigalle', 23, 75009, 'Paris', 1234567890, 'Ablanc@gmail.com', 291),
(18, 'Leclerc', 'Élodie', 'Voltaire', 17, 75011, 'Paris', 1234567890, 'Eleclerc@gmail.com', 92),
(19, 'Chevalier', 'Victor', 'Gambetta', 12, 75020, 'Paris', 1234567890, 'Vchevalier@gmail.com', 117),
(20, 'Marchand', 'Clara', 'Jaurès', 25, 75019, 'Paris', 1234567890, 'Cmarchand@gmail.com', 245),
(21, 'Dumont', 'Alexandre', 'Crimée', 16, 75019, 'Paris', 1234567890, 'Adumont@gmail.com', 313),
(22, 'Guillaume', 'Sarah', 'Laumière', 13, 75019, 'Paris', 1234567890, 'Sguillaume@gmail.com', 331),
(23, 'Henry', 'Lucas', 'Ourcq', 18, 75019, 'Paris', 1234567890, 'Lhenry@gmail.com', 85),
(24, 'Muller', 'Jeanne', 'Stalingrad', 20, 75019, 'Paris', 1234567890, 'Jmuller@gmail.com', 145),
(25, 'Simon', 'Martin', 'Riquet', 15, 75019, 'Paris', 1234567890, 'Msimon@gmail.com', 237),
(26, 'Leroy', 'Sophie', 'Marx Dormoy', 11, 75018, 'Paris', 1234567890, 'Sleroy@gmail.com', 124),
(27, 'David', 'Paul', 'Marcadet', 14, 75018, 'Paris', 1234567890, 'Pdavid@gmail.com', 260),
(28, 'Perrin', 'Marie', 'Porte de Clignancourt', 17, 75018, 'Paris', 1234567890, 'Mperrin@gmail.com', 281),
(29, 'Morel', 'Julien', 'Porte de Saint-Ouen', 13, 75018, 'Paris', 1234567890, 'Jmorel@gmail.com', 19),
(30, 'Gauthier', 'Laura', 'Guy Môquet', 16, 75017, 'Paris', 1234567890, 'Lgauthier@gmail.com', 268);

-- Insertion Cuisinier
INSERT INTO Cuisinier (Code_Cuisinier) VALUES ('1');
INSERT INTO Cuisinier (Code_Cuisinier) VALUES ('2');
INSERT INTO Cuisinier (Code_Cuisinier) VALUES ('3');
INSERT INTO Cuisinier (Code_Cuisinier) VALUES ('4');
INSERT INTO Cuisinier (Code_Cuisinier) VALUES ('5');
INSERT INTO Cuisinier (Code_Cuisinier) VALUES ('6');
INSERT INTO Cuisinier (Code_Cuisinier) VALUES ('7');

UPDATE Client SET Code_Cuisinier = '1' WHERE Code_Client = 2;  -- Dupond : Cuisinier 1
UPDATE Client SET Code_Cuisinier = '2' WHERE Code_Client = 7;  -- Martinez : Cuisinier 2
UPDATE Client SET Code_Cuisinier = '3' WHERE Code_Client = 12; -- Fontaine : Cuisinier 3
UPDATE Client SET Code_Cuisinier = '4' WHERE Code_Client = 15; -- Petit : Cuisinier 4
UPDATE Client SET Code_Cuisinier = '5' WHERE Code_Client = 18; -- Leclerc : Cuisinier 5
UPDATE Client SET Code_Cuisinier = '6' WHERE Code_Client = 21; -- Dumont : Cuisinier 6
UPDATE Client SET Code_Cuisinier = '7' WHERE Code_Client = 24; -- Muller : Cuisinier 7

-- Insertion Entreprise Locale
INSERT INTO Entreprise_local (Référence, Nom) VALUES
('1', 'Ferme Bio'),
('2', 'Boucherie Artisanale'),
('3', 'Boulangerie Traditionnelle'),
('4', 'Marché Local'),
('5', 'Fromagerie Artisanale'),
('6', 'Épicerie Fine'),
('7', 'Pâtisserie Gourmande');

-- Insertion Radié (Optionnel)
INSERT INTO Radié (Code_Cl) VALUES
(7),
(10),
(19),
(25);

-- Insertion Avis
INSERT INTO Avis (ID_Retour, Code_Cuisinier, Code_Client, Référence, Note) VALUES
('1', '1', 1, '1', 5),
('2', '1', 2, '2', 4),
('3', '2', 3, '1', 3),
('4', '3', 4, '2', 5),
('5', '2', 5, '1', 2),
('6', '4', 3, '3', 4),
('7', '5', 6, '4', 5),
('8', '4', 8, '3', 3),
('9', '5', 9, '4', 4),
('10', '6', 11, '5', 4),
('11', '7', 13, '6', 5),
('12', '6', 14, '5', 3),
('13', '7', 16, '6', 4);

-- Insertion Plat
INSERT INTO Plat (Nom_P, Prix, Type, Date_Fabrication, Date_péremption, Régime, Nature) VALUES
('Raclette', 10, 'Plat', '10/01/2025', '15/01/2025', NULL, 'Française'),
('Salade de fruit', 5, 'Dessert', '10/01/2025', '15/01/2025', 'Végétarien', 'Indifférent'),
('Quiche Lorraine', 8, 'Plat', '12/01/2025', '17/01/2025', NULL, 'Française'),
('Tarte aux pommes', 6, 'Dessert', '12/01/2025', '17/01/2025', 'Végétarien', 'Indifférent'),
('Pizza Margherita', 9, 'Plat', '14/01/2025', '19/01/2025', NULL, 'Italienne'),
('Tiramisu', 7, 'Dessert', '14/01/2025', '19/01/2025', NULL, 'Italienne'),
('Couscous Royal', 12, 'Plat', '16/01/2025', '21/01/2025', NULL, 'Maghrébine'),
('Salade Niçoise', 6, 'Entrée', '16/01/2025', '21/01/2025', NULL, 'Française'),
('Boeuf Bourguignon', 11, 'Plat', '18/01/2025', '23/01/2025', NULL, 'Française'),
('Crème Brûlée', 6, 'Dessert', '18/01/2025', '23/01/2025', NULL, 'Française'),
('Sushi Assortiment', 15, 'Plat', '20/01/2025', '25/01/2025', NULL, 'Japonaise'),
('Mousse au Chocolat', 5, 'Dessert', '20/01/2025', '25/01/2025', NULL, 'Française'),
('Paella Valenciana', 14, 'Plat', '22/01/2025', '27/01/2025', NULL, 'Espagnole'),
('Flan Pâtissier', 4, 'Dessert', '22/01/2025', '27/01/2025', NULL, 'Française'),
('Tajine d\'Agneau', 13, 'Plat', '24/01/2025', '29/01/2025', NULL, 'Marocaine');

-- Insertion Ingrédient
INSERT INTO Ingrédient (Nom_I) VALUES
('raclette fromage'),
('pommes_de_terre'),
('jambon'),
('cornichon'),
('fraise'),
('kiwi'),
('sucre'),
('lardons'),
('crème fraîche'),
('oeufs'),
('pommes'),
('cannelle'),
('mozzarella'),
('tomates'),
('basilic'),
('mascarpone'),
('café'),
('semoule'),
('légumes'),
('viande'),
('haricots verts'),
('thon'),
('olives'),
('boeuf'),
('carottes'),
('chocolat'),
('riz'),
('poisson'),
('algues'),
('safran'),
('poulet'),
('agneau'),
('pruneaux'),
('amandes');

-- Insertion est_composé
INSERT INTO est_composé (Nom_P, Nom_I, Quantité) VALUES
('Raclette', 'raclette fromage', '250g'),
('Raclette', 'pommes_de_terre', '200g'),
('Raclette', 'jambon', '200g'),
('Raclette', 'cornichon', '3p'),
('Salade de fruit', 'fraise', '100g'),
('Salade de fruit', 'kiwi', '100g'),
('Salade de fruit', 'sucre', '10g'),
('Quiche Lorraine', 'lardons', '100g'),
('Quiche Lorraine', 'crème fraîche', '200g'),
('Quiche Lorraine', 'oeufs', '3p'),
('Tarte aux pommes', 'pommes', '300g'),
('Tarte aux pommes', 'sucre', '50g'),
('Tarte aux pommes', 'cannelle', '1p'),
('Pizza Margherita', 'mozzarella', '150g'),
('Pizza Margherita', 'tomates', '100g'),
('Pizza Margherita', 'basilic', '5g'),
('Tiramisu', 'mascarpone', '250g'),
('Tiramisu', 'café', '50ml'),
('Tiramisu', 'sucre', '50g'),
('Couscous Royal', 'semoule', '200g'),
('Couscous Royal', 'légumes', '300g'),
('Couscous Royal', 'viande', '200g'),
('Salade Niçoise', 'haricots verts', '100g'),
('Salade Niçoise', 'thon', '100g'),
('Salade Niçoise', 'olives', '50g'),
('Boeuf Bourguignon', 'boeuf', '300g'),
('Boeuf Bourguignon', 'carottes', '100g'),
('Crème Brûlée', 'crème fraîche', '200g'),
('Crème Brûlée', 'sucre', '50g'),
('Sushi Assortiment', 'riz', '200g'),
('Sushi Assortiment', 'poisson', '150g'),
('Sushi Assortiment', 'algues', '20g'),
('Mousse au Chocolat', 'chocolat', '100g'),
('Mousse au Chocolat', 'oeufs', '2p'),
('Paella Valenciana', 'riz', '300g'),
('Paella Valenciana', 'poulet', '200g'),
('Paella Valenciana', 'safran', '1g'),
('Flan Pâtissier', 'oeufs', '3p'),
('Flan Pâtissier', 'sucre', '100g'),
('Tajine d\'Agneau', 'agneau', '300g'),
('Tajine d\'Agneau', 'pruneaux', '100g'),
('Tajine d\'Agneau', 'amandes', '50g');

-- Insertion est_approvisioné
INSERT INTO est_approvisioné (Nom_P, Référence, Quantité) VALUES
('Raclette', '1', '50kg'),
('Salade de fruit', '1', '20kg'),
('Quiche Lorraine', '3', '30kg'),
('Tarte aux pommes', '4', '15kg'),
('Pizza Margherita', '5', '25kg'),
('Tiramisu', '6', '15kg'),
('Couscous Royal', '1', '40kg'),
('Salade Niçoise', '2', '20kg'),
('Boeuf Bourguignon', '3', '35kg'),
('Crème Brûlée', '4', '10kg'),
('Sushi Assortiment', '7', '20kg'),
('Mousse au Chocolat', '6', '10kg'),
('Paella Valenciana', '5', '25kg'),
('Flan Pâtissier', '4', '15kg'),
('Tajine d\'Agneau', '2', '20kg');

-- Insertion est_livré
INSERT INTO est_livré (Nom_P, Code_Cuisinier, Date_Livraison) VALUES
('Raclette', '1', '11/01/2025'),
('Salade de fruit', '1', '11/01/2025'),
('Raclette', '2', '10/01/2025'),
('Salade de fruit', '2', '09/01/2025'),
('Raclette', '3', '08/01/2025'),
('Quiche Lorraine', '4', '13/01/2025'),
('Tarte aux pommes', '4', '13/01/2025'),
('Quiche Lorraine', '5', '12/01/2025'),
('Tarte aux pommes', '5', '11/01/2025'),
('Pizza Margherita', '6', '14/01/2025'),
('Tiramisu', '6', '14/01/2025'),
('Couscous Royal', '7', '16/01/2025'),
('Salade Niçoise', '7', '16/01/2025'),
('Boeuf Bourguignon', '1', '18/01/2025'),
('Crème Brûlée', '1', '18/01/2025'),
('Sushi Assortiment', '2', '20/01/2025'),
('Mousse au Chocolat', '2', '20/01/2025'),
('Paella Valenciana', '3', '22/01/2025'),
('Flan Pâtissier', '3', '22/01/2025'),
('Tajine d\'Agneau', '4', '24/01/2025');

-- Insertion est_commandé
INSERT INTO est_commandé (Nom_P, Code_Client, ID_Commande, Quantité) VALUES
('Raclette', 1, '1', 6),
('Salade de fruit', 1, '2', 6),
('Quiche Lorraine', 4, '3', 5),
('Tarte aux pommes', 5, '4', 4),
('Pizza Margherita', 6, '5', 3),
('Tiramisu', 7, '6', 4),
('Couscous Royal', 8, '7', 2),
('Salade Niçoise', 9, '8', 3),
('Boeuf Bourguignon', 10, '9', 2),
('Crème Brûlée', 11, '10', 4),
('Sushi Assortiment', 12, '11', 3),
('Mousse au Chocolat', 13, '12', 5),
('Paella Valenciana', 14, '13', 2),
('Flan Pâtissier', 15, '14', 3),
('Tajine d\'Agneau', 16, '15', 2);

-- Insertion est_cuisiné
INSERT INTO est_cuisiné (Nom_P, Code_Cuisinier) VALUES
('Raclette', '1'),
('Salade de fruit', '1'),
('Quiche Lorraine', '4'),
('Tarte aux pommes', '5'),
('Pizza Margherita', '6'),
('Tiramisu', '6'),
('Couscous Royal', '7'),
('Salade Niçoise', '7'),
('Boeuf Bourguignon', '1'),
('Crème Brûlée', '1'),
('Sushi Assortiment', '2'),
('Mousse au Chocolat', '2'),
('Paella Valenciana', '3'),
('Flan Pâtissier', '3'),
('Tajine d\'Agneau', '4');

INSERT INTO PlatDuJour (Nom_P) VALUES ('Pizza Margherita');

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Raclette' AND Code_Client = 1)
WHERE Nom_P = 'Raclette' AND Code_Cuisinier = '1';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Salade de fruit' AND Code_Client = 1)
WHERE Nom_P = 'Salade de fruit' AND Code_Cuisinier = '1';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Quiche Lorraine' AND Code_Client = 4)
WHERE Nom_P = 'Quiche Lorraine' AND Code_Cuisinier = '4';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Tarte aux pommes' AND Code_Client = 5)
WHERE Nom_P = 'Tarte aux pommes' AND Code_Cuisinier = '5';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Pizza Margherita' AND Code_Client = 6)
WHERE Nom_P = 'Pizza Margherita' AND Code_Cuisinier = '6';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Tiramisu' AND Code_Client = 7)
WHERE Nom_P = 'Tiramisu' AND Code_Cuisinier = '6';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Couscous Royal' AND Code_Client = 8)
WHERE Nom_P = 'Couscous Royal' AND Code_Cuisinier = '7';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Salade Niçoise' AND Code_Client = 9)
WHERE Nom_P = 'Salade Niçoise' AND Code_Cuisinier = '7';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Boeuf Bourguignon' AND Code_Client = 10)
WHERE Nom_P = 'Boeuf Bourguignon' AND Code_Cuisinier = '1';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Crème Brûlée' AND Code_Client = 11)
WHERE Nom_P = 'Crème Brûlée' AND Code_Cuisinier = '1';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Sushi Assortiment' AND Code_Client = 12)
WHERE Nom_P = 'Sushi Assortiment' AND Code_Cuisinier = '2';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Mousse au Chocolat' AND Code_Client = 13)
WHERE Nom_P = 'Mousse au Chocolat' AND Code_Cuisinier = '2';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Paella Valenciana' AND Code_Client = 14)
WHERE Nom_P = 'Paella Valenciana' AND Code_Cuisinier = '3';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Flan Pâtissier' AND Code_Client = 15)
WHERE Nom_P = 'Flan Pâtissier' AND Code_Cuisinier = '3';

UPDATE est_cuisiné
SET Quantité = (SELECT Quantité FROM est_commandé WHERE Nom_P = 'Tajine d\'Agneau' AND Code_Client = 16)
WHERE Nom_P = 'Tajine d\'Agneau' AND Code_Cuisinier = '4';

    
SELECT Nom, Prenom FROM Client WHERE Rue = 'Cardinet';
SELECT Id_Metro FROM Client WHERE Code_Cuisinier = '1';
SELECT Nom_P FROM Plat WHERE Régime = 'Végétarien';
SELECT * FROM est_composé WHERE Nom_P = 'Salade de fruit';
SELECT Nom_P, Quantité, ID_Commande FROM est_commandé WHERE Code_Client = 1;
SELECT Nom_P FROM est_cuisiné WHERE Code_Cuisinier = '1';
