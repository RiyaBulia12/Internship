<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact-us.aspx.cs" Inherits="contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="contact-page" class="container">
    	<div class="bg">
	    	<div class="row">    		
	    		<div class="col-sm-12">    			   			
					<h2 class="title text-center">Contact <strong>Us</strong></h2>    			    				    				
				</div>			 		
			</div> 
            <div class="row">  
                <div class="col-sm-12" style="padding-bottom:50px">  
	                    <iframe src="http://www.map-generator.org/ff3ca546-b171-42ac-8a8f-82f5eb591827/iframe-map.aspx" scrolling="no" height="300" width="100%" frameborder="0" ></iframe>

                </div>
            </div> 	
    		<div class="row" style="margin-left:150px">  	
	    		<div class="col-sm-6">
	    			<div class="contact-form">
	    				<h2 class="title text-center">Get In Touch</h2>
	    				<div class="status alert alert-success" style="display: none"></div>
				    	<div id="main-contact-form" class="contact-form row" name="contact-form">
				            <div class="form-group col-md-5">
				                <input type="text" name="name" class="form-control" required="required" placeholder="xxxx xxxx xxxx xxxx "/>
				            </div>
				            <div class="form-group col-md-6">
				                <input type="email" name="email" class="form-control" required="required" placeholder="xxxx xxxx xxxx@gmail.com"/>
				            </div>
				            <div class="form-group col-md-11">
				                <input type="text" name="subject" class="form-control" required="required" placeholder="Subject"/>
				            </div>
				            <div class="form-group col-md-11">
				                <textarea name="message" id="message" required="required" class="form-control" rows="8" placeholder="Your Message Here"></textarea>
				            </div>                        
				            <div class="form-group col-md-11">
				                <input type="submit" class="btn btn-warning pull-right" value="Submit"/>
				            </div>
				        </div>
	    			</div>
	    		</div>
	    		<div class="col-sm-4">
	    			<div class="contact-info">
	    				<h2 class="title text-center">Contact Info</h2>
	    				<address>
	    					<h3>Reet Enterprise</h3>
							<p>305, Vijay Chambers,</p>
							<p>Nr. Bhagatalao post office,</p>
							<p>Chauta Pool,</p>
							<p>Surat (Gujarat) - 395 003</p>
                            <br />
                            <p>Freephone: +91 98241 47003</p>
                            <p>Telephone: (0261) 3293823</p>
                            <p>Fax: +0 000 000 0000</p>
                            <p>E-mail: <a href="mailto:info@reetenterprise.com" style="color:#696763;">info@reetenterprise.com</a></p>
	    				</address>
	    			</div>
    			</div>    			
	    	</div>  
    	</div>	
    </div><!--/#contact-page-->
</asp:Content>

