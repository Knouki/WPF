using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace WpfGestionMagasinFrontOffice.Entité
{
    [Table(Name = "Commande")]
    public class Commande
    {
        private int idCommande;
        private float totalCommande;
        private int idProduit;
        private DateTime dateCommande;
        private int idUtilisateur;

        public Commande() { }

        public Commande(int idCommande, float totalCommande, int idProduit, DateTime dateCommande, int idUtilisateur)
        {
            this.idCommande = idCommande;
            this.totalCommande = totalCommande;
            this.idProduit = idProduit;
            this.dateCommande = dateCommande;
            this.idUtilisateur = idUtilisateur;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "IdCommande", Storage = "idCommande")]
        public int IdCommande
        {
            set { this.idCommande = value; }
            get { return this.idCommande; }
        }

        [Column(Name = "TotalCommande", Storage = "totalCommande")]
        public float TotalCommande
        {
            set { this.totalCommande = value; }
            get { return this.totalCommande; }
        }
        [Column(Name = "IdProduit", Storage = "idProduit")]
        public int IdProduit
        {
            set { this.idProduit = value; }
            get { return this.idProduit; }
        }

        [Column(Name = "DateCommande", Storage = "dateCommande")]
        public DateTime DateCommande
        {
            set { this.dateCommande = value; }
            get { return this.dateCommande; }
        }

        [Column(Name = "IdUtilisateur", Storage = "idUtilisateur")]
        public int IdUtilisateur
        {
            set { this.idUtilisateur = value; }
            get { return this.idUtilisateur; }
        }
    }
}
