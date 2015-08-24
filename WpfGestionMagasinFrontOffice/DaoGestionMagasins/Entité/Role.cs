using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace WpfGestionMagasinFrontOffice.Entité
{
    [Table(Name = "Role")]
    public class Role
    {
        private int idRole;
        private string codeRole;
        private string descriptionRole;

        public Role()
        {
        }

        public Role(int idRole, string codeRole, string descriptionRole)
        {
            this.idRole = idRole;
            this.codeRole = codeRole;
            this.descriptionRole = descriptionRole;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "IdRole", Storage = "idRole")]
        public int IdRole
        {
            set { this.idRole = value; }
            get { return this.idRole; }
        }

        [Column(Name = "CodeRole", Storage = "codeRole")]
        public string CodeRole
        {
            set { this.codeRole = value; }
            get { return this.codeRole; }
        }

        [Column(Name = "DescriptionRole", Storage = "descriptionRole")]
        public string DescriptionRole
        {
            set { this.descriptionRole = value; }
            get { return this.descriptionRole; }
        }
    }
}
