<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="~/admin-person.aspx.cs" Inherits="admin_person" %>

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
                                <div>
                                    <asp:Image runat="server" ID="imgava" Style="height: 250px; margin: 0px !important;" />

                                    <div class="bg" style="margin-left:15%">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="360px" Height="27px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" Display="None" ErrorMessage="You need to select an image file before pressing &quot;Upload&quot;"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2"></div>

                        <div class="col-sm-5">

                            <div class="form-group col-md-6">
                                <asp:Label runat="server">Username :</asp:Label>
                            </div>
                            <div class="col-md-6">
                                <h2 class="title" >
                                    <asp:Label runat="server" ID="lblUsname"></asp:Label>
                                </h2>
                            </div>
                            <div class="form-group col-md-6">
                                <asp:Label runat="server">Age :</asp:Label>
                            </div>
                            <div class="form-group col-md-4">
                                <asp:TextBox runat="server" class="form-control" ID="txtAge" ToolTip="Age" placeholder="Age" />
                            </div>
                            <div class="form-group col-md-10">
                                <asp:TextBox runat="server" class="form-control" ID="txtName" ToolTip="Full Name" placeholder="Full Name" />
                            </div>

                            <div class="form-group col-md-10">
                                <asp:TextBox ID="txtEmail" class="form-control" ToolTip="Email" placeholder="Email" runat="server" />
                            </div>

                            <div class="form-group col-md-10">
                                <asp:LinkButton CommandName="shpa" ID="lbtnshpa" runat="server" OnCommand="Unnamed_Command2" OnClientClick="javascript:document.forms[0].encoding = 'multipart/form-data';"><div class="btn btn-default cart"><i class="fa fa-edit"></i>
                                        Update Password </div></asp:LinkButton>
                            </div>

                            <div class="form-group col-md-10">
                                <asp:TextBox runat="server" ID="txtPassword" class="form-control" ToolTip="Password" placeholder="Password" Visible="False" TextMode="Password" />
                            </div>

                            <div class="form-group col-md-10">
                                <asp:TextBox runat="server" ID="txtrepass" class="form-control" ToolTip="Confirm Password" placeholder="Confirm Password" Visible="False" TextMode="Password" />
                            </div>

                            <div class="form-group col-md-10">
                                <asp:LinkButton CommandName="cpa" ID="lbtnCpa" Style="margin-left: 0px !important" runat="server" OnCommand="Unnamed_Command1" OnClientClick="javascript:document.forms[0].encoding = 'multipart/form-data';" Visible="False"><div class="btn btn-fefault cart"><i class="fa fa-edit"></i>
                                        Change Password  </div></asp:LinkButton>
                            </div>

                            <div class="form-group col-md-10">
                                <asp:LinkButton CommandName="atc" runat="server" OnCommand="Unnamed_Command" OnClientClick="javascript:document.forms[0].encoding = 'multipart/form-data';"> <div class="btn btn-fefault cart"><i class="fa fa-edit"></i>
                                        Update </div></asp:LinkButton>
                            </div>
                        </div>

                    </div>
                    <!--/product-details-->
                </div>
            </div>
        </div>
    </section>
</asp:Content>

