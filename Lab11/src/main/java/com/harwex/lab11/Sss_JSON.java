package com.harwex.lab11;

import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import lombok.SneakyThrows;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Random;

@WebServlet(name = "Sss_JSON", value = "/Sss-json")
public class Sss_JSON extends HttpServlet {
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
        System.out.println("Sss_JSON:doPost");
        Integer n = new Integer(rq.getHeader("XRand-N"));
        System.out.println(n);
        XXRand num = new XXRand(n);
        rs.setContentType("application/json");
        PrintWriter w = rs.getWriter();
        String s ="{\"X\":[" ;
        for (int i = 0; i < 10; i++)
        {
            s += ("{\"rand\":"+ num.Get() +"}" + ((i < 9)?",":" "));
        }
        s+="]}";
        System.out.println(s);
        w.println(s);
        Thread.sleep(5000);
    }
}