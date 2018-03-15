using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_banner : System.Web.UI.Page
{
    classes cl = new classes();
    List<CatPro> prim;

    protected void Page_Load(object sender, EventArgs e)
    {

        prim = cl.getbanner();
        Repeater3.DataSource = prim;
        Repeater3.DataBind();
    
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/scripts/jquery-1.4.1.min.js",
            DebugPath = "~/scripts/jquery-1.4.1.js",
            CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.min.js",
            CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.js"
        });
    }
}