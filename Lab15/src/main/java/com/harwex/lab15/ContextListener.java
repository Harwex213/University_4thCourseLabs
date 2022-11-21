package com.harwex.lab15;

import jakarta.servlet.ServletContextEvent;
import jakarta.servlet.ServletContextListener;
import jakarta.servlet.annotation.WebListener;

@WebListener
public class ContextListener implements ServletContextListener {
    @Override
    public void contextInitialized(ServletContextEvent servletContextEvent) {
        var servletContext = servletContextEvent.getServletContext();
        EmailService.initSmtp(servletContext);
        EmailService.initImap(servletContext);
    }
}