using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace VerleihProjekt.Klassen
{
    public class Konto
    {
        private int kontonummer;
        private string username;
        private string passwort;
        private bool admin;


        public int Kontonummer {
            get{ return kontonummer; } 
            set { kontonummer = value; }
        }
        public string Username { 
            get { return username; } 
            set { username = value; } }
    
        public string Passwort {
            get { return passwort;}
            set { passwort = value; } }
         
        public bool Admin
        {
            get { return admin; }
            set { admin = value; } }
    

    public Konto(int kontonummer, string username, string passwort, bool admin){

      
            kontonummer = this.kontonummer; 
        username = this.username;
        passwort = this.passwort;
        admin = this.admin;
    }
        


    }
}