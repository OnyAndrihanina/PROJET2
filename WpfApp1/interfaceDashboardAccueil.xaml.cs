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
    /// Logique d'interaction pour interfaceDashboardAccueil.xaml
    /// </summary>
    public partial class interfaceDashboardAccueil : Window
    {
        public interfaceDashboardAccueil()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_achat.Visibility = Visibility.Visible;
        }

        private void DataGrid_achat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
