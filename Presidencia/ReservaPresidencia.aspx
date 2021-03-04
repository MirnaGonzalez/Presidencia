<%@ Page Title="" ClientIDMode="static" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ReservaPresidencia.aspx.cs" Inherits="Presidencia.ReservaPresidencia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>

    <script src="Scripts/CalendarioPresidencia.js" type="text/javascript"></script>
    <%--<script type="text/javascript">  
    $(function () {
        $('[id*=gridPersonas]').footable();


    });
</script>--%>


    <div id="content" class="p-4 p-md-5 pt-5">

        <h2 class="mb-4">Agenda de Presidencia</h2>
        <div class="card">
            <div class="card-body">
                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAgregar" />
                    </Triggers>
                    <ContentTemplate>--%>
                <div id="divCalendario" runat="server">
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <div id='calendar'></div>
                        </div>
                    </div>
                </div>


                <asp:HiddenField ID="hfIdAudiencia" runat="server" />


                <div id="divFormulario" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-3">
                            <asp:LinkButton runat="server" ID="LinkDetalle" class="btn btn-link btn-lg" OnClick="LinkDetalle_Click"> <%-- OnClientClick="history.go(-1); return false;" > --%>
                               <i class="fa fa-file-archive-o " aria-hidden="true"></i> Ver Detalle
                            </asp:LinkButton>
                        </div>
                        <div class="col-lg-6">
                        </div>
                        <div class="col-lg-3">
                            <asp:LinkButton runat="server" ID="LinkButton1" class="btn btn-link btn-lg" OnClick="LinkButton1_Click"> <%-- OnClientClick="history.go(-1); return false;" > --%>
                               <i class="fa fa-arrow-circle-left" aria-hidden="true"></i> Regresar
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div>

                        <div class="form-row mb-4">
                            <div class="card col-12">
                                <div class="card-header">
                                    Nombre de la persona
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="form-group col-md-4">
                                            <label class="h6">Nombre</label>
                                            <asp:TextBox type="text" runat="server" class="form-control" ID="txt_Nombre" />
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label class="h6">Apellido Paterno</label>
                                            <asp:TextBox type="text" runat="server" class="form-control" ID="txt_AP" />
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label class="h6">Apellido Materno</label>
                                            <asp:TextBox type="text" runat="server" class="form-control" ID="txt_AM" />
                                        </div>
                                        <%--   <div class="form-group col-md-2" style="display: flex; align-items: center; justify-content: center; min-height: 100%;">
                                        <button id="Button1" runat="server" type="submit" class="btn btn-link btn-sm mr-2" data-toggle="tooltip" data-placement="top" title="Adjuntar Foto">
                                            <i class="fa fa-photo icon">Adjuntar Foto</i></button>
                                    </div>--%>

                                        <div class="form-group col-md-8">
                                            <div class="form-row">
                                                <div class="form-group col-md-11">
                                                    <label class="h6">Adjuntar Fotografia</label>
                                                    <asp:FileUpload ID="fuImage" runat="server" accept=".png,.jpg,.jpeg,.gif" CssClass="Boton" />
                                                    <asp:Label ID="LblAdjuntar" runat="server" Text=""></asp:Label>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group col-md-4" style="display: flex; align-items: center; justify-content: center; min-height: 100%;">
                                            <button id="btnAgregar" runat="server" type="submit" onserverclick="btnAgregar_ServerClick" class="btn btn-success mr-2" data-toggle="tooltip" data-placement="top" title="Agregar">
                                                <i runat="server" id="iAgregar" class="fa fa-user-plus icon">Agregar</i>
                                            </button>

                                            <%--<asp:Button runat="server" type="submit" class="btn btn-sm btn-link btn-block" ID="btnAdd" Text="Agregar" OnClick="btnAdd_Click"></asp:Button>--%>
                                        </div>

                                        <div class="col-md-12" style="display: flex; align-items: center; justify-content: center; min-height: 100%;">
                                            <div class="table-responsive">
                                                <asp:GridView ID="gridPersonas" runat="server" AutoGenerateColumns="false" OnRowCommand="gridPersonas_RowCommand"
                                                    CssClass="table  table-striped table-hover table-bordered">
                                                    <Columns>

                                                        <asp:BoundField DataField="IdPersona" Visible="false" />
                                                        <asp:TemplateField HeaderText="#" ItemStyle-CssClass="text-center " ItemStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="text-center" />
                                                        <asp:BoundField DataField="APaterno" HeaderText="A. Paterno" HeaderStyle-CssClass="text-center" />
                                                        <asp:BoundField DataField="AMaterno" HeaderText="A. Materno" HeaderStyle-CssClass="text-center" />


                                                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="Modificar">
                                                            <ItemTemplate>

                                                                <%--          <button id="btnAgregar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Modificar"  type="submit"
                                                                 class="btn btn-info mr-2" data-toggle="tooltip" data-placement="top" title="Modificar">
                                                         <i class="fa fa-edit icon"></i>
                                                           </button>--%>

                                                                <asp:LinkButton runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Modificar" CssClass="btn btn-info mr-2">
                                                                <i class="fa fa-eraser icon"></i></i>  </asp:LinkButton>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="Eliminar">
                                                            <ItemTemplate>

                                                                <%--         <button id="btnAgregar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar"  type="submit"
                                                                 class="btn btn-danger mr-2" data-toggle="tooltip" data-placement="top" title="Eliminar">
                                                         <i class="fa fa-eraser icon"></i>
                                                           </button>--%>

                                                                <asp:LinkButton runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar" CssClass="btn btn-danger mr-2">
                                                                <i class="fa fa-eraser icon"></i></i>  </asp:LinkButton>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="thead-dark" />
                                                </asp:GridView>

                                            </div>
                                        </div>
                                        <div class="col-md-12" style="display: flex; align-items: center; justify-content: center; min-height: 100%;">
                                            <div class="table-responsive">
                                                <asp:GridView ID="gridModificar" runat="server" AutoGenerateColumns="false" OnRowCommand="gridModificar_RowCommand"
                                                    CssClass="table  table-striped table-hover table-bordered">
                                                    <Columns>

                                                        <asp:BoundField DataField="IdPersona" Visible="false" />
                                                        <asp:TemplateField HeaderText="#" ItemStyle-CssClass="text-center " ItemStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="text-center" />
                                                        <asp:BoundField DataField="APaterno" HeaderText="A. Paterno" HeaderStyle-CssClass="text-center" />
                                                        <asp:BoundField DataField="AMaterno" HeaderText="A. Materno" HeaderStyle-CssClass="text-center" />


                                                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="Modificar">
                                                            <ItemTemplate>

                                                                <%--          <button id="btnAgregar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Modificar"  type="submit"
                                                                 class="btn btn-info mr-2" data-toggle="tooltip" data-placement="top" title="Modificar">
                                                         <i class="fa fa-edit icon"></i>
                                                           </button>--%>

                                                                <asp:LinkButton runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Modificar" CssClass="btn btn-info mr-2">
                                                                <i class="fa fa-edit icon"></i></i>  </asp:LinkButton>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="Eliminar">
                                                            <ItemTemplate>

                                                                <%--         <button id="btnAgregar" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar"  type="submit"
                                                                 class="btn btn-danger mr-2" data-toggle="tooltip" data-placement="top" title="Eliminar">
                                                         <i class="fa fa-eraser icon"></i>
                                                           </button>--%>

                                                                <asp:LinkButton runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar" CssClass="btn btn-danger mr-2">
                                                                <i class="fa fa-eraser icon"></i></i>  </asp:LinkButton>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="thead-dark" />
                                                </asp:GridView>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-row mb-4">
                            <div class="card col-12">
                                <div class="card-header">
                                    Datos de visita
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="form-group col-md-4">
                                            <label class="h6">Tipo de Visita</label>
                                            <asp:DropDownList ID="ddlTipoVisita" CssClass="form-control" data-style="btn-primary" runat="server">
                                                <asp:ListItem Value="SN">Seleccione aquí</asp:ListItem>
                                                <asp:ListItem Value="INTERNA">INTERNA</asp:ListItem>
                                                <asp:ListItem Value="EXTERNA">EXTERNA</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label class="h6">Tipo de Asunto</label>
                                            <asp:DropDownList ID="ddlTipoAsunto" CssClass="form-control" data-style="btn-primary" runat="server">
                                                <asp:ListItem Value="SN">Seleccione aquí</asp:ListItem>
                                                <asp:ListItem Value="JUDICIAL">JUDICIAL</asp:ListItem>
                                                <asp:ListItem Value="LABORAL">LABORAL</asp:ListItem>
                                                <asp:ListItem Value="PERSONAL">PERSONAL</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="form-group col-md-4">
                                            <label class="h6">Teléfono</label>
                                            <asp:TextBox TextMode="Phone" runat="server" class="form-control" ID="txtTel" />

                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="form-row mb-4">
                            <div class="card col-12">
                                <div class="card-header">
                                    Fecha y duración
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="form-group col-md-4">
                                            <label for="message-text" class="col-form-label">Fecha:</label>
                                            <asp:TextBox ID="txtFecha" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                        </div>

                                        <div class="form-group col-md-4">
                                            <label for="message-text" class="col-form-label">Hora Inicio:</label>
                                            <asp:TextBox ID="txtHoraInicio" class="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label for="message-text" class="col-form-label">Hora Final:</label>
                                            <asp:TextBox ID="txtHoraFinal" class="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="form-row">

                            <div class="form-group col-md-12">
                                <label class="h6">Información adicional</label>
                                <asp:TextBox type="text" runat="server" class="form-control" ID="txt_informacion" />

                            </div>

                        </div>

                        <asp:HiddenField ID="hfIndexSeleccionado" runat="server" />

                        <div class="form-row">
                            <div class="container mb-lg-5">
                                <div class="row">
                                    <div class="col-md-4 offset-md-4 justify-content-center align-items-center minh-100">
                                        <asp:Button runat="server" type="submit" ID="btnAlta" class="btn btn-success btn-block" Text="Guardar" OnClick="btnAlta_Click"></asp:Button>
                                    </div>
                                </div>

                                <div class="col-md-4 offset-md-4">
                                    <asp:Button runat="server" type="submit" class="btn btn-sm btn-link btn-block" ID="btn_cancelar" Text="Cancelar" OnClick="btn_cancelar_Click"></asp:Button>
                                </div>

                            </div>
                        </div>


                        <div class="form-row">
                            <div class="container mb-lg-5">
                                <div class="row">
                                    <div class="col-md-4 offset-md-4 justify-content-center align-items-center minh-100">
                                        <asp:Button runat="server" type="submit" ID="btnEliminarAudiencia" class="btn btn-danger btn-block" Text="Eliminar" OnClick="btnEliminarAudiencia_Click" Visible="false"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <%--     </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
</asp:Content>
