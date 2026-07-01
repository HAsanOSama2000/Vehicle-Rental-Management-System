using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;

namespace VerleihProjekt.Klassen
{
    public class Leihmaterial
    {
        private int inventarnummer;
        private string modell;
        private string farbe;
        private Kategorien kategorie;
        private decimal preis;
        private DateTime leihbeginn;
        private DateTime leihende;


        public int Inventarnummer
        {
            get { return inventarnummer; }
            set { inventarnummer = value; }
        }


        public string Modell {
            get { return modell; }
            set { modell = value; }
        }
       
     
        public string Farbe {
            get { return farbe; }
            set { farbe = value; }
        }

        public Kategorien Kategorie
        {
            get { return kategorie; }
            set { kategorie = value; }

        }
        public decimal Preis {
            get { return preis; }
            set { preis = value; }
        }
        protected DateTime Leihbeginn
        { //Fehler
            get { return leihbeginn; }
            set { leihbeginn = value; }
        }
        protected DateTime Leihende
        {
            get { return leihende; }
            set { leihende = value; }
        }

        public Leihmaterial(int Inventarnummer, Kategorien kategorie, string modell, string farbe, decimal preis)
        {
            this.inventarnummer = Inventarnummer;
            this.kategorie = kategorie;
            this.modell = modell;
            this.farbe = farbe;
            this.preis = preis;
            
        }
        public Leihmaterial(int Inventarnummer, Kategorien kategorie, string modell, string farbe, DateTime leihbeginn, DateTime leihende )
        {
            this.inventarnummer = Inventarnummer;
            this.kategorie = kategorie;
            this.modell = modell;
            this.farbe = farbe;
            this.leihbeginn = leihbeginn;
            this.leihende = leihende;
            
        }
        public Leihmaterial () { }

        public enum Kategorien {
            Kompaktwagen,
            Limousine,
            Geländewagen,
            Kombi,
            Cabriolet,
            Sportwagen

        }
      


    }  
}   
    
    