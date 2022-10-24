<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimplexWebForm.aspx.cs" Inherits="Lab04.WebForms.SimplexWebForm" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Lab04 Client via AJAX</title>
<script src="jquery-3.4.1.min.js"></script>
<script>
    function Sum() {
        const data = {
            x: $("#x").val(),
            y: $("#y").val()
        };
        $.ajax({
            url: "http://localhost:10000/WebServices/Simplex.asmx/Adds-simplex",
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
    <form>
        <div>
            Simplex-Adds:
            <label>
                X: 
                <input type="text" id="x"/>
            </label>
            <label>
                Y:
                <input type="text" id="y"/>
            </label>
            <button type="button" onclick="Sum()">Submit</button>
        </div>
    </form>
    <div id="result">Result is:</div>
</body>
</html>
