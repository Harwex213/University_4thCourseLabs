package com.harwex.lab05.tags;

import jakarta.servlet.jsp.tagext.SimpleTagSupport;

import java.io.IOException;

public class Name extends SimpleTagSupport {
    @Override
    public void doTag() throws IOException {
        getJspContext().getOut().write("<div class='input-group mb-3'>" +
                "<label class='form-label'>Your name<input class='form-control' type='text' name='name'></label>" +
        "</div>");
    }
}