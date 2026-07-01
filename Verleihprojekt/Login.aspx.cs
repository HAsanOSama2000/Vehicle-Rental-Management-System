using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VerleihProjekt.Klassen;

namespace VerleihProjekt
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fehler.Visible = false;
            
        }
        //protected override void OnPreInit(EventArgs e)
        //{
        //    this.MasterPageFile = "~/SiteMitarbeiter.master";
        //    base.OnPreInit(e);
        //}
        protected void Log_Click(object sender, EventArgs e)
        {
            SDB sdb = new SDB();
            Konto konto;
            if (CheckAdmin.Checked) 
            {
                konto = sdb.getAdmin(username.Text, passwort.Text);  
               
            }
            else
            {
               konto = sdb.getKonto(username.Text, passwort.Text);
            }
            if (konto == null) {
                Fehler.Text = "Username oder Passwort ist falsch";
                Fehler.ForeColor= Color.Red;
                Fehler.Visible = true;
                return;
            }
            
            Session["Kundennummer"] = konto.Kontonummer;
            Session["LoginKonto"] = konto;
            Session["Name"] = username.Text;
            Session["Admin"] = konto.Admin;

            if (CheckAdmin.Checked)
            {
                Response.Redirect("Leihmaterial.aspx");//if Arbeiter else Admin *
            }
            else
            {
                Response.Redirect("Default.aspx");

            }
        }
        

        
        
    }
}