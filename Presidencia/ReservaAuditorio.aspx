<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ReservaAuditorio.aspx.cs" Inherits="Presidencia.ReservaAuditorio" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/CalendarioAuditorio.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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

        function mostrarModal() {
            $('#exampleModal').modal('show')
        }


        function loadEvents() {
            var calendarEl = document.getElementById('calendar');
            calendarEl.next();
        }

        function cancelar() {

            $("[id*='txtNombreEvento']").val('');
            $("[id*='txtFecha']").val('');
            $("[id*='txtHoraInicio']").val('');
            $("[id*='txtHoraFinal']").val('');
            $("[id*='txtInformacion']").val('');
            $('#exampleModal').modal('hide')
        }

    </script>

    <div id="content" class="p-4 p-md-5 pt-5">

        <div class="form-row">
        <h2 class="mb-4 text-center">Reservas de Auditorio Benito Juarez del PJEH</h2>

            <div class="form-group col-md-12">
                <div id='calendar'></div>

            </div>
        </div>
    </div>

 

    <asp:HiddenField ID="hiddenIdReserva" runat="server" />
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Registro</h5>
                  <%--  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>--%>
                </div>
            
                <div class="modal-body">
                    <div class="form-group wrap-input100 validate-input m-b-26" data-validate="El usuario es requerido">
                        <label for="recipient-name" class="col-form-label">Nombre de evento:</label>
                        <asp:TextBox ID="txtNombreEvento" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Fecha:</label>
                        <asp:TextBox ID="txtFecha" class="form-control" runat="server" TextMode="Date" ></asp:TextBox>
                    </div>
                  
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Hora Inicio:</label>
                        <asp:TextBox ID="txtHoraInicio" class="form-control" runat="server" TextMode="Time"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Hora Final:</label>
                        <asp:TextBox ID="txtHoraFinal" class="form-control" runat="server" TextMode="Time"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Informacion Adicional:</label>
                        <asp:TextBox ID="txtInformacion" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
     <%--      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
                <div class="modal-footer">
                     <asp:Button ID="btnCancelar" runat="server" class="btn btn-secondary" Text="Cancelar" OnClientClick="cancelar();" />
                    <asp:Button ID="btnEditar" runat="server" class="btn btn-primary" Visible="true" Text="Editar" OnClick="btnEditar_Click" />
<%--                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                    <%--<button type="button" class="btn btn-primary">Send message</button>--%>
                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" Text="Guardar"  OnClick="btnGuardar_Click" />
                   <div class=" form-row text-left">
                    <asp:Button ID="btnEliminar" runat="server" class="btn btn-danger" Visible="true" Text="Eliminar"  OnClick="btnEliminar_Click" />
                   </div>
                </div>  

<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>

</asp:Content>