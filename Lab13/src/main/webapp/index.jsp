<%@ page import="com.harwex.lab13.ChoiceXXX" %>
<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Harwex'es Lab13</title>
</head>
<body>
<main>
    <%
        String d = config.getServletContext().getInitParameter("docs-directory");
        ChoiceXXX ch = new ChoiceXXX(d, "docx");
        String file;
        for (int i = 0; i < ch.list.length; i++) {
            file = ch.list[i];
    %>
    <br />
    <a href="${pageContext.request.contextPath}/Sss?file=<%=file%>"> <%=file%> </a>
    <%}%>
</main>
</body>
</html>