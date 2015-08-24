using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace WpfGestionMagasinFrontOffice.Entité
{
    [Table(Name = "Adresse")]
    public class Adresse
    {
        private int idAdresse;
        private string numeroRue;
        private string nomRue;
        private string codePostal;
        private int idVille;
        private int idUtilisateur;
        private string image;

        /**
         * Constructeur.
         */
        public Adresse()
        {
        }

        /**
         * Constructeur avec paramètre.
         */
        public Adresse(int idAdresse, string numeroRue, string nomRue,
            string codePostal, int idVille, int idUtilisateur, string image)
        {
            this.idAdresse = idAdresse;
            this.numeroRue = numeroRue;
            this.nomRue = nomRue;
            this.codePostal = codePostal;
            this.idVille = idVille;
            this.idUtilisateur = idUtilisateur;
            this.image = image;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "IdAdresse", Storage = "idAdresse")]
        public int IdAdresse
        {
            set { this.idAdresse = value; }
            get { return this.idAdresse; }
        }

        [Column(Name = "NumeroRue", Storage = "numeroRue")]
        public string NumeroRue
        {
            set { this.numeroRue = value; }
            get { return this.numeroRue; }
        }

        [Column(Name = "NomRue", Storage = "nomRue")]
        public string setNomRue
        {
            set { this.nomRue = value; }
            get { return this.nomRue; }
        }

        [Column(Name = "CodePostal", Storage = "codePostal")]
        public string setCodePostal
        {
            set { this.codePostal = value; }
            get { return this.codePostal; }
        }

        [Column(Name = "IdVille", Storage = "idVille")]
        public int setIdVille
        {
            set { this.idVille = value; }
            get { return this.idVille; }
        }

        [Column(Name = "IdUtilisateur", Storage = "idUtilisateur")]
        public int setIdUtilisateur
        {
            set { this.idUtilisateur = value; }
            get { return this.idUtilisateur; }
        }
        
    }
}
