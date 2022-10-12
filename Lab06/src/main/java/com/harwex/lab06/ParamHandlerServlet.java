package com.harwex.lab06;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.utils.URIBuilder;
import org.apache.http.impl.client.HttpClients;

import java.io.IOException;
import java.net.URISyntaxException;
import java.util.Scanner;


@WebServlet(name = "ParamHandler", value = "/param-handler")
public class ParamHandlerServlet extends HttpServlet {
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        var n = request.getParameter("urln");
        if (n != null && (n.equals("1") || n.equals("2"))) {
            var param = getServletContext().getInitParameter("URL" + n);
            makeRequest(param, response);
        }
        else {
            response.getWriter().println("parameter URLn not found");
        }
    }

    private void makeRequest(String param, HttpServletResponse response)
    {
        try {
            var httpGet = new HttpGet(param);
            var uri = new URIBuilder(httpGet.getURI()).build();
            httpGet.setURI(uri);

            var httpClient = HttpClients.createDefault();
            var httpResponse = httpClient.execute(httpGet);
            response.setStatus(httpResponse.getStatusLine().getStatusCode());
            var sc = new Scanner(httpResponse.getEntity().getContent());
            var out = response.getWriter();
            while (sc.hasNext()) {
                out.println((sc.nextLine()));
            }
        } catch (URISyntaxException | IOException e) {
            throw new RuntimeException(e);
        }
    }
}
