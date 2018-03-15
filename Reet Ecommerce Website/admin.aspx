<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="form1">
        <!--form-->
        <div class="container bg">
            <div class="row">
                <div class="col-sm-12">
                     <%--<h2 class="title text-center border">Category Section</h2>--%>
                    <div class="col-sm-3" <%--style="margin-left:150px"--%>>
                        <h2 class="title text-center">Add New Category</h2>
                        <div class="contact-form">

                            <div class="form-group col-md-12">

                                <asp:TextBox ID="tbCate" runat="server" class="form-control" placeholder="Category Name" />
                            </div>
                            <div class="form-group col-md-12">
                                <asp:Button Text="Add" runat="server" ID="addCate" OnClick="addCate_Click" class="btn btn-warning"></asp:Button>
                            </div>

                        </div>
                    </div>
                    <div class="col-sm-2"></div>
                    <div class="col-sm-7">
                        <div class="table-responsive cart_info">
                            <h2 class="title text-center">Existing Category List</h2>
                            <table class="table table-condensed">
                                <thead>
                                    <tr >
                                        <td class="image">ID</td>
                                        <td class="image">Category</td>
                                        <td class="image"></td>
                                        <td class="image">Option</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="repCate" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="cart_description">    
                                                    <asp:Label ID="lblidCat" Text=' <%#Eval("id_cat") %>' runat="server" />
                                                </td>

                                                <td class="col-lg-4">
                                                    <asp:TextBox ID="txtCateName" class="form-control" runat="server" Text='<%#Eval("cat_name")%>' required="true" />
                                                </td>
                                               <td class="col-sm-1"></td>

                                               <td class="cart_delete">
                                                   
                                                        <asp:LinkButton runat="server" CommandName="ghUpdate" CommandArgument='<%#Eval("id_cat")%>' OnCommand="Unnamed_Command" ToolTip="Update"><i class="fa fa-refresh"></i></asp:LinkButton>
                                                        <asp:LinkButton runat="server" CommandName="ghDel" CommandArgument='<%#Eval("id_cat")%>' OnCommand="del_Command" ToolTip="delete"><i class="fa fa-times"></i></asp:LinkButton>
                                                   
                                                </td>

                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            </div>
       
    </section>

    <!--/form-->
</asp:Content>

