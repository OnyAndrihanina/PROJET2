using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour interfaceInscriptionFournissseur.xaml
    /// </summary>
    public partial class interfaceInscriptionFournissseur : Window
    {
        string connectionString = "Host=localhost;Port=5432;Database=projet2;User Id=postgres;Password=mdppostgres;";


        public interfaceInscriptionFournissseur()
        {
            InitializeComponent();
        }

        private void bt_ajout_Click(object sender, RoutedEventArgs e)
        {
            string compagnie = tb_comp.Text;
            string nom = tb_propri.Text;
            string adresse = tb_adresse.Text;
            string email = tb_mail.Text;
            string nifstat = tb_stat.Text;
            string modp = tb_mdp.Text;
            string role = "fournisseur";
            string telephone = tb_tel.Text;
            //bool isvalide = false;
            // Vérifier si tous les champs sont remplis
            if (string.IsNullOrEmpty(compagnie) || string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(adresse) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nifstat) || string.IsNullOrEmpty(modp) || string.IsNullOrEmpty(telephone))
            {
                label_message.Content = "Veuillez remplir tous les champs";
                label_message.Foreground = Brushes.Red; // Définir la couleur du texte sur rouge
                return;
            }

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO fournisseur (nomentreprise, nomproprietaire, adresse, email,nifstat,motdepasse,role) VALUES('" + compagnie + "','" + nom + "','" + adresse + "','" + email + "','" + nifstat + "','" + modp + "','" + role + "')";

                using (var cmd = new NpgsqlCommand(query, conn))
                {


                    cmd.ExecuteNonQuery();
                    raz();
                    label_message.Content = "Succès";

                }
                conn.Close();
            }
        }

        private void bt_annuler_Click(object sender, RoutedEventArgs e)
        {
            raz();
        }

        private void bt_retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            interfaceChoixInscription choix = new interfaceChoixInscription();
            choix.Show();

        }

        private void bt_logo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void raz()
        {
            tb_comp.Text = "";
            tb_propri.Text = "";
            tb_adresse.Text = "";
            tb_mail.Text = "";
            tb_stat.Text = "";
            tb_mdp.Text = "";
            tb_tel.Text = "";
        }
    }
}
