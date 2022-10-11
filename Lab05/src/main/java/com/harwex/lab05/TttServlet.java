package com.harwex.lab05;

import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;

@WebServlet(name = "TttServlet", value = "/ttt")
public class TttServlet extends HttpServlet {
    @Override
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
        var parameterNames = request.getParameterNames();
        var out = response.getWriter();
        if (!parameterNames.hasMoreElements()) {
            out.println("No parameters!");
            return;
        }

        var output = new StringBuilder();
        while (parameterNames.hasMoreElements()) {
            var paramName = parameterNames.nextElement();
            var paramValues = request.getParameterValues(paramName);
            output.append(paramName).append("=");
            for (var paramValue : paramValues) {
                output.append(paramValue).append(";");
            }
            output.append("\n");
        }

        out.println(output);
    }
}
