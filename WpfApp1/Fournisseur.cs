using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    internal class Fournisseur
    {

        string nomentreprise { get; set; }
        string nomproprietaire { get; set; }
        string adresse { get; set; }
        string email { get; set; }
        string nifstat { get; set; }
        string motdepasse { get; set; }
        string role { get; set; }
        bool isfournisseur { get; set; }
        int solde { get; set; }

        //public Fournisseur(string nomentreprise,string nomproprietaire,string adresse,string email,string nifstat,string motdepasse,string role,bool isfournisseur,int solde)
        //{
        //    this.nomentreprise = nomentreprise; 
        //    this.nomproprietaire = nomproprietaire;
        //    this.adresse = adresse;
        //    this.email = email;
        //    this.nifstat = nifstat;
        //    this.motdepasse = motdepasse;
        //    this.role = role;
        //    this.solde = solde;
        //    this.isfournisseur = isfournisseur;
        //}

        public Fournisseur(string nomentreprise, string nomproprietaire, string adresse, string email, string nifstat)
        {
            this.nomentreprise = nomentreprise;
            this.nomproprietaire = nomproprietaire;
            this.adresse = adresse;
            this.email = email;
            this.nifstat = nifstat;
        }

        public static ObservableCollection<Fournisseur> chargerDonnees()
        {

            string connectionString = "Host=localhost;Port=5432;Database=Energie;Username=postgres;Password=postgres";
            NpgsqlConnection connection = null;
            NpgsqlCommand command = null;
            NpgsqlDataReader reader = null;
            ObservableCollection<Fournisseur> listeFournisseur = new ObservableCollection<Fournisseur>();
            try
            {
                // Créer une nouvelle instance de NpgsqlConnection
                connection = new NpgsqlConnection(connectionString);

                // Ouvrir explicitement la connexion à la base de données
                connection.Open();

                // Préparer la requête SQL pour récupérer les données
                string query = "SELECT nomentreprise, nomproprietaire, adresse, email, nifstat FROM public.fournisseur where isfournisseur=false;";
                command = new NpgsqlCommand(query, connection);

                // Exécuter la requête et récupérer les données dans un NpgsqlDataReader
                reader = command.ExecuteReader();

                Console.WriteLine("Connexion réussi");

                // Créer une liste pour stocker les données récupérées
                //List<Fournisseur> donnees = new List<Fournisseur>();



                // Parcourir le NpgsqlDataReader pour récupérer les données
                while (reader.Read())
                {
                    // Lire les valeurs des colonnes "Nom", "Prenom" et "Adresse"
                    string nomentreprise = reader.GetString(0);
                    string nomproprietaire = reader.GetString(1);
                    string adresse = reader.GetString(2);
                    string mail = reader.GetString(3);
                    string nifstat = reader.GetString(4);

                    Fournisseur frs = new Fournisseur(nomentreprise, nomproprietaire, adresse, mail, nifstat);

                    Console.WriteLine(nomentreprise + " " + nomproprietaire + " " + adresse + " " + mail + " " + nifstat);

                    // Créer un objet VotreClasseDeDonnees avec les valeurs lues
                    //Fournisseur donnee = new Fournisseur(nomentreprise, nomproprietaire, adresse, mail, nifstat);

                    // Ajouter l'objet à la liste
                    //donnees.Add(donnee);
                    listeFournisseur.Add(frs);
                }

                // Assigner la liste comme ItemsSource du DataGrid

            }
            catch (Exception ex)
            {
                // Gérer les exceptions ou les erreurs de connexion
                MessageBox.Show("Erreur lors de la récupération des données : " + ex.Message);
            }
            return listeFournisseur;
        }
    }
}
