using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class classes
{

    

    public List<CatPro> getbanner()
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.banners
                 select (new CatPro
                 {
                     banimg=a.banner_image
                 }

                 )
                 );
        return q.ToList();
    }



    public int getUser(string name, string pass)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.user_details
                 where a.user_name == name
                 where a.user_password == pass
                 where a.user_cat_id == 1
                 select a).SingleOrDefault();
        if (q == null)
        {
            return -1;
        }
        else
        {
            return q.user_id;
        }
    }
    public user_detail getUserbyID(int id)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.user_details
                 where a.user_id == id
                 select a).SingleOrDefault();
        return q;
    }
    public void UpdateUser(user_detail un)
    {
        try
        {
            LQDataContext ctxx = new LQDataContext();
            var q = ctxx.user_details.Where(d => d.user_id == un.user_id).SingleOrDefault();
            q.user_name = un.user_name;
            q.user_fullname = un.user_fullname;
            q.user_pro_image = un.user_pro_image;
            q.user_age = un.user_age;
            q.user_email = un.user_email;
            ctxx.SubmitChanges();
        }
        catch (Exception ex)
        {

        }
    }
    public void UpdateUserPass(user_detail un)
    {
        try
        {
            LQDataContext ctxx = new LQDataContext();
            var q = ctxx.user_details.Where(d => d.user_id == un.user_id).SingleOrDefault();
            q.user_password = un.user_password;
            ctxx.SubmitChanges();
        }
        catch (Exception ex)
        {

        }
    }
    //all about category
    public List<category_name> getAllCategory()
    {
        LQDataContext ctx = new LQDataContext();
        return ctx.category_names.ToList();
    }
    public category_name getCate(int id)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.category_names
                 where a.id_cat == id
                 select a).SingleOrDefault();
        return q;
    }
    public bool AddCate(category_name catss)
    {

        LQDataContext ctxs = new LQDataContext();
        ctxs.category_names.InsertOnSubmit(catss);
        ctxs.SubmitChanges();
        return true;
    }
    public void UpdateCate(category_name ca)
    {
        try
        {
            LQDataContext ctxx = new LQDataContext();
            var q = ctxx.category_names.Where(d => d.id_cat == ca.id_cat).SingleOrDefault();
            q.cat_name = ca.cat_name;
            ctxx.SubmitChanges();
        }
        catch (Exception ex)
        {

        }
    }
    public bool DeleteCate(int id)
    {
        try
        {
            LQDataContext dm = new LQDataContext();
            var q = (from a in dm.category_names
                     where a.id_cat == id
                     select a).SingleOrDefault();
            dm.category_names.DeleteOnSubmit(q);
            dm.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    //all about pro duct
    public List<category_product_detail> getAllProduct()
    {
        LQDataContext ctx = new LQDataContext();
        return ctx.category_product_details.ToList();
    }
    public List<category_product_detail> getTopProduct(int top)
    {
        LQDataContext ctx = new LQDataContext();
        var list = (from t in ctx.category_product_details
                    orderby t.pro_price
                    select t).Take(top);
        return list.ToList();
    }
    public List<category_product_detail> getCateProduct(int cate)
    {
        LQDataContext ctx = new LQDataContext();
        var list = (from t in ctx.category_product_details
                    where t.id_cat == cate
                    select t);
        return list.ToList();
    }
    public bool checkalprod(string name)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.category_product_details
                 where a.pro_name == name
                 select a).SingleOrDefault();
        if (q == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public category_product_detail getProduct(int id)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.category_product_details
                 where a.id_pro == id
                 select a).SingleOrDefault();
        return q;
    }
    public List<CatPro> getMainProduct()
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.category_product_details
                 join c in dm.product_images
                 on a.id_pro equals c.id_prod
                 where c.sub_img == 1
                 select (new CatPro
                 {
                     idCatMPro = a.id_cat,
                     CatPro_id = a.id_pro,
                     CatPro_name = a.pro_name,
                     CatPro_price = float.Parse(a.pro_price + ""),
                     CatPro_img = c.img_url
                 }

                 )
                 );
        return q.ToList();
    }
    public List<CatPro> getMainCateProduct(int cate)
    {
        LQDataContext ctx = new LQDataContext();

        var q = (from a in ctx.category_product_details
                 join c in ctx.product_images
                 on a.id_pro equals c.id_prod
                 where a.id_cat == cate
                 where c.sub_img == 1

                 select (new CatPro
                 {
                     idCatMPro = a.id_cat,
                     CatPro_id = a.id_pro,
                     CatPro_name = a.pro_name,
                     CatPro_price = float.Parse(a.pro_price + ""),
                     CatPro_img = c.img_url
                 }

                 )
             );

        return q.ToList();
    }
    public List<CatPro> getSearchProduct(string result)
    {
        LQDataContext ctx = new LQDataContext();

        var q = (from a in ctx.category_product_details
                 join c in ctx.product_images
                 on a.id_pro equals c.id_prod
                 where a.pro_name.Contains(result.Trim())
                 where c.sub_img == 1

                 select (new CatPro
                 {
                     idCatMPro = a.id_cat,
                     CatPro_id = a.id_pro,
                     CatPro_name = a.pro_name,
                     CatPro_price = float.Parse(a.pro_price + ""),
                     CatPro_img = c.img_url
                 }

                 )
             );

        return q.ToList();
    }
    public bool AddProduct(category_product_detail pr)
    {
        LQDataContext ctxs = new LQDataContext();
        ctxs.category_product_details.InsertOnSubmit(pr);
        ctxs.SubmitChanges();
        return true;
    }
    public void UpdateProduct(category_product_detail pr)
    {
        try
        {
            LQDataContext ctxx = new LQDataContext();
            var q = ctxx.category_product_details.Where(d => d.id_pro == pr.id_pro).SingleOrDefault();
            q.id_cat = pr.id_cat;
            q.pro_name = pr.pro_name;
            q.pro_price = pr.pro_price;
            ctxx.SubmitChanges();
        }
        catch (Exception ex)
        {

        }
    }
    public bool DeleteProduct(int id)
    {
        try
        {
            LQDataContext dm = new LQDataContext();
            var q = (from a in dm.category_product_details
                     where a.id_pro == id
                     select a).SingleOrDefault();
            dm.category_product_details.DeleteOnSubmit(q);
            dm.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }




    }
    //all about customer
    public List<customer_detail> getAllCustomer()
    {
        LQDataContext ctx = new LQDataContext();
        return ctx.customer_details.ToList();
    }
    public bool AddCustomer(customer_detail ca)
    {
        LQDataContext ctxs = new LQDataContext();
        ctxs.customer_details.InsertOnSubmit(ca);
        ctxs.SubmitChanges();
        return true;
    }
    public void UpdateCustomer(customer_detail ca)
    {
        try
        {
            LQDataContext ctxx = new LQDataContext();
            var q = ctxx.customer_details.Where(d => d.id_cus == ca.id_cus).SingleOrDefault();
            q.cus_name = ca.cus_name;
            q.email = ca.email;
            ctxx.SubmitChanges();
        }
        catch (Exception ex)
        {

        }
    }
    public bool DeleteCustomer(int id)
    {
        try
        {
            LQDataContext dm = new LQDataContext();
            var q = (from a in dm.customer_details
                     where a.id_cus == id
                     select a).SingleOrDefault();
            dm.customer_details.DeleteOnSubmit(q);
            dm.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    public int checkCus(string name, string cust_email)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.customer_details
                 where a.cus_name == name
                 where a.email == cust_email
                 select a).SingleOrDefault();
        if (q == null)
        {
            return -1;
        }
        else
        {
            return q.id_cus;
        }
    }
    public customer_detail getCusbyID(int id)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.customer_details
                 where a.id_cus == id
                 select a).SingleOrDefault();
        return q;
    }

    //all about customer_cart_time
    public List<customer_cart_time> getAllCart()
    {
        LQDataContext ctx = new LQDataContext();
        return ctx.customer_cart_times.ToList();
    }
    public List<customer_cart_time> getCustomerCart(int idcus)
    {
        LQDataContext ctx = new LQDataContext();
        var list = (from t in ctx.customer_cart_times
                    where t.id_cus == idcus
                    select t);
        return list.ToList();
    }
    public bool checkalcate(string name)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.category_names
                 where a.cat_name == name
                 select a).SingleOrDefault();
        if (q == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool AddCart(customer_cart_time ca)
    {
        LQDataContext ctxs = new LQDataContext();
        ctxs.customer_cart_times.InsertOnSubmit(ca);
        ctxs.SubmitChanges();
        return true;
    }
    public void UpdateCate(customer_cart_time ca)
    {
        try
        {
            LQDataContext ctxx = new LQDataContext();
            var q = ctxx.customer_cart_times.Where(d => d.id_cart == ca.id_cart).SingleOrDefault();
            q.time_cart = ca.time_cart;
            ctxx.SubmitChanges();
        }
        catch (Exception ex)
        {

        }
    }
    public bool DeleteCart(int id)
    {
        try
        {
            LQDataContext dm = new LQDataContext();
            var q = (from a in dm.customer_cart_times
                     where a.id_cart == id
                     select a).SingleOrDefault();
            dm.customer_cart_times.DeleteOnSubmit(q);
            dm.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }



    //all about detail customer_cart_time
    public List<cart_detail> getAlldtCart()
    {
        LQDataContext ctx = new LQDataContext();
        return ctx.cart_details.ToList();
    }
    public List<cart_detail> getDetailCartID(int idcart)
    {
        LQDataContext ctx = new LQDataContext();
        var list = (from t in ctx.cart_details
                    where t.id_cart == idcart
                    select t);
        return list.ToList();
    }
    public bool AdddtCart(cart_detail ca)
    {
        LQDataContext ctxs = new LQDataContext();
        ctxs.cart_details.InsertOnSubmit(ca);
        ctxs.SubmitChanges();
        return true;
    }

    public cart_detail getdtCart(int id_Cart)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.cart_details
                 where a.id_cart == id_Cart
                 select a).SingleOrDefault();
        return q;
    }
    public bool checkdtCart(int id_dtCart, int id_proz)
    {
        LQDataContext dm = new LQDataContext();
        var q = (from a in dm.cart_details
                 where a.id_dtcart == id_dtCart
                 where a.id_pro == id_proz
                 select a).SingleOrDefault();
        if (q != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void updatedtCart(cart_detail dtc)
    {
        LQDataContext ctxx = new LQDataContext();
        var q = ctxx.cart_details.Where(d => d.id_dtcart == dtc.id_dtcart).SingleOrDefault();
        q.id_pro = dtc.id_pro;
        q.quantity = dtc.quantity;
        ctxx.SubmitChanges();
    }
    public bool DeletedtCart(int id_dtCart)
    {
        try
        {
            LQDataContext dm = new LQDataContext();
            var q = (from a in dm.cart_details
                     where a.id_dtcart == id_dtCart
                     select a).SingleOrDefault();
            dm.cart_details.DeleteOnSubmit(q);
            dm.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    //all about image
    public List<product_image> getAllimgpro()
    {
        LQDataContext ctx = new LQDataContext();
        return ctx.product_images.ToList();
    }
    public List<product_image> getProdImage(int idprod)
    {
        LQDataContext ctx = new LQDataContext();
        var list = (from t in ctx.product_images
                    where t.id_prod == idprod
                    select t);
        return list.ToList();
    }
    public product_image getImage(int id)
    {
        LQDataContext ctx = new LQDataContext();
        var n = (from t in ctx.product_images
                 where t.id_img == id
                 select t).SingleOrDefault();
        return n;
    }
    public bool AddimgProd(product_image imp)
    {
        LQDataContext ctxs = new LQDataContext();
        ctxs.product_images.InsertOnSubmit(imp);
        ctxs.SubmitChanges();
        return true;
    }
    //public product_image getMainimg(int idprod)
    //{
    //    LQDataContext ctx = new LQDataContext();
    //    var azz = (from t in ctx.product_images
    //               where t.id_prod == idprod
    //               where t.sub_img == 1
    //               select t).SingleOrDefault();
    //    return azz;
    //}
    
    public void UpdateimgProd(product_image imp)
    {
        try
        {
            LQDataContext ctxx = new LQDataContext();
            var q = ctxx.product_images.Where(d => d.id_img == imp.id_img).SingleOrDefault();
            q.img_url = imp.img_url;
            ctxx.SubmitChanges();
        }
        catch (Exception ex)
        {

        }
    }
    public bool DeleteImgProd(int id)
    {
        try
        {
            LQDataContext dm = new LQDataContext();
            var q = (from a in dm.product_images
                     where a.id_img == id
                     select a).SingleOrDefault();
            dm.product_images.DeleteOnSubmit(q);
            dm.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

}
