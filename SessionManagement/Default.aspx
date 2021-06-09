<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SessionManagement.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOG IN PAGE</title>
</head>
<body style="font-family:'Comic Sans MS'; background-color:black; color:red">
    <form id="form1" runat="server">
        <div style="height:90%;">
            <div style="float:none;width:300px;border: 5px dashed red;padding:100px;">
                Username: <asp:TextBox ID="txtUser" ToolTip="Input Username Here" runat="server" /><br />
                Password:&nbsp <asp:TextBox ID="txtPassword" ToolTip="Input Password Here" runat="server" /><br />
                <asp:Label ID ="lblMessage" runat="server" ForeColor="Red" />
                <div style="float:none;width:300px;padding:5px; text-align:center;">
                    <asp:Button BackColor="White" BorderColor="Red" ID="btnLogIn" Font-Bold="true" BorderStyle="Dashed" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
