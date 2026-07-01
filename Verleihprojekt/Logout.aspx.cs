using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VerleihProjekt
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LoginKonto"] = null;
            Session["Admin"] = null;
            if (Session["LoginKonto"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}