package com.harwex.lab10.datasource;

import jakarta.servlet.ServletContextEvent;
import jakarta.servlet.ServletContextListener;
import jakarta.servlet.annotation.WebListener;

@WebListener
public class ContextListener implements ServletContextListener {
    @Override
    public void contextInitialized(ServletContextEvent servletContextEvent) {
        var connectionString = servletContextEvent.getServletContext().getInitParameter("ConnectionString");
        DbContext.setConnectionString(connectionString);
        DbContext.getConnection();
    }
}