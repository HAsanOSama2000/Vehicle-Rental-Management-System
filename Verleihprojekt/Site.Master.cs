using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VerleihProjekt.Klassen;

namespace VerleihProjekt
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                                
            StartSeite.Visible = false;

            ReservierenSeite.Visible = false;
            MyReservationSeite.Visible = false;
            LeihMaterialSeite.Visible=false;
            ReservierungenSeite.Visible=false; 
            KundenSeite.Visible=false;
            LogOutSeite.Visible = false;

            if (Session["Admin"] == null)
            {
              
            }

            // kontrolliert, ob die Session[Admin] vorhanden ist
            if (Session["Admin"] != null)
            {
                bool isAdmin = (Boolean)Session["Admin"]; // 1=f 0 = t
               
                if (isAdmin) // Mitarbeiter
                {
                    
                    LeihMaterialSeite.Visible = true; 
                    ReservierungenSeite.Visible = true;
                    KundenSeite.Visible=true;
                    LogOutSeite.Visible = true;

                }
                else // Kunde
                {
                    ReservierenSeite.Visible = true;
                    MyReservationSeite.Visible = true;
                    LogOutSeite.Visible = true;

                }
            }
        }
    }
}
