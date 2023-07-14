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
using Npgsql;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour interfaceValidationInscriptionFournisseur.xaml
    /// </summary>
    public partial class interfaceValidationInscriptionFournisseur : Window
    {
        private Fournisseur testtest;
        interfaceDashboardAdmin admin = new interfaceDashboardAdmin();
        
        

        public interfaceValidationInscriptionFournisseur()
        {
            InitializeComponent();
            afficherFournisseurSelectione();
            
        }

        public void afficherFournisseurSelectione()
        {
            textBoxNomCompagnie.Text = personne.nomentreprise;
            textBoxNomProprio.Text = personne.nomentreprise;
            textBoxAdresse.Text = personne.adresse;
            textBoxEmail.Text = personne.email;
            textBoxNifStat.Text = personne.nifstat;
        }

        private void btValider_Click(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection con = connexionBD();

            MessageBoxResult result = MessageBox.Show("Voulez-vous confirmer ce confirmation?", "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                try
                {

                    string insertQuery = "UPDATE public.fournisseur SET isfournisseur=true WHERE id_fournisseur=" + personne.id_fournisseur + ";";
                    NpgsqlCommand command = new NpgsqlCommand(insertQuery, con);
                    command.ExecuteNonQuery();
                    interfaceDashboardAdmin admin = new interfaceDashboardAdmin();
                    admin.Show();
                    this.Close();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("Erreur de connexion avec la base de données : " + ee.Message);
                }
            }


            else if (result == MessageBoxResult.Cancel)
            {

            }
        }

        private void btRejeter_Click(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection con = connexionBD();

            MessageBoxResult result = MessageBox.Show("Voulez-vous confirmer ce rejection?", "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                try
                {


                    string insertQuery = "DELETE FROM public.fournisseur WHERE id_fournisseur=" + personne.id_fournisseur + ";";
                    NpgsqlCommand command = new NpgsqlCommand(insertQuery, con);
                    command.ExecuteNonQuery();
                    interfaceDashboardAdmin admin = new interfaceDashboardAdmin();
                    admin.Show();
                    this.Close();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("Erreur de connexion avec la base de données : " + ee.Message);
                }
            }


            else if (result == MessageBoxResult.Cancel)
            {

            }

        }

        public static NpgsqlConnection connexionBD()
        {
            string connectionString = "Host=localhost;Port=5432;Database=Energie;Username=postgres;Password=postgres";
            NpgsqlConnection connexion = new NpgsqlConnection(connectionString);
            connexion.Open();
            return connexion;
        }
    }
}
