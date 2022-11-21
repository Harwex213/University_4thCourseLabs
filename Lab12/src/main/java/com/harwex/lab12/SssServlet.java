package com.harwex.lab12;

import java.io.*;

import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

@WebServlet(name = "SssServlet", value = "/Sss")
public class SssServlet extends HttpServlet {
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        PrintWriter out = response.getWriter();
        out.println("Servlet:SSS");
        System.out.println("Servlet:SSS");
    }
}