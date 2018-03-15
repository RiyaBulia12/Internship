<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="product-details.aspx.cs" Inherits="product_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="col-sm-12" style="padding: 0px">
            <!--category-products-->
            <ul class="ul_cat">
                <asp:Repeater runat="server" ID="repCate">
                    <ItemTemplate>
                        <li class="col-sm-2 li_cat">
                            <h4 class="panel-title">
                                <asp:LinkButton ID="linkc" Text='<%#Eval("cat_name") %>' CommandArgument='<%#Eval("id_cat") %>' CommandName="linkCate" runat="server" OnCommand="linkc_Command" /></h4>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!--/category-products-->

        <div class="container bg">
            <div class="row">
                <div class="col-sm-12 padding-right bg">
                    <div class="product-details">
                        <!--product-details-->
                        <div class="col-sm-6">
                            <div class="view-product">
                                <div id="carousel-example-generic1" class="carousel slide" data-ride="carousel">
                                    <!-- Indicators -->
                                    <!-- Wrapper for slides -->
                                    <div class="carousel-inner ">
                                        <asp:Repeater ID="Repeater3" runat="server">
                                            <ItemTemplate>
                                                <div class='item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                                    <asp:Image ID="imgsold" ImageUrl='<%#Eval("img_url", "images/product-category/{0}") %>' Style="height: 450px; margin: 0px !important;" runat="server" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <!-- Controls -->
                                    <a class="left control-carousel hidden-xs" data-slide="prev" href="#carousel-example-generic1" role="button">
                                        <i class="fa fa-angle-left"></i>
                                    </a>
                                    <a class="right control-carousel hidden-xs" data-slide="next" href="#carousel-example-generic1" role="button">
                                        <i class="fa fa-angle-right"></i>
                                    </a>

                                </div>
                            </div>


                        </div>
                        <div class="col-sm-5">
                            <div class="product-information">
                                <!--/product-information-->

                                <h2>
                                    <asp:Label runat="server" ID="lblName" /></h2>
                                <p>
                                    Product ID:
                                   
                                    <asp:Label runat="server" ID="lblID" />
                                </p>

                                <span>
                                    <span><i class="fa fa-inr"></i></span>
                                    <asp:Label runat="server" ID="lblPrice"></asp:Label>

                                    <div class="btn btn-fefault cart">
                                        <asp:LinkButton CommandName="atc" OnCommand="cmdaddtocart" runat="server"><i class="fa fa-shopping-cart"></i>
                                        Add to cart</asp:LinkButton>
                                    </div>

                                </span>
                                <p><b>Availability:</b> In Stock</p>
                                <p><b>Condition:</b> New</p>
                            </div>
                            <!--/product-information-->
                        </div>
                    </div>
                    <!--/product-details-->

                </div>
            </div>
        </div>
    </section>
</asp:Content>

