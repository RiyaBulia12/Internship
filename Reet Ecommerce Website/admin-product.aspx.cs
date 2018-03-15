using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_product : System.Web.UI.Page
{
    classes cl = new classes();
    List<CatPro> prim;
    category_product_detail pr;
    product_image ip;
    List<category_name> cate_list;
    List<product_image> listim = new List<product_image>();
    category_name ca;
    validation ck = new validation();
    int idCate;
    int tam = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Form.DefaultButton = btnAddPro.UniqueID;

        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/scripts/jquery-1.4.1.min.js",
            DebugPath = "~/scripts/jquery-1.4.1.js",
            CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.min.js",
            CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.js"
        });
        if (!IsPostBack)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("404.html");
            }
            else
            {
                ViewState["bf"] = 0;
                loadCate();
                load_Prod();
            }
           
        }
    }


    public void load_Prod()
    {
        prim = cl.getMainProduct();
        CollectionPager2.PageSize = 12;
        CollectionPager2.DataSource = prim;
        CollectionPager2.BindToControl = grid_product;
        grid_product.DataSource = CollectionPager2.DataSourcePaged;
        grid_product.DataBind();
    }
    public void loadCate()
    {
        cate_list = cl.getAllCategory();
        drCate.DataSource = cate_list;
        drCate.DataTextField = "cat_name";
        drCate.DataValueField = "id_cat";
        drCate.DataBind();
    }
    protected void del_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "delcm")
        {
            foreach (RepeaterItem it in grid_product.Items)
            {
                Label n1 = (Label)it.FindControl("lblid");
                if (n1.Text == e.CommandArgument.ToString())
                {
                    int n = Convert.ToInt32(n1.Text);
                    List<product_image> lim = cl.getProdImage(n);
                    foreach (product_image imgpr in lim)
                    {
                        listim.Add(imgpr);
                        cl.DeleteImgProd(imgpr.id_img);
                    }
                    if (cl.DeleteProduct(n))
                    {
                        
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Complete')", true);
                        break;
                    }
                    else
                    {
                        foreach (product_image imgpr1 in listim)
                        {
                            product_image imgtam = new product_image();
                            imgtam.id_prod = imgpr1.id_prod;
                            imgtam.img_url = imgpr1.img_url;
                            imgtam.sub_img = imgpr1.sub_img;
                            cl.AddimgProd(imgtam);
                        }
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Delete Fail')", true);
                       }
                }

            }
            load_Prod();
        }

    }
    protected void udate_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "upcm")
        {
            int idp = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("admin-detail.aspx?id=" + idp);
        }
    }
    public void clearall()
    {
        tbName1.Text = "";
        tbPrice1.Text = "";
    }
    protected void btnAddPro_Click(object sender, EventArgs e)
    {
      
        
        if (FileU.HasFile)
        {
            foreach (var file in FileU.PostedFiles)
            {
                if (!ck.CheckFileType(file.FileName))
                {
                    tam = 1;
                    break;
                }
            }
            if (tam == 0)
            {
                int dem = 0;
                pr = new category_product_detail();
                if ((int)ViewState["bf"] == 1)
                {
                    pr.id_cat = idCate;
                    ViewState["bf"] = 0;
                }
                else
                {
                    drCate.SelectedIndex = 0;
                    pr.id_cat = Convert.ToInt32(drCate.SelectedItem.Value);
                }
                if (ck.checkstringnull(tbName1.Text))
                {
                    if (ck.checkstringnull(tbPrice1.Text))
                    {
                        if (ck.checknumber(tbPrice1.Text))
                        {
                            if (ck.checkstring(tbName1.Text, 50))
                            {
                                if (cl.checkalprod(tbName1.Text.Trim()))
                                {
                                    pr.pro_name = tbName1.Text.Trim();
                                    pr.pro_price = float.Parse(tbPrice1.Text.Trim());
                                    cl.AddProduct(pr);
                                    foreach (var file in FileU.PostedFiles)
                                    {
                                       
                                        string fileName = "images/product-category/" + file.FileName;
                                        string filePath = MapPath(fileName);
                                        file.SaveAs(filePath);
                                        ip = new product_image();
                                        ip.id_prod = pr.id_pro;
                                        ip.img_url = file.FileName;
                                        imgS.ImageUrl = ip.img_url;
                                        if (dem == 0)
                                        {
                                            ip.sub_img = 1;
                                        }
                                        else
                                        {
                                            ip.sub_img = 0;
                                        }
                                        dem++;
                                        cl.AddimgProd(ip);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product Name Already Exist')", true);

                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product Name Too Long')", true);

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product Price Is Incorrect')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Type Product Price')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Type Product Name')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Image File Too Large Or Not Format(.jpg|.png|.gif)')", true);
               
            }
            
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Choose Image')", true);
        }
        load_Prod();
        loadCate();
        clearall();
    }
    protected void drCate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["bf"] = 1;
        idCate = Convert.ToInt32(drCate.SelectedItem.Value);
    }

}