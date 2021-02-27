<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ReporteReservas.aspx.cs" Inherits="Presidencia.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

      <div id="content" class="p-4 p-md-5 pt-5">

        <h2 class="mb-4">Reporte de Reservas de Auditorio Benito Juárez</h2>

        <div class="card" >
            <div class="card-body">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                           

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <label class="h6">Número de reserva :</label>
                                    <asp:TextBox type="text" runat="server" class="form-control" ID="txtNumReserva" />
                                </div>
                                <div class="form-group col-md-12">
                                    <label class="h6">Nombre del evento :</label>
                                    <asp:TextBox type="text" runat="server" class="form-control" ID="txtNombreEvento" />
                                </div>
                                
                                <div class="form-group col-md-6">
                                    <label class="h6">Fecha Inicio:</label>
                                    <asp:TextBox TextMode="Date" runat="server" class="form-control" ID="txtFechaIni" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label class="h6">Fecha Fin:</label>
                                    <asp:TextBox TextMode="Date" runat="server" class="form-control" ID="txtFechaFin" />
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
                        
                                <asp:GridView ID="gridReservas" CssClass="StyleGridV" runat="server" Width="100%"
                                    AutoGenerateColumns="False" Height="160px">
                                    <Columns>

                                        <asp:BoundField DataField="IdReserva" HeaderText="No. Audiencia" Visible="false" />
                                        <asp:BoundField DataField="Evento" HeaderText="Persona" />
                                        <asp:BoundField DataField="FechaIni" HeaderText="Fecha Inicio" DataFormatString="" />
                                        <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" />
                                        <asp:BoundField DataField="InfoAdicional" HeaderText="Información Adicional" />
                                        
                              
                                    </Columns>
                                </asp:GridView>

                                <br />
                                <div class="container mb-lg-5">
                                <div class="row">
                                    <div class="col-md-4 offset-md-4 justify-content-center align-items-center minh-100">
                                        <asp:Button runat="server" type="submit" ID="Exportar" class="btn btn-primary btn-block" Text="Exportar" OnClick="Exportar_Click" ></asp:Button>
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
