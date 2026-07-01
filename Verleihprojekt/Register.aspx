<%@ Page Title="Registrierung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="VerleihProjekt.Registrierung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <style> 
        body{
            color: rgb(0,67,122);
        }
      .Ski{
        position:absolute;
        left:45em;
        bottom:18em;
        transform:translate()

        
      }
     #MainContent_Schritt1{
         position: absolute;
        
          
     }
      #MainContent_Teil1{
         position:relative;
         top: 8px;
         left:20em;
        
      }
      #MainContent_Kbutton{
           position:relative;   
           bottom: 4.5em;
           right:20em;
      }
      #MainContent_Schritt2{
          position:relative;
          bottom: 4em;
         
      } #MainContent_Schritt3{
           position:relative;
           bottom: 10em;
           left:20em;
         
      }
   
        Label{ display:flex;
               font-weight:bold;
               padding:2px;
               margin-left:5px;
               margin-top:10px;
   }
        
        input,.input,.form-control {
            border: 1px solid rgb(17,92,155);
            width: 13em;
            padding: 5px;
            margin: 3px;
            border-radius: 50px;
            backdrop-filter: blur(30px);
        }
       #MainContent_Kbutton, #MainContent_Kbutton2, #MainContent_Kbutton3 {
           background-color:rgb(241,180,52);
           font-weight:bold;
           color:white;
           border:none;
           margin:10px;
           width:8em;
           position:relative;
           border-radius:50px;
       }
       #MainContent_Kbutton:hover{
      
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
       }
      datalist{
          width:100%;
          border: 1px solid green;
      }
      #MainContent_Model , #MainContent_Kategorie, #MainContent_Länge{
        border: 1px solid green;
        width:100%;
        padding: 5px;
        margin:3px;
        border-radius:50px;
       /*transform:rotate(90deg);*/
      }
      h3{
          transform:translate(5px,10px);
          position:relative;
          
      }

      
    </style>  

     
    <div class="Kunde" >
        <h2>Registrierung</h2>
        <br/>
                <div><asp:Label ID="Fehler" runat="server" CssClass="attention"></asp:Label></div>
        <div  id="Schritt1" runat="server">
            <asp:Label ID="N" runat="server" Text="Username" AssociatedControlID="username"></asp:Label>
     <asp:TextBox  ID="username" runat="server" ></asp:TextBox>    
       
     <asp:Label ID="V" runat="server" Text="Nachname" AssociatedControlID="nachname"></asp:Label>
        <asp:TextBox  CssClass="form-control" ID="nachname"  runat="server" ></asp:TextBox> 
       <br />
     <asp:Label ID="S" runat="server" Text="Straße" AssociatedControlID="straße"></asp:Label>

     <asp:TextBox  CssClass="form-control" ID="straße" runat="server"></asp:TextBox>           
    
            <asp:Label ID="H" runat="server" Text="Hausnummer" AssociatedControlID="hausnummer"></asp:Label>
       
     <asp:TextBox CssClass="form-control" ID="hausnummer" runat="server" TextMode="Number"></asp:TextBox>
       <br />
      </div>
     <section  id="Teil1" runat="server">
              <asp:Label ID="P" runat="server" Text="PLZ" AssociatedControlID="plz"></asp:Label>
     <asp:TextBox CssClass="form-control" ID="plz" runat="server" TextMode="Number"></asp:TextBox>
 
             <asp:Label ID="O" runat="server" Text="Ort" AssociatedControlID="ort"></asp:Label>
     <asp:TextBox CssClass="form-control" ID="ort" runat="server"></asp:TextBox>
             <br />
            <asp:Label ID="L" runat="server" Text="Land"  AssociatedControlID="land"></asp:Label>
     <asp:TextBox CssClass="form-control" ID="land" runat="server"></asp:TextBox>
       
            <asp:Label ID="T" runat="server" Text="Telefon" AssociatedControlID="telefon"></asp:Label>
     <asp:TextBox CssClass="form-control" ID="telefon" runat="server" TextMode="Phone"></asp:TextBox>
     
            <asp:Label ID="mo" runat="server" Text="mobil" AssociatedControlID="mobil"></asp:Label>
     <asp:TextBox CssClass="form-control" ID="mobil" runat="server" TextMode="Phone"></asp:TextBox>
           <br />
    <asp:Button ID="Kbutton" runat="server" Text="weiter" OnCommand="butnNext_Command" CommandArgument="1"/>
    </section>
        </div>
   
    <section id="Schritt2"  runat="server">
    <h5>Zahlungsinformationen</h5>
   
        <asp:Label ID="labelIban" runat="server" AssociatedControlID="iban" Text="IBAN"></asp:Label>
        <asp:TextBox CssClass="form-control" ID="iban" runat="server"></asp:TextBox>
    
    <div>
        <asp:Label ID="labelBic" runat="server" AssociatedControlID="bic" Text="BIC"></asp:Label>
        <asp:TextBox CssClass="form-control" ID="bic" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="Kbutton2" runat="server" Text="weiter" OnCommand="butnNext_Command" CommandArgument="2" />
    </div>
</section>

<section id="Schritt3"  runat="server">
    <h5>Zugangsdaten</h5>
    <asp:Label ID="E" runat="server" Text="Email" AssociatedControlID="email"></asp:Label>
   
    <asp:TextBox CssClass="form-control" ID="email" runat="server" TextMode="Email"></asp:TextBox>
    <Asp:label  ID="pass1" runat="server" AssociatedControlID="passwort1" Text="Passwort"></Asp:label>
   
    <Asp:TextBox CssClass="form-control" ID="passwort1" runat="server"  TextMode="Password" name="Password1"/>
    
        <asp:Label ID="pass2" runat="server" Text="wiederhole Passwort" AssociatedControlID="passwort2"></asp:Label>
        <asp:TextBox CssClass="form-control" ID="passwort2" runat="server" TextMode="Password" name="Password2"></asp:TextBox>
    
    <div>
        <asp:Button ID="Kbutton3" runat="server" Text="Konto erstellen" OnCommand="butnNext_Command" CommandArgument="3" />
    </div>
</section>

</asp:Content>