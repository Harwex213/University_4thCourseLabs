package com.harwex.lab02;

import java.io.*;
import java.util.Date;

import jakarta.servlet.ServletException;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

@WebServlet(name = "SssServlet", value = "/GoSss")
public class Sss extends HttpServlet {

    private String log = "";

    public static class Parameters {
        public static String Log = "log";
        public static String Method = "method";
        public static String Host = "host";
        public static String Firstname = "firstname";
        public static String Lastname = "lastname";
    }

    public void init() {
        var logMessage = new Date() + ": init";
        System.out.println(logMessage);
        log += logMessage + "\n";
    }

    @Override
    public void service(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        super.service(request, response);

        var logMessage = new Date() + ": service";
        System.out.println(logMessage);
        log += logMessage + "\n";

        var duplicate = request.getParameter(Parameters.Log);
        var method = request.getParameter(Parameters.Method);
        var host = request.getParameter(Parameters.Host);

        PrintWriter out = response.getWriter();
        out.println();
        if (duplicate != null) {
            out.println(log);
        }
        if (method != null) {
            out.println("Your method is " + request.getMethod());
        }
        if (host != null) {
            out.println("Server name: " + request.getServerName() + "; Ip addr: " + request.getRemoteAddr());
        }
    }

    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        PrintWriter out = response.getWriter();
        out.println(request.getQueryString());
    }

    @Override
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
        PrintWriter out = response.getWriter();
        out.println("Param firstname: " + request.getParameter(Parameters.Firstname));
        out.println("Param lastname: " + request.getParameter(Parameters.Lastname));
    }

    public void destroy() {
        var logMessage = new Date() + ": destroy";
        System.out.println(logMessage);
        log += logMessage + "\n";
    }
}