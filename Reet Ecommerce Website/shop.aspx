<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shop.aspx.cs" Inherits="shop" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    

    <section>
         <div class="col-sm-12" style="padding: 0px">
        <!--category-products-->
        <ul class="ul_cat">
            <asp:Repeater runat="server" ID="repCate">
                <ItemTemplate>
                    <li class="col-sm-2 li_cat">
                        <h4 class="panel-title">
                                                <asp:LinkButton ID="linkc" Text='<%#Eval("cat_name") %>' CommandArgument='<%#Eval("id_cat") %>' CommandName="linkCate" runat="server" OnCommand="linkc_Command" /> </h4>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!--/category-products-->

                 <div class="container bg">
        <div class="row">
            <div class="col-sm-12 padding-right bg">
                <div class="features_items">
                    <!--features_items-->
                    <h2 class="title text-center">Features Items</h2>


                    <asp:Repeater ID="rep" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-3">

                                <div class="product-image-wrapper">
                                    <div class="single-products">

                                        <div class="productinfo text-center">

                                            <asp:Image ID="imgcat" ImageUrl='<%#Eval("CatPro_img", "images/product-category/{0}") %>' runat="server" Style="height: 230px" />
                                            <h2><i class="fa fa-inr"></i><asp:Label ID="lblPrice" Text='<%#Eval("CatPro_price")%>' runat="server" /></h2>
                                            <asp:Label ID="lblid" Text='<%#Eval("CatPro_id")%>' runat="server" Visible="false" />
                                            <p>
                                                <asp:Label ID="lblName" Text='<%#Eval("CatPro_name")%>' runat="server" />
                                            </p>

                                        </div>
                                        <div class="product-overlay">
                                            <div class="overlay-content">
                                                <h2><i class="fa fa-inr"></i><%#Eval("CatPro_price") %></h2>
                                                <p><%#Eval("CatPro_name") %></p>

                                                <asp:LinkButton CommandArgument='<%#Eval("CatPro_id")%>' class="btn btn-default add-to-cart" ID="Info" runat="server" OnCommand="cmdInfo1"><i class="fa fa-info-circle"></i>Info</asp:LinkButton>
                                                <asp:LinkButton CommandArgument='<%#Eval("CatPro_id")%>' class="btn btn-default add-to-cart" ID="AddToCart" runat="server" OnCommand="cmdAddToCart"><i class="fa fa-shopping-cart"></i>Add To Cart</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    </div>
                    <div style="text-align: center; margin-bottom: 5%">
                        <cc1:CollectionPager ID="CollectionPager1" runat="server" ShowPageNumbers="True" PageNumbersDisplay="Numbers" BackNextDisplay="Buttons" ResultsLocation="Bottom" ResultsStyle="display:none" LabelText="Trang" ShowLabel="False" NextText="Next" BackText="Back" ShowFirstLast="False" BackNextLocation="Split" PageNumbersStyle="margin:2%;"></cc1:CollectionPager>
                    </div>
    </section>
</asp:Content>

