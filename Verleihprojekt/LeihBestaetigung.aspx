<%@ Page Title="Leihbestätigung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeihBestaetigung.aspx.cs" Inherits="VerleihProjekt.LeihBestaetigung" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
  <style>
     /* .pos {
          position: relative;
          left: 15em;
      }*/
     /* span {
        float:right;            } */

  </style>  
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
       <br />
        <asp:Label ID="Fehler" runat="server" CssClass="attention"></asp:Label>
        <br />
        <p>
           
            
            <asp:Label ID="Beginn" runat="server" Text="Leihbeginn:" Font-Bold="true"></asp:Label>
            <asp:Label CssClass="pos" ID="leihbeginn" runat="server" Text="Leihbeginn:"></asp:Label>
            <br />
            
            <asp:Label ID="Ende" runat="server" Text="Leihende:" Font-Bold="true"></asp:Label>
            <asp:Label CssClass="pos" ID="leihende" runat="server" Text=""></asp:Label>
            <br />

            <asp:Label ID="K" runat="server" Text="Kategorie:" Font-Bold="true"></asp:Label>
            <asp:Label CssClass="pos" ID="kategorie" runat="server" Text=""></asp:Label>
            <br />

            <asp:Label ID="M" runat="server" Text="Modell:" Font-Bold="true"></asp:Label>
            <asp:Label CssClass="pos" ID="model" runat="server" Text=""></asp:Label>
            <br />
            
            <asp:Label ID="F" runat="server" Text="Farbe:" Font-Bold="true"></asp:Label>
            <asp:Label CssClass="pos" ID="farbe" runat="server" Text=""></asp:Label> 
            <br />
            
            <asp:Label ID="P" runat="server" Text="Preis:" Font-Bold="true"></asp:Label>
            <asp:Label CssClass="pos" ID="preis" runat="server" Text="">€</asp:Label> 
            
            <br />
            <asp:LinkButton style="float:right" runat="server" OnClick="BuchungList_Click"  Font-Bold="true" Text="Meine Buchungen ansehen">   </asp:LinkButton>
                    
        </p>
    </main>
</asp:Content>
