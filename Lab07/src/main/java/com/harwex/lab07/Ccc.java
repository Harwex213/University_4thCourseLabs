package com.harwex.lab07;
import jakarta.servlet.ServletConfig;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;

@WebServlet(name = "CccServlet", value = "/Ccc")
public class Ccc extends HttpServlet {
    public static class Parameters {
        public static String CBean = "CBean";
        public static String Value1 = "Value1";
        public static String Value2 = "Value2";
        public static String Value3 = "Value3";
        public static String Session = "Session";
    }

    private CBean cBean = null;

    private void initializeCBean()
    {
        cBean = new CBean();
    }

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        initializeCBean();
    }

    @Override
    public void service(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        var method = request.getMethod();
        if (!(method.equals("GET") || method.equals("POST"))) {
            return;
        }

        var paramCBean = request.getParameter(Parameters.CBean);
        var value1 = request.getParameter(Parameters.Value1);
        var value2 = request.getParameter(Parameters.Value2);
        var value3 = request.getParameter(Parameters.Value3);
        var sessionParam = request.getParameter(Parameters.Session);

        if (paramCBean != null && paramCBean.equals("new")) {
            initializeCBean();
        }
        if (value1 != null && !value1.isEmpty()) {
            cBean.setValue1(value1);
        }
        if (value2 != null && !value2.isEmpty()) {
            cBean.setValue2(value2);
        }
        if (value3 != null && !value3.isEmpty()) {
            cBean.setValue3(value3);
        }

        request.setAttribute("CBean", cBean);
        if (sessionParam != null) {
            var session = request.getSession(true);
            session.setAttribute(session.getId(), cBean);
        }

        getServletContext()
                .getRequestDispatcher("/Ccc.jsp")
                .forward(request, response);
    }
}
