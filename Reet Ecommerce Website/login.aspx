<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    
    <div class="container">
    	<div class="bg">
	    	
            <div class="row">    		
	    		<div class="col-sm-12">    			   			
					<h2 class="title text-center">Login to your account </h2>    			    				    				
				</div>			 		
			</div> 
           
    		<div class="row" >  	
                 
	    		<div class="col-sm-5" style="margin-left:400px">
                   <div class="login-form"><!--login form-->
						<form id="form1" defaultbutton="btnLogin">
                            <div class="form-group col-md-7">
							<asp:TextBox  runat="server" class="form-control" placeholder="Username" ID="tbName"/>  
                                </div>
                           <div class="form-group col-md-7">
							<asp:TextBox  runat="server" class="form-control" TextMode="Password" placeholder="Password" ID="tbPass"/>  
                               </div>
                          <div class="form-group col-md-6">
                            <asp:Button ID="btnLogin" Text="Login" class="btn btn-warning pull-right" runat="server"  OnClick="Unnamed_Click" />
                              </div>
						</form>
					</div><!--/login form-->
	    		</div>

    		</div>  
    	</div><!--/bg-->
    </div><!--/container-->
</asp:Content>

