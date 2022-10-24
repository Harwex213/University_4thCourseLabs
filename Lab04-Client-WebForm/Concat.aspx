<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Concat.aspx.cs" Inherits="Concat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div>
        <p>Concat</p>
        <form id="Form2" runat="server">
            <label>
                k - string
                <input type="text" id="k" runat="server" />
            </label>
            <label>
                d - double
                <input type="text" id="d" runat="server" />
            </label>
            <button type="submit">Submit</button>
        </form>
    </div>
    <div id="concatResult" runat="server" style="margin-top: 20px;">Result is:</div>
</body>
</html>
