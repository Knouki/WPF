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

namespace WpfGestionMagasinFrontOffice.BackOfficeScreen
{
    /// <summary>
    /// Logique d'interaction pour ListUsers.xaml
    /// </summary>
    public partial class ListUsers : Window
    {

        private ObservableCollection<Utilisateur> userCollection =
            new ObservableCollection<Utilisateur>();

        private Utilisateur user;

        private IGestionMagasin gestionMagasin;

        public ListUsers()
        {
            InitializeComponent();
            this.initializeListe();

            this.rechercheBox.Items.Add("Prénom");
            this.rechercheBox.Items.Add("Nom");
        }

        public ObservableCollection<Utilisateur> UserCollection
        { get { return this.userCollection; } }

        private void initializeListe()
        {
            this.gestionMagasin = GestionMagasinBuilderFactory.getInterface();

            List<Utilisateur> users = this.gestionMagasin.getAllUsers();

            userCollection.Clear();

            foreach (Utilisateur user in users)
            {
                userCollection.Add(user);
            }
        }

        private void onClickItem(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            if (item != null && item.IsSelected)
            {
                this.user = (Utilisateur)item.Content;
            }
        }

        private void Ajouter(object sender, RoutedEventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.Show();
        }

        private void Supprimer(object sender, RoutedEventArgs e)
        {
            if (this.user != null)
            {
                this.gestionMagasin.deleteUser(this.user);
            }

        }

        private void Modifier(object sender, RoutedEventArgs e)
        {
            CreateUser createUser = new CreateUser(this.user);
            createUser.Show();
        }

        private void Rafraichir(object sender, RoutedEventArgs e)
        {
            this.initializeListe();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            BackOffice back = new BackOffice();
            back.Show();
            this.Close();
        }

        private void Rechercher(object sender, RoutedEventArgs e)
        {
            List<Utilisateur> users = null;

            if (this.rechercheBox.SelectedValue == "Prénom" && searchBox.Text != "")
            {
                users = this.gestionMagasin.findUsersByFirstName(this.searchBox.Text);
            }
            else if (this.rechercheBox.SelectedValue == "Nom" && searchBox.Text != "")
            {
                users = this.gestionMagasin.findUsersByFirstName(this.searchBox.Text);
            }

            
            if (users != null)
            {
                userCollection.Clear();

                foreach (Utilisateur user in users)
                {
                    userCollection.Add(user);
                }
            }
        }
    }
}
