using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VerleihProjekt.Klassen;
using static VerleihProjekt.Klassen.Leihmaterial;

namespace VerleihProjekt
{
    public partial class _Default : Page
    {
        public SDB sdb;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Von.CssClass.
            
            if (Session["LoginKonto"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            sdb = new SDB();
            Fehler.Visible = false;
            if (IsPostBack) { return; }
            List<string> Zeiten = new List<string>();
            Zeiten.Add("08:00");
            Zeiten.Add("09:00");
            Zeiten.Add("10:00");
            Zeiten.Add("11:00");
            Zeiten.Add("12:00");
            Zeiten.Add("13:00");
            Zeiten.Add("14:00");
            Zeiten.Add("15:00");
            Zeiten.Add("16:00");
            Zeiten.Add("17:00");

            Zeitbeginn.DataSource = Zeiten;
            Zeitbeginn.DataBind();
            Zeitbeginn.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            Zeitbeginn.SelectedIndex = 0;
            Zeitende.DataSource = Zeiten;
            Zeitende.DataBind();
            Zeitende.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            Zeitende.SelectedIndex = 0;

            Kategorie.DataSource = Enum.GetNames(typeof(Kategorien));
            Kategorie.DataBind();
            Kategorie.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            Kategorie.SelectedIndex = 0;

            Schritt2.Visible = false;
            Schritt3.Visible = false;
            Schritt4.Visible = false;
            Schritt5.Visible = false;
        }
        protected void CommandClick(object sender, CommandEventArgs e)
        {
            switch (e.CommandArgument.ToString())
            {
                case "1":
                    if (String.IsNullOrEmpty(Von.Text) || String.IsNullOrEmpty(Bis.Text) || Zeitbeginn.SelectedIndex < 1 || Zeitende.SelectedIndex < 1)
                    {
                        Fehler.Text = "Bitte geben Sie Datum und Zeit für Leihbeginn und Leihende an.";
                        Fehler.Visible = true;
                        break;
                    }
                    if (Kategorie.Items.Count == 0)
                    {
                        Fehler.Text = "Kein Leihmaterial im ausgewählten Zeitraum verfügbar.";
                        Fehler.Visible = true;
                        break;
                    }
                    Kbutton1.Visible = false;
                    Schritt2.Visible = true;
                    return;
                case "2":
                    if (Kategorie.SelectedIndex < 1)
                    {
                        Fehler.Text = "Bitte wählen Sie eine Kategorie aus.";
                        Fehler.Visible = true;
                        break;
                    }
                    if (Model.Items.Count == 0)
                    {
                        Fehler.Text = "Kein Leihmaterial im ausgewählten Zeitraum für die ausgewählte Kategorie verfügbar.";
                        Fehler.Visible = true;
                        break;
                    }
                    Kbutton2.Visible = false;
                    Schritt3.Visible = true;
                    return;
                case "3":
                    if (Model.SelectedIndex < 1)
                    {
                        Fehler.Text = "Bitte wählen Sie ein Model aus.";
                        Fehler.Visible = true;
                        break;
                    }
                    if (Farbe.Items.Count == 0)
                    {
                        Fehler.Text = "Kein Leihmaterial im ausgewählten Zeitraum für das ausgewählte Modell verfügbar.";
                        Fehler.Visible = true;
                        break;
                    }
                    Kbutton3.Visible = false;
                    Schritt4.Visible = true;
                    return;
                case "4":
                    if (Farbe.SelectedIndex < 1)
                    {
                        Fehler.Text = "Bitte wählen Sie eine Länge aus.";
                        Fehler.Visible = true;
                        break;
                    }
                    Kbutton4.Visible = false;
                    Schritt5.Visible = true;
                    return;
                case "5":
                    Response.Redirect("LeihBestaetigung.aspx");
                   
                    return;



            }
        }
        protected void Kategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Items.Clear();
            Farbe.Items.Clear();

            if (Kategorie.SelectedIndex == 0) { return; }

            DateTime von = DateTime.Parse(Von.Text, new CultureInfo("es-ES"));
            DateTime bis = DateTime.Parse(Bis.Text, new CultureInfo("es-ES"));
            DateTime zeitbeginn = DateTime.Parse(Zeitbeginn.Text, new CultureInfo("es-ES"));
            DateTime zeitende = DateTime.Parse(Zeitende.SelectedValue, new CultureInfo("es-ES"));
            DateTime Beginn = von.Add(zeitbeginn.TimeOfDay);
            DateTime Ende = bis.Add(zeitende.TimeOfDay);

            Kategorien kategorie = (Kategorien)Enum.Parse(typeof(Kategorien), Kategorie.SelectedItem.Text);
            List<string> Modelle = sdb.getVerfuegbarModels(kategorie, Beginn, Ende);

            if (Modelle.Count == 0)
            {
                //kein Leihmaterial zum ausgewählten Zeitraum in der ausgewählten Kategorie verfügbar
                Fehler.Text = "Im ausgewählten Zeitraum ist kein Auto in der gewünschten Kategorie! " + Kategorie.ToString() + " verfügbar.";
                Fehler.Visible = true;
                return;
            }

            Model.DataSource = Modelle;
            Model.DataBind();
            Model.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            Model.SelectedIndex = 0;

        }
        protected void Model_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Farbe.Items.Clear();

