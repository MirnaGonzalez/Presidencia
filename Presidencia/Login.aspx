<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presidencia.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Inicio de Sesión.</title>
   	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="EstilosLogin/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="EstilosLogin/vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="EstilosLogin/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="EstilosLogin/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="EstilosLogin/vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="EstilosLogin/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="EstilosLogin/vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="EstilosLogin/vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="EstilosLogin/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="EstilosLogin/css/util.css">
	<link rel="stylesheet" type="text/css" href="EstilosLogin/css/main.css">
<!--===============================================================================================-->

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>




</head>
<body>
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-form-title" style="background-image: url(EstilosLogin/images/tsjhgo.jpg);">
					<span class="login100-form-title-1">
						Poder Judicial del Estado de Hidalgo
					</span>
				</div>

				<form runat="server" class="login100-form validate-form">
					<div class="wrap-input100 validate-input m-b-26" data-validate="El usuario es requerido">
						<span class="label-input100">Usuario:</span>
						<asp:TextBox ID="txtUser" runat="server" class="input100" type="text"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 validate-input m-b-18" data-validate = "La contraseña es requerida">
						<span class="label-input100">Contraseña:</span>
						<asp:TextBox ID="txtContraseña" runat="server" class="input100" type="password"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>

				<%--	<div class="flex-sb-m w-full p-b-30">
						<div class="contact100-form-checkbox">
							<input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
							<label class="label-checkbox100" for="ckb1">
								Remember me
							</label>
						</div>

						<div>
							<a href="#" class="txt1">
								Forgot Password?
							</a>
						</div>
					</div>--%>
					
					<asp:Button ID="btnIngresar" OnClick="btnIngresar_Click" runat="server" Text="Ingresar" class="container-login100-form-btn login100-form-btn" />

				</form>
			</div>
		</div>
	</div>
	
<!--===============================================================================================-->
	<script src="EstilosLogin/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="EstilosLogin/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="EstilosLogin/vendor/bootstrap/js/popper.js"></script>
	<script src="EstilosLogin/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="EstilosLogin/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="EstilosLogin/vendor/daterangepicker/moment.min.js"></script>
	<script src="EstilosLogin/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="EstilosLogin/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="EstilosLogin/js/main.js"></script>

</body>
</html>
