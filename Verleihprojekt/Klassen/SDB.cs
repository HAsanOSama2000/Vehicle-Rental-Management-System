using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using static VerleihProjekt.Klassen.Leihmaterial;

namespace VerleihProjekt.Klassen
{
    public class SDB
    {
        public string ErrorMessage { get; private set; }

        private SqlConnection connection;
     


        public SDB()
        {
            OpenSDB();
        }


        private void OpenSDB()
        {
            try
            {

                
                // Verbindungsinformationen zur Datenbank
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

             
                connection = new SqlConnection(connectionString);

               
                connection.Open();

                
            }
            catch (SqlException e)
            {
                // Bei Fehlern während der Verbindungsaufnahme die Fehlerinformationen ausgeben
                Console.WriteLine("Keine Verbindung zur Datenbank möglich: " + e.Message);
            }
        }


        /**
         * Gibt das Statement-Objekt zurück, das für die Ausführung von SQL-Anweisungen verwendet wird.
         * @return Ein Statement-Instanz, die für die Ausführung von SQL-Anweisungen verwendet wird.
         */
        public void Dispose()
        {
            connection.Close();
        }


        // speichert die Daten aus der Datenbank in Listen mit Variabeln aus der Klasse Leihmateriaal
        public List<Leihmaterial> GetLeihmaterial()
        {

           
            SqlCommand comm = new SqlCommand();
            SqlDataReader reader = null;

            try
            {
                List<Leihmaterial> LeihmaterialList = new List<Leihmaterial>();

                comm.CommandText = "SELECT * FROM LEIHMATERIAL";
                comm.Connection = connection;
                reader = comm.ExecuteReader();


                while (reader.Read())
                {
                    LeihmaterialList.Add(new Leihmaterial(

                           (int)reader["Inventarnummer"],
                           (Kategorien)Enum.Parse(typeof(Kategorien), reader["Kategorie"].ToString()),
                            reader["Modell"].ToString(),
                            reader["Farbe"].ToString(),
                           (decimal)reader["Preis"]));

                }

                return LeihmaterialList;
            }
            catch (SqlException e)
            {
                //Error Logging hier
                return null;
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (comm != null) comm.Dispose();
            }
        }
      
        
        public List<string> getVerfuegbarModels(Kategorien Kat, DateTime Beginn, DateTime Ende)
        {
            SqlCommand comm = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                List<string> Models = new List<string>();

                comm.CommandText = "SELECT DISTINCT M.Modell from LEIHMATERIAL M WHERE M.Kategorie= @Kat ";
                comm.CommandText += "AND M.Inventarnummer NOT IN (SELECT R.Inventarnummer FROM RESERVIERUNG R ";
                comm.CommandText += "WHERE @Beginn BETWEEN R.Leihbeginn AND R.Leihende OR @Ende BETWEEN R.Leihbeginn AND R.Leihende ";
                comm.CommandText += " OR R.Leihbeginn BETWEEN @Beginn AND @Ende OR R.Leihende BETWEEN @Beginn AND @Ende);";

                comm.Connection = connection;

                comm.Parameters.Add("@Kat", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@Beginn", System.Data.SqlDbType.DateTime);
                comm.Parameters.Add("@Ende", System.Data.SqlDbType.DateTime);

                comm.Parameters["@Kat"].Value = Kat.ToString();
                comm.Parameters["@Beginn"].Value = Beginn;
                comm.Parameters["@Ende"].Value = Ende;


                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Models.Add(reader["Modell"].ToString());

                }
                return Models;
            }
            catch (SqlException eSql)
            {
                //Error Logging hier
                return null;
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (comm != null) comm.Dispose();
            }
        }
    
