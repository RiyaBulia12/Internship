﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    classes cl = new classes();
    validation ck = new validation();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Form.DefaultButton = btnLogin.UniqueID;
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        string name = tbName.Text;
        string pass = tbPass.Text;
        if (ck.checkstringnull(name))
        {
            if (ck.checkstringnull(pass))
            {
                int n = cl.getUser(name,pass);
                if (n>=0)
                {
                    Session["login"] = n;
                    Response.Redirect("admin.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login Fail! Please Check Your Username or Password')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Type Your Password')", true);
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Type Your Username')", true);
        }
        
    
    }

    
}