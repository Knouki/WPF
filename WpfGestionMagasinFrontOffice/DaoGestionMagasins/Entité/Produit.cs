using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace WpfGestionMagasinFrontOffice.Entité
{
    [Table(Name = "Produit")]
    public class Produit
    {
        private int idProduit;
        private string reference;
        private float prix;
        private string nom;
        private string description;
        private int stock;

        public Produit() { }

        public Produit(int idProduit, string reference, float prix, string nom, string description, int stock)
        {
            this.idProduit = idProduit;
            this.reference = reference;
            this.prix = prix;
            this.nom = nom;
            this.description = description;
            this.stock = stock;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "IdProduit", Storage = "idProduit")]
        public int IdProduit
        {
            set { this.idProduit = value; }
            get { return this.idProduit; }
        }

        [Column(Name = "Reference", Storage = "reference")]
        public string Reference
        {
            set { this.reference = value; }
            get { return this.reference; }
        }

        [Column(Name = "Prix", Storage = "prix")]
        public float Prix
        {
            set { this.prix = value; }
            get { return this.prix; }
        }

        [Column(Name = "Nom", Storage = "nom")]
        public string Nom
        {
            set { this.nom = value; }
            get { return this.nom; }
        }

        [Column(Name = "Description", Storage = "description")]
        public string Description
        {
            set { this.description = value; }
            get { return this.description; }
        }

        [Column(Name = "Stock", Storage = "stock")]
        public int Stock
        {
            set { this.stock = value; }
            get { return this.stock; }
        }

    }
}
