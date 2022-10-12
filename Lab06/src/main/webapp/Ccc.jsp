<%@ page import="com.harwex.lab06.CBean" %>
<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Lab06 - Ccc</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
<main>
    <% CBean atrCBean = (CBean)application.getAttribute("atrCBean"); %>
    <h1>Value1 = <%= atrCBean.getValue1()%></h1>
    <h1>Value2 = <%= atrCBean.getValue2()%></h1>
    <h1>Value3 = <%= atrCBean.getValue3()%></h1>
</main>
</body>
</html>