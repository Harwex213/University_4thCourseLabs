package com.harwex.lab11;

import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

@WebServlet(name = "Sss_Header", value = "/Sss-header")
public class Sss_Header extends HttpServlet {

    protected void doGet(HttpServletRequest rq, HttpServletResponse rs) {
        System.out.println("Sss:doGet");
    }

    @lombok.SneakyThrows
    protected void doPost(HttpServletRequest rq, HttpServletResponse rs) {
        System.out.println("Sss:doPost");
        System.out.println(rq.getHeader("Value-X"));
        System.out.println(rq.getHeader("Value-Y"));
        Float x = new Float(rq.getHeader("Value-X"));
        Float y = new Float(rq.getHeader("Value-Y"));
        float z = x + y;
        System.out.println(z);
        rs.setHeader("Value-Z", Float.toString(z));
        Thread.sleep(10000);
    }

}