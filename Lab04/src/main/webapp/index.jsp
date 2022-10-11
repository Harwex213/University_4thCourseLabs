<%@ page import="java.util.Calendar" %>
<%@ page import="com.harwex.lab04.DateTime" %>
<%@ page import="java.text.SimpleDateFormat" %>
<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Lab04</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
<main style="margin: 20px">
    <h1>
        <%
            int currentHour = Calendar.getInstance().get(Calendar.HOUR_OF_DAY);
            DateTime currentDateTime;
            if (currentHour <= 6 || currentHour >= 21) {
                currentDateTime = DateTime.NIGHT;
            } else if (currentHour <= 12) {
                currentDateTime = DateTime.MORNING;
            } else if (currentHour <= 18) {
                currentDateTime = DateTime.AFTERNOON;
            } else {
                currentDateTime = DateTime.EVENING;
            }
            out.println("Good " + currentDateTime.getDateTimeName());
        %>
    </h1>
    <table class="table table-bordered">
        <thead class="">
            <tr>
                <td>Date</td>
                <td>Day</td>
            </tr>
        </thead>
        <tbody>
        <%
            Calendar calendar = Calendar.getInstance();
            int max = 7;
            SimpleDateFormat formatDate = new SimpleDateFormat("dd.MM.yyyy");
            SimpleDateFormat formatDay = new SimpleDateFormat("EEEE");
            for (int i = 0; i < max; i++) {
                StringBuilder record = new StringBuilder();
                record.append("<tr>");

                record.append("<td>").append(formatDate.format(calendar.getTime())).append("</td>");
                record.append("<td>").append(formatDay.format(calendar.getTime())).append("</td");

                record.append("</tr>");
                out.println(record);

                calendar.add(Calendar.DATE, 1);
            }
        %>
        </tbody>
    </table>
    <div style="display: flex; flex-direction: row;">
        <form>
            <label>
                <input style="display: none" name="dateTime" value="<%=currentDateTime.getDateTimeName()%>" />
                <input style="display: none" name="staticInclude" value="true" />
            </label>
            <button class="btn btn-primary">Press to static include</button>
        </form>
        <form style="margin: 0 25px;">
            <label>
                <input style="display: none" name="dateTime" value="<%=currentDateTime.getDateTimeName()%>" />
                <input style="display: none" name="dynamicInclude" value="true" />
            </label>
            <button class="btn btn-primary">Press to dynamic include</button>
        </form>
        <form>
            <label>
                <input style="display: none" name="servlet" value="true" />
            </label>
            <button class="btn btn-primary">Press to invoke servlet</button>
        </form>
        <form style="margin: 0 25px;">
            <label>
                <input style="display: none" name="dateTime" value="<%=currentDateTime.getDateTimeName()%>" />
                <input style="display: none" name="forward" value="true" />
            </label>
            <button class="btn btn-primary">Press to forward</button>
        </form>
    </div>
    <%
        String dateTime = request.getParameter("dateTime");

        String staticInclude = request.getParameter("staticInclude");
        boolean isStaticInclude = staticInclude != null && !staticInclude.isEmpty();
        if (isStaticInclude && dateTime.equals(DateTime.MORNING.getDateTimeName()))
            {%><%@include file="dateTimes/morning.jsp" %><%}
        if (isStaticInclude && dateTime.equals(DateTime.AFTERNOON.getDateTimeName()))
            {%><%@include file="dateTimes/afternoon.jsp" %><%}
        if (isStaticInclude && dateTime.equals(DateTime.EVENING.getDateTimeName()))
            {%><%@include file="dateTimes/evening.jsp" %><%}
        if (isStaticInclude && dateTime.equals(DateTime.NIGHT.getDateTimeName()))
            {%><%@include file="dateTimes/night.jsp" %><%}
    %>
    <%
        String path = "dateTimes/" + dateTime + ".jsp";
        String dynamicInclude = request.getParameter("dynamicInclude");
        boolean isDynamicInclude = dynamicInclude != null && !dynamicInclude.isEmpty();
        if (isDynamicInclude)
            {%><jsp:include page="<%=path%>" /><%}
    %>
    <%
        String servlet = request.getParameter("servlet");
        boolean isServlet = servlet != null && !servlet.isEmpty();
        if (isServlet)
            {%><jsp:include page="/afternoon" /><%}
    %>
    <%
        String forward = request.getParameter("forward");
        boolean isForward = forward != null && !forward.isEmpty();
        if (isForward)
            {%><jsp:forward page="<%=path%>" /><%}
    %>
</main>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>