using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VerleihProjekt.Klassen;

namespace VerleihProjekt
{
    public partial class LeihBestaetigung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Verhindert doppeltes Laden
            {
                Fehler.Visible = false;
                if (Session["LoginKonto"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (Session["SelectedMaterial"] == null || Session["Beginn"] == null || Session["Ende"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                SDB sdb = new SDB();
                DateTime Beginn = (DateTime)Session["Beginn"];
                DateTime Ende = (DateTime)Session["Ende"];
                Leihmaterial material = (Leihmaterial)Session["SelectedMaterial"];
                Konto konto = (Konto)Session["LoginKonto"];
                Kunde kunde = sdb.getKunde(konto.Kontonummer);//fehler // warum Fehler ?!
                Reservierung reservierung = new Reservierung(-1, kunde, material, Beginn, Ende); 


                //if (sdb.SaveReservierung(Reserve) != true)
                //{
                //    Response.Write("Oops!Error");
                //    return;
                //}
                if (sdb.SaveReservierung(reservierung) == true)
                {
                    leihbeginn.Text = Beginn.ToString("dd.MM.yyyy HH:mm");
                    leihende.Text = Ende.ToString("dd.MM.yyyy HH:mm");
                    kategorie.Text = material.Kategorie.ToString();
                    model.Text = material.Modell.ToString();
                    farbe.Text = material.Farbe.ToString();
                    decimal days = (decimal)Math.Ceiling((Ende - Beginn).TotalDays);
                    preis.Text = (days * material.Preis).ToString("#,00#€");
                }
                else
                {
                    Fehler.Text = sdb.ErrorMessage.ToString();
                    Fehler.Visible = true;
                    Fehler.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
        }

        protected void BuchungList_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyReservation.aspx");
        }
    }
}