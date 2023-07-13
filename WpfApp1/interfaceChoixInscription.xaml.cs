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
    /// Logique d'interaction pour interfaceChoixInscription.xaml
    /// </summary>
    public partial class interfaceChoixInscription : Window
    {
        interfaceInscriptionClient client = new interfaceInscriptionClient();
        interfaceInscriptionFournissseur fournisseur = new interfaceInscriptionFournissseur();
        
        public interfaceChoixInscription()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rbtFournisseur.IsChecked == true)
            {
                fournisseur.Show();
                this.Close();
            }
            else
            if (rbtClient.IsChecked == true)
            {

                client.Show();
                this.Close();
            }
        }

        private void btRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
