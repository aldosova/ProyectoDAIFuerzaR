<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreacionCuentaOrg.aspx.cs" Inherits="ProyectoDAIFuerzaR.CreacionCuentaOrg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Nombre de la organización:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Domicilio:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Ciudad:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Estado:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Página web:
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Teléfono:
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            Correo:
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            Verificar correo:
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            Contraseña:
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            Verificar contraseña:
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
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
