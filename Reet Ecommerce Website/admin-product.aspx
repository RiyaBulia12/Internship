<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin-product.aspx.cs" Inherits="admin_product" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--form-->

    <section class="bg">
        <!--form-->
        <div class="container">
            <div class="row">
                <h2 class="title text-center border">Add New Products</h2>
                <div class="col-sm-5" style="margin-left:150px">
                    <div class="contact-form">
                       
                        <div class="form-group col-md-5">
                            <asp:DropDownList ID="drCate" runat="server" class="form-control" OnSelectedIndexChanged="drCate_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-3">
                            <asp:TextBox ID="tbPrice1" runat="server" placeholder="Price" class="form-control" />
                        </div>
                        <div class="form-group col-md-8">
                            <asp:TextBox ID="tbName1" runat="server" placeholder="Name" class="form-control" />
                        </div>
                        
                        <div class="form-group col-md-12">
                            <asp:FileUpload runat="server" ID="FileU" AllowMultiple="true" onchange="ShowpImage(this);" />
                        </div>
                       
                        <div class="form-group col-md-12">
                            <asp:RequiredFieldValidator ErrorMessage="Select an image file before pressing &quot;Add&quot;" ControlToValidate="FileU" runat="server" />
                        </div>
                        <div class="form-group col-md-9 text-center">
                            <asp:Button Text="Add" runat="server" ID="btnAddPro" class="btn btn-warning" OnClick="btnAddPro_Click"></asp:Button>
                        </div>
                    
                    </div>
                    <!--/contact form-->
                </div>
                <div class="form-group col-md-4">
                    <asp:Image ID="imgS" runat="server"/>
                </div>
                <div class="col-md-12 bg">
                    <h2 class="title text-center border">Already in Database</h2>
                    <asp:Repeater ID="grid_product" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-3">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <img src="images//product-category/<%#Eval("CatPro_img") %>" alt="" style="height: 230px" />
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

                                                    <asp:LinkButton class="btn btn-default add-to-cart" ID="LinkButton2" CommandArgument='<%#Eval("CatPro_id")%>' CommandName="upcm" runat="server" OnCommand="udate_Command"><i class="fa fa-edit"></i>Update</asp:LinkButton>

                                                    <asp:LinkButton class="btn btn-default add-to-cart" ID="LinkButton3" CommandArgument='<%#Eval("CatPro_id")%>' CommandName="delcm" runat="server" OnCommand="del_Command"><i class="fa fa-times"></i>Delete</asp:LinkButton>
                                               
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <div style="text-align: center; margin-bottom: 5%">
                        <cc1:CollectionPager ID="CollectionPager2" runat="server" ShowPageNumbers="True" PageNumbersDisplay="Numbers" BackNextDisplay="Buttons" ResultsLocation="Bottom" ResultsStyle="display:none" LabelText="Trang" ShowLabel="False" NextText="Next" BackText="Back" ShowFirstLast="False" BackNextLocation="Split" PageNumbersStyle="margin:2%;"></cc1:CollectionPager>
                    </div>

                </div>
                
            </div>

    </section>
    <!--/form-->
</asp:Content>

