package com.harwex.lab11;

import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import lombok.SneakyThrows;

import java.io.IOException;
import java.io.PrintWriter;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Random;
import java.util.stream.Collectors;

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
            return (this.random.nextInt() % this.n);
        }
    }
    @SneakyThrows
    protected void doPost(HttpServletRequest rq, HttpServletResponse rs) throws IOException {
        System.out.println("Sss_JSON:doPost");

        Integer n = new Integer(rq.getHeader("XRand-N"));
        XXRand num = new XXRand(n);

        System.out.println(n);

        int cycle = (10 - new Random().nextInt(5));
        String s ="[";
        var arr = new ArrayList<Integer>();
        for (int i = 0; i < cycle; i++)
        {
            arr.add(num.Get());
        }
        s += arr.stream().map(String::valueOf).collect(Collectors.joining(",")) + "]";

        System.out.println(s);
        rs.setContentType("application/json");
        PrintWriter w = rs.getWriter();
        w.println(s);

        Thread.sleep(5000);
    }
}