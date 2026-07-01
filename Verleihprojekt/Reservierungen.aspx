<%@ Page Title="Reservierungen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservierungen.aspx.cs" Inherits="VerleihProjekt.Reservierungen" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Label  runat="server" ID="mErrorText" Font-Bold="true" ForeColor="DarkRed"></asp:Label>
       <style> 

        body{
             color: rgb(0,67,122);
             } 

</style>
    <br />
   
<section  runat="server" ID="ReservationData"> 
         <h1> Reservierungen</h1>
        <br />
         <h4>Hier finden sie all ihre Reservierungen</h4> 
        <div class="table-responsive"> 
        
  <asp:GridView 
        CssClass="table table-borderless table-hover table-striped" 
        ID="ReservData" 
        OnRowDataBound="LeihmaterialData_RowDataBound"
        runat="server"  
        DataSourceID="Projekt" 
        EmptyDataText="keine Reservierungen" BorderColor="#F1B434">
   </asp:GridView></div>




   <asp:SqlDataSource 
    ID="Projekt"
    runat="server"
    DataSourceMode="DataReader" OnSelected="Projekt_Selected"
    ConnectionString='<%$ ConnectionStrings:MyConnectionString %>'
    SelectCommand="SELECT R.Reservierungsnummer , K.Name, K.Nachname, 
		            FORMAT(R.Leihbeginn, 'yyyy-MM-dd HH:mm') AS Leihbeginn,
                    FORMAT(R.Leihende, 'yyyy-MM-dd HH:mm') AS Leihende,
		            L.Farbe, L.Modell, L.Kategorie, L.Preis, 
		            Preis * DATEDIFF(DAY, Leihbeginn, Leihende) AS Gesamtsumme 
		            FROM RESERVIERUNG R, KUNDE K, LEIHMATERIAL L
                    Where R.Kundennummer= K.Kundennummer and R.Inventarnummer= L.Inventarnummer;">
    <SelectParameters>
        <asp:SessionParameter Name="Kundennummer" SessionField="Kundennummer" Type="Int32" />
    </SelectParameters>
  </asp:SqlDataSource>

 </section>
</asp:Content>