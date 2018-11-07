<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="APP.Plant.Engineer.Default" %>

<!DOCTYPE html>

<html lang="es-mx">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../../../favicon.ico">
    <link href="css/menuFlotante.css" rel="stylesheet" />

    <title>Login Ingenieria</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="signin.css" rel="stylesheet">
</head>

<body class="text-center" style="background-image:url('Images/Fondo_Login.jpg'); background-repeat: no-repeat; background-size:cover;">
    <form class="form-signin" runat="server">
        <img class="mb-4" src="Images/149071.png" alt="" width="72" height="72">
        <h1 class="h3 mb-3 font-weight-normal">Ingrese su usuario</h1>
        <label for="inputEmail" class="sr-only">Usuario</label>
        <input type="text" id="inputEmail" runat="server" class="form-control" placeholder="Usuario" required autofocus>
        <label for="inputPassword" class="sr-only">Password</label>
        <input type="password" id="inputPassword" runat="server" class="form-control" placeholder="Password" required>
        <asp:Label runat="server" ID="msgError" Visible="false"></asp:Label>
        <asp:Button runat="server" ID="btnLogin" class="btn btn-lg btn-primary btn-block" Text="Entrar" OnClick="btnLogin_Click" />
        <p class="mt-5 mb-3 text-muted">&copy; 2018-2019</p>
    </form>
</body>
</html>

