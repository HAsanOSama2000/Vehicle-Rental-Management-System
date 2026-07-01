using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VerleihProjekt
{
    public partial class Kunden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginKonto"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            bool isAdmin = (Boolean)Session["Admin"]; // 1=f 0 = t

            if (!isAdmin) // true 
            {
                KundenData.Visible = false;
                KundenData.Style.Value = "Display:none;";
                mErrorText.Text = "Sie haben keinen Zugriff auf diese Seite!";
                mErrorText.Visible = true;
            }

            }
        protected void Projekt_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {

                mErrorText.Text = e.Exception.Message;
                mErrorText.Visible = true;
                e.ExceptionHandled = true;
            }
        }
    }
}