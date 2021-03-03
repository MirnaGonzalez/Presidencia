<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgendaLogin.aspx.cs" Inherits="Presidencia.AgendaLogin" %>

<html lang="es">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="StyleLogin/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="StyleLogin/vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="StyleLogin/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="StyleLogin/fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="StyleLogin/vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="StyleLogin/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="StyleLogin/vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="StyleLogin/vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="StyleLogin/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="StyleLogin/css/util.css">
	<link rel="stylesheet" type="text/css" href="StyleLogin/css/main.css">
<!--===============================================================================================-->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
<!--===============================================================================================-->


</head>
<body>
	<img src="images/CINTILLO-SUPERIOR2.png" class="img-fluid" alt="Responsive image">
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-t-10 p-b-20">
				<form runat="server" class="login100-form validate-form">
					<span class="login100-form-title p-b-70">
						Agenda Digital de Audiencias
					</span>
					<span class="login100-form-avatar">
						<img src="StyleLogin/images/PoderJudicialHgo.png" alt="AVATAR">
					</span>

					<div class="wrap-input100 validate-input m-t-85 m-b-35" data-validate = "Ingrese Usuario">
						<asp:TextBox ID="txtUser" runat="server" class="input100" type="text"></asp:TextBox>
						<%--<input class="input100" type="text" name="username">--%>
						<span class="focus-input100" data-placeholder="Usuario"></span>
					</div>

					<div class="wrap-input100 validate-input m-b-50" data-validate="Ingrese contraseña">
						<%--<input class="input100" type="password" name="pass">--%>
						<asp:TextBox ID="txtContraseña" runat="server" class="input100" type="password"></asp:TextBox>

						<span class="focus-input100" data-placeholder="Contraseña"></span>
					</div>

					<div class="container-login100-form-btn">
					<%--	<button class="login100-form-btn">
							Login
						</button>--%>
					<asp:Button ID="btnIngresar" OnClick="btnIngresar_Click"  runat="server" Text="Ingresar" class="container-login100-form-btn login100-form-btn" />
					</div>
				</form>
			</div>
		</div>
	</div>
	
	<img src="images/CINTILLO-INFERIOR.png" class="img-fluid" alt="Responsive image">

	
<!--===============================================================================================-->
	<script src="StyleLogin/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="StyleLogin/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="StyleLogin/vendor/bootstrap/js/popper.js"></script>
	<script src="StyleLogin/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="StyleLogin/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="StyleLogin/vendor/daterangepicker/moment.min.js"></script>
	<script src="StyleLogin/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="StyleLogin/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="StyleLogin/js/main.js"></script>

</body>
</html>