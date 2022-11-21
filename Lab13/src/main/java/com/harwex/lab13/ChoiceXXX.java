package com.harwex.lab13;

import java.io.File;
import java.io.FilenameFilter;

public class ChoiceXXX {
    public String[] list;

    protected static class OnlyXXX implements FilenameFilter {
        private final String xxx;

        public OnlyXXX(String xxx) {
            this.xxx = "." + xxx;
        }

        public boolean accept(File d, String name) {
            return name.endsWith(xxx);
        }
    }

    public ChoiceXXX(String dirPath, String xxx) {
        File dir = new File(dirPath);
        if (dir.exists()) {
            list = dir.list(new OnlyXXX(xxx));
        }
    }
}
