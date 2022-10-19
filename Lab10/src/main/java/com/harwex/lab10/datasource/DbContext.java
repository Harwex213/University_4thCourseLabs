package com.harwex.lab10.datasource;

import lombok.SneakyThrows;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;

public final class DbContext {
    private static Connection connection;
    private static Statement statement;
    private static String connectionString;

    private DbContext() {}

    @SneakyThrows
    private static Connection getConnectionInstance()
    {
        Class.forName("org.mariadb.jdbc.Driver").getDeclaredConstructor().newInstance();
        return DriverManager.getConnection(connectionString);
    }

    public static void setConnectionString(String _connectionString) {
        connectionString = _connectionString;
    }

    @SneakyThrows
    public static Connection getConnection() {
        if (connectionString == null) {
            throw new Exception("ConnectionString must be set before getting connection");
        }
        if (connection == null) {
            connection = getConnectionInstance();
        }
        return connection;
    }

    @SneakyThrows
    public static Statement getStatement() {
        if (connection == null) {
            throw new Exception("Connection must be opened before getting statement");
        }
        if (statement == null) {
            statement = connection.createStatement();
        }
        return statement;
    }
}