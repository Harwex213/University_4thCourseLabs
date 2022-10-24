<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lab04 client</title>
</head>
<body>
    <div>
        <p>Add</p>
        <form id="Form1" runat="server">
            <input type="text" id="x" runat="server" />
            <input type="text" id="y" runat="server" />
            <button type="submit">Submit</button>
        </form>
    </div>
    <div id="addResult" runat="server" style="margin-top: 20px;">Result is:</div>
</body>
</html>
