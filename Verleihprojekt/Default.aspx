<%@ Page Title="Reservieren" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VerleihProjekt._Default" %>

<asp:Content  ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
  <script type="text/javascript">
      
      $(function () {
          $(".js-date-picker").datepicker({
              dateFormat: "dd.mm.yy",
              placeholder: "hallo",

             
              showButtonPanel: true,

          });

          


      });
  </script>
    <style type="text/css">
   
        .ui-datepicker{
            background-color: rgb(0,67,122);
            color: black;
            font-size: 12pt;

        }
        .js-date-picker   {
      
     
      color: black;
     
      font-size: 12pt;
    }
</style>
      <style> 
      body{
          color: rgb(0,67,122);
      }
    
  
      Label{ display:flex;
             font-weight:bold;
             padding:2px;
             margin-left:5px;
             margin-top:10px;
 }
      
      input {
          border: 1px solid rgb(17,92,155);
          width: 13em;
          padding: 5px;
          margin: 3px;
          border-radius: 50px;
          backdrop-filter: blur(30px);
      }
      #MainContent_Kategorie{
          border: 1px solid rgb(17,92,155);
          width: 13em;
          padding: 5px;
          margin: 3px;
          border-radius: 50px;
          backdrop-filter: blur(30px);
      } #MainContent_Model {
          border: 1px solid rgb(17,92,155);
          width: 13em;
          padding: 5px;
          margin: 3px;
          border-radius: 50px;
          backdrop-filter: blur(30px);
      }#MainContent_Farbe {
          border: 1px solid rgb(17,92,155);
          width: 13em;
          padding: 5px;
          margin: 3px;
          border-radius: 50px;
          backdrop-filter: blur(30px);
      }
     #MainContent_Kbutton1, #MainContent_Kbutton2, #MainContent_Kbutton3, #MainContent_Kbutton4, #MainContent_Kbutton5 {
         background-color:rgb(241,180,52);
         font-weight:bold;
         color:white;
         border:none;
         margin:10px;
         width:8em;
         position:relative;
         border-radius:50px;
     }
     #MainContent_Kbutton1:hover{
    
        transform:scale(1.1);
        background-color:rgb(204,141,14);
}
     #MainContent_Kbutton2:hover{
         transform:scale(1.1);
         background-color:rgb(204,141,14);
     }
     #MainContent_Kbutton3:hover{
         transform:scale(1.1);
         background-color:rgb(204,141,14);
     } #MainContent_Kbutton4:hover{
         transform:scale(1.1);
         background-color:rgb(204,141,14);
     } #MainContent_Kbutton5:hover{
         transform:scale(1.1);
         background-color:rgb(204,141,14);
     }
    datalist{
        width:100%;
        border: 1px solid green;
    }
 
    h3{
        transform:translate(5px,10px);
        position:relative;
        
    }


      
    </style>
        <br />
        <h1>Willkommen <%: Session["Name"].ToString() %> </h1>
        <br />
        <asp:Label ID="Fehler" runat="server" CssClass="attention"></asp:Label>
        <div id="Schritt1" runat="server">
        <h5>Bitte geben Sie den Zeitraum für den Leih an</h5>
        <asp:Label ID="Beginn" runat="server" Text="Leihbeginn:" ></asp:Label>
        <asp:TextBox runat="server" ID="Von"  CssClass="js-date-picker" />
        <asp:Label ID="UhrzeitA" runat="server" Text="Uhrzeit:"></asp:Label>
        <asp:DropDownList ID="Zeitbeginn" runat="server"></asp:DropDownList>
        <asp:Label ID="Ende" runat="server" Text="Leihende:"></asp:Label>
        <asp:TextBox runat="server" ID="Bis" CssClass="js-date-picker" />
        <asp:Label ID="UhrzeitB" runat="server" Text="Uhrzeit:"></asp:Label>
        <asp:DropDownList ID="Zeitende" runat="server"></asp:DropDownList>

        <asp:Button ID="Kbutton1" runat="server" Text="weiter" OnCommand="CommandClick" CommandArgument="1"/>
        </div>
    
        <br />
        <div ID="Schritt2" runat="server">
        <h5> Bitte die gewünschte Kategorie auswählen</h5>
        <asp:Label ID="k" runat="server" Text="Kategorie" AssociatedControlID="Kategorie" ></asp:Label> 
        <asp:DropDownList ID="Kategorie" runat="server"  EnableViewState="true" AutoPostBack="true" Placeholder="Wähle eine Kategorie" OnSelectedIndexChanged="Kategorie_SelectedIndexChanged"> </asp:DropDownList>
        
        <asp:Button ID="Kbutton2" runat="server" Text="weiter" OnCommand="CommandClick" CommandArgument="2"/>
        </div>

         <br />
        <div ID="Schritt3" runat="server">
        <h5> bitte jetzt das Model wählen</h5>
        <asp:Label ID="m" runat="server" Text="Model" AssociatedControlID="Model"></asp:Label>
        <asp:DropDownList ID="Model" runat="server" EnableViewState="true" Placeholder="Wähle ein Model"  AutoPostBack="true" OnSelectedIndexChanged="Model_SelectedIndexChanged" > </asp:DropDownList>
        
        <asp:Button  ID="Kbutton3" runat="server" Text="weiter" OnCommand="CommandClick" CommandArgument="3"/>
        </div> 
         <br />
        <div ID="Schritt4" runat="server">
        <h5>Bitte geben Sie Ihre gewünschte Farbe an</h5>
        <asp:Label ID="f" runat="server" Text="Farbe" AssociatedControlID="Farbe"></asp:Label>
        <asp:DropDownList ID="Farbe" runat="server" Placeholder="Wähle eine Farbe"  AutoPostBack="true" OnSelectedIndexChanged="Farbe_SelectedIndexChanged" ></asp:DropDownList>
        <asp:Button ID="Kbutton4" runat="server" Text="Bestätigen" OnCommand="CommandClick" CommandArgument="4"/>
       </div>
        <br />    
     <div id="Schritt5" class="row" runat="server">
        <h5>Kasse:</h5>
           <asp:Label ID="Wert" runat="server" Text="Preis" ></asp:Label>
         <br />
        <asp:Button ID="Kbutton5" runat="server" Text="Bestätigen" OnCommand="CommandClick" CommandArgument="5" />
        </div>
         

        </asp:Content>

