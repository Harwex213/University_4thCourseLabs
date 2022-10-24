<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sum.aspx.cs" Inherits="Sum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<div>
    <p>Sum</p>
        <form id="Form3" runat="server">
            <div style="display: flex;">
                <div style="display: flex; flex-direction: column;">
                    <p>a1</p>
                    <label>
                        k
                        <input type="text" id="k_a1" runat="server" />
                    </label>
                    <label>
                        f
                        <input type="text" id="f_a1" runat="server" />
                    </label>
                    <label>
                        s
                        <input type="text" id="s_a1" runat="server" />
                    </label>
                </div>
                <div style="display: flex; margin-left: 20px; flex-direction: column;">
                    <p>a2</p>
                    <label>
                        k
                        <input type="text" id="k_a2" runat="server" />
                    </label>
                    <label>
                        f
                        <input type="text" id="f_a2" runat="server" />
                    </label>
                    <label>
                        s
                        <input type="text" id="s_a2" runat="server" />
                    </label>
                </div>
            </div>
            <button type="submit" style="margin-top: 10px;">Submit</button>
        </form>
    </div>
    <div id="sumResult" runat="server" style="margin-top: 20px;">Result is:</div>
</body>
</html>
