<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ReservaAuditorio.aspx.cs" Inherits="Presidencia.ReservaAuditorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/CalendarioAuditorio.js" type="text/javascript"></script>

    <script>
        function myFunction() {
            var mql = window.matchMedia("(orientation: portrait)");

            // If there are matches, we're in portrait
            if (mql.matches) {
                // Portrait orientation
                alert("Please use Portrait!");
            } else {
                // Landscape orientation
                alert("Please use Landscape!");

            }
        }
    </script>
    
    <div id="content" class="p-4 p-md-5 pt-5">

          <div class="form-row">
               <div class="form-group col-md-12">
            <div id='calendar'></div>

              </div>
          </div>
    </div>





</asp:Content>
