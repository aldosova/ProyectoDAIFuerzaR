<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginOrgVol.aspx.cs" Inherits="ProyectoDAIFuerzaR.loginOrgVol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Fuerza de respuesta<br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            Correo:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Contraseña:
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Entrar" />
            <br />
            ¿No estás registrado? <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Crea una cuenta" />
        </div>
    </form>
</body>
</html>
