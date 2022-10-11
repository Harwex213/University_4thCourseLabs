package com.harwex.lab04;

public enum DateTime {
    MORNING("morning"),
    EVENING("evening"),
    AFTERNOON("afternoon"),
    NIGHT("night");

    private final String dateTimeName;

    DateTime(String dateTimeName) {
        this.dateTimeName = dateTimeName;
    }

    public String getDateTimeName() {
        return dateTimeName;
    }
}
