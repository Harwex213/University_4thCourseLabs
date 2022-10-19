package com.harwex.lab10;

import com.harwex.lab10.datasource.DbContext;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import lombok.SneakyThrows;

import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Types;

@WebServlet(name = "StoredProcedureServlet", value = "/stored-procedure")
public class StoredProcedureServlet extends HttpServlet {
    private static class Parameters {
        public static String Threshold = "age";
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response)  {
        try {
            var out = response.getWriter();

            var thresholdStr = request.getParameter(Parameters.Threshold);
            if (thresholdStr == null || thresholdStr.isEmpty()) {
                out.println("Set threshold age before please");
                return;
            }
            var threshold = Integer.parseInt(thresholdStr);

            var connection = DbContext.getConnection();
            var prepareStatement = connection.prepareCall("CALL CountCatsThreshold(?, ?)");
            prepareStatement.setInt(1, threshold);
            prepareStatement.registerOutParameter(2, java.sql.Types.INTEGER);

            prepareStatement.executeQuery();
            out.println("Cats counted: " + prepareStatement.getInt(2));

            prepareStatement.close();
        } catch (SQLException | IOException e) {
            e.printStackTrace();
        }
    }
}

/*
USE java_10;

CREATE or replace TABLE cats
(
    id int primary key auto_increment,
    name nvarchar(50) NOT NULL,
    age int NOT NULL
);

create or replace procedure CountCatsThreshold(IN _age int, OUT _count int)
begin
    select count(*) into _count from cats where age <= _age;
end;


call CountCatsThreshold(5,@out_value);
select @out_value;

insert into cats(name, age) values('bobik', 3);
insert into cats(name, age) values('oleg', 4);
insert into cats(name, age) values('vasek', 5);

select * from cats
 */