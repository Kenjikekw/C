using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Alumnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idEmpleado = DropDownList2.SelectedValue;

        AccessDataSource1.SelectParameters.Clear();
        AccessDataSource1.SelectParameters.Add("IdEmpleado", idEmpleado);

        GridView1.DataBind();
    }
}