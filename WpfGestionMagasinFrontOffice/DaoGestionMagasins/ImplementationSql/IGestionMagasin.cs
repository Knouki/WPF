using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfGestionMagasinFrontOffice.Entité;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WpfGestionMagasinFrontOffice
{
    public interface IGestionMagasin
    {

        void connection();
        int login(string identifiant, string motPasse);
        void addUser(Utilisateur user);
        void addProduit(Produit produit);
        void updateUser(Entité.Utilisateur userUpdate);
        void deleteUser(Utilisateur userDelete);
        void addStock(Produit produitUpdate);
        List<Entité.Utilisateur> findUsersByLastName(string lastName);
        List<Entité.Utilisateur> findUsersByFirstName(string firstName);
        List<Entité.Utilisateur> findUsersByRole(Role role);
        List<Produit> findProduitById(int id);
        List<Produit> findProduitByName(string name);
        List<Produit> findProduitByReference(string reference);
        List<Commande> findCommandeById(int id);
        List<Commande> findCommandeByProduit(int id);
        List<Commande> findCommandeByUsers(Utilisateur user);
        List<Produit> getAllProduit();
        List<Entité.Utilisateur> getAllUsers();
        void addCommande(Commande commande);
        int getUserRole(int idUser);
        List<Entité.Adresse> getAdresseByUser(int idUser);
        List<Entité.Role> getAllRole();
        List<Entité.Role> getRoleByCodeRole(string codeRole);
        List<Commande> getAllCommande();
        void updateCommande(Commande commandeToUpdate);
        void updateProduit(Produit produitToUpdate);
        void deleteProduit(Produit produitDelete);
        void deleteCommande(Commande commandeDelete);
    }
}
