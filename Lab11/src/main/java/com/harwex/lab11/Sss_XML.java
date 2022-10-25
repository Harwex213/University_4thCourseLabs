package com.harwex.lab11;

import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import lombok.SneakyThrows;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;

@WebServlet(name = "Sss_XML", value = "/Sss-xml")
public class Sss_XML extends HttpServlet {
    private class XXRand {
        private Integer n = Integer.MAX_VALUE;
        private final Random random = new Random();

        public XXRand(Integer n) {
            if (n > 0)
                this.n = n;
        }

        public Integer Get() {
            return (this.random.nextInt()%this.n);
        }
    }

    @SneakyThrows
    protected void doPost(HttpServletRequest rq, HttpServletResponse rs) throws IOException {
        System.out.println("Sss_Rand:doPost");

        Integer n = new Integer(rq.getHeader("XRand-N"));
        System.out.println(n);

        rs.setContentType("text/xml");
        PrintWriter w = rs.getWriter();
        String s = "<?xml version=\"1.0\"  encoding = \"utf-8\" ?><rand>";

        int cycle = (10 - new Random().nextInt(5));
        XXRand num = new XXRand(n);
        for (int i = 0; i < cycle; i++)
        {
            s += "<num>" + num.Get().toString() + "</num>";
        }
        s += "</rand>";
        w.println(s);
        Thread.sleep(1000);
    }

}