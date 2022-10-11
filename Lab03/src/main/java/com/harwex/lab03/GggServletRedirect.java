package com.harwex.lab03;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Date;

@WebServlet(name = "GggServletRedirect", value = "/ggg-redirect")
public class GggServletRedirect extends HttpServlet {
    public void init() throws ServletException {
        super.init();
        System.out.println("GGG-REDIRECT --- " + new Date() + ": init");
    }

    public void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        super.service(request, response);
        System.out.println("GGG-REDIRECT --- " + new Date() + ": service");
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        PrintWriter out = response.getWriter();
        out.println("GGG-REDIRECT doGet here!");

        var doubleParam = request.getParameter(SssServlet.Parameters.Double);
        if (doubleParam != null) {
            response.sendRedirect(getServletContext().getContextPath() + "/additional.html");
        }
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
        PrintWriter out = response.getWriter();
        out.println("GGG-REDIRECT doPost here!");
    }

    public void destroy() {
        super.destroy();
        System.out.println("GGG-REDIRECT --- " + new Date() + ": destroy");
    }
}
