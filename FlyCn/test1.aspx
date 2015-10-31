<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="FlyCn.test1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>A Simple Responsive HTML Email</title>
        <style type="text/css">
        /*body {margin: 0; padding: 0; min-width: 100%!important;}
        .content {width: 100%; max-width: 600px;}*/  
        </style>
    </head>
  
    <div style="margin: 0; padding: 0; min-width: 100%!important;">
    <div style="border-style: solid; border-color: inherit; border-width: medium; margin: 0; padding: 0; min-width: 100%!important; height:27px; color:lightseagreen; background:lightseagreen; text-align:center;"> <label style="color:white; vertical-align:central; font-family: 'Segoe UI Light'; font-size:18px"> Document For Approvel</label></div>
        <div style="background-color:#f6f8f1; text-align:left;">
                <label style="font:bold; font-size:15px; font-family:'Segoe UI'; color:#006666; margin-left:20px;" > Hi SSSSS</label>
        </div>
        <table width="100%" bgcolor="#f6f8f1" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table class="content" align="center" cellpadding="0" cellspacing="0" border="0">
                      
                        <tr>
                            <td style="height:50px; ">
                       <div id="music" class="nav">Music I Like <span id="hyperspan"><a href="Music.html"></a></span></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:50px">
                               We will send you another email once the items in your order have been shipped. Meanwhile, you can check the status of your order on Flipkart.com
                            </td>
                        </tr>
                        <tr>
                            <td style="height:50px;padding-left:190px">
                                <button style="Width:203px; Height:31px; background-color:lightseagreen;color:white;align-self:center; margin-left: 0px; font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif;border-style:none;">Link To Document</button>
                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-size:12px; color:seagreen;">
                    This is an automatically generated email – please do not reply to it. If you have any queries please email to <a href="mailto:info.thrithvam@gmail.com"> amrutha@thrithvam.com</a>
                </td>
            </tr>
        </table>
   
        </div>
    
</html>