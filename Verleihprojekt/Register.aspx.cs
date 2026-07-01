using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using VerleihProjekt.Klassen;

namespace VerleihProjekt
{
    public partial class Registrierung : Page
    {
        private SDB sdb;
        protected void Page_Load(object sender, EventArgs e)
        {
            sdb = new SDB();
            Fehler.Visible = false;
            if (IsPostBack) { return; }
           // Schritt1.Visible = false;
            Schritt2.Visible = false;
            Schritt3.Visible = false;

           

        }
   
        protected void butnNext_Command(object sender, CommandEventArgs e)
        {
            //try
            //{
                switch (e.CommandArgument.ToString())
                {
                    case "1":
                        if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(nachname.Text) || String.IsNullOrEmpty(straße.Text)
                            || String.IsNullOrEmpty(hausnummer.Text) || String.IsNullOrEmpty(plz.Text) || String.IsNullOrEmpty(ort.Text)
                            || String.IsNullOrEmpty(land.Text)|| String.IsNullOrEmpty(telefon.Text)|| String.IsNullOrEmpty(mobil.Text))
                        {
                            Fehler.Text = "Bitte füllen Sie alle Felder aus!.";
                            Fehler.ForeColor = Color.Red;
                            Fehler.Visible = true;
                            break;
                        }
                        Kbutton.Visible = false;
                        Schritt2.Visible = true;
                        break;
                    case "2":
                        if (String.IsNullOrEmpty(iban.Text) || String.IsNullOrEmpty(bic.Text))
                        {
                            Fehler.Text = "Bitte füllen Sie alle Felder aus!.";
                            Fehler.Visible = true;
                            break;
                        }
                        Kbutton2.Visible = false;
                        Schritt3.Visible = true;
                        break;
                    case "3":
                        if (String.IsNullOrEmpty(email.Text) || String.IsNullOrEmpty(passwort1.Text) || String.IsNullOrEmpty(passwort2.Text))
                        {
                            Fehler.Text = "Bitte füllen Sie alle Felder aus!.";
                            Fehler.Visible = true;
                            break;
                        }
                        if (passwort1.Text != passwort2.Text)
                        {
                            Fehler.Text = "Die Passwörter stimmen nicht überein!.";
                            Fehler.Visible = true;
                            break;
                        }
                        string User= username.Text;

                        Kunde kunde = new Kunde(-1, username.Text, nachname.Text, straße.Text, int.Parse(hausnummer.Text),
                                                 int.Parse(plz.Text), ort.Text, land.Text, telefon.Text, mobil.Text,
                                                 email.Text, passwort1.Text, iban.Text, bic.Text);

                        Konto konto = new Konto(-1, User, passwort2.Text, false);

                    if (sdb.SaveKunde(kunde, konto))  {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {

                        Response.Write(sdb.ErrorMessage);
                    }

                    break;



                        }


            //    }
            
            //catch (SqlException e)
            //{
            //    Response.Write(e.ToString());
            //}

}

        protected void BuchungList_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyReservation.aspx");
        }
    }
}