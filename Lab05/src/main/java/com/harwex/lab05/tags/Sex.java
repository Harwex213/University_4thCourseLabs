package com.harwex.lab05.tags;

import jakarta.servlet.jsp.tagext.SimpleTagSupport;

import java.io.IOException;

public class Sex extends SimpleTagSupport {
    @Override
    public void doTag() throws IOException {
        getJspContext().getOut().write("<div class='form-check form-check-inline mb-3'>" +
                "<label class='form-check-label'><input class='form-check-input' type='radio' name='sex' value='male'>Male</label>" +
                "<label class='form-check-label ml-3'><input class='form-check-input' type='radio' name='sex' value='female'>Female</label>" +
                "</div>");
    }
}