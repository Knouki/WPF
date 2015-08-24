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
    /// Logique d'interaction pour CommandeListScreen.xaml
    /// </summary>
    public partial class CommandeListScreen : Window
    {
        private ObservableCollection<Commande> commandeCollection =
            new ObservableCollection<Commande>();

        private Commande commande;

        private IGestionMagasin gestionMagasin;

        public CommandeListScreen()
        {
            InitializeComponent();
            this.initializeListe();
        }

        public ObservableCollection<Commande> CommandeCollection
        { get { return this.commandeCollection; } }

        private void initializeListe()
        {
            this.gestionMagasin = GestionMagasinBuilderFactory.getInterface();

            List<Commande> commandes = this.gestionMagasin.getAllCommande();

            commandeCollection.Clear();

            foreach (Commande commande in commandes)
            {
                commandeCollection.Add(commande);
            }
        }

        private void onClickItem(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            if (item != null && item.IsSelected)
            {
                this.commande = (Commande)item.Content;
            }
        }

        private void Rafraichir(object sender, RoutedEventArgs e)
        {
            this.initializeListe();
        }

        private void Supprimer(object sender, RoutedEventArgs e)
        {
            if (this.commande != null)
            {
                this.gestionMagasin.deleteCommande(this.commande);
            }

            this.initializeListe();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            BackOffice back = new BackOffice();
            back.Show();
            this.Close();
        }
    }
}
