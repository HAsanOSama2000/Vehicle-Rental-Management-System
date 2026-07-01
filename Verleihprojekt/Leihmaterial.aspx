<%@ Page Title="LeihMaterial" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeihMaterial.aspx.cs" Inherits="VerleihProjekt.LeihMaterial"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
     

    body{
    color: rgb(0,67,122);
} 


     table{
          border: solid 1px black;
      }
      th{
          border: solid 1px black;
          margin-left:2em;
          padding:10px;
      }
      .page{
          text-decoration:none;
      }
      td,tr{
           
          border : solid 1px black;
          margin-left:2em;
          padding:7px;
      }

      .End {
          border-top-color: goldenrod;
      }
      .GridPager a,
      .GridPager span {
            display: inline-block;
            padding: 0px 9px;
            margin-right: 4px;
            border-radius: 3px;
            border: solid 1px #c0c0c0;
            background: #e9e9e9;
            box-shadow: inset 0px 1px 0px rgba(255,255,255, .8), 0px 1px 3px rgba(0,0,0, .1);
            font-size: .875em;
            font-weight: bold;
            text-decoration: none;
            color: #717171;
            text-shadow: 0px 1px 0px rgba(255,255,255, 1);
        }
        
        .GridPager a {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }
        
        .GridPager span {
        
            background: #F1B434 ; /*#616161;*/
            box-shadow: inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8);
            color: #f0f0f0;
            text-shadow: 0px 0px 3px rgba(0,0,0, .5);
            border: 1px solid #3AC0F2;
        }

    

    </style>

  

        <asp:Label  runat="server" ID="mErrorText" CssClass="alert-warning" Font-Bold="true" ForeColor="DarkRed"></asp:Label>             
        
  
        <br />
   

    
  
    <div runat="server" id="LeihMaterialData"> 
       <h1 <%--style="text-decoration:underline"--%>>Leihmaterial </h1>
        <h4>Hier finden sie alle Leihobjekte</h4>


    <br/>
          <asp:label id="Message"
                forecolor="Red"
                runat="server" />

 <asp:GridView ID="LeihmaterialData2"  allowpaging="True" 
     ondatabound="LeihmaterialData2_DataBound"
     onpageindexchanging="LeihmaterialData2_PageIndexChanging"  
     onrowcancelingedit="LeihmaterialData2_RowCancelingEdit"
     onpageindexchanged="LeihmaterialData2_PageIndexChanged" CssClass="table table-hover table-striped" GridLines="None"
        runat="server" >
        
            
          <%-- 
              Option to add images:
              <Columns>
                <asp:ImageField HeaderText="Image" AlternateText="hier könnten Bilder"> 
                  
                </asp:ImageField>
            </Columns>--%>
        
            <pagersettings mode="Numeric"
          position="Top"            

          pagebuttoncount="10" 
                />
                 
            <pagerstyle backcolor="DarkBlue"
                height="20px"
                verticalalign="Top" 
                CssClass=" GridPager"
              
                Font-Bold="true"
                
          horizontalalign="Center"/>
                    
        </asp:GridView>
  
</div>
    
</asp:Content>