        public List<string> getVerfugbarFarben(Kategorien Kat, string Mod, DateTime Beginn, DateTime Ende)
        {

            SqlCommand comm = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                List<string> Farben = new List<string>();

                comm.CommandText = "SELECT DISTINCT M.Farbe from LEIHMATERIAL M WHERE M.Kategorie= @Kat and M.Modell = @Mod ";
                comm.CommandText += "AND M.Inventarnummer NOT IN (SELECT R.Inventarnummer FROM RESERVIERUNG R ";
                comm.CommandText += "WHERE @Beginn BETWEEN R.Leihbeginn AND R.Leihende OR @Ende BETWEEN R.Leihbeginn AND R.Leihende ";
                comm.CommandText += "OR R.Leihbeginn BETWEEN @Beginn AND @Ende OR R.Leihende BETWEEN @Beginn AND @Ende);";

                comm.Connection = connection;

                comm.Parameters.Add("@Kat", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@Mod", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@Beginn", System.Data.SqlDbType.DateTime);
                comm.Parameters.Add("@Ende", System.Data.SqlDbType.DateTime);

                comm.Parameters["@Kat"].Value = Kat.ToString();
                comm.Parameters["@Mod"].Value = Mod;
                comm.Parameters["@Beginn"].Value = Beginn;
                comm.Parameters["@Ende"].Value = Ende;


                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Farben.Add(reader["Farbe"].ToString());

                }
                return Farben;
            }
            catch (SqlException eSql)
            {
                //Error Logging hier
                return null;
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (comm != null) comm.Dispose();
            }


        }
      
        public Leihmaterial getVerfugbarMatrialien(Kategorien Kat, string Mod, string Farb, DateTime Beginn, DateTime Ende)
        {

            SqlCommand comm = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                Leihmaterial VerfugbarLeihMatrialien = null;

                comm.CommandText = "SELECT Top 1 M.* from LEIHMATERIAL M WHERE M.Kategorie= @Kat and M.Modell = @Mod ";
                comm.CommandText += "AND Farbe = @Farb AND M.Inventarnummer NOT IN (SELECT R.Inventarnummer FROM RESERVIERUNG R ";
                comm.CommandText += "WHERE @Beginn BETWEEN R.Leihbeginn AND R.Leihende OR @Ende BETWEEN R.Leihbeginn AND R.Leihende ";
                comm.CommandText += "OR R.Leihbeginn BETWEEN @Beginn AND @Ende OR R.Leihende BETWEEN @Beginn AND @Ende);";

                comm.Connection = connection;

                comm.Parameters.Add("@Kat", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@Mod", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@Farb", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@Beginn", System.Data.SqlDbType.DateTime);
                comm.Parameters.Add("@Ende", System.Data.SqlDbType.DateTime);

                comm.Parameters["@Kat"].Value = Kat.ToString();
                comm.Parameters["@Mod"].Value = Mod;
                comm.Parameters["@Farb"].Value = Farb;
                comm.Parameters["@Beginn"].Value = Beginn;
                comm.Parameters["@Ende"].Value = Ende;


                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    VerfugbarLeihMatrialien = new Leihmaterial((int)reader["Inventarnummer"],
                   (Kategorien)Enum.Parse(typeof(Kategorien), reader["Kategorie"].ToString()),
                    reader["Modell"].ToString(),
                    reader["Farbe"].ToString(),
                   (decimal)reader["Preis"]
                   );


                }

                return VerfugbarLeihMatrialien;
            }
            catch (SqlException eSql)
            {
                //Error Logging hier
                return null;
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (comm != null) comm.Dispose();
            }


        }
        // speichert verfügbare Models in Listen mit Variabeln aus der Klasse Konto
        public Konto getKonto(string username, string passwort)
        {

            SqlCommand comm = new SqlCommand();
        SqlDataReader reader = null;
            try
            {
                Konto konto = null;

                comm.CommandText = " SELECT t.Kontonummer, t.Username , t.Passwort, t.Admin , k.Name, k.Nachname ";
                comm.CommandText += " FROM Konto t INNER JOIN Kunde k ON t.Kontonummer = k.Kundennummer ";
                comm.CommandText += " WHERE t.Username = @username AND t.Passwort= @passwort; ";

                comm.Connection = connection;

              
                comm.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@passwort", System.Data.SqlDbType.VarChar);
                comm.Parameters["@username"].Value = username;
                comm.Parameters["@passwort"].Value = passwort;


                reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        konto = new Konto((int) reader["Kontonummer"],//fehler  // Warum Fehler?
                        reader["Username"].ToString(),
                        reader["Passwort"].ToString(),
                        (Boolean) reader["Admin"]);
           
                    
        
    }
                    if (konto.Kontonummer == 0)
                    {
                        reader.Close();
                        comm.CommandText += "SELECT SCOPE_IDENTITY() AS ID FROM Konto;";
                        konto.Kontonummer = int.Parse(comm.ExecuteScalar().ToString());
                    }

                }

