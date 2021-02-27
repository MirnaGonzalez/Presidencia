<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ReporteAudiencias.aspx.cs" Inherits="Presidencia.ReporteAudiencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

      <div id="content" class="p-4 p-md-5 pt-5">

        <h2 class="mb-4">Reporte de Audiencias de Presidencia </h2>

        <div class="card" >
            <div class="card-body">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                           

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <label class="h6">Número de audiencia :</label>
                                    <asp:TextBox type="text" runat="server" class="form-control" ID="txtNumAudiencia" />
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="h6">Nombre de la persona :</label>
                                    <asp:TextBox type="text" runat="server" class="form-control" ID="txtNombrePersona" />
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="h6">Tipo visita :</label>
                                    <asp:DropDownList type="text" runat="server" class="form-control" ID="ddlTipoVisita" >
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Interna</asp:ListItem>
                                        <asp:ListItem>Externa</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="h6">Tipo asunto :</label>
                                    <asp:DropDownList type="text" runat="server" class="form-control" ID="ddlTipoAsunto" >
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Judicial</asp:ListItem>
                                        <asp:ListItem>Laboral</asp:ListItem>
                                        <asp:ListItem>Personal</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-md-6">
                                    <label class="h6">Fecha Inicio:</label>
                                    <asp:TextBox TextMode="Date" runat="server" class="form-control" ID="txtFechaIni" >01/01/2021</asp:TextBox>
                                </div>
                                 <div class="form-group col-md-6">
                                    <label class="h6">Fecha Fin:</label>
                                    <asp:TextBox TextMode="Date" runat="server" class="form-control" ID="txtFechaFin" >28/02/2021</asp:TextBox>
                                </div>
                                
                            </div>
                                                        
                        
                            <div class="form-row">
                             
                                                       
                            <div class="container mb-lg-5">
                                <div class="row">
                                    <div class="col-md-4 offset-md-4 justify-content-center align-items-center minh-100">
                                        <asp:Button runat="server" type="submit" ID="btnBuscar" class="btn btn-primary btn-block" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
                                    </div>
                                </div>

                            </div>


                     <!-- mostrar datos tabla -->
                    <div runat="server" id="DivMostrar" visible="false" class="container mb-lg-5">
                        <fieldset style="border-color: black; width: 95%; margin-left: 11px;">
                            <br />

                            <div class="auto-style2">
                                 <asp:Label ID="LblTotal" runat="server" Width="166px" CssClass="auto-style6" Font-Bold="True"></asp:Label>
                            </div>

                            <br />


                            <div>
                        
                                <asp:GridView ID="gridAudiencias" CssClass="StyleGridV" runat="server" Width="98%"
                                    AutoGenerateColumns="False" Height="160px">
                                    <Columns>

                                        <asp:BoundField DataField="IdAudiencia" HeaderText="No. Audiencia" />
                                        <asp:BoundField DataField="Persona" HeaderText="Persona" />
                                        <asp:BoundField DataField="TipoVisita" HeaderText="Tipo Visita" />
                                        <asp:BoundField DataField="TipoAsunto" HeaderText="Tipo Asunto" />
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                        <asp:BoundField DataField="FechaIni" HeaderText="Fecha Inicio"  />
                                        <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" />
                                        <asp:BoundField DataField="InfoAdicional" HeaderText="Información Adicional" />
                                        
                              
                                    </Columns>
                                </asp:GridView>

                                <br />
                                <div class="container mb-lg-5">
                                <div class="row">
                                    <div class="col-md-4 offset-md-4 justify-content-center align-items-center minh-100">
                                        <asp:Button runat="server" type="submit" ID="Exportar" class="btn btn-primary btn-block" Text="Exportar" ></asp:Button>
                                    </div>
                                </div>

                            </div>


                             </fieldset>
                          </div>



                  </div>

                  </ContentTemplate>
               </asp:UpdatePanel>
          
            
            </div>


        </div>


    </div>


   </div>
  
</asp:Content>
