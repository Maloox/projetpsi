
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

using projeta2;
using SkiaSharp;

using System;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;


    class Programme
    {
    static string chaineConnexion = "Server=localhost;Port=3306;Database=PSI;User Id=root;Password=malo;";
    static void Main()
        {

        while (true)
            {
                Console.WriteLine("Choisissez une option :");
                Console.WriteLine("1. Interface Client");
                Console.WriteLine("2. Interface Cuisinier");
                Console.WriteLine("3. Gestion des Commandes");
                Console.WriteLine("4. Statistiques");
                Console.WriteLine("5. Autre");
                Console.WriteLine("6. Quittez");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        CalculerEtMettreAJourMontantAchats();
                        InterfaceClient();
                        break;
                    case "2":
                        InterfaceCuisinier();
                        break;
                    case "3":
                        GererCommandes();
                        break;
                    case "4":
                        AfficherStatistiques();
                        break;
                    case "5":
                        AfficherStatistiquesAutres();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
        }

        static void CalculerEtMettreAJourMontantAchats()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                conn.Open();

                string requete = @"
                SELECT c.Code_Client, SUM(p.Prix * ec.Quantité) as MontantAchats
                FROM Client c, est_commandé ec, Plat p
                WHERE c.Code_Client = ec.Code_Client
                AND ec.Nom_P = p.Nom_P
                GROUP BY c.Code_Client";

                List<Tuple<int, decimal>> montants = new List<Tuple<int, decimal>>();

                // lire et stocker les resultats avant modification
                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                using (MySqlDataReader lecteur = cmd.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        int codeClient = lecteur.GetInt32("Code_Client");
                        decimal montantAchats = lecteur.IsDBNull(1) ? 0 : lecteur.GetDecimal("MontantAchats");
                        montants.Add(new Tuple<int, decimal>(codeClient, montantAchats));
                    }
                }

                // mettre a jour les montants calcules
                foreach (var item in montants)
                {
                    using (MySqlCommand cmdMiseAJour = new MySqlCommand(
                        "UPDATE Client SET MontantAchats = @MontantAchats WHERE Code_Client = @Code_Client", conn))
                    {
                        cmdMiseAJour.Parameters.AddWithValue("@MontantAchats", item.Item2);
                        cmdMiseAJour.Parameters.AddWithValue("@Code_Client", item.Item1);
                        cmdMiseAJour.ExecuteNonQuery();
                    }
                }
            }
        }



        static void InterfaceClient()
        {
            Console.Write("Entrez votre Code_Client : ");
            int codeClient = int.Parse(Console.ReadLine());

            Console.WriteLine("Interface Client :");
            Console.WriteLine("1. Voir Profil");
            Console.WriteLine("2. Mettre à jour Profil");
            Console.WriteLine("3. Voir Commandes");
            Console.WriteLine("4. Ajouter un Client");
            Console.WriteLine("5. Supprimer un Client");
            Console.WriteLine("6. Afficher Clients triés");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1": VoirProfilClient(codeClient);
                break;
                case "2": MettreAJourProfilClient(codeClient);
                break;
                case "3": VoirCommandesClient(codeClient);
                break;
                case "4": AjouterClient();
                break;
                case "5": SupprimerClient();
                break;
                case "6": AfficherClientsTries();
                break;
                default: Console.WriteLine("Choix invalide. Veuillez réessayer.");
                break;
            }
        }


        static void VoirProfilClient(int codeClient)
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = "SELECT * FROM Client WHERE Code_Client = @Code_Client";
                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Client", codeClient);
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        if (lecteur.Read())
                        {
                            Console.WriteLine($"Nom: {lecteur["Nom"]}, Prénom: {lecteur["Prenom"]}, Rue: {lecteur["Rue"]}, Ville: {lecteur["Ville"]}");
                        }
                        else
                        {
                            Console.WriteLine("Client non trouvé.");
                        }
                    }
                }
            }
        }

        static void MettreAJourProfilClient(int codeClient)
        {
            Console.Write("Entrez le nouveau Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Entrez le nouveau Prénom : ");
            string prenom = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = "UPDATE Client SET Nom = @Nom, Prenom = @Prenom WHERE Code_Client = @Code_Client";
                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Client", codeClient);
                    cmd.Parameters.AddWithValue("@Nom", nom);
                    cmd.Parameters.AddWithValue("@Prenom", prenom);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Profil client mis à jour avec succès.");
                }
            }
        }

        static void VoirCommandesClient(int codeClient)
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                    SELECT ec.ID_Commande, p.Nom_P, ec.Quantité
                    FROM est_commandé ec
                    JOIN Plat p ON ec.Nom_P = p.Nom_P
                    WHERE ec.Code_Client = @Code_Client";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Client", codeClient);
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Vos Commandes :");
                        while (lecteur.Read())
                        {
                            Console.WriteLine($"ID Commande: {lecteur["ID_Commande"]}, Plat: {lecteur["Nom_P"]}, Quantité: {lecteur["Quantité"]}");
                        }
                    }
                }
            }
        }

    static void AjouterClient()
    {
        int nouveauCodeClient = 1;

        using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
        {
            conn.Open();

            string requeteMaxId = "SELECT MAX(Code_Client) FROM Client";
            using (MySqlCommand cmdMax = new MySqlCommand(requeteMaxId, conn))
            {
                object resultat = cmdMax.ExecuteScalar();
                if (resultat != DBNull.Value && resultat != null)
                {
                    nouveauCodeClient = Convert.ToInt32(resultat) + 1;
                }
            }

            Console.Write("Nom : "); string nom = Console.ReadLine();
            Console.Write("Prénom : "); string prenom = Console.ReadLine();
            Console.Write("Rue : "); string rue = Console.ReadLine();
            Console.Write("Ville : "); string ville = Console.ReadLine();
            Console.Write("Code Postal : "); int codePostal = int.Parse(Console.ReadLine());
            Console.Write("Téléphone : "); int tel = int.Parse(Console.ReadLine());
            Console.Write("Email : "); string email = Console.ReadLine();

            string requeteInsert = "INSERT INTO Client (Code_Client, Nom, Prenom, Rue, Ville, CodePostal, Tel, Email, MontantAchats) " +
                                   "VALUES (@Code_Client, @Nom, @Prenom, @Rue, @Ville, @CodePostal, @Tel, @Email, 0)";

            using (MySqlCommand cmd = new MySqlCommand(requeteInsert, conn))
            {
                cmd.Parameters.AddWithValue("@Code_Client", nouveauCodeClient);
                cmd.Parameters.AddWithValue("@Nom", nom);
                cmd.Parameters.AddWithValue("@Prenom", prenom);
                cmd.Parameters.AddWithValue("@Rue", rue);
                cmd.Parameters.AddWithValue("@Ville", ville);
                cmd.Parameters.AddWithValue("@CodePostal", codePostal);
                cmd.Parameters.AddWithValue("@Tel", tel);
                cmd.Parameters.AddWithValue("@Email", email);

                cmd.ExecuteNonQuery();
                Console.WriteLine($"Client ajouté avec succès. Code_Client : {nouveauCodeClient}");
            }
        }
    }

    static void SupprimerClient()
        {
            Console.Write("Entrez le Nom du client à supprimer : ");
            string nom = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = "DELETE FROM Client WHERE Nom = @Nom";
                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@Nom", nom);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client supprimé avec succès.");
                }
            }
        }

        static void AfficherClientsTries()
        {
            Console.WriteLine("Trier par : 1. Nom  2. Rue  3. Montant des achats");
            string choix = Console.ReadLine();
            string ordre = choix == "1" ? "Nom" : choix == "2" ? "Rue" : "MontantAchats DESC";

            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = $"SELECT * FROM Client ORDER BY {ordre}";
                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nListe des Clients :");
                        while (lecteur.Read())
                        {
                            Console.WriteLine($"Nom: {lecteur["Nom"]}, Rue: {lecteur["Rue"]}, Achats: {lecteur["MontantAchats"]}");
                        }
                    }
                }
            }
        }

        static void InterfaceCuisinier()
        {
            Console.Write("Entrez votre Code_Cuisinier : ");
            string codeCuisinier = Console.ReadLine();

            Console.WriteLine("Interface Cuisinier :");
            Console.WriteLine("1. Ajouter un Cuisinier");
            Console.WriteLine("2. Modifier un Cuisinier");
            Console.WriteLine("3. Supprimer un Cuisinier");
            Console.WriteLine("4. Voir Clients Servis");
            Console.WriteLine("5. Voir Plats Réalisés");
            Console.WriteLine("6. Voir Plat du Jour");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterCuisinier();
                    break;
                case "2":
                    ModifierCuisinier();
                    break;
                case "3":
                    DissocierCuisinier();
                    break;
                case "4":
                    VoirClientsServis(codeCuisinier);
                    break;
                case "5":
                    VoirPlatsRealises(codeCuisinier);
                    break;
                case "6":
                    VoirPlatDuJour();
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }

    // fonction pour ajouter un cuisinier
    static void AjouterCuisinier()
    {
        using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
        {
            conn.Open();

            int nouveauCodeClient = 1;
            string requeteDernierClient = "SELECT MAX(Code_Client) FROM Client";
            using (MySqlCommand cmd = new MySqlCommand(requeteDernierClient, conn))
            {
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    nouveauCodeClient = Convert.ToInt32(result) + 1;
                }
            }

            Console.Write("Entrez le Nom du client : ");
            string nomClient = Console.ReadLine();

            Console.Write("Entrez le Prénom du client : ");
            string prenomClient = Console.ReadLine();

            Console.Write("Entrez l'adresse du client : ");
            string rueClient = Console.ReadLine();

            Console.Write("Entrez le code postal du client : ");
            int codePostalClient = int.Parse(Console.ReadLine());

            Console.Write("Entrez la ville du client : ");
            string villeClient = Console.ReadLine();

            Console.Write("Entrez le téléphone du client : ");
            int telClient = int.Parse(Console.ReadLine());

            Console.Write("Entrez l'email du client : ");
            string emailClient = Console.ReadLine();

            string requeteClient = @"
        INSERT INTO Client (Code_Client, Nom, Prenom, Rue, CodePostal, Ville, Tel, Email, MontantAchats)
        VALUES (@Code_Client, @Nom, @Prenom, @Rue, @CodePostal, @Ville, @Tel, @Email, 0)";

            using (MySqlCommand cmd = new MySqlCommand(requeteClient, conn))
            {
                cmd.Parameters.AddWithValue("@Code_Client", nouveauCodeClient);
                cmd.Parameters.AddWithValue("@Nom", nomClient);
                cmd.Parameters.AddWithValue("@Prenom", prenomClient);
                cmd.Parameters.AddWithValue("@Rue", rueClient);
                cmd.Parameters.AddWithValue("@CodePostal", codePostalClient);
                cmd.Parameters.AddWithValue("@Ville", villeClient);
                cmd.Parameters.AddWithValue("@Tel", telClient);
                cmd.Parameters.AddWithValue("@Email", emailClient);

                cmd.ExecuteNonQuery();
                Console.WriteLine($"Client créé avec succès (Code_Client: {nouveauCodeClient}).");
            }

            string codeCuisinier = "" + nouveauCodeClient;

            string requeteCuisinier = "INSERT INTO Cuisinier (Code_Cuisinier) VALUES (@Code_Cuisinier)";
            using (MySqlCommand cmd = new MySqlCommand(requeteCuisinier, conn))
            {
                cmd.Parameters.AddWithValue("@Code_Cuisinier", codeCuisinier);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Cuisinier créé avec succès (Code_Cuisinier: {codeCuisinier}).");
            }

            string requeteAssocier = @"
        UPDATE Client 
        SET Code_Cuisinier = @Code_Cuisinier 
        WHERE Code_Client = @Code_Client";

            using (MySqlCommand cmd = new MySqlCommand(requeteAssocier, conn))
            {
                cmd.Parameters.AddWithValue("@Code_Cuisinier", codeCuisinier);
                cmd.Parameters.AddWithValue("@Code_Client", nouveauCodeClient);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Le client a été associé au cuisinier.");
            }
        }
    }


    // fonction pour modifier un cuisinier et son client associe
    static void ModifierCuisinier()
        {
            Console.Write("Entrez le Code_Cuisinier à modifier : ");
            string codeCuisinier = Console.ReadLine();

            // demander les informations a modifier pour le cuisinier et le client
            Console.Write("Entrez le nouveau Nom : ");
            string nouveauNom = Console.ReadLine();

            Console.Write("Entrez le nouveau Prénom : ");
            string nouveauPrenom = Console.ReadLine();

            Console.Write("Entrez la nouvelle adresse du client : ");
            string nouvelleAdresseClient = Console.ReadLine();

            // modification des informations du client associe (la table Client)
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                conn.Open();

                // modifier les informations du client associe
                string requeteClient = @"
                UPDATE Client 
                SET Nom = @Nom, Prenom = @Prenom, Rue = @Rue 
                WHERE Code_Cuisinier = @Code_Cuisinier";

                using (MySqlCommand cmd = new MySqlCommand(requeteClient, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Cuisinier", codeCuisinier);
                    cmd.Parameters.AddWithValue("@Nom", nouveauNom);
                    cmd.Parameters.AddWithValue("@Prenom", nouveauPrenom);
                    cmd.Parameters.AddWithValue("@Rue", nouvelleAdresseClient);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Informations du client modifiées avec succès.");
                }
            }
        }


        // fonction pour dissocier un cuisinier des clients associes
        static void DissocierCuisinier()
        {
            Console.Write("Entrez le Code_Cuisinier à dissocier : ");
            string codeCuisinier = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                conn.Open();

                // mettre a null le Code_Cuisinier des clients associes
                string requeteDissocierClients = "UPDATE Client SET Code_Cuisinier = NULL WHERE Code_Cuisinier = @Code_Cuisinier";
                using (MySqlCommand cmd = new MySqlCommand(requeteDissocierClients, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Cuisinier", codeCuisinier);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} client(s) dissocié(s).");
                }

                // supprimer le cuisinier
                string requeteSupprimerCuisinier = "DELETE FROM Cuisinier WHERE Code_Cuisinier = @Code_Cuisinier";
                using (MySqlCommand cmd = new MySqlCommand(requeteSupprimerCuisinier, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Cuisinier", codeCuisinier);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} cuisinier(s) supprimé(s).");
                }
            }
        }

        // voir les clients servis par un cuisinier
        static void VoirClientsServis(string codeCuisinier)
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                SELECT DISTINCT 
                    c.Nom, 
                    c.Prenom, 
                    ec.Quantité AS Quantité_Commandée, 
                    ecu.Quantité AS Quantité_Cuisinée
                    FROM Client c
                    JOIN est_commandé ec ON c.Code_Client = ec.Code_Client
                    JOIN est_cuisiné ecu ON ec.Nom_P = ecu.Nom_P
                    WHERE ecu.Code_Cuisinier = @Code_Cuisinier;";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Cuisinier", codeCuisinier);

                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Clients servis :");
                        while (lecteur.Read())
                        {
                            Console.WriteLine($"{lecteur["Nom"]} {lecteur["Prenom"]}");
                        }
                    }
                }
            }
        }


        // voir les plats réalises par un cuisinier par frequence
        static void VoirPlatsRealises(string codeCuisinier)
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                SELECT p.Nom_P, SUM(ec.Quantité) AS Fréquence
                FROM Plat p
                JOIN est_cuisiné ec ON p.Nom_P = ec.Nom_P
                WHERE ec.Code_Cuisinier = @Code_Cuisinier
                GROUP BY p.Nom_P";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Cuisinier", codeCuisinier);
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Plats réalisés par fréquence :");
                        while (lecteur.Read())
                        {
                            Console.WriteLine($"{lecteur["Nom_P"]}: {lecteur["Fréquence"]} fois");
                        }
                    }
                }
            }
        }

        // plat du jour propose
        static void VoirPlatDuJour()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = "SELECT Nom_P FROM PlatDuJour";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        if (lecteur.Read())  // Si un plat du jour est trouvé
                        {
                            Console.WriteLine($"Plat du jour : {lecteur["Nom_P"]}");
                        }
                        else
                        {
                            Console.WriteLine("Aucun plat du jour proposé.");
                        }
                    }
                }
            }
        }


        static void GererCommandes()
        {
            Console.WriteLine("Gestion des Commandes :");
            Console.WriteLine("1. Créer Commande");
            Console.WriteLine("2. Mettre à jour Commande");
            Console.WriteLine("3. Afficher Commandes");
            Console.WriteLine("4. Calculer Prix Commande");
            Console.WriteLine("5. Déterminer Chemin de Livraison");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    CreerCommande();
                    break;
                case "2":
                    MettreAJourCommande();
                    break;
                case "3":
                    AfficherCommandes();
                    break;
                case "4":
                    CalculerPrixCommande();
                    break;
                case "5":
                    DeterminerCheminLivraison();
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }

        static void CreerCommande()
        {
            Console.Write("Entrez ID_Commande : ");
            string idCommande = Console.ReadLine();
            Console.Write("Entrez Code_Client : ");
            int codeClient = int.Parse(Console.ReadLine());
            Console.Write("Entrez Nom_P : ");
            string nomP = Console.ReadLine();
            Console.Write("Entrez Quantité : ");
            int quantite = int.Parse(Console.ReadLine());

            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                conn.Open();

                // verifier si la commande existe deja
                string requeteVerification = "SELECT COUNT(*) FROM est_commandé WHERE Nom_P = @Nom_P AND Code_Client = @Code_Client";
                using (MySqlCommand cmdVerification = new MySqlCommand(requeteVerification, conn))
                {
                    cmdVerification.Parameters.AddWithValue("@Nom_P", nomP);
                    cmdVerification.Parameters.AddWithValue("@Code_Client", codeClient);
                    int compte = Convert.ToInt32(cmdVerification.ExecuteScalar());

                    if (compte > 0)
                    {
                        // mettre a jour la quantite existante
                        string requeteMiseAJour = "UPDATE est_commandé SET Quantité = Quantité + @Quantité WHERE Nom_P = @Nom_P AND Code_Client = @Code_Client";
                        using (MySqlCommand cmdMiseAJour = new MySqlCommand(requeteMiseAJour, conn))
                        {
                            cmdMiseAJour.Parameters.AddWithValue("@Quantité", quantite);
                            cmdMiseAJour.Parameters.AddWithValue("@Nom_P", nomP);
                            cmdMiseAJour.Parameters.AddWithValue("@Code_Client", codeClient);
                            cmdMiseAJour.ExecuteNonQuery();
                            Console.WriteLine("Quantité de commande mise à jour avec succès.");
                        }
                    }
                    else
                    {
                        // inserer une nouvelle commande
                        string requeteInsertion = "INSERT INTO est_commandé (Nom_P, Code_Client, ID_Commande, Quantité) VALUES (@Nom_P, @Code_Client, @ID_Commande, @Quantité)";
                        using (MySqlCommand cmdInsertion = new MySqlCommand(requeteInsertion, conn))
                        {
                            cmdInsertion.Parameters.AddWithValue("@Nom_P", nomP);
                            cmdInsertion.Parameters.AddWithValue("@Code_Client", codeClient);
                            cmdInsertion.Parameters.AddWithValue("@ID_Commande", idCommande);
                            cmdInsertion.Parameters.AddWithValue("@Quantité", quantite);
                            cmdInsertion.ExecuteNonQuery();
                            Console.WriteLine("Commande créée avec succès.");
                        }
                    }
                }
            }
        }

        static void MettreAJourCommande()
        {
            Console.Write("Entrez ID_Commande à mettre à jour : ");
            string idCommande = Console.ReadLine();
            Console.Write("Entrez nouvelle Quantité : ");
            int quantite = int.Parse(Console.ReadLine());

            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = "UPDATE est_commandé SET Quantité = @Quantité WHERE ID_Commande = @ID_Commande";
                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_Commande", idCommande);
                    cmd.Parameters.AddWithValue("@Quantité", quantite);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Commande mise à jour avec succès.");
                }
            }
        }

        static void AfficherCommandes()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = "SELECT * FROM est_commandé";
                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Commandes :");
                        while (lecteur.Read())
                        {
                            Console.WriteLine($"{lecteur["ID_Commande"]}, {lecteur["Nom_P"]}, {lecteur["Code_Client"]}, {lecteur["Quantité"]}");
                        }
                    }
                }
            }
        }

        static void CalculerPrixCommande()
        {
            Console.Write("Entrez ID_Commande pour calculer le prix : ");
            string idCommande = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                    SELECT SUM(p.Prix * ec.Quantité) as PrixTotal
                    FROM est_commandé ec
                    NATURAL JOIN Plat p
                    WHERE ec.ID_Commande = @ID_Commande";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_Commande", idCommande);
                    conn.Open();
                    object resultat = cmd.ExecuteScalar();

                    if (resultat != DBNull.Value)
                    {
                        decimal prixTotal = Convert.ToDecimal(resultat);
                        Console.WriteLine($"Prix Total pour la Commande {idCommande} : {prixTotal}");
                    }
                    else
                    {
                        Console.WriteLine($"Aucune donnée trouvée pour l'ID Commande {idCommande}.");
                    }
                }
            }
        }

        static void DeterminerCheminLivraison()
        {

        Console.Write("Entrez ID_Commande pour déterminer le chemin de livraison : ");
        string idCommande = Console.ReadLine();

        string chemin = "../../MetroParis.csv"; // arc
        string chemin2 = "../../MetroParis2.csv"; // noeud

        MetroMapGenerator generator = new MetroMapGenerator(chemin2, chemin);

        List<Lien<int>> matrice = new List<Lien<int>>();

        matrice = CreaMatrice(chemin);

        Graphe<int> graphe = new Graphe<int>(matrice);

        int[,] matadj = graphe.matriceadj;

        PlusCourtChemin pcc = new PlusCourtChemin(matadj);

        using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
        {
            try
            {
                conn.Open();
                string query = @"
                    SELECT 
                        client.Id_Metro AS Client_Station,
                        cuisinier.Id_Metro AS Cuisinier_Station
                    FROM est_commandé ec
                    JOIN Client client ON ec.Code_Client = client.Code_Client
                    JOIN est_cuisiné ecui ON ec.Nom_P = ecui.Nom_P
                    JOIN Client cuisinier ON ecui.Code_Cuisinier = cuisinier.Code_Cuisinier
                    WHERE ec.ID_Commande = @idCommande;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idCommande", idCommande);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int dest = reader.GetInt32("Client_Station");
                            int src = reader.GetInt32("Cuisinier_Station");

                            dest--;
                            src--;

                            Console.WriteLine($"Station du client : {dest+1}");
                            Console.WriteLine($"Station du cuisinier : {src+1}");

                            string filename = Path.GetFullPath("../../metro_map.png");
                            var djResult = pcc.Dijkstra(src, dest);
                            generator.DrawMetroMap(filename, djResult.Item1);
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            { FileName = filename, UseShellExecute = true });


                            Console.WriteLine($"Chemin de livraison pour la Commande {idCommande}");
                            Console.Write($"Trajet: {string.Join(" -> ", djResult.Item1)}\nTemps: {djResult.Item2} minutes \n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }

        
    }

        static void AfficherStatistiques()
        {
            Console.WriteLine("Statistiques :");
            Console.WriteLine("1. Afficher Livraisons par Cuisinier");
            Console.WriteLine("2. Afficher Prix Moyen des Commandes");
            Console.WriteLine("3. Afficher Comptes Clients Moyens");
            Console.WriteLine("4. Afficher Commandes par Client et Nationalité du Plat");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AfficherLivraisonsParCuisinier();
                    break;
                case "2":
                    AfficherPrixMoyenCommandes();
                    break;
                case "3":
                    AfficherComptesClientsMoyens();
                    break;
                case "4":
                    AfficherCommandesParClientEtNationalitePlat();
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }

        static void AfficherLivraisonsParCuisinier()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                    SELECT c.Code_Cuisinier, COUNT(*) as Livraisons
                    FROM est_livré el
                    JOIN Cuisinier c ON el.Code_Cuisinier = c.Code_Cuisinier
                    GROUP BY c.Code_Cuisinier";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Livraisons par Cuisinier :");
                        while (lecteur.Read())
                        {
                            Console.WriteLine($"{lecteur["Code_Cuisinier"]}: {lecteur["Livraisons"]} livraisons");
                        }
                    }
                }
            }
        }

        static void AfficherPrixMoyenCommandes()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                    SELECT AVG(p.Prix * ec.Quantité) as PrixMoyen
                    FROM est_commandé ec
                    JOIN Plat p ON ec.Nom_P = p.Nom_P";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    decimal prixMoyen = Convert.ToDecimal(cmd.ExecuteScalar());
                    Console.WriteLine($"Prix Moyen des Commandes : {prixMoyen}");
                }
            }
        }

        static void AfficherComptesClientsMoyens()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                    SELECT AVG(TotalDepense) as CompteMoyen
                    FROM (
                        SELECT c.Code_Client, SUM(p.Prix * ec.Quantité) as TotalDepense
                        FROM Client c
                        JOIN est_commandé ec ON c.Code_Client = ec.Code_Client
                        JOIN Plat p ON ec.Nom_P = p.Nom_P
                        GROUP BY c.Code_Client
                    ) as ComptesClients";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    decimal compteMoyen = Convert.ToDecimal(cmd.ExecuteScalar());
                    Console.WriteLine($"Compte Client Moyen : {compteMoyen}");
                }
            }
        }

        static void AfficherCommandesParClientEtNationalitePlat()
        {
            Console.Write("Entrez Code_Client : ");
            int codeClient = int.Parse(Console.ReadLine());
            Console.Write("Entrez Nationalité du Plat : ");
            string nationalitePlat = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                    SELECT ec.*
                    FROM est_commandé ec
                    JOIN Plat p ON ec.Nom_P = p.Nom_P
                    WHERE ec.Code_Client = @Code_Client AND p.Nature = @NationalitePlat";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Client", codeClient);
                    cmd.Parameters.AddWithValue("@NationalitePlat", nationalitePlat);
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Commandes par Client et Nationalité du Plat :");
                        while (lecteur.Read())
                        {
                            Console.WriteLine($"{lecteur["ID_Commande"]}, {lecteur["Nom_P"]}, {lecteur["Quantité"]}");
                        }
                    }
                }
            }
        }

        static void AfficherStatistiquesAutres()
        {
            Console.WriteLine("Statistiques Autres :");
            Console.WriteLine("1. Note Moyenne des Avis pour un Cuisinier");
            Console.WriteLine("2. Plat le plus commandé");
            Console.WriteLine("3. Liste des clients radiés");
            Console.WriteLine("4. Note moyenne générale des avis");
            Console.WriteLine("5. Client avec le plus de commandes");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    VoirNoteMoyenneCuisinier();
                    break;
                case "2":
                    VoirPlatLePlusCommandé();
                    break;
                case "3":
                    VoirClientsRadies();
                    break;
                case "4":
                    VoirNoteMoyenneGenerale();
                    break;
                case "5":
                    VoirClientLePlusDeCommandes();
                    break;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }

        // note moyenne des avis pour un cuisinier
        static void VoirNoteMoyenneCuisinier()
        {
            Console.Write("Entrez le Code_Cuisinier : ");
            int codeCuisinier = int.Parse(Console.ReadLine());

            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = "SELECT AVG(Note) AS Moyenne FROM Avis WHERE Code_Cuisinier = @Code_Cuisinier";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    cmd.Parameters.AddWithValue("@Code_Cuisinier", codeCuisinier);
                    conn.Open();
                    object resultat = cmd.ExecuteScalar();

                    if (resultat != DBNull.Value)
                        Console.WriteLine($"Note moyenne : {Convert.ToDouble(resultat):0.0}");
                    else
                        Console.WriteLine("Aucun avis trouvé.");
                }
            }
        }

        // plat le plus commande
        static void VoirPlatLePlusCommandé()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                SELECT Nom_P, SUM(Quantité) AS TotalCommandé
                FROM est_commandé
                GROUP BY Nom_P
                ORDER BY TotalCommandé DESC
                LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        if (lecteur.Read())
                        {
                            Console.WriteLine($"Le plat le plus commandé est : {lecteur["Nom_P"]} avec {lecteur["TotalCommandé"]} commandes.");
                        }
                        else
                        {
                            Console.WriteLine("Aucune commande enregistrée.");
                        }
                    }
                }
            }
        }

        // liste des clients radies
        static void VoirClientsRadies()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                        SELECT Code_Cl
                        FROM Radié";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Clients radiés :");
                        while (lecteur.Read())
                        {
                            Console.WriteLine($"Code Client : {lecteur["Code_Cl"]}");
                        }
                    }
                }
            }
        }

        // note moyenne generale des avis
        static void VoirNoteMoyenneGenerale()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = "SELECT AVG(Note) AS MoyenneGenerale FROM Avis";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    object resultat = cmd.ExecuteScalar();

                    if (resultat != DBNull.Value)
                        Console.WriteLine($"Note moyenne générale de tous les avis : {Convert.ToDouble(resultat):0.0}");
                    else
                        Console.WriteLine("Aucun avis enregistré.");
                }
            }
        }

        // client avec le plus de commandes
        static void VoirClientLePlusDeCommandes()
        {
            using (MySqlConnection conn = new MySqlConnection(chaineConnexion))
            {
                string requete = @"
                SELECT c.Nom, c.Prenom, COUNT(*) AS NombreCommandes
                FROM est_commandé ec
                JOIN Client c ON ec.Code_Client = c.Code_Client
                GROUP BY c.Code_Client
                ORDER BY NombreCommandes DESC
                LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    conn.Open();
                    using (MySqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        if (lecteur.Read())
                        {
                            Console.WriteLine($"Le client avec le plus de commandes est : {lecteur["Nom"]} {lecteur["Prenom"]} avec {lecteur["NombreCommandes"]} commandes.");
                        }
                        else
                        {
                            Console.WriteLine("Aucun client trouvé.");
                        }
                    }
                }
            }
        }

    /// <summary>
    /// cree une matrice a partir d'un chemin vers un fichier
    /// </summary>
    static List<Lien<int>> CreaMatrice(string chemin)
    {
        List<Lien<int>> matrice = new List<Lien<int>>();
        chemin = Path.GetFullPath(chemin);
        List<(string nom, List<int> idstation, int changement)> liste = new List<(string, List<int>, int)>();

        using (StreamReader fichier = new StreamReader(chemin))
        {
            string line = "";
            fichier.ReadLine(); // saute l'entete
            while ((line = fichier.ReadLine()) != null)
            {
                string[] ligne = line.Split(';');

                if (ligne.Length >= 2)
                {
                    int depart = Convert.ToInt32(ligne[0]);

                    string nom = ligne[1];

                    int suivant = Convert.ToInt32(ligne[3]);

                    int temps = Convert.ToInt32(ligne[4]);

                    int changement = Convert.ToInt32(ligne[5]);

                    Lien<int> lien = new Lien<int>(depart, suivant, temps);
                    matrice.Add(lien);

                    if (ligne[6] != "sens unique")
                    {
                        Lien<int> lien2 = new Lien<int>(suivant, depart, temps);
                        matrice.Add(lien2);
                    }

                    bool verif = false;
                    foreach ((string n, List<int> id, int changement_temps) in liste) // verifie si la station est deja dans la liste et ajoute le numero si elle y est
                    {
                        if (n == nom)
                        {
                            id.Add(depart);
                            verif = true;
                        }

                    }
                    if (!verif) //ajoute dans la liste si la station n y est pas deja
                    {
                        List<int> id = new List<int>();
                        id.Add(depart);
                        liste.Add((nom, id, changement));
                    }
                }
            }

            foreach ((string n, List<int> id, int changement_temps) in liste)
            {
                foreach (int id2 in id)
                {
                    foreach (int id3 in id)
                    {
                        if (id3 != id2)
                        {
                            Lien<int> lien = new Lien<int>(id3, id2, changement_temps);

                            matrice.Add(lien);// ajoute le trajet (changement) entre chaque station ayant le meme nom
                        }
                    }
                }
            }

            /*
                foreach(Lien<int> l in matrice)
                    Console.WriteLine(l.Sommet1.Nom + " vers " + l.Sommet2.Nom);
            */
        }
        return matrice;
    }
}

