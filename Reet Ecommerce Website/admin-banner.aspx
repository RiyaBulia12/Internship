<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="admin-banner.aspx.cs" Inherits="admin_banner"  MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--form-->

    <section class="bg">
        <!--form-->
        <div class="container">
            <div class="row">
                <h2 class="title text-center border">Add Banner</h2>
                <div class="col-sm-5" style="margin-left:150px">
                    <div class="contact-form">
                        
                        <div class="form-group col-md-12">
                            <asp:FileUpload runat="server" ID="FileU" AllowMultiple="true" onchange="ShowpImage(this);" />
                        </div>
                       
                        <div class="form-group col-md-12">
                            <asp:RequiredFieldValidator ErrorMessage="Select an image file before pressing &quot;Add&quot;" ControlToValidate="FileU" runat="server" />
                        </div>
                        <div class="form-group col-md-9 text-center">
                            <asp:Button Text="Add" runat="server" ID="btnAddPro" class="btn btn-warning" ></asp:Button>
                        </div>
                    
                    </div>
                    <!--/contact form-->
                </div>
                <div class="form-group col-md-4">
                    <asp:Image ID="imgS" runat="server"/>
                </div>
                <div class="col-md-12 bg">
                    <h2 class="title text-center border">Already in Database</h2>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-3">
                                <div class="product-image-wrapper">
                                    <div class="single-products">
                                        <div class="productinfo text-center">
                                            <asp:Image ID="banner" ImageUrl='<%#Eval("banimg","images/banner/{0}") %>' style="height: 230px"  runat="server" />
                                        </div>
                                        <div class="product-overlay">
                                            <div class="overlay-content">
                                                <asp:LinkButton class="btn btn-default add-to-cart" ID="LinkButton3"   runat="server" ><i class="fa fa-times"></i>Delete</asp:LinkButton>
                                               
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                
            </div>

    </section>
    <!--/form-->
</asp:Content>

