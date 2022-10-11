package com.harwex.lab03;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Date;

@WebServlet(name = "SssServlet", value = "/sss")
public class SssServlet extends HttpServlet {
    public static class Parameters {
        public static String Html = "html";
        public static String Double = "double";
    }

    public void init() throws ServletException {
        super.init();
        System.out.println("SSS --- " + new Date() + ": init");
    }

    public void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        super.service(request, response);
        System.out.println("SSS --- " + new Date() + ": service");
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        PrintWriter out = response.getWriter();
        out.println("SSS doGet here!");

        var htmlParam = request.getParameter(Parameters.Html);
        var doubleParam = request.getParameter(Parameters.Double);

        if (htmlParam != null) {
            getServletContext()
                    .getRequestDispatcher("/additional.html")
                    .forward(request, response);
            return;
        }
        if (doubleParam != null) {
            getServletContext()
                    .getRequestDispatcher("/ggg?double")
                    .forward(request, response);
            return;
        }
        getServletContext()
                .getRequestDispatcher("/ggg")
                .forward(request, response);
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        PrintWriter out = response.getWriter();
        out.println("SSS doPost here!");

        getServletContext()
                .getRequestDispatcher("/ggg")
                .forward(request, response);
    }

    public void destroy() {
        super.destroy();
        System.out.println("SSS --- " + new Date() + ": destroy");
    }
}
