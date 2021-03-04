<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ConsAudienciaFoto.aspx.cs" Inherits="Presidencia.ConsAudienciaFoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div id="content" class="p-4 p-md-5 pt-5">

        <h2 class="mb-4">Consulta de Audiencia </h2>

        <div class="col-lg-12">
            <asp:LinkButton runat="server" ID="LinkbtnRegresar" class="btn btn-link btn-lg" OnClick="LinkButton1_Click" > <%-- OnClientClick="history.go(-1); return false;" > --%>
                               <i class="fa fa-arrow-circle-left" aria-hidden="true"></i> Regresar
            </asp:LinkButton>
        </div>

        <fieldset style="border-color: black; width: 95%; margin-left: 11px;">




            <br />

            <br />
        </fieldset>


        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>



                    <div class="card col-12 ">


                        <div class="row no-gutters">
                            <div class="col-md-4">
                                <asp:Image ID="imgFoto" runat="server" class="img-fluid" Visible="False" />
                            </div>

                            <div class="col-md-8">
                                <div class="card-header mb-3">Detalles de audiencia</div>
                                <div class="card-body">
                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Label ID="lblAudiencia" runat="server" CssClass="h6" Font-Bold="True">Número de audiencia :</asp:Label>
                                        </div>
                                        <div class=" col-md-8">
                                            <asp:Label ID="lblAudiencia0" runat="server" CssClass="h6"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Label ID="lblPersona" runat="server" CssClass="h6" Font-Bold="True">Persona :</asp:Label>
                                        </div>
                                        <div class=" col-md-8">
                                            <asp:Label ID="lblPersona0" runat="server" CssClass="h6"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Label ID="lblTipoVisita" runat="server" CssClass="h6" Font-Bold="True">Tipo Visita :</asp:Label>
                                        </div>
                                        <div class=" col-md-8">
                                            <asp:Label ID="lblTipoVisita0" runat="server" CssClass="h6"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Label ID="lblTipoAsunto" runat="server" CssClass="h6" Font-Bold="True">Tipo Asunto :</asp:Label>
                                        </div>
                                        <div class=" col-md-8">
                                            <asp:Label ID="lblTipoAsunto0" runat="server" CssClass="h6"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Label ID="lblTelefono" runat="server" CssClass="h6" Font-Bold="True">Teléfono :</asp:Label>
                                        </div>
                                        <div class=" col-md-8">
                                            <asp:Label ID="lblTelefono0" runat="server" CssClass="h6"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Label ID="lblFecha" runat="server" CssClass="h6" Font-Bold="True">Fecha :</asp:Label>
                                        </div>
                                        <div class=" col-md-8">
                                            <asp:Label ID="lblFecha0" runat="server" CssClass="h6"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="row">

                                        <div class="col-md-4">
                                            <asp:Label ID="lblInfoAdicional" runat="server" CssClass="h6" Font-Bold="True">Información Adicional :</asp:Label>
                                        </div>
                                        <div class=" col-md-8">
                                            <asp:Label ID="lblInfoAdicional0" runat="server" CssClass="h6"></asp:Label>
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>

                    </div>



                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
