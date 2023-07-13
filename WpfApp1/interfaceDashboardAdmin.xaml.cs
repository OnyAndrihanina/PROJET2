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
    /// Interaction logic for interfaceDashboardAdmin.xaml
    /// </summary>
    public partial class interfaceDashboardAdmin : Window
    {
        public interfaceDashboardAdmin()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fournisseur.chargerDonneesFournisseurValide();
            dataGridNotification.ItemsSource = Fournisseur.chargerDonneesFournisseurValide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Fournisseur.chargerDonneesFournisseurNonValide();
            dataGridNotification.ItemsSource = Fournisseur.chargerDonneesFournisseurNonValide();
        }

        private void dataGridNotification_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
