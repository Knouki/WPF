using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace WpfGestionMagasinFrontOffice.Entité
{
    [Table(Name = "Ville")]
    public class Ville
    {
        private int idVille;
        private string codeVille;
        private string descriptionVille;

        public Ville()
        {
        }

        public Ville(int idVille, string codeVille, string descriptionVille)
        {
            this.idVille = idVille;
            this.codeVille = codeVille;
            this.descriptionVille = descriptionVille;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "IdVille", Storage = "idVille")]
        public int IdVille
        {
            set { this.idVille = value; }
            get { return this.idVille; }
        }

        [Column(Name = "CodeVille", Storage = "codeVille")]
        public string CodeVille
        {
            set { this.codeVille = value; }
            get { return this.codeVille; }
        }

        [Column(Name = "DescriptionVille", Storage = "descriptionVille")]
        public string DescriptionVille
        {
            set { this.descriptionVille = value; }
            get { return this.descriptionVille; }
        }
    }
}
