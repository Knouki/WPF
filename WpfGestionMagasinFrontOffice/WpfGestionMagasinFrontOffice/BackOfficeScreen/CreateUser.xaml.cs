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
using DaoGestionMagasins;
using WpfGestionMagasinFrontOffice.Entité;

namespace WpfGestionMagasinFrontOffice.BackOfficeScreen
{
    /// <summary>
    /// Logique d'interaction pour CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        private IGestionMagasin gestionMagasin =
            GestionMagasinBuilderFactory.getInterface();

        private Utilisateur utilisateur;

        public CreateUser()
        {
            List<Role> roles = this.gestionMagasin.getAllRole();

            InitializeComponent();

            foreach (Role role in roles)
            {
                roleCombobox.Items.Add(new ComboBoxItem().Content = role.CodeRole);
            }

        }

        public CreateUser(Utilisateur user)
        {
            this.utilisateur = user;

            List<Role> roles = this.gestionMagasin.getAllRole();

            InitializeComponent();

            foreach (Role role in roles)
            {
                roleCombobox.Items.Add(new ComboBoxItem().Content = role.CodeRole);
            }

            if (user != null)
            {
                this.identifiantBox.Text = user.Identifiant;
                this.passwordBox.Text = user.MotPasse;
                this.prenomBox.Text = user.Prenom;
                this.nomBox.Text = user.Nom;
            }
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            String identifiant = this.identifiantBox.Text;
            String password = this.passwordBox.Text;
            String prenom = this.prenomBox.Text;
            String nom = this.nomBox.Text;

            if (identifiant != "" && password != "" && prenom != "" && nom != "" && roleCombobox.SelectedValue != null) {
                List<Role> role = this.gestionMagasin.getRoleByCodeRole((String) this.roleCombobox.SelectedValue);

                Role rol = role.First();

                if (this.utilisateur != null)
                {
                    this.gestionMagasin.updateUser(this.utilisateur);
                }
                else
                {
                    Utilisateur user = new Utilisateur(0, rol.IdRole, identifiant, password, DateTime.Now, DateTime.Now, true, prenom, nom);
                    this.gestionMagasin.addUser(user);
                }
                
            }

            this.Close();
        }
    }
}
