using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace WpfGestionMagasinFrontOffice.Entité
{
    [Table(Name = "Utilisateur")]
    public class Utilisateur
    {
        private int id;
        private int idRole;
        private string identifiant;
        private string motPasse;
        private DateTime dateDebut;
        private DateTime dateFin;
        private bool status;
        private string prenom;
        private string nom;

        public Utilisateur()
        {
        }

        public Utilisateur(int id, int idRole, string identifiant, string motPasse,
            DateTime dateDebut, DateTime dateFin, bool status, string prenom, string nom)
        {
            this.id = id;
            this.idRole = idRole;
            this.identifiant = identifiant;
            this.motPasse = motPasse;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.status = status;
            this.prenom = prenom;
            this.nom = nom;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "IdUtilisateur", Storage = "id")]
        public int Id
        {
            set { id = value; }
            get { return this.id; }
        }

        [Column(Name = "IdRole", Storage = "idRole")]
        public int IdRole
        {
            set {idRole = value; }
            get { return this.idRole; }
        }

        [Column(Name = "Identifiant", Storage = "identifiant")]
        public string Identifiant
        {
            set { identifiant = value; }
            get { return this.identifiant; }
        }

        [Column(Name = "MotPasse", Storage = "motPasse")]
        public string MotPasse
        {
            set { motPasse = value; }
            get { return this.motPasse; }
        }

        [Column(Name = "DateDebut", Storage = "dateDebut")]
        public DateTime DateDebut
        {
            get { return this.dateDebut; }
            set { this.dateDebut = value; }
        }

        [Column(Name = "DateFin", Storage = "dateFin")]
        public DateTime DateFin
        {
            set {this.dateFin = value;}
            get { return this.dateFin; }
        }

        [Column(Name = "Status", Storage = "status")]
        public bool Status
        {
            set {this.status = value;}
            get { return this.status; }
        }

        [Column(Name = "Prenom", Storage = "prenom")]
        public string Prenom
        {
            set {this.prenom = value;}
            get {return this.prenom;}
        }

        [Column(Name = "Nom", Storage = "nom")]
        public string Nom
        {
            set { this.nom = value; }
            get { return this.nom; }
        }
    }
}
