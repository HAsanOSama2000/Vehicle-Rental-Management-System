using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace VerleihProjekt.Klassen
{
    public class Kunde
    {
         public int kundennummer { get; set; }
        private string name;
        private string nachname;
        private string straße;
        private int hausnummer;
        private int plz;
        private string ort;
        private string land;
        private string telefon;
        private string mobil;
        private string email;
        public string ErrorMessage { get;  set; }
        public string passwort { get; set; }
        private string iban;
        public string bic { get; set; }


        public string Name{
           get { return name; }
           set { name = value; }
    }
        public string Nachname{
           get { return nachname; }
           set { nachname = value; }                        
    }
        public string Straße{
        get { return straße; }
        set { straße = value; }
    }
        public int Hausnummer {
         get { return hausnummer;}
         set { hausnummer = value; }
        }

        public int PLZ{
         get { return plz; }
         set { plz = value; }
        }

        public string Ort {
         get { return ort; }
         set { ort = value; }
        }
        public string Land {
            get { return land; }
            set { land = value; }}
        public string Telefon { 
         get { return telefon; }
         set { telefon = value; 
        }
        }
        public string Mobil { 
         get { return mobil; }
         set { mobil = value; }
        }
        public string Email{
         get { return email; }   
         set { email = value; }
        }
        public string Iban { 
         get { return iban; }
         set { iban = value; }
        
        }

        public Kunde(int kundennummer, string name, string nachname, string straße, int hausnummer, int plz, string ort, string land, string telefon, string mobil, string email, string passwort, string iban, string bic)
        {
            this.kundennummer = kundennummer;   
            this.name = name;
            this.nachname = nachname;
            this.straße = straße;
            this.hausnummer = hausnummer;
            this.plz = plz;
            this.ort = ort;
            this.land = land;
            this.telefon = telefon;
            this.mobil = mobil;
            this.email = email;
            this.passwort= passwort;
            this.iban = iban;
            this.bic = bic;

        }
        


    }
}