using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shopping_cart : System.Web.UI.Page
{
    classes cl = new classes();
    customer_detail c;
    customer_cart_time cart1;
    cart_detail dc;
    validation ck = new validation();
    static DataTable tbguest = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data();
        }

    }
    private void load_data()
    {

        if (Session["guest"] == null || (Session["guest"] as DataTable).Rows.Count == 0)
        {
            Response.Redirect("Cart-message.aspx");

        }
        tbguest = (DataTable)Session["guest"];
        string strnumber = tbguest.Compute("Sum(P_sum)", "").ToString();
        rpguest.DataSource = tbguest;
        rpguest.DataBind();
    }
    private void del_data(string ms)
    {
        string n = ms;
        DataTable ca = Session["guest"] as DataTable;
        foreach (RepeaterItem it in rpguest.Items)
        {

            Label n1 = (Label)it.FindControl("lblID");
            if (n1.Text == ms)
            {
                foreach (DataRow dr in ca.Rows)
                {
                    if (dr["P_ID"].ToString() == ms)
                    {
                        dr.Delete();
                        break;
                    }
                }
            }
        }
        Session["guest"] = ca;
        load_data();
    }
    private void ud_data(string ms)
    {
        DataTable ca = Session["guest"] as DataTable;
        foreach (RepeaterItem it in rpguest.Items)
        {
            Label n1 = (Label)it.FindControl("lblID");

            if (n1.Text == ms)
            {
                foreach (DataRow dr in ca.Rows)
                {
                    TextBox n2 = (TextBox)it.FindControl("tbqty");
                    if (dr["P_ID"].ToString() == ms)
                    {
                        if (ck.checkstringnull(n2.Text))
                        {
                            if (ck.checkQuantity(n2.Text))
                            {
                                dr["P_qty"] = int.Parse(n2.Text);
                                break;
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Quantity Is Incorrect')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Quantity')", true);

                        }
                    }
                }
            }
        }
        Session["guest"] = ca;
        load_data();
    }
    protected void cmdDelete(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "cmdDel")
        {
            del_data(e.CommandArgument.ToString());
        }

    }
    protected void cmdUpd(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "cmdUpdate")
        {
            ud_data(e.CommandArgument.ToString());

        }
    }
    public bool add_cus()
    {
        string cname = txtCusName.Text;
        string cemail = txtEmail.Text;
        if (ck.checkstringnull(cname))
        {
            if (ck.checkstringnull(cemail))
            {
                if (ck.checkEmail(cemail))
                {
                    if (ck.checkstring(cemail, 100))
                    {
                        if (ck.checkstring(cname, 50))
                        {
                            int n = cl.checkCus(cname, cemail);
                            if (n == -1)
                            {
                                c = new customer_detail();
                                c.cus_name = cname;
                                c.email = cemail;
                                cl.AddCustomer(c);
                            }
                            else
                            {
                                c = cl.getCusbyID(n);
                            }
                            return true;
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Name exceeds the required length')", true);

                            return false;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email exceeds the required length')", true);

                        return false;
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Email Is Incorrect')", true);
                    return false;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Type Your Email')", true);
                return false;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Type Your Name')", true);
            return false;
        }


    }
    public void add_cart()
    {
        if (c != null)
        {
            cart1 = new customer_cart_time();
            cart1.id_cus = c.id_cus;
            cart1.time_cart = DateTime.Now;
            cl.AddCart(cart1);
        }
    }
    public void add_dtCart()
    {
        if (cart1 != null)
        {
            DataTable ca = Session["guest"] as DataTable;
            foreach (RepeaterItem it in rpguest.Items)
            {
                Label n1 = (Label)it.FindControl("lblID");
                TextBox n2 = (TextBox)it.FindControl("tbqty");
                Label n3 = (Label)it.FindControl("lblsum");
                Label n4 = (Label)it.FindControl("lbltsum");
                

                dc = new cart_detail();
                dc.id_cart = cart1.id_cart;
                dc.id_pro = Convert.ToInt32(n1.Text);
                dc.quantity = Convert.ToInt32(n2.Text);
                dc.total_price = float.Parse(n3.Text);
                //n4.Text = tbguest.Compute("Sum(lblsum)", "").ToString();
                cl.AdddtCart(dc);
            }
           
        }
    }
    protected void cmdCheckout(object sender, CommandEventArgs e)
    {
        if (add_cus())
        {
            add_cart();
            add_dtCart();
            Response.Redirect("checkout.aspx");
        }

    }
}