﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Harwex.Models;

public partial class Main : System.Web.UI.Page
{
    private Simplex simplex;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            return;
        }

        simplex = new SimplexImplementaion();
        int.TryParse(x.Value, out int paramX);
        int.TryParse(y.Value, out int paramY);

        addResult.InnerText = "Result is: " + simplex.Add(paramX, paramY);
    }
}