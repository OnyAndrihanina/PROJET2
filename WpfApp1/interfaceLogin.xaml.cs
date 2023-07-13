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
    /// Logique d'interaction pour interfaceLogin.xaml
    /// </summary>
    public partial class interfaceLogin : Window
    {
        public interfaceLogin()
        {
            InitializeComponent();
        }
        private void textEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Entrez votre texte")
            {
                textBox.Text = String.Empty;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            loginconnect();
        }
        public void loginconnect()
        {
            if (!string.IsNullOrEmpty(textMotdepasse.Text) || !string.IsNullOrEmpty(textEmail.Text))
            {
                bool isLoggedIn = false;
                bool isValid = true;
                using (NpgsqlConnection connection = new NpgsqlConnection("Host=localhost;Database=Energie;Username=postgres;Password=postgres"))
                {
                    connection.Open();
                    // connexion Admin

                    using (var cmd = new NpgsqlCommand("select * from admin where email='" + textEmail.Text + "' and motdepasse='" + textMotdepasse.Text + "'", connection))
                    {
                        cmd.Parameters.AddWithValue("email", textMotdepasse.Text);
                        cmd.Parameters.AddWithValue("motdepasse", textEmail.Text);

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                isLoggedIn = true;
                                this.Hide();
                                interfaceDashboardAdmin homeAdmin = new interfaceDashboardAdmin();
                                homeAdmin.ShowDialog();
                                return;
                            }

                        }
                    }
                    // connexion client

                    using (var cmd = new NpgsqlCommand("select * from client where email='" + textEmail.Text + "' and motdepasse='" + textMotdepasse.Text + "'", connection))
                    {
                        cmd.Parameters.AddWithValue("email", textMotdepasse.Text);
                        cmd.Parameters.AddWithValue("motdepasse", textEmail.Text);

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                isLoggedIn = true;
                                this.Hide();
                                interfaceDashboardAccueil home = new interfaceDashboardAccueil();
                                home.ShowDialog();
                            }


                        }
                    }
                    // connexion fournisseur
                    using (var cmd = new NpgsqlCommand("select * from fournisseur where email='" + textEmail.Text + "' and motdepasse='" + textMotdepasse.Text + "' ", connection))
                    {
                        cmd.Parameters.AddWithValue("email", textMotdepasse.Text);
                        cmd.Parameters.AddWithValue("motdepasse", textEmail.Text);

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                isLoggedIn = true;
                                this.Hide();
                                interfaceDashboardFournisseur home = new interfaceDashboardFournisseur();
                                home.ShowDialog();
                            }


                        }
                    }

                    if (!isLoggedIn)
                    {
                        MessageBox.Show("l'email et le mot de passe ne correspondent à aucun compte", "Erreur");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une valeur dans tous les champs.", "Erreur");
            }
        }
    }
}
