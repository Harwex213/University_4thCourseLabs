<%@ page import="com.harwex.lab09.CBean" %>
<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Lab07 - Ccc</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
<main>
    <%
        CBean cBeanFromReq = (CBean) request.getAttribute("CBean");
        CBean cBeanFromSess = (CBean) request.getSession().getAttribute(request.getSession().getId());

        if (cBeanFromReq == null && cBeanFromSess == null)
        {%>
            <h1>No CBean</h1>
        <%}

        if (cBeanFromReq != null)
        {%>
            <h1>CBean values from request attr</h1>
            <h2>Value1 = <%= cBeanFromReq.getValue1()%></h2>
            <h2>Value2 = <%= cBeanFromReq.getValue2()%></h2>
            <h2>Value3 = <%= cBeanFromReq.getValue3()%></h2>
        <%}

        if (cBeanFromSess != null)
        {%>
            <h1>CBean values from session attr</h1>
            <h1>Value1 = <%= cBeanFromSess.getValue1()%></h1>
            <h1>Value2 = <%= cBeanFromSess.getValue2()%></h1>
            <h1>Value3 = <%= cBeanFromSess.getValue3()%></h1>
        <%}

    %>
</main>
</body>
</html>