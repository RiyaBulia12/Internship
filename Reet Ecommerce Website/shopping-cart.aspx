<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shopping-cart.aspx.cs" Inherits="shopping_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section id="cart_items">
        <div class="container">

            <div class="table-responsive cart_info">
                <table class="table table-condensed">

                    <thead>
                        <tr class="cart_menu">
                            <td class="image">Item</td>
                            <td class="description"></td>
                            <td class="price">Price</td>
                            <td class="quantity">Quantity</td>
                            <td class="total">Total</td>
                            <td></td>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="rpguest" runat="server">

                            <ItemTemplate>
                                <tr>
                                    <td class="cart_product">
                                        <img src="<%#Eval("P_img") %>" alt="" style="height: 100px; width: 90px" />
                                    </td>
                                    <td class="cart_description">
                                        <h4>
                                            <p>
                                                <%#Eval("P_desc")%>
                                        </h4>
                                        <p>Product ID:<asp:Label ID="lblID" Text='<%#Eval("P_ID")%>' runat="server" />
                                        </p>
                                    </td>
                                    <td class="cart_price">
                                        <p><%#Eval("P_price") %></p>
                                    </td>
                                    <td class="cart_quantity">
                                        <div class="cart_quantity_input">
                                            <asp:TextBox class="form-control pagination-centered" ID="tbqty" runat="server" Text='<%#Eval("P_qty")%>' />
                                        </div>
                                    </td>
                                    <td class="cart_total">
                                        <p class="cart_total_price"><i class="fa fa-inr"></i><asp:Label ID="lblsum" Text='<%#Eval("P_sum") %>' runat="server" /></p>
                                    </td>
                                    <td class="cart_delete">
                                        <div class="cart_quantity_delete">
                                            <asp:LinkButton runat="server" CommandName="cmdUpdate" CommandArgument='<%#Eval("P_ID")%>' OnCommand="cmdUpd" ToolTip="Update"><i class="fa fa-refresh"></i></asp:LinkButton>

                                            <asp:LinkButton runat="server" CommandName="cmdDel" CommandArgument='<%#Eval("P_ID")%>' OnCommand="cmdDelete" ToolTip="delete"><i class="fa fa-times"></i></asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                                  <table class="table table-condensed" style="margin: 40px 0px 0px 0px">
                    <thead>
                        <tr class="cart_menu">
                            <td class="image">Grand Total</td>
                            <td class="cart_total">
                                <p class="cart_total_price" ><i class="fa fa-inr"></i><asp:Label ID="lbltsum" runat="server" style="color:white" /></p>
                            </td>
                        </tr>
                    </thead>
                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

             <%--   <table class="table table-condensed" style="margin: 40px 0px 0px 0px">
                    <thead>
                        <tr class="cart_menu">
                            <td class="image">Grand Total</td>
                            <td class="cart_total">
                                <p class="cart_total_price" ><i class="fa fa-inr"></i><asp:Label ID="lbltsum" runat="server" style="color:white" /></p>
                            </td>
                        </tr>
                    </thead>
                </table>--%>
                
            </div>

        </div>
    </section>
    <!--/#cart_items-->
    <div class="container">
        <div class="bg">

            <div class="row">
                <div class="col-sm-12">
                    <h2 class="title text-center">Checkout</h2>
                </div>
            </div>

            <div class="row">
                <div class="total_area">
                    <div class="col-sm-5" style="margin-left: 400px">
                        <div class="form-group col-md-7">
                            <asp:TextBox ID="txtCusName" CssClass="form-control" runat="server" placeholder="Type Your Name" required="true" />
                        </div>
                        <div class="form-group col-md-9">
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Type Your Email" required="true" />
                        </div>
                        <div class="form-group col-md-5">
                            <asp:LinkButton CommandName="co" OnCommand="cmdCheckout" class="check_out" runat="server">Checkout</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <!--/bg-->
    </div>
    <!--/container-->

</asp:Content>

