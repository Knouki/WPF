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

namespace WpfGestionMagasinFrontOffice
{
    /// <summary>
    /// Logique d'interaction pour ChoixOffice.xaml
    /// </summary>
    public partial class ChoixOffice : Window
    {
        public ChoixOffice()
        {
            InitializeComponent();
        }

        private void backOfficeClick(object sender, RoutedEventArgs e)
        {

            if (Properties.Settings.Default.UtilisateurRole != 2)
            {
                BackOffice fenetre = new BackOffice();
                fenetre.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vous n'avez pas accès à cette partie");
            }
        }

        private void frontOfficeClick(object sender, RoutedEventArgs e)
        {
            FrontOffice fenetre = new FrontOffice();
            fenetre.Show();
            this.Close();
        }
    }
}
