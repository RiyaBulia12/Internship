<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
<div id="myCarousel" class="carousel slide" data-ride="carousel" style="margin-top:-90px;">
  
    <div class="carousel-inner ">
        <asp:Repeater ID="Repeater3" runat="server">
            <ItemTemplate>
                <div class='item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                    <asp:Image ID="banner" ImageUrl='<%#Eval("banimg","images/banner/{0}") %>' Style="margin: 0px !important;" runat="server" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
  
    <!-- Left and right controls -->
    <a class="left control-carousel hidden-xs" data-slide="prev" href="#myCarousel" role="button">
      <i class="fa fa-angle-left"></i>
    </a>
    <a class="right control-carousel hidden-xs" data-slide="next" href="#myCarousel" role="button">
        <i class="fa fa-angle-right"></i>
    </a>
  </div>
   
</asp:Content>