return konto;
            }
            catch (SqlException eSql)
            {
                //Error Logging hier
                return null;
            }
            finally
            {
    if (reader != null) { reader.Close(); reader.Dispose(); }
    if (comm != null) comm.Dispose();
}

        } public Konto getAdmin(string username, string passwort)
        {

            SqlCommand comm = new SqlCommand();
        SqlDataReader reader = null;
            try
            {
                Konto konto = null;

                comm.CommandText = " SELECT Kontonummer, Username , Passwort, Admin  ";
                comm.CommandText += " FROM Konto WHERE Username = @username AND Passwort = @passwort ";
                comm.CommandText += " AND Admin = 1 ";

                comm.Connection = connection;

                //comm.Parameters.Add("@Kontonummer", System.Data.SqlDbType.Int);
                comm.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@passwort", System.Data.SqlDbType.VarChar);
                comm.Parameters["@username"].Value = username;
                comm.Parameters["@passwort"].Value = passwort;


                reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        konto = new Konto( (int) reader["Kontonummer"],
                        reader["Username"].ToString(),
                        reader["Passwort"].ToString(),
                        (bool) reader["Admin"]);
           
                    if(konto.Admin == false)
                        {
                            konto.Admin = true;
                        }        
    }
                   
                }

                return konto;
            }
            catch (SqlException eSql)
            {
                //Error Logging hier
                return null;
            }
            finally
            {
                 if (reader != null) { reader.Close(); reader.Dispose(); }
                if (comm != null) comm.Dispose();
}

        }

        // speichert verfügbare Models in Listen mit Variabeln aus der Klasse Kunde
        public Kunde getKunde(int Kundennummer)
        {

            SqlCommand comm = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                Kunde kunde = null;

                comm.CommandText = "SELECT k.* , t.* , b.* FROM Kunde k ";
                comm.CommandText += "INNER JOIN Konto t ON k.Kundennummer = t.Kontonummer ";
                comm.CommandText += "INNER JOIN Bankverbindung b ON k.Kundennummer = b.Kundennummer ";
                comm.CommandText += "WHERE k.Kundennummer = @Kundennummer"; //0 fehler

                comm.Connection = connection;

                comm.Parameters.Add("@Kundennummer", System.Data.SqlDbType.Int);
                comm.Parameters["@Kundennummer"].Value = Kundennummer;



                reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        kunde = new Kunde((int)reader["Kundennummer"],
                                                 reader["Name"].ToString(),
                                               reader["Nachname"].ToString(),
                                               reader["Straße"].ToString(),
                                               (int)reader["Hausnummer"],
                                               (int)reader["PLZ"],
                                               reader["Ort"].ToString(),
                                               reader["Land"].ToString(),
                                               reader["Telefon"].ToString(),
                                               reader["mobil"].ToString(),
                                               reader["Email"].ToString(),
                                               reader["Passwort"].ToString(),
                                               reader["IBAN"].ToString(),
                                               reader["BIC"].ToString());
                    };


                }


                return kunde;
            }
            catch (SqlException eSql)
            {
                //Error Logging hier
                return null;
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (comm != null) comm.Dispose();
            }
        }

        // speichert verfügbare Models in Listen mit Variabeln aus der Klasse Kunde und Konto
        public bool SaveKunde (Kunde kunde, Konto konto)
        {
            SqlTransaction trs = connection.BeginTransaction();
            SqlCommand comm = new SqlCommand();

            try
            {
                comm.Connection = connection;
                comm.Transaction = trs;

                bool istNeu = (kunde.kundennummer == -1);
                if (istNeu)
                {
                    comm.CommandText = "INSERT INTO KUNDE (Name, Nachname, Straße, Hausnummer, PLZ, Ort, Land, Telefon, mobil, Email, Passwort) ";
                    comm.CommandText += "VALUES (@username, @nachname, @straße, @hausnummer, @plz, @ort, @land, @telefon, @mobil, @email, @passwort)";
                }
                else
                {
                    comm.CommandText = "UPDATE KUNDE SET Name = @username, Nachname = @nachname, Straße = @straße, Hausnummer = @hausnummer, PLZ = @plz, ";
                    comm.CommandText += "Ort = @ort, Land = @land, Telefon = @telefon, mobil = @mobil, Email = @email,  Passwort= @passwort ";
                    comm.CommandText += "WHERE Kundennummer = @kundennummer; ";

                    comm.Parameters.Add("@kundennummer", System.Data.SqlDbType.Int);
                    comm.Parameters["@kundennummer"].Value = kunde.kundennummer;
                }
                comm.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@nachname", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@straße", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@hausnummer", System.Data.SqlDbType.Int);
                comm.Parameters.Add("@plz", System.Data.SqlDbType.Int);
                comm.Parameters.Add("@ort", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@land", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@telefon", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@mobil", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@passwort", System.Data.SqlDbType.VarChar);
                comm.Parameters["@username"].Value = kunde.Name;
                comm.Parameters["@nachname"].Value = kunde.Nachname;
                comm.Parameters["@straße"].Value = kunde.Straße;
                comm.Parameters["@hausnummer"].Value = kunde.Hausnummer;
                comm.Parameters["@plz"].Value = kunde.PLZ;
                comm.Parameters["@ort"].Value = kunde.Ort;
                comm.Parameters["@land"].Value = kunde.Land;
                comm.Parameters["@telefon"].Value = kunde.Telefon ;
                comm.Parameters["@mobil"].Value = kunde.Mobil;
                comm.Parameters["@email"].Value = kunde.Email;
                comm.Parameters["@passwort"].Value = kunde.passwort;


                if (istNeu)
                {
                    comm.CommandText += "SELECT SCOPE_IDENTITY() AS ID FROM KUNDE;";
                    kunde.kundennummer = int.Parse(comm.ExecuteScalar().ToString());
                }
                else
                {
                    comm.ExecuteNonQuery();
                }

                //Der SQL-Command wird geleert,um einen neuen auszuführen
                comm.CommandText = string.Empty;
            
                comm.Parameters.Clear();

                if (istNeu)
                {
                    
                    comm.CommandText += "INSERT INTO BANKVERBINDUNG (Kundennummer, IBAN, BIC) ";
                    comm.CommandText += "VALUES (@kundennummer, @iban, @bic); ";
                    comm.CommandText += "INSERT INTO KONTO (Kontonummer, Username, Passwort, Admin) ";
                    comm.CommandText += "VALUES (@kundennummer, @username, @passwort, @admin); ";
                   

                }
                else
                {
                    comm.CommandText = "UPDATE BANKVERBINDUNG SET IBAN = @iban, BIC = @bic, ";
                    comm.CommandText += "Leihbeginn = @leihbeginn, Leihende = @leihende WHERE Kundennummer = @kundennummer; ";
                    comm.CommandText += "UPDATE KONTO SET Username = @username, Passwort = @passwort, ";
                    comm.CommandText += "Admin = @admin WHERE Kontonummer = @kundennummer" ;
                   
                }

                comm.Parameters.Add("@kundennummer", System.Data.SqlDbType.Int);
                comm.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@passwort", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@admin", System.Data.SqlDbType.Bit);
                comm.Parameters.Add("@iban", System.Data.SqlDbType.VarChar);
                comm.Parameters.Add("@bic", System.Data.SqlDbType.VarChar);
                comm.Parameters["@kundennummer"].Value = kunde.kundennummer;
                comm.Parameters["@username"].Value = kunde.Name;
                comm.Parameters["@passwort"].Value = kunde.passwort;
                comm.Parameters["@admin"].Value = konto.Admin;
                comm.Parameters["@iban"].Value = kunde.Iban;
                comm.Parameters["@bic"].Value = kunde.bic;

                comm.ExecuteNonQuery();
                trs.Commit();

                return true;
            }
            catch (SqlException eSql)
            {
                //Error Logging hier
                Console.WriteLine("SQL-Fehler: " + eSql.Message);
                ErrorMessage= "SQL-Fehler:"+eSql.Message;

              

                return false;
            }
            finally
            {
                if (trs != null) { trs.Dispose(); }
                if (comm != null) comm.Dispose();
            }
        }
        // speichert verfügbare Models in Listen mit Variabeln aus der Klasse Resservierung
        public bool SaveReservierung(Reservierung reservierung)
        {
            SqlTransaction trs = connection.BeginTransaction();
            SqlCommand comm = new SqlCommand();

            try
            {
                bool istNeu = (reservierung.Reservierungsnummer == -1);
                if (istNeu)
                {
                    comm.CommandText = "INSERT INTO RESERVIERUNG (Inventarnummer, Kundennummer, Leihbeginn, Leihende) ";
                    comm.CommandText += "VALUES (@inventarnummer, @kundennummer, @leihbeginn, @leihende)";
                }
                else
                {
                    comm.CommandText = "UPDATE RESERVIERUNG SET Inventarnummer = @inventarnummer, Kundennummer = @kundennummer, ";
                    comm.CommandText += "Leihbeginn = @leihbeginn, Leihende = @leihende";
                }
                
                comm.Parameters.Add("@inventarnummer", System.Data.SqlDbType.Int);
                comm.Parameters.Add("@kundennummer", System.Data.SqlDbType.Int);
                comm.Parameters.Add("@leihbeginn", System.Data.SqlDbType.DateTime); 
                comm.Parameters.Add("@leihende", System.Data.SqlDbType.DateTime);
                comm.Parameters["@inventarnummer"].Value = reservierung.Material.Inventarnummer;
                comm.Parameters["@kundennummer"].Value = reservierung.Kunde.kundennummer;
                comm.Parameters["@leihbeginn"].Value = reservierung.Leihbeginn;
                comm.Parameters["@leihende"].Value = reservierung.Leihende;

                comm.Transaction = trs;
                comm.Connection = connection;


                if (istNeu)
                {
                    comm.CommandText += " SELECT SCOPE_IDENTITY() AS ID ;";
                    reservierung.Reservierungsnummer = int.Parse(comm.ExecuteScalar().ToString());
                }
                else
                {
                    comm.ExecuteNonQuery();
                }

                trs.Commit();

                return true;
            }
            catch (SqlException eSql)
            {
                //Error Logging hier
                ErrorMessage = "SQL-Fehler: " + eSql.Message;
                return false;
            }
            finally
            {
                if (trs != null) { trs.Dispose(); }
                if (comm != null) comm.Dispose();
            }
        }

        
         public List<Leihmaterial> GetMyReservierung(int Kundennummer)
      {

          // SDB connect = new SDB();
          //SqlCommand comm = connect.getCommand();
          SqlCommand comm = new SqlCommand();
          SqlDataReader reader = null;

          try
          {
              List<Leihmaterial> LeihmaterialList = new List<Leihmaterial>();

              comm.CommandText = "Select L.*, R.Leihbeginn, R.Leihende from LEIHMATERIAL L inner join RESERVIERUNG R on R.Inventarnummer = L.Inventarnummer Where R.Kundennummer = @Kundennummer"; 

              comm.Connection = connection;
             

              comm.Parameters.Add("@Kundennummer", System.Data.SqlDbType.Int);
              comm.Parameters["@Kundennummer"].Value = Kundennummer;
                reader = comm.ExecuteReader();

                while (reader.Read())
              {
                  LeihmaterialList.Add(new Leihmaterial(

                         (int)reader["Inventarnummer"],
                         (Kategorien)Enum.Parse(typeof(Kategorien), reader["Kategorie"].ToString()),
                          reader["Modell"].ToString(),
                          reader["Farbe"].ToString(),
                          (DateTime)reader["Leihbeginn"],
                          (DateTime)reader["Leihende"]
                         //(decimal)reader["Preis"])
                      ));

              }

              return LeihmaterialList;
          }
          catch (SqlException e)
          {
              //Error Logging hier
              ErrorMessage = e.Message.ToString();
            
              return null;
          }
          finally
          {
              if (reader != null) { reader.Close(); reader.Dispose(); }
              if (comm != null) comm.Dispose();
          }
      }
       
    }
}    

    
    