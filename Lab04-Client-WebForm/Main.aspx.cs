using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    private Simplex client;

    protected void Page_Load(object sender, EventArgs e)
    {
        client = new Simplex();
    }

    protected void Sum_Click(object sender, EventArgs e)
    {
        int x, y;
        if (int.TryParse(first.Text.ToString(), out x) && int.TryParse(second.Text.ToString(), out y))
        {
            result.Text = client.Add(x, y).ToString();

        }
        else
        {
            result.Text = "Error!";
        }
    }
}