<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreacionCuentaVol.aspx.cs" Inherits="ProyectoDAIFuerzaR.CreacionCuentaVol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Nombre(s):
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Apellido paterno:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Apellido materno:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Fecha de Nacimiento:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Sexo:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            CURP:
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            Ciudad de residencia:
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            Estado de residencia:
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            Teléfono:
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            Correo:
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <br />
            Verificar correo:
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            <br />
            Contraseña:
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <br />
            Verificar contraseña:
            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Registrar" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Ingresar a FuerzaR" />
        </div>
    </form>
</body>
</html>
