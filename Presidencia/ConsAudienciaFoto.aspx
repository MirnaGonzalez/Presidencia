<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ConsAudienciaFoto.aspx.cs" Inherits="Presidencia.ConsAudienciaFoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

      <div id="content" class="p-4 p-md-5 pt-5">

        <h2 class="mb-4">Consulta de Audiencia </h2>

           <div class="form-row">
               <asp:Image ID="imgImagen" runat="server" ImageUrl="C:/Users/Mirna/Documents/Visual%20Studio%202019/GIT/Presidencia/Presidencia/images/FotoConCamaraWebExterna.jpg" AlternateText="kyocode" style="width: 294px; height: 171px" />
 
           </div>


        <div class="card" >
            <div class="card-body">
                <div>
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                    

                            <div class="form-row">


                                <div class="form-group col-md-12">
                                    <label class="h6">Número de audiencia :</label>

                                </div>
                                <div class="form-group col-md-12">
                                    <label class="h6">Nombre de la persona :</label>

                                </div>
                                <div class="form-group col-md-12">
                                    <label class="h6">Tipo visita :</label>

                                </div>
                                <div class="form-group col-md-12">
                                    <label class="h6">Tipo asunto :</label>

                                    </asp:DropDownList>
                                </div>

                                
                            </div>
                                                        
                        
                            <div class="form-row">
                             
                                                       
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
