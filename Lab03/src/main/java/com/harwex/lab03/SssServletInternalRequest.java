package com.harwex.lab03;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.utils.URIBuilder;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;

import java.io.IOException;
import java.io.PrintWriter;
import java.net.URI;
import java.net.URISyntaxException;
import java.util.Date;
import java.util.Scanner;

@WebServlet(name = "SssServletInternalRequest", value = "/sss-internal-request")
public class SssServletInternalRequest extends HttpServlet {
    public void init() throws ServletException {
        super.init();
        System.out.println("SSS-INTERNAL-REQUEST --- " + new Date() + ": init");
    }

    public void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        super.service(request, response);
        System.out.println("SSS-INTERNAL-REQUEST --- " + new Date() + ": service");
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        var out = response.getWriter();
        out.println("SSS-INTERNAL-REQUEST doGet here!");

        var url = request.getRequestURL();
        var uri = request.getRequestURI();
        var host = url.substring(0, url.indexOf(uri));
        var httpClient = HttpClients.createDefault();
        var httpGet = new HttpGet(host + getServletContext().getContextPath() + "/ggg-internal-request" +
                "?param1=value1&param2=value2");
        try {
            var httpResponse = httpClient.execute(httpGet);
            var sc = new Scanner(httpResponse.getEntity().getContent());

            while(sc.hasNext()) {
                out.println((sc.nextLine()));
            }
        } catch (Exception e) {
            e.printStackTrace(System.out);
        }
    }

    public void destroy() {
        super.destroy();
        System.out.println("SSS-INTERNAL-REQUEST --- " + new Date() + ": destroy");
    }
}
