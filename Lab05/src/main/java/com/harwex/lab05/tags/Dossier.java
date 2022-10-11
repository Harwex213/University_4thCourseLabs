package com.harwex.lab05.tags;

import jakarta.servlet.jsp.tagext.TagSupport;

import java.io.IOException;

public class Dossier extends TagSupport {
    private String action = "";

    public String getAction() {
        return this.action;
    }

    public void setAction(String action) {
        this.action = action;
    }

    @Override
    public int doStartTag() {
        try {
            pageContext.getOut().write("<form method='POST' action='" + action + "'>");
        } catch (IOException e) {
            e.printStackTrace();
        }
        return EVAL_BODY_INCLUDE;
    }

    @Override
    public int doEndTag() {
        try {
            pageContext.getOut().write("</form>");
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        return EVAL_PAGE;
    }
}