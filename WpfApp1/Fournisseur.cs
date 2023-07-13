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
        

        public string nomentreprise { get; set; }
        public string nomproprietaire { get; set; }
        public string adresse { get; set; }
        public string email { get; set; }
        public string nifstat { get; set; }
        public string motdepasse { get; set; }
        public string role { get; set; }
        public bool isfournisseur { get; set; }
        public int solde { get; set; }

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

        public static ObservableCollection<Fournisseur> chargerDonneesFournisseurValide()
        {

            string connectionString = "Host=localhost;Port=5432;Database=projet2;Username=postgres;Password=ronyandrihanina";
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
                string query = "SELECT nomentreprise, nompropriétaire, adresse, email, nifstat FROM public.fournisseur where isfournisseur=true;";
                command = new NpgsqlCommand(query, connection);

                reader = command.ExecuteReader();

                Console.WriteLine("Connexion réussi");

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


                    listeFournisseur.Add(frs);
                }

            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Erreur lors de la récupération des données : " + ex.Message);
            }
            return listeFournisseur;
        }

        public static ObservableCollection<Fournisseur> chargerDonneesFournisseurNonValide()
        {

            string connectionString = "Host=localhost;Port=5432;Database=projet2;Username=postgres;Password=ronyandrihanina";
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
                string query = "SELECT nomentreprise, nompropriétaire, adresse, email, nifstat FROM fournisseur where isfournisseur=false;";
                command = new NpgsqlCommand(query, connection);

                reader = command.ExecuteReader();

                Console.WriteLine("Connexion réussi");

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


                    listeFournisseur.Add(frs);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erreur lors de la récupération des données : " + ex.Message);
            }
            return listeFournisseur;
        }
    }
}
