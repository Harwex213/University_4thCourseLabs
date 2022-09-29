<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimplexWebForm.aspx.cs" Inherits="Lab04.WebForms.SimplexWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lab4 Jquery Client</title>
    <script src="jquery-3.4.1.min.js"></script>
    <script>
        function Sum() {
            const data = {
                x: $("#x").val(),
                y: $("#y").val()
            };
            $.ajax({
                url: "http://localhost:58277/WebServices/Simplex.asmx/Adds-simplex",
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: data,
                success: result => {
                    $("#result").text("Result is: " + result.d);
                },
                error: error => {
                    console.log(error);
                }
            })
        }
    </script>
</head>
<body>
    <form id="sumform" runat="server">
        <div>
            <div>
                <input type="text" id="x"/>
                <input type="text" id="y"/>
                <button type="button" onclick="Sum()">Submit</button>
            </div>
            <div id="result">Result is:</div>
        </div>
    </form>
</body>
</html>
