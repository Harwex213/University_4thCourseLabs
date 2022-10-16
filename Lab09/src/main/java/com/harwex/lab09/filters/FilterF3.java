package com.harwex.lab09.filters;

import jakarta.servlet.*;

import java.io.IOException;

public class FilterF3 implements Filter {
    private final String FilterName = "FilterF3";
    private final String FilterNumber = "3";

    @Override
    public void init(FilterConfig filterConfig) {
        System.out.println(FilterName + ": init");
    }

    @Override
    public void doFilter(ServletRequest servletRequest, ServletResponse servletResponse, FilterChain filterChain) throws IOException, ServletException {
        System.out.println(FilterName + ": doFilter");

        var out = servletResponse.getWriter();
        out.println("Hello from " + FilterName);

        var blockParameter = servletRequest.getParameter("stop");
        if (blockParameter != null && blockParameter.equals(FilterNumber)) {
            return;
        }

        filterChain.doFilter(servletRequest, servletResponse);
    }

    @Override
    public void destroy() {
        System.out.println(FilterName + ": destroy");
    }
}