package com.harwex.lab08;

import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.util.Arrays;

@WebServlet(name = "BbbServlet", value = "/Bbb")
public class BbbServlet extends HttpServlet {
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
        var out = response.getWriter();

        out.println("<h2>Request params</h2>");
        var requestParams = request.getParameterMap();
        for (var key : requestParams.keySet()) {
            out.println("<h3>" + key + ": " + Arrays.toString(requestParams.get(key)) + "</h3>");
        }

        out.println("<h2>Request headers</h2>");
        var requestHeaderNames = request.getHeaderNames();
        while (requestHeaderNames.hasMoreElements()) {
            String headerName = requestHeaderNames.nextElement();
            out.println("<h3>" + headerName + ": " + request.getHeader(headerName) + "</h3>");
        }

        response.addHeader("X-Response-Header-1", "header-value-1");
        response.addHeader("X-Response-Header-2", "header-value-2");
    }
}
