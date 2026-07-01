using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VerleihProjekt
{
    public partial class Reservierungen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoginKonto"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            bool isAdmin = (Boolean)Session["Admin"]; // 1=f 0 = t

            if (!isAdmin) 
            {
                ReservationData.Visible = false;
                ReservationData.Style.Value = "Display:none;";
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

        protected void LeihmaterialData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < ReservData.Columns.Count; i++)
                {
                    var headerText = ReservData.Columns[i].HeaderText;
                    if (headerText == "Preis" || headerText == "Gesamtsumme")
                    {
                        if (i < e.Row.Cells.Count)
                        {
                            if (decimal.TryParse(e.Row.Cells[i].Text, out decimal value))
                            {
                                // Format the cell text as currency
                                e.Row.Cells[i].Text = value.ToString("C", new CultureInfo("de-DE"));
                            }
                        }
                    }
                }
            }
        }
    }

    }
                

                
               
        
    
