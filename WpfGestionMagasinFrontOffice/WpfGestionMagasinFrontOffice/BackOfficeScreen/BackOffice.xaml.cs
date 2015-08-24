using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using WpfGestionMagasinFrontOffice.Entité;
using DaoGestionMagasins;
using WpfGestionMagasinFrontOffice.BackOfficeScreen;

namespace WpfGestionMagasinFrontOffice
{
    /// <summary>
    /// Logique d'interaction pour BackOffice.xaml
    /// </summary>
    public partial class BackOffice : Window
    {

        public BackOffice()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {

            if (sender.Equals(commandeButton)) {
                CommandeListScreen commande = new CommandeListScreen();
                commande.Show();
            }
            else if (sender.Equals(produitButton))
            {
                ListeProduit produit = new ListeProduit();
                produit.Show();
            }
            else if (sender.Equals(utilisateurButton))
            {
                ListUsers listUsers = new ListUsers();
                listUsers.Show();
            }


            this.Close();

        }


    }
}
