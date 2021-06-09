<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherPage.aspx.cs" Inherits="SessionManagement.OtherPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Continue Log In</title>
</head>
<body style="font-family: 'Comic Sans MS'; background-color:black; color:red">
    <form id="form1" runat="server">
        <div style="float: none; width: 300px; padding: 5px; text-align: center;">
            <asp:Label ID="lblUser" runat="server" Font-Size="Large" />
            <asp:Button BorderStyle="Dashed" ID="btnLogIn" runat="server" Font-Bold="true" BackColor="White" BorderColor="Red" Text="Continue Log In" OnClick="btnLogIn_Clicked" />
        </div>
    </form>
</body>
</html>
