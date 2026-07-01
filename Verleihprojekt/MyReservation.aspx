<%@ Page Title="Meine Buchung" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="MyReservation.aspx.cs" Inherits="VerleihProjekt.MyReservation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style> 

        body{
    color: rgb(0,67,122);
        } 

        </style>
     <asp:Label  runat="server" ID="mErrorText"></asp:Label>
    <h1> Hallo <%: Session["Name"].ToString() %></h1>
    <br />
    <h4 >Hier finden sie all ihre Reservierungen</h4>
    <div class="table-responsive"> 
    <asp:GridView 
        CssClass="table table-borderless table-hover table-striped" 
        ID="LeihmaterialData" 
        runat="server"  
        DataSourceID="Projekt" 
        EmptyDataText="Sie haben noch keine Reservierungen getätigt" BorderColor="#F1B434">
</asp:GridView></div>
 <asp:SqlDataSource 
    ID="Projekt"
    runat="server"
    DataSourceMode="DataReader" OnSelected="Projekt_Selected" 
    ConnectionString='<%$ ConnectionStrings:MyConnectionString %>'
    SelectCommand="EXEC ReserviertTabelleZeigen @Kn = @Kundennummer">
    <SelectParameters>
        <asp:SessionParameter Name="Kundennummer" SessionField="Kundennummer" Type="Int32" />
    </SelectParameters>
  </asp:SqlDataSource>
</asp:Content>
