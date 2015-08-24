using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Linq;
using System.Configuration;
using System.Data;
using WpfGestionMagasinFrontOffice.Entité;

namespace WpfGestionMagasinFrontOffice
{
    public class GestionMagasin : IGestionMagasin
    {

        private static string CONNECTION_STRING = "Data Source=.\\SQLEXPRESS;Database=BaseGestionMagasins;User Id=PC\\SANDRA;Integrated Security=true; ";
        private DataContext dataContext;

        public GestionMagasin() {
            this.connection();
        }

        public void connection()
        {
            dataContext = new DataContext(CONNECTION_STRING);
        }
        
        public int login(string identifiant, string motPasse)
        {
            int result = -1;

            Table<Utilisateur> users = dataContext.GetTable<Utilisateur>();

            var query = from user in users
                        where user.Identifiant == identifiant
                        && user.MotPasse == motPasse
                        select user;

            foreach (Utilisateur user in query)
            {
                result = user.Id;
            }

            return result;
        }

        public void addUser(Utilisateur user)
        {
            dataContext.GetTable<Utilisateur>().InsertOnSubmit(user);

            dataContext.SubmitChanges();
        }

        public void addProduit(Produit produit)
        {
            dataContext.GetTable<Produit>().InsertOnSubmit(produit);

            dataContext.SubmitChanges();
        }

        public void addCommande(Commande commande)
        {
            dataContext.GetTable<Commande>().InsertOnSubmit(commande);

            dataContext.SubmitChanges();
        }

        public void updateUser(Entité.Utilisateur userUpdate)
        {
            Table<Utilisateur> users = dataContext.GetTable<Utilisateur>();

            var query = from user in users
                        where user.Id == userUpdate.Id
                        select user;

            foreach (Utilisateur user in query)
            {
                user.Id = userUpdate.Id;
                user.Prenom = userUpdate.Prenom;
                user.Nom = userUpdate.Nom;
                user.MotPasse = userUpdate.MotPasse;
                user.IdRole = userUpdate.IdRole;
                user.Status = user.Status;
                user.DateDebut = user.DateDebut;
                user.DateFin = user.DateFin;
            }

            dataContext.SubmitChanges();
        }

        public void deleteUser(Utilisateur userDelete)
        {
            Table<Utilisateur> users = dataContext.GetTable<Utilisateur>();

            var query = from user in users
                        where user.Id == userDelete.Id
                        select user;

            foreach (Utilisateur user in query)
            {
                dataContext.GetTable<Utilisateur>().DeleteOnSubmit(user);
            }

            dataContext.SubmitChanges();
        }

        public void addStock(Produit produitUpdate)
        {
            Table<Produit> produits = dataContext.GetTable<Produit>();

            var query = from produit in produits
                        where produit.IdProduit == produitUpdate.IdProduit
                        select produit;

            foreach (Produit produit in query)
            {
                produit.Stock = produitUpdate.Stock;
            }

            dataContext.SubmitChanges();
        }

        public List<Entité.Utilisateur> getAllUsers()
        {
            List<Entité.Utilisateur> result = new List<Entité.Utilisateur>();
            Table<Utilisateur> users = dataContext.GetTable<Utilisateur>();

            var query = from user in users
                        select user;

            foreach (Utilisateur user in query)
            {
                result.Add(user);
            }

            return result;
        }

        public List<Entité.Role> getAllRole()
        {
            List<Entité.Role> result = new List<Entité.Role>();
            Table<Role> roles = dataContext.GetTable<Role>();

            var query = from role in roles
                        select role;

            foreach (Role role in query)
            {
                result.Add(role);
            }

            return result;
        }

        public List<Entité.Adresse> getAdresseByUser(int idUser)
        {
            List<Entité.Adresse> result = new List<Entité.Adresse>();
            Table<Adresse> adresses = dataContext.GetTable<Adresse>();

            var query = from adresse in adresses
                        where adresse.setIdUtilisateur == idUser
                        select adresse;

            foreach (Adresse adresse in query)
            {
                result.Add(adresse);
            }

            return result;
        }

        public List<Entité.Role> getRoleByCodeRole(string codeRole)
        {
            List<Entité.Role> result = new List<Entité.Role>();
            Table<Role> roles = dataContext.GetTable<Role>();

            var query = from role in roles
                        where role.CodeRole == codeRole
                        select role;

            foreach (Role role in query)
            {
                result.Add(role);
            }

            return result;
        }

        public int getUserRole(int idUser)
        {
            int result = -1;
            Table<Utilisateur> users = dataContext.GetTable<Utilisateur>();

            var query = from user in users
                        where user.Id == idUser
                        select user;

            foreach (Utilisateur user in query)
            {
                result = user.IdRole;
            }

            return result;
        }

        public List<Entité.Utilisateur> findUsersByLastName(string lastName)
        {
            List<Entité.Utilisateur> result = new List<Entité.Utilisateur>();
            Table<Utilisateur> users = dataContext.GetTable<Utilisateur>();

            var query = from user in users
                        where user.Nom == lastName
                        select user;

            foreach (Utilisateur user in query)
            {
                result.Add(user);
            }

            return result;
        }

        public List<Entité.Utilisateur> findUsersByFirstName(string firstName)
        {
            List<Entité.Utilisateur> result = new List<Entité.Utilisateur>();
            Table<Utilisateur> users = dataContext.GetTable<Utilisateur>();

            var query = from user in users
                        where user.Prenom == firstName
                        select user;

            foreach (Utilisateur user in query)
            {
                result.Add(user);
            }

            return result;
        }

