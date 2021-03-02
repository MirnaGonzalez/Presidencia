<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ConsAudienciaFoto.aspx.cs" Inherits="Presidencia.ConsAudienciaFoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

      <div id="content" class="p-4 p-md-5 pt-5">

        <h2 class="mb-4">Consulta de Audiencia </h2>

           <fieldset style="border-color: black; width: 95%; margin-left: 11px;">
           



                <br />
               
                   <br />
           </fieldset>

        <div class="card" >
            <div class="card-body">
                <div>
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                    
                            <div class="table table-responsive">

                    <span class="login100-form-avatar">
						         <asp:Image ID="imgFoto" runat="server"  style="width: 281px; height: 168px" />
					</span>

                                <div class="form-group col-md-12">
                                   
                                     <asp:Label ID="lblAudiencia" runat="server" Width="15%" CssClass="h6" Font-Bold="True" >Número de audiencia :</asp:Label>
                                     <asp:Label ID="lblAudiencia0" runat="server" CssClass="h6"  Width="80%"></asp:Label>
                                </div>
                                <div class="form-group col-md-12">
                                     <asp:Label ID="lblPersona" runat="server" Width="15%" CssClass="h6" Font-Bold="True" >Persona :</asp:Label>
                                    <asp:Label ID="lblPersona0" runat="server" CssClass="h6"  Width="80%"></asp:Label>
                                </div>
                                <div class="form-group col-md-12">
                                     <asp:Label ID="lblTipoVisita" runat="server" Width="15%" CssClass="h6" Font-Bold="True" >Tipo Visita :</asp:Label>
                                    <asp:Label ID="lblTipoVisita0" runat="server" CssClass="h6"  Width="80%"></asp:Label>
                                </div>
                                <div class="form-group col-md-12">
                                     <asp:Label ID="lblTipoAsunto" runat="server" Width="15%" CssClass="h6" Font-Bold="True" >Tipo Asunto :</asp:Label>   
                                    <asp:Label ID="lblTipoAsunto0" runat="server" CssClass="h6"  Width="80%"></asp:Label>
                                </div>
                                <div class="form-group col-md-12">
                                     <asp:Label ID="lblTelefono" runat="server" Width="15%" CssClass="h6" Font-Bold="True" >Teléfono :</asp:Label> 
                                    <asp:Label ID="lblTelefono0" runat="server" CssClass="h6"  Width="80%"></asp:Label>
                                </div>
                                <div class="form-group col-md-12">
                                     <asp:Label ID="lblFecha" runat="server" Width="15%" CssClass="h6" Font-Bold="True" >Fecha :</asp:Label>     
                                    <asp:Label ID="lblFecha0" runat="server" CssClass="h6"  Width="80%"></asp:Label>
                                </div>
                                <div class="form-group col-md-12">
                                     <asp:Label ID="lblInfoAdicional" runat="server" Width="15%" CssClass="h6" Font-Bold="True" >Información Adicional :</asp:Label>   
                                    <asp:Label ID="lblInfoAdicional0" runat="server" CssClass="h6"  Width="80%"></asp:Label>
                                </div>
                            </div>                                                      
                
                            
                                                       
                            <div class="container mb-lg-5">
                                <div class="row">
                                    <div class="col-md-4 offset-md-4 justify-content-center align-items-center minh-100">
                                        <asp:Button runat="server" type="submit" ID="btnCerrar" class="btn btn-primary btn-block" Text="Cerrar"></asp:Button>
                                    </div>
                                </div>

                            </div>



                 </ContentTemplate>
               </asp:UpdatePanel>
 
            
            </div>


        </div>


    </div>


   </div>
  
</asp:Content>
