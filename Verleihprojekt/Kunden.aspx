<%@ Page Title="Kunden" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Kunden.aspx.cs" Inherits="VerleihProjekt.Kunden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <style> 

 body{
     color: rgb(0,67,122);
 } 

 </style>
<br />
<asp:Label  runat="server" ID="mErrorText" Font-Bold="true" ForeColor="DarkRed"></asp:Label>
    
    <section runat="server" id="KundenData">
    <h1>Kunden</h1>
    <br />
    <h4 >Hier werden alle registrierten Kunden aufgelistet</h4>
    <div class="table-responsive"> 
    <asp:GridView 
        CssClass="table table-borderless table-hover table-striped" 
        ID="KunData" 
        runat="server"  
        DataSourceID="Projekt" 
        EmptyDataText="Keine Kunden vefügbar" BorderColor="#F1B434">
    </asp:GridView></div></section>
    <asp:SqlDataSource 
    ID="Projekt"
    runat="server"
    DataSourceMode="DataReader" OnSelected="Projekt_Selected" 
    ConnectionString='<%$ ConnectionStrings:MyConnectionString %>'
    SelectCommand="SELECT K.Kundennummer ,Name ,Nachname ,Straße ,Hausnummer
                   ,PLZ ,Ort ,Land ,Telefon ,mobil ,Email ,Passwort, BV.IBAN, BV.BIC
                    FROM KUNDE K INNER JOIN BANKVERBINDUNG BV
                    ON BV.Kundennummer = K.Kundennummer ;">
    <SelectParameters>
        <asp:SessionParameter Name="Kundennummer" SessionField="Kundennummer" Type="Int32" />
    </SelectParameters>
  </asp:SqlDataSource>

</asp:Content>
