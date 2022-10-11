package com.harwex.lab03;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Date;

@WebServlet(name = "SssServletRedirect", value = "/sss-redirect")
public class SssServletRedirect extends HttpServlet {
    public void init() throws ServletException {
        super.init();
        System.out.println("SSS-REDIRECT --- " + new Date() + ": init");
    }

    public void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        super.service(request, response);
        System.out.println("SSS-REDIRECT --- " + new Date() + ": service");
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        PrintWriter out = response.getWriter();
        out.println("SSS-REDIRECT doGet here!");

        var htmlParam = request.getParameter(SssServlet.Parameters.Html);
        var doubleParam = request.getParameter(SssServlet.Parameters.Double);

        if (htmlParam != null) {
            response.sendRedirect(getServletContext().getContextPath() + "/additional.html");
            return;
        }
        if (doubleParam != null) {
            response.sendRedirect(getServletContext().getContextPath() + "/ggg-redirect?double");
            return;
        }

        response.sendRedirect(getServletContext().getContextPath() + "/ggg-redirect");
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        PrintWriter out = response.getWriter();
        out.println("SSS-REDIRECT doPost here!");

        response.setStatus(307);
        response.addHeader("Location", getServletContext().getContextPath() + "/ggg-redirect");
//        response.sendRedirect(getServletContext().getContextPath() + "/ggg-redirect" );
    }

    public void destroy() {
        super.destroy();
        System.out.println("SSS-REDIRECT --- " + new Date() + ": destroy");
    }
}
