package com.harwex.lab05.tags;

import jakarta.servlet.jsp.tagext.SimpleTagSupport;

import java.io.IOException;

public class Submit extends SimpleTagSupport {
    @Override
    public void doTag() throws IOException {
        getJspContext().getOut().write("<div class='input-group mb-3'>" +
                "<button class='btn btn-primary' type='submit'>Ok</button>" +
                "<button class='btn btn-secondary ml-3' type='button'>Cancel</button>" +
        "</div>");
    }
}