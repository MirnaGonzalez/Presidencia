<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presidencia.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .footer {
            position: fixed;
            bottom: 0;
            color: white;
            text-align: center;
        }



        .avatar {
  display: block;
  width: 120px;
  height: 120px;
  border-radius: 50%;
  overflow: hidden;
  margin: 0 auto;
}
    </style>


    <div id="content" class="pt-5">
        <asp:Image ID="imgBannerSup" runat="server" class="img-fluid" ImageUrl="~/images/CINTILLO-SUPERIOR.png" />

       	<div class="text-center" style="margin-top:5%">
               <img src="images/PoderJudicialHgo.png" width="30%" />
	   </div>

        <div class="footer">

            <asp:Image ID="imgBannerInf" runat="server" class="img-fluid" ImageUrl="~/images/CINTILLO-INFERIOR.png" />


        </div>
    </div>





</asp:Content>
