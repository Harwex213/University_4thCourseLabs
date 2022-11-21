package com.harwex.lab15;

import jakarta.servlet.ServletContext;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import javax.mail.Session;
import java.io.IOException;

@WebServlet(name = "SendEmailServlet", value = "/send-email")
public class SendEmailServlet extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
        ServletContext context = request.getServletContext();
        final String from = context.getInitParameter("EmailName");
        final String to = request.getParameter("email");
        final String message = request.getParameter("message");

        EmailService.sendEmail(from, to, message);

        var out = response.getWriter();
        out.println("Successfully sent");
    }

}