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

namespace WpfGestionMagasinFrontOffice
{
    /// <summary>
    /// Logique d'interaction pour FrontOffice.xaml
    /// </summary>
    public partial class FrontOffice : Window
    {
        private ObservableCollection<Produit> produitCollection =
            new ObservableCollection<Produit>();

        private ObservableCollection<Produit> commandeCollection =
            new ObservableCollection<Produit>();

        private IGestionMagasin gestionMagasin;

        public FrontOffice()
        {
            InitializeComponent();

            this.initializeListe();
        }

        private void initializeListe() {

            this.gestionMagasin = GestionMagasinBuilderFactory.getInterface();

            List<Produit> produits = this.gestionMagasin.getAllProduit();
            this.produitCollection.Clear();

            foreach (Produit produit in produits)
            {
                produitCollection.Add(produit);
            }
        }

        public ObservableCollection<Produit> ProduitCollection
        { get { return this.produitCollection; } }

        public ObservableCollection<Produit> CommandeCollection
        { get { return this.commandeCollection; } }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            if (item != null && item.IsSelected)
            {
                this.commandeCollection.Add((Produit) item.Content);
            }
        }

        private void NewCommande(object sender, RoutedEventArgs e)
        {
            foreach (Produit produit in this.commandeCollection) {
                int stock = produit.Stock;

                if (stock > 0)
                {
                    produit.Stock = stock - 1;

                    Commande commande = new Commande(0, produit.Prix, produit.IdProduit,
                        DateTime.Now, Properties.Settings.Default.Utilisateur);

                    this.gestionMagasin.addStock(produit);
                    this.gestionMagasin.addCommande(commande);
                }
                else
                {
                    MessageBox.Show("Le produit " + produit.Nom + "n'est plus en stock");
                }
            }

            this.commandeCollection.Clear();

            this.initializeListe();

        }
    }
}
