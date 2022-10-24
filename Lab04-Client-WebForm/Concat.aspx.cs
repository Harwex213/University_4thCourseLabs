using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Harwex.Models;

public partial class Concat : System.Web.UI.Page
{
    private Simplex simplex;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            return;
        }

        simplex = new SimplexImplementaion();
        double.TryParse(d.Value, out double _d);

        concatResult.InnerText = "Result is: " + simplex.Concat(k.Value, _d);
    }
}