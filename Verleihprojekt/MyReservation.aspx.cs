using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using VerleihProjekt.Klassen;
using WebGrease.Activities;

namespace VerleihProjekt
{
    public partial class MyReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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