            if (Kategorie.SelectedIndex == 0) { return; }
            if (Model.SelectedIndex == 0) { return; }
            

            DateTime von = DateTime.Parse(Von.Text, new CultureInfo("es-ES"));
            DateTime bis = DateTime.Parse(Bis.Text, new CultureInfo("es-ES"));
            DateTime zeitbeginn = DateTime.Parse(Zeitbeginn.Text, new CultureInfo("es-ES"));
            DateTime zeitende = DateTime.Parse(Zeitende.SelectedValue, new CultureInfo("es-ES"));
            DateTime Beginn = von.Add(zeitbeginn.TimeOfDay);
            DateTime Ende = bis.Add(zeitende.TimeOfDay);

            Kategorien kategorie = (Kategorien)Enum.Parse(typeof(Kategorien), Kategorie.SelectedItem.Text);
            string model = Model.SelectedItem.ToString();
            List<string> farben = sdb.getVerfugbarFarben(kategorie, model, Beginn, Ende);

            if (farben.Count == 0)
            {
                //kein Leihmaterial zum ausgewählten Zeitraum in der ausgewählten Kategorie verfügbar
                Fehler.Text = "Im ausgewählten Zeitraum ist die gewünschte Farbe nicht vorhanden! " + Kategorie.ToString() + " verfügbar.";
                Fehler.Visible = true;
                return;
            }

            Farbe.DataSource = farben;
            Farbe.DataBind();
            Farbe.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            Farbe.SelectedIndex = 0;

        }
        protected void Farbe_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Kategorie.SelectedIndex == 0) { return; }
            if (Model.SelectedIndex == 0) { return; }
            if (Farbe.SelectedIndex == 0) { return; }
            

            DateTime von = DateTime.Parse(Von.Text, new CultureInfo("es-ES"));
            DateTime bis = DateTime.Parse(Bis.Text, new CultureInfo("es-ES"));
            DateTime zeitbeginn = DateTime.Parse(Zeitbeginn.Text, new CultureInfo("es-ES"));
            DateTime zeitende = DateTime.Parse(Zeitende.SelectedValue, new CultureInfo("es-ES"));
            DateTime Beginn = von.Add(zeitbeginn.TimeOfDay);
            DateTime Ende = bis.Add(zeitende.TimeOfDay);

            Kategorien kategorie = (Kategorien)Enum.Parse(typeof(Kategorien), Kategorie.SelectedItem.Text);
            string model = Model.SelectedItem.ToString();
            string farbe = Farbe.SelectedItem.ToString();
            Leihmaterial material = sdb.getVerfugbarMatrialien(kategorie, model,farbe, Beginn, Ende);

            Session["SelectedMaterial"] = material;
            Session["Beginn"] = Beginn;
            Session["Ende"] = Ende;

            decimal days = (decimal)Math.Ceiling((Ende - Beginn).TotalDays);
            Wert.Text = (days * material.Preis).ToString("#.00#€");
        }
    }
}