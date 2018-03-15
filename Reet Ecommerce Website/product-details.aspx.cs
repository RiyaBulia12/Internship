using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class product_detail : System.Web.UI.Page
{
    classes cl = new classes();
    List<category_name> cate_list;
    validation ck = new validation();
    int id = 0;
    static DataTable tbguest = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

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
            load_pro();
            loadCate();
        }
    }
    public void load_pro()
    {
        if (ck.checkQuantity(Request.QueryString["id"]))
        {

            id = Convert.ToInt32(Request.QueryString["id"]);
        }

        category_product_detail p = cl.getProduct(id);
        lblID.Text = p.id_pro + "";
        lblName.Text = p.pro_name;
        lblPrice.Text = p.pro_price + "";
        Repeater3.DataSource = p.product_images;
        Repeater3.DataBind();
    }
    public void loadCate()
    {
        cate_list = cl.getAllCategory();
        repCate.DataSource = cate_list;
        repCate.DataBind();
    }
    protected void linkc_Command(object sender, CommandEventArgs e)
    {
        int n = Convert.ToInt32(e.CommandArgument);
        Response.Redirect("shop.aspx?id=" + n);
    }
    protected void cmdaddtocart(object sender, CommandEventArgs e)
    {

        if (e.CommandName == "atc")
        {
            foreach (RepeaterItem it in Repeater3.Items)
            {
                Image img = (Image)it.FindControl("imgsold");
                int P_ID = int.Parse(lblID.Text);
                string strP_desc = (lblName.Text);
                string imgcat = img.ImageUrl;
                float flP_price = float.Parse(lblPrice.Text);
                int intP_qty = 1;
                addtocart(P_ID, imgcat, strP_desc, flP_price, intP_qty);
            }
        }

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

        Response.Write("<script>alert('Add Complete')</script>");
    }
}