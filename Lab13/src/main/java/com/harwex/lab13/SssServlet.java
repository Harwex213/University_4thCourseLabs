package com.harwex.lab13;

import java.io.*;

import jakarta.servlet.ServletOutputStream;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

@WebServlet(name = "SssServlet", value = "/Sss")
public class SssServlet extends HttpServlet {
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        var fileName = request.getParameter("file");
        OutputDoc(new File(getServletContext().getInitParameter("docs-directory") + "\\" + fileName), response);
    }

    protected void OutputDoc(File doc, HttpServletResponse rs) throws IOException {
        rs.setContentType("application/msword");
        rs.addHeader("Content-Disposition", "attachment; filename=" + doc.getName());
        rs.setContentLength(Math.toIntExact(doc.length()));

        FileInputStream in = new FileInputStream(doc);
        BufferedInputStream buf = new BufferedInputStream(in);
        ServletOutputStream out = rs.getOutputStream();
        int readBytes;
        while ((readBytes = buf.read()) != -1)
            out.write(readBytes);

        System.out.println("Sent file " + doc.getName() + " to the client.");
    }
}