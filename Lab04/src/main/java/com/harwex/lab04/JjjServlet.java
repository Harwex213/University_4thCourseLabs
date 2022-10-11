package com.harwex.lab04;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.HttpClients;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Calendar;
import java.util.Scanner;

@WebServlet(name = "JjjServlet", value = "/jjj")
public class JjjServlet extends HttpServlet {
    public static class Parameters {
        public static String WithRequest = "withRequest";
        public static String WithPost = "withPost";
    }

    private DateTime getCurrentDateTime()
    {
        int currentHour = Calendar.getInstance().get(Calendar.HOUR_OF_DAY);
        DateTime currentDateTime;
        if (currentHour <= 6 || currentHour >= 21) {
            currentDateTime = DateTime.NIGHT;
        } else if (currentHour <= 12) {
            currentDateTime = DateTime.MORNING;
        } else if (currentHour <= 18) {
            currentDateTime = DateTime.AFTERNOON;
        } else {
            currentDateTime = DateTime.EVENING;
        }
        return currentDateTime;
    }

    private void executeRequest(PrintWriter out, CloseableHttpResponse execute) {
        try {
            var sc = new Scanner(execute.getEntity().getContent());

            while(sc.hasNext()) {
                out.println((sc.nextLine()));
            }
        } catch (Exception e) {
            e.printStackTrace(System.out);
        }
    }

    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        var currentDateTime = getCurrentDateTime();
        var path = "/dateTimes/" + currentDateTime.getDateTimeName() + ".jsp";
        var out = response.getWriter();

        var url = request.getRequestURL();
        var uri = request.getRequestURI();
        var host = url.substring(0, url.indexOf(uri));
        var httpClient = HttpClients.createDefault();

        var withRequest = request.getParameter(Parameters.WithRequest);
        if (withRequest != null) {
            var httpGet = new HttpGet(host + getServletContext().getContextPath() + path);
            executeRequest(out, httpClient.execute(httpGet));
        }

        var withPost = request.getParameter(Parameters.WithPost);
        if (withPost != null) {
            var httpPost = new HttpPost(host + getServletContext().getContextPath() + path);
            executeRequest(out, httpClient.execute(httpPost));
        }

        getServletContext()
                .getRequestDispatcher(path)
                .forward(request, response);
    }
}