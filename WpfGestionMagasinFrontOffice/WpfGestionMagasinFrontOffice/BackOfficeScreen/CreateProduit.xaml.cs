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
using WpfGestionMagasinFrontOffice.Entité;
using DaoGestionMagasins;

namespace WpfGestionMagasinFrontOffice.BackOfficeScreen
{
    /// <summary>
    /// Logique d'interaction pour CreateProduit.xaml
    /// </summary>
    public partial class CreateProduit : Window
    {
        private IGestionMagasin gestionMagasin =
            GestionMagasinBuilderFactory.getInterface();

        private Produit produit;

        public CreateProduit()
        {
            InitializeComponent();
        }

        public CreateProduit(Produit produit)
        {
            this.produit = produit;

            InitializeComponent();

            if (produit != null)
            {
                this.nomBox.Text = produit.Nom;
                this.referenceBox.Text = produit.Reference;
                this.prixBox.Text = produit.Prix.ToString();
                this.stockBox.Text = produit.Stock.ToString();
                this.descriptionBox.Text = produit.Description;
            }
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            String nom = this.nomBox.Text;
            String reference = this.referenceBox.Text;
            float prix = float.Parse(this.prixBox.Text);
            int stock = int.Parse(this.stockBox.Text);
            String description = this.descriptionBox.Text;

            if (nom != "" && reference != "" && prix > 0 && stock > -1 && description != "")
            {
                if (this.produit != null)
                {
                    this.gestionMagasin.updateProduit(produit);
                }
                else
                {
                    Produit produit = new Produit(0, reference, prix, nom, description, stock);
                    this.gestionMagasin.addProduit(produit);
                }
            }

            this.Close();
        }
    }
}
