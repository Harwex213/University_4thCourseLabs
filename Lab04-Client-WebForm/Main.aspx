<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="first" placeholder="int"/>
            <asp:TextBox runat="server" ID="second" placeholder="int"/>
            <asp:Button runat="server" ID="sum" OnClick="Sum_Click" Text="Add" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="result" />
        </div>
    </form>
</body>
</html>
