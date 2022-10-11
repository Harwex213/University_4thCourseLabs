package com.harwex.lab03;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.util.Date;

@WebServlet(name = "GggServletInternalRequest", value = "/ggg-internal-request")
public class GggServletInternalRequest extends HttpServlet {
    public void init() throws ServletException {
        super.init();
        System.out.println("GGG-INTERNAL-REQUEST --- " + new Date() + ": init");
    }

    public void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        super.service(request, response);
        System.out.println("GGG-INTERNAL-REQUEST --- " + new Date() + ": service");
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
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

    public void destroy() {
        super.destroy();
        System.out.println("GGG-INTERNAL-REQUEST --- " + new Date() + ": destroy");
    }
}
