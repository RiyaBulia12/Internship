using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search : System.Web.UI.Page
{
    validation ck = new validation();
    classes cl = new classes();
    List<CatPro> prim;
    List<category_name> cate_list;
    static DataTable tbguest = new DataTable();
    static string result;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            result = Request.QueryString["result"];

            if (Session["guest"] != null)
            {
                tbguest = Session["guest"] as DataTable;
            }
            else
            {
                tbguest.Rows.Clear();
                tbguest.Columns.Clear();
                tbguest.Columns.Add("P_ID", typeof(int));
                tbguest.Columns.Add("P_img", typeof(string));
                tbguest.Columns.Add("P_desc", typeof(string));
                tbguest.Columns.Add("P_price", typeof(float));
                tbguest.Columns.Add("P_qty", typeof(int));
                tbguest.Columns.Add("P_sum", typeof(double), "P_qty * P_price");
            }
            loadCate();
            load_Prod(result);
        }
    }
    public void loadCate()
    {
        cate_list = cl.getAllCategory();
        repCate.DataSource = cate_list;
        repCate.DataBind();
    }
    public void load_Prod(string res)
    {

        prim = cl.getSearchProduct(res);
        CollectionPager1.PageSize = 12;
        CollectionPager1.DataSource = prim;
        CollectionPager1.BindToControl = rep;
        rep.DataSource = CollectionPager1.DataSourcePaged;
        rep.DataBind();


    }

    protected void linkc_Command(object sender, CommandEventArgs e)
    {
        int n = Convert.ToInt32(e.CommandArgument);
        Response.Redirect("shop.aspx?id=" + n);
    }
    protected void cmdInfo(object sender, CommandEventArgs e)
    {

        int n = Convert.ToInt32(e.CommandArgument);
        Response.Redirect("product-details.aspx?id=" + n);
    }
    public void addtocart(int P_ID, string imgh, string strP_desc, float flP_price, int intP_qty)
    {
        foreach (DataRow row in tbguest.Rows)
        {
            if ((int)row["P_ID"] == P_ID)
            {
                row["P_qty"] = (int)row["P_qty"] + 1;
                goto guest;
            }
        }
        tbguest.Rows.Add(P_ID, imgh, strP_desc, flP_price, intP_qty);
    guest:
        Session["guest"] = tbguest;

        Response.Write("<script>alert('Added to Cart')</script>");
    }
    protected void cmdAddToCart(object sender, CommandEventArgs e)
    {
        foreach (RepeaterItem it in rep.Items)
        {
            Label n1 = (Label)it.FindControl("lblid");
            Label n2 = (Label)it.FindControl("lblName");
            Label n3 = (Label)it.FindControl("lblPrice");
            Image n4 = (Image)it.FindControl("imgcat");
            if (n1.Text == e.CommandArgument.ToString())
            {
                int P_ID = Convert.ToInt32(n1.Text);
                string strP_desc = n2.Text;
                float P_price = float.Parse(n3.Text);
                int intP_qty = 1;
                string imgcatzz = n4.ImageUrl;
                addtocart(P_ID, imgcatzz, strP_desc, P_price, intP_qty);
            }

        }
        load_Prod(result);
    }
}