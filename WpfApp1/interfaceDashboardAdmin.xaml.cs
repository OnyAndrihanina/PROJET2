using System;
using System.Collections.Generic;
using System.Data;
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
         Fournisseur personne = new Fournisseur();
        public interfaceDashboardAdmin()
        {
            InitializeComponent();
            
        }
        // afficher les fournisseur
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fournisseur.chargerDonneesFournisseurValide();
            dataGridNotification.ItemsSource = Fournisseur.chargerDonneesFournisseurValide();
        }
        // afficher les non fournisseur
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Fournisseur.chargerDonneesFournisseurNonValide();
            dataGridNotification.ItemsSource = Fournisseur.chargerDonneesFournisseurNonValide();
        }
        // récuperer sur un table
        private void dataGridNotification_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fournisseur fournisseurSelectionner = dataGridNotification.SelectedItems as Fournisseur;

            if (dataGridNotification.SelectedItem != null)
            {
                Fournisseur fournisseurSelectionne = dataGridNotification.SelectedItem as Fournisseur;
                personne = fournisseurSelectionne;
                if (fournisseurSelectionne != null)
                {
                    bool isFournisseur = fournisseurSelectionne.isfournisseur;
                    textboxIsF.Text = isFournisseur.ToString();
                    int id_fournisseur = fournisseurSelectionne.id_fournisseur;
                    bool isfournisseur = fournisseurSelectionne.isfournisseur;
                    string nomEntreprise = fournisseurSelectionne.nomentreprise;
                    string nomProprietaire = fournisseurSelectionne.nomproprietaire;
                    string adresse = fournisseurSelectionne.adresse;
                    string email = fournisseurSelectionne.email;
                    string nifstat = fournisseurSelectionne.nifstat;
                    Fournisseur testtest = new Fournisseur(id_fournisseur, isfournisseur, nomEntreprise, nomProprietaire, adresse,email, nifstat);

                }
            }
            
        }
        //Afficher produits
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
