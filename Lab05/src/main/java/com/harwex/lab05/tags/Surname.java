package com.harwex.lab05.tags;

import jakarta.servlet.jsp.JspException;
import jakarta.servlet.jsp.tagext.SimpleTagSupport;

import java.io.IOException;

public class Surname extends SimpleTagSupport {
    @Override
    public void doTag() throws IOException {
        getJspContext().getOut().write("<div class='input-group mb-3'>" +
                "<label class='form-label'>Your surname<input class='form-control' type='text' name='surname'></label>" +
        "</div>");
    }
}