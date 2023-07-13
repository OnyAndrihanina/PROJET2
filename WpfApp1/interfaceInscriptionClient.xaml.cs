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
    /// Logique d'interaction pour interfaceInscriptionClient.xaml
    /// </summary>
    public partial class interfaceInscriptionClient : Window
    {
        string connectionString = "Host=localhost;Port=5432;Database=projet2;User Id=postgres;Password=ronyandrihanina;";

        public interfaceInscriptionClient()
        {
            InitializeComponent();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void bt_ajout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            interfaceChoixInscription choix = new interfaceChoixInscription();
            choix.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nom = textbox_nom.Text;
            string prenom = textbox_prenom.Text;
            string adresse = textbox_adresse.Text;
            string date = textbox_date.Text;
            string telephone = textbox_tel.Text;
            string email = textbox_mail.Text;
            string cin = textbox_cin.Text;
            string role = "client";
            string mdp = box_pass.Password;


            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO client (nom, prenom, adresse, datedenaissance, telephone, email, numeroicin, motdepasse, role) VALUES('" + nom + "','" + prenom + "','" + adresse + "','" + date + "','" + telephone + "','" + email + "','" + cin + "','" + mdp + "','" + role + "')";

                using (var cmd = new NpgsqlCommand(query, conn))
                {


                    cmd.ExecuteNonQuery();

                }
                conn.Close();

            }
            textbox_nom.Text = "";
            textbox_prenom.Text = "";
            textbox_adresse.Text = "";
            textbox_date.Text = "";
            textbox_tel.Text = "";
            textbox_mail.Text = "";
            textbox_cin.Text = "";
            box_pass.Password = "";
            password_confirm.Password = "";
        }
    }
}
