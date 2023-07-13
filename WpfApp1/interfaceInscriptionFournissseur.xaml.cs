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
        string connectionString = "Host=localhost;Port=5432;Database=projet2;User Id=postgres;Password=ronyandrihanina;";


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
            
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO fournisseur (nomentreprise, nompropriétaire, adresse, email,nifstat,motdepasse,role) VALUES('" + compagnie + "','" + nom + "','" + adresse + "','" + email + "','" + nifstat + "','" + modp + "','" + role + "')";

                using (var cmd = new NpgsqlCommand(query, conn))
                {


                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }
        }

        private void bt_annuler_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
