using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerleihProjekt.Klassen
{
    public class Reservierung
    {
        private int reservierungsnummer;
        private Kunde kunde;
        private Leihmaterial material;
        private DateTime leihbeginn;
        private DateTime leihende;


        public int Reservierungsnummer{ 
            get { return reservierungsnummer; }
            set {  reservierungsnummer = value;}
            }
        public Kunde Kunde{
            get { return kunde; } 
            set { kunde = value; }
        }

        public Leihmaterial Material{
            get { return material; }    
            set { material = value; }
        }    
        public DateTime Leihbeginn{ //Fehler
            get { return leihbeginn; }
            set { leihbeginn = value; } 
            } 
        public DateTime Leihende{
            get { return leihende; }
            set { leihende = value; } 
        }
            
         public Reservierung (int reservierungsnummer, Kunde kunde, Leihmaterial material, DateTime leihbeginn, DateTime leihende){
            this.reservierungsnummer= reservierungsnummer;
            this.kunde = kunde;
            this.material=material;
            this.leihbeginn= leihbeginn;
            this.leihende= leihende;

        }
            
    }
}