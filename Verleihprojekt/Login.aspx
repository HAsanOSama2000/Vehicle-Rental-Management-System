<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VerleihProjekt.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body{
            color: rgb(0,67,122);
       }
        input{
                /*border: 1px solid rgb(17,92,155);
                width: 13em;
                padding: 5px;
                margin: 3px;
                border-radius: 50px;
                backdrop-filter: blur(30px);*/
        }
        #MainContent_Kbutton{
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
        .TextLabel {
           position:relative;
             left:-2px;
            top: -3px;
            height: 26px;
            margin-bottom: 0px;
        }
        .Link{
            position:relative;
            left:5px;
            top: -6px;
            height: 26px;
            margin-bottom: 0px;   
            font-size:small;
        } .Link2{
            position:relative;
            left:-2px;
            top: 2px;
            height: 26px;
            margin-bottom: 0px;   
            font-size:small;
        }
        .cp{
            position: relative; top: 5px; left:50px;
        }
        #MainContent_CheckAdmin{
            position: relative; top:1px;

        }
          


    </style>
    <main aria-labelledby="title">
        <br />
        <h2 id="title"><%: Title %></h2>
        <div><asp:Label ID="Fehler" runat="server" CssClass="attention"></asp:Label></div>
        <br />
        <Asp:label ID="N"  runat="server" CssClass="TextLabel"  AssociatedControlID="username">Username</Asp:label>
        <br />
        
        <Asp:Textbox ID = "username" runat="server" CssClass="form-control" name="Username" ValidateRequestMode="Enabled"  />
       <h6>
        <asp:RequiredFieldValidator ID="NameRequired" runat="server" CssClass="Link2" ControlToValidate="username" ErrorMessage="Bitte den Username eingeben!. " ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
       </h6> 
         
        <Asp:label  ID="P" runat="server"  Text="Passwort" CssClass="TextLabel" AssociatedControlID="passwort" 
            ></Asp:label> 
        <br />
        <Asp:Textbox ID="passwort" runat="server"  CssClass="form-control" ValidateRequestMode="enabled" TextMode="Password" name="Password"  />
       
         <h6  CssClass="form-label" >
             <br />
             <a class="Link" href="Register.aspx"> Account erstellen</a><%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; --%> 
             <asp:RequiredFieldValidator ID="PasswortRequired" CssClass="Link" runat="server" Height="16px"  ControlToValidate="passwort" ErrorMessage="Bitte das Passswort eingeben!. " ForeColor="Red" style="margin-bottom: 0px" Width="325px"></asp:RequiredFieldValidator>
           </h6>
        
        <Asp:Button  ID="Kbutton" CssClass="btn btn-primary" runat="server" Text="Bestätigen" type="submit" OnClick="Log_Click"/>
        
        <asp:CheckBox ID="CheckAdmin"  class= "cp" runat="server" text="&nbsp;Als Admin einloggen" /> </main>
</asp:Content>
