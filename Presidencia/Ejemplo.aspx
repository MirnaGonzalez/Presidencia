<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Ejemplo.aspx.cs" Inherits="Presidencia.Ejemplo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

      <div id="content" class="p-4 p-md-5 pt-5">

        <h2 class="mb-4">Solicitud de Reserva</h2>

        <div class="card" >
            <div class="card-body">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>                         
                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <label class="h6">Nombre del Evento</label>
                                    <asp:TextBox type="text" runat="server" class="form-control" ID="txt_NombreEvento" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label class="h6">Fecha</label>
                                    <asp:TextBox TextMode="Date" runat="server" class="form-control" ID="txtFecha" />
                                </div>
                                 <div class="form-group col-md-6">
                                    <label class="h6">Hora</label>
                                    <asp:TextBox TextMode="Time" runat="server" class="form-control" ID="txtHora" />
                                </div>
                            </div>

                            <div class="form-row">
                               
                                <div class="form-group col-md-12">
                                    <label class="h6">Información adicional</label>
                                    <asp:TextBox type="text" runat="server" class="form-control" ID="txt_informacion" />

                                </div>
                                
                            </div>

                            
                        
                            <div class="form-row">
                             
                                                       
                            <div class="container mb-lg-5">
                                <div class="row">
                                    <div class="col-md-4 offset-md-4 justify-content-center align-items-center minh-100">
                                        <asp:Button runat="server" type="submit" ID="btnAlta" class="btn btn-primary btn-block" Text="Guardar"></asp:Button>
                                    </div>
                                </div>

                                <div class="col-md-4 offset-md-4">
                                    <asp:Button runat="server" type="submit" class="btn btn-sm btn-link btn-block" ID="btn_cancelar" Text="Cancelar" ></asp:Button>
                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                

                </div>
            </div>
        </div>
    </div>
</asp:Content>
