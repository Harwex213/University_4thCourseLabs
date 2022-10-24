using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Harwex.Models;

public partial class Sum : System.Web.UI.Page
{
    private Simplex simplex;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            return;
        }

        int.TryParse(k_a1.Value, out int a1_k);
        int.TryParse(k_a2.Value, out int a2_k);
        float.TryParse(f_a1.Value, out float a1_f);
        float.TryParse(f_a2.Value, out float a2_f);

        simplex = new SimplexImplementaion();
        sumResult.InnerText = "Result A is: " + simplex.Sum(new A()
        {
            k = a1_k,
            f = a1_f,
            s = s_a1.Value,
        }, new A()
        {
            k = a2_k,
            f = a2_f,
            s = s_a2.Value,
        }).Display();
    }
}