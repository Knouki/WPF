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
    /// Logique d'interaction pour ListeProduit.xaml
    /// </summary>
    public partial class ListeProduit : Window
    {
        private ObservableCollection<Produit> produitCollection =
            new ObservableCollection<Produit>();

        private Produit produit;

        private IGestionMagasin gestionMagasin;

        public ListeProduit()
        {
            InitializeComponent();
            this.initializeListe();

            this.rechercheBox.Items.Add("Id");
            this.rechercheBox.Items.Add("Nom");
            this.rechercheBox.Items.Add("Reference");
        }

        public ObservableCollection<Produit> ProduitCollection
        {
            get { return this.produitCollection; }
        }

        private void initializeListe()
        {
            this.gestionMagasin = GestionMagasinBuilderFactory.getInterface();

            List<Produit> produits = this.gestionMagasin.getAllProduit();

            produitCollection.Clear();

            foreach (Produit produit in produits)
            {
                produitCollection.Add(produit);
            }
        }

        private void onClickItem(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            if (item != null && item.IsSelected)
            {
                this.produit = (Produit)item.Content;
            }
        }

        private void Ajouter(object sender, RoutedEventArgs e)
        {
            CreateProduit createProduit = new CreateProduit();
            createProduit.Show();
        }

        private void Supprimer(object sender, RoutedEventArgs e)
        {
            if (this.produit != null)
            {
                this.gestionMagasin.deleteProduit(this.produit);
            }

            this.initializeListe();
        }

        private void Modifier(object sender, RoutedEventArgs e)
        {
            CreateProduit createProduit = new CreateProduit(this.produit);
            createProduit.Show();
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
            List<Produit> produits = null;

            if (this.rechercheBox.SelectedValue == "Nom" && searchBox.Text != "")
            {
                produits = this.gestionMagasin.findProduitByName(this.searchBox.Text);
            }
            else if (this.rechercheBox.SelectedValue == "Reference" && searchBox.Text != "")
            {
                produits = this.gestionMagasin.findProduitByReference(this.searchBox.Text);
            }
            else if (this.rechercheBox.SelectedValue == "Id" && searchBox.Text != "")
            {
                produits = this.gestionMagasin.findProduitById(int.Parse(this.searchBox.Text));
            }


            if (produits != null)
            {
                produitCollection.Clear();

                foreach (Produit produit in produits)
                {
                    produitCollection.Add(produit);
                }
            }
        }
    }
}
