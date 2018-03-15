<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="admin-detail.aspx.cs" Inherits="admin_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="container bg">
            <div class="row">
                <div class="col-sm-1">
                </div>

                <div class="col-sm-9">
                    <div class="product-details">
                        <!--product-details-->
                        <div class="col-sm-5">
                            <div class="view-product">
                                <div id="carousel-example-generic1" class="carousel slide" data-ride="carousel">
                                   
                                    <!-- Wrapper for slides -->
                                    <div class="carousel-inner ">
                                        <asp:Repeater ID="Repeater3" runat="server">
                                            <ItemTemplate>
                                                <div class='item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                                    <img id="imgsold" src="images//product-category/<%#Eval("img_url") %>" alt="" style="height: 250px; margin: 0px !important;" />
                                                    <asp:Label ID="lblIDIMG" Text='<%#Eval("id_img") %>' runat="server" Visible="False" />
                                                    <div style="margin-left: 15%">
                                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="360px" Height="27px" AllowMultiple="true" class="bg"/>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" Display="None" ErrorMessage="You need to select an image file before pressing &quot;Upload&quot;"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>
                                    <!-- Controls -->
                                    <a class="left control-carousel" href="#carousel-example-generic1" role="button" style="top:23%" data-slide="prev">
                                        <span class="fa fa-angle-left" aria-hidden="true" ></span>
                                       
                                    </a>
                                    <a class="right control-carousel" href="#carousel-example-generic1" style="top:23%" role="button" data-slide="next">
                                        <span class="fa fa-angle-right" aria-hidden="true" ></span>
                                        
                                    </a>

                                </div>
                                <br />
                                <span><b>Add More Images: </b></span>
                                <asp:FileUpload ID="FileUploadMore" runat="server" Width="348px" Height="27px" AllowMultiple="true" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUploadMore" Display="None" ErrorMessage="You need to select an image file before the press &quot;Upload&quot;"></asp:RequiredFieldValidator>
                            </div>


                        </div>

                        <div class="col-sm-2"></div>

                        <div class="col-sm-6">

                            <div class="form-group col-md-5">
                                <asp:Label runat="server">Product ID :</asp:Label>
                            </div>
                            <div class="form-group col-md-4">
                                <h2 class="title">
                                    <asp:Label runat="server" ID="lblID" /></h2>
                            </div>

                            <div class="form-group col-md-11">
                                <asp:TextBox runat="server" class="form-control" ID="txtName" />
                            </div>

                            <div class="form-group col-md-6">
                                <asp:DropDownList ID="drCate" class="form-control" runat="server" OnSelectedIndexChanged="drCate_SelectedIndexChanged" />
                            </div>

                            <div class="form-group col-sm-1" style="margin-top: 8px;">
                                <span class="fa fa-inr" style="font-size: x-large;"></span>
                            </div>

                            <div class="form-group col-md-4">
                                <asp:TextBox runat="server" class="form-control" ID="txtPrice" />
                            </div>

                            <div class="form-group col-md-4 bg" style="margin-left: 20%">
                                <asp:LinkButton class="btn btn-warning" CommandName="atc" runat="server" OnCommand="Unnamed_Command" OnClientClick="javascript:document.forms[0].encoding = 'multipart/form-data';" ID="update"><i class="fa fa-edit"></i>
                                        Update</asp:LinkButton>
                            </div>


                        </div>
                    <!--/product-details-->
                </div>
            </div>
        </div>
    </section>
</asp:Content>

