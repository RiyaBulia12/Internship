using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
{
    classes cl = new classes();
  
    List<category_name> cate_list;
    category_name ca;
    validation ck = new validation();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Form.DefaultButton = addCate.UniqueID;

        if (!IsPostBack)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("404.html");
            }
            else
            {
                loadCate();
            }
        }
    }

    public void loadCate()
    {
        cate_list = cl.getAllCategory();
        repCate.DataSource = cate_list;
        repCate.DataBind();  
    }

    
    public void clearall()
    {
        tbCate.Text = "";
    }
   
    protected void addCate_Click(object sender, EventArgs e)
    {
        if (ck.checkstringnull(tbCate.Text))
        {
            if (ck.checkstring(tbCate.Text, 50))
            {
                if(cl.checkalcate(tbCate.Text.Trim())){
ca = new category_name();
                ca.cat_name = tbCate.Text.Trim();
                cl.AddCate(ca);
                loadCate();
                clearall();
                }
                else{
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The Category Name Already Exist')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The Category Name Too Long')", true);
           
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Type Category')", true);
           
        }
      
    }
    protected void del_Command(object sender, CommandEventArgs e)
    {

        if (e.CommandName == "ghDel")
        {
            for (int item = 0; item < repCate.Items.Count; item++)
            {
                Label lb = repCate.Items[item].FindControl("lblidcat") as Label;
                if (lb.Text == e.CommandArgument.ToString())
                {
                    if (cl.DeleteCate(Convert.ToInt32(lb.Text)))
                    {
                        loadCate();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Complete')", true);
           
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Fail')", true);
           
                    }

                }
            }
        }
    }
   
    protected void Unnamed_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "ghUpdate")
        {
            for (int item = 0; item < repCate.Items.Count; item++)
            {
                Label lb = repCate.Items[item].FindControl("lblidcat") as Label;
                TextBox tb = repCate.Items[item].FindControl("txtCateName") as TextBox;
                if (lb.Text == e.CommandArgument.ToString())
                {
                    ca = cl.getCate(int.Parse(lb.Text));
                    if (ck.checkstringnull(tb.Text))
                    {
                        ca.cat_name = tb.Text;
                        cl.UpdateCate(ca);
                        loadCate();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Type Your Category')", true);
                    }
                }
            }
        }
    }
}