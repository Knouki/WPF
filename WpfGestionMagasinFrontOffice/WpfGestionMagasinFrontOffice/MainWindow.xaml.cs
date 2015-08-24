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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DaoGestionMagasins;

namespace WpfGestionMagasinFrontOffice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            String identifiant = this.loginBox.Text;
            String password = this.passwordBox.Password;

            IGestionMagasin gestionMagasin = GestionMagasinBuilderFactory.getInterface();
            gestionMagasin.connection();

            int idUser = gestionMagasin.login(identifiant, password);

            if (idUser > 0)
            {

                Properties.Settings.Default.Utilisateur = idUser;

                int idRole = gestionMagasin.getUserRole(idUser);

                if (idRole > 0)
                {
                    Properties.Settings.Default.UtilisateurRole = idRole;
                }

                ChoixOffice fenetre = new ChoixOffice();
                fenetre.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Identifiant ou mot de passe incorrect.");
            }
        }


    }
}