        public List<Entité.Utilisateur> findUsersByRole(Role role)
        {
            List<Entité.Utilisateur> result = new List<Entité.Utilisateur>();
            Table<Utilisateur> users = dataContext.GetTable<Utilisateur>();

            var query = from user in users
                        where user.IdRole == role.IdRole
                        select user;

            foreach (Utilisateur user in query)
            {
                result.Add(user);
            }

            return result;
        }

        public List<Produit> findProduitById(int id)
        {
            List<Produit> result = new List<Produit>();
            Table<Produit> produits = dataContext.GetTable<Produit>();

            var query = from produit in produits
                        where produit.IdProduit == id
                        select produit;

            foreach (Produit produit in query)
            {
                result.Add(produit);
            }

            return result;
        }

        public List<Produit> getAllProduit()
        {
            List<Produit> result = new List<Produit>();
            Table<Produit> produits = dataContext.GetTable<Produit>();

            var query = from produit in produits
                        select produit;

            foreach (Produit produit in query)
            {
                result.Add(produit);
            }

            return result;
        }

        public List<Produit> findProduitByName(string name)
        {
            List<Produit> result = new List<Produit>();
            Table<Produit> produits = dataContext.GetTable<Produit>();

            var query = from produit in produits
                        where produit.Nom == name
                        select produit;

            foreach (Produit produit in query)
            {
                result.Add(produit);
            }

            return result;
        }

        public List<Produit> findProduitByReference(string reference)
        {
            List<Produit> result = new List<Produit>();
            Table<Produit> produits = dataContext.GetTable<Produit>();

            var query = from produit in produits
                        where produit.Reference == reference
                        select produit;

            foreach (Produit produit in query)
            {
                result.Add(produit);
            }

            return result;
        }

        public List<Commande> findCommandeById(int id)
        {
            List<Commande> result = new List<Commande>();
            Table<Commande> commandes = dataContext.GetTable<Commande>();

            var query = from commande in commandes
                        where commande.IdCommande == id
                        select commande;

            foreach (Commande commande in query)
            {
                result.Add(commande);
            }

            return result;
        }

        public List<Commande> findCommandeByProduit(int id)
        {
            List<Commande> result = new List<Commande>();
            Table<Commande> commandes = dataContext.GetTable<Commande>();

            var query = from commande in commandes
                        where commande.IdProduit == id
                        select commande;

            foreach (Commande commande in query)
            {
                result.Add(commande);
            }

            return result;
        }

        public List<Commande> findCommandeByUsers(Utilisateur user)
        {
            List<Commande> result = new List<Commande>();
            Table<Commande> commandes = dataContext.GetTable<Commande>();

            var query = from commande in commandes
                        where commande.IdUtilisateur == user.Id
                        select commande;

            foreach (Commande commande in query)
            {
                result.Add(commande);
            }

            return result;
        }


        public List<Commande> getAllCommande()
        {
            List<Commande> result = new List<Commande>();
            Table<Commande> commandes = dataContext.GetTable<Commande>();

            var query = from commande in commandes
                        select commande;

            foreach (Commande commande in query)
            {
                result.Add(commande);
            }

            return result;
        }

        public void updateCommande(Commande commandeToUpdate)
        {
            Table<Commande> commandes = dataContext.GetTable<Commande>();

            var query = from commande in commandes
                        where commande.IdCommande == commandeToUpdate.IdCommande
                        select commande;

            foreach (Commande commande in query)
            {
                commande.IdCommande = commandeToUpdate.IdCommande;
                commande.IdProduit = commandeToUpdate.IdProduit;
                commande.IdUtilisateur = commandeToUpdate.IdUtilisateur;
                commande.DateCommande = commandeToUpdate.DateCommande;
                commande.TotalCommande = commandeToUpdate.TotalCommande;
            }

            dataContext.SubmitChanges();
        }

        public void updateProduit(Produit produitToUpdate)
        {
            Table<Produit> produits = dataContext.GetTable<Produit>();

            var query = from produit in produits
                        where produit.IdProduit == produitToUpdate.IdProduit
                        select produit;

            foreach (Produit produit in query)
            {
                produit.Description = produitToUpdate.Description;
                produit.IdProduit = produitToUpdate.IdProduit;
                produit.Nom = produitToUpdate.Nom;
                produit.Prix = produitToUpdate.Prix;
                produit.Reference = produitToUpdate.Reference;
                produit.Stock = produitToUpdate.Stock;
            }

            dataContext.SubmitChanges();
        }

        public void deleteProduit(Produit produitDelete)
        {
            Table<Produit> produits = dataContext.GetTable<Produit>();

            var query = from produit in produits
                        where produit.IdProduit == produitDelete.IdProduit
                        select produit;

            foreach (Produit produit in query)
            {
                dataContext.GetTable<Produit>().DeleteOnSubmit(produit);
            }

            dataContext.SubmitChanges();
        }

        public void deleteCommande(Commande commandeDelete)
        {
            Table<Commande> commandes = dataContext.GetTable<Commande>();

            var query = from commande in commandes
                        where commande.IdCommande == commandeDelete.IdCommande
                        select commande;

            foreach (Commande commande in query)
            {
                dataContext.GetTable<Commande>().DeleteOnSubmit(commande);
            }

            dataContext.SubmitChanges();
        }
    }

    
}
