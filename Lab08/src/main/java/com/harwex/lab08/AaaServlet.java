package com.harwex.lab08;

import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.utils.URIBuilder;
import org.apache.http.impl.client.HttpClients;

import java.io.IOException;
import java.net.URISyntaxException;
import java.util.Scanner;

@WebServlet(name = "AaaServlet", value = "/Aaa")
public class AaaServlet extends HttpServlet {
    private String getHost(HttpServletRequest request)
    {
        var url = request.getRequestURL();
        var uri = request.getRequestURI();
        return url.substring(0, url.indexOf(uri));
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        try {
            var host = getHost(request);
            var httpPost = new HttpPost(host + getServletContext().getContextPath() + "/Bbb");
            httpPost.setURI(new URIBuilder(httpPost.getURI())
                    .addParameter("param1", "value1")
                    .addParameter("param2", "value2")
                    .addParameter("param3", "value3")
                    .build());
            httpPost.addHeader("param1", "value1");
            httpPost.addHeader("param2", "value2");
            httpPost.addHeader("param3", "value3");

            var httpClient = HttpClients.createDefault();
            var httpResponse = httpClient.execute(httpPost);

            var scanner = new Scanner(httpResponse.getEntity().getContent());
            var out = response.getWriter();

            out.println("<h1>Response from Bbb</h1>");
            while (scanner.hasNext()) {
                out.println(scanner.nextLine());
            }

            out.println("<h1>Response headers</h1>");
            var responseHeaders = httpResponse.getAllHeaders();
            for (var header : responseHeaders) {
                out.println("<h2>" + header.getName() + ": " + header.getValue() + "</h2>");
            }
        } catch (URISyntaxException e) {
            throw new RuntimeException(e);
        }
    }
}
