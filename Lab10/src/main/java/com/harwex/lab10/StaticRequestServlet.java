package com.harwex.lab10;

import com.google.gson.Gson;
import com.harwex.lab10.datasource.Cat;
import com.harwex.lab10.datasource.DbContext;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import lombok.SneakyThrows;

import java.io.IOException;
import java.sql.ResultSet;
import java.util.ArrayList;

@WebServlet(name = "StaticRequestServlet", value = "/request")
public class StaticRequestServlet extends HttpServlet {
    private static class Parameters {
        public static String Static = "static";
        public static String Dynamic = "dynamic";
        public static String Dynamic_Name = "name";
    }

    @SneakyThrows
    private String resultSetToJson(ResultSet result) {
        var cats = new ArrayList<Cat>();

        while (result.next()){
            var cat = new Cat();
            cat.setId(result.getInt("id"));
            cat.setName(result.getString("name"));
            cat.setAge(result.getShort("age"));
            cats.add(cat);
        }

        var gson = new Gson();

        return gson.toJson(cats);
    }


    @SneakyThrows
    private void doStatic(HttpServletRequest request, HttpServletResponse response) {
        var statement = DbContext.getStatement();

        var result = statement.executeQuery("select * from cats");
        var json = resultSetToJson(result);

        var out = response.getWriter();
        out.println(json);
    }

    @SneakyThrows
    private void doDynamic(HttpServletRequest request, HttpServletResponse response) {
        var nameParam = request.getParameter(Parameters.Dynamic_Name);
        if (nameParam == null || nameParam.isEmpty()) {
            var out = response.getWriter();
            out.println("Set name before please");
            return;
        }

        var connection = DbContext.getConnection();
        var prepareStatement = connection.prepareStatement("select * from cats where name like ?");
        prepareStatement.setString(1, "%" + nameParam + "%");

        var result = prepareStatement.executeQuery();
        var json = resultSetToJson(result);
        prepareStatement.close();

        var out = response.getWriter();
        out.println(json);
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        var staticParam = request.getParameter(Parameters.Static);
        var dynamicParam = request.getParameter(Parameters.Dynamic);

        if (staticParam != null) {
            doStatic(request, response);
            return;
        } else if (dynamicParam != null) {
            doDynamic(request, response);
            return;
        }

        var out = response.getWriter();
        out.println("Nothing to do");
    }
}