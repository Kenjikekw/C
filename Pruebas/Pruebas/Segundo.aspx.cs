using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Segundo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Drop.Items.Add("Baloncesto");
        Drop.Items.Add("Futbol");
        Drop.Items.Add("Tenis");
    }
}