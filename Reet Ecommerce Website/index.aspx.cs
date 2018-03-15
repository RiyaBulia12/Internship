using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    classes cl = new classes();
    List<CatPro> prim;
    protected void Page_Load(object sender, EventArgs e)
    {
        prim = cl.getbanner();
        Repeater3.DataSource = prim;
        Repeater3.DataBind();

    }
}