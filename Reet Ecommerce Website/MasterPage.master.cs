using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    classes cl = new classes();
    validation ck = new validation();
    static user_detail un;
    int idus;
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["login"] == null)
            {
                lbtnUser.Visible = false;
                lbtncart.Visible = true;
                lbtnlogin.Visible = true;
               
                lbtnlog.Visible = false;
                lbtnbanner.Visible = false;
                lbtnCate.Visible = false;
                lbtnProd.Visible = false;
                lbtnuserCart.Visible = false;
            }
            else
            {
                idus = Convert.ToInt32(Session["Login"]);
                un = cl.getUserbyID(idus);
                lblUser.Text = un.user_fullname;
                imguser.ImageUrl = "images/Userimg/" + un.user_pro_image;
                lbtnUser.Visible = true;
                lbtncart.Visible = false;
                lbtnlogin.Visible = false;
               
                lbtnlog.Visible = true;
                lbtnbanner.Visible = true;
                lbtnCate.Visible = true;
                lbtnProd.Visible = true;
                lbtnuserCart.Visible = true;
            }
        
    }

    protected void Unnamed_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("shopping-cart.aspx");
    }
    protected void Unnamed_Command1(object sender, CommandEventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    protected void Unnamed_Command2(object sender, CommandEventArgs e)
    {
        Response.Redirect("admin.aspx");
    }
    protected void Unnamed_Command3(object sender, CommandEventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void Unnamed_Command4(object sender, CommandEventArgs e)
    {
        Session["login"] = null;
        Response.Redirect("index.aspx");
    }
    protected void lbtnCate_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("admin.aspx");
    }
    protected void Unnamed_Command5(object sender, CommandEventArgs e)
    {
        Response.Redirect("admin-person.aspx");
    }
    protected void lbtnBanner_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("admin-banner.aspx");
    }
    protected void lbtnProd_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("admin-product.aspx");
    }
    protected void lbtnuserCart_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("admin-cart.aspx");
    }
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        string res = txtSearch.Text.Trim();
        if (ck.checkstringnull(res))
        {
            Response.Redirect("search.aspx?result=" + res);
        }
        else
        {
            Response.Redirect("index.aspx");
        }
        
    }
   
}
