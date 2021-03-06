﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="InputTemplateContent.aspx.cs" Inherits="FlyCn.Templates.InputTemplateContent" %>

<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Input</title>
<!-----bootstrap css--->
<link href="../Content/themes/FlyCnBlue/css/roboto_google_api.css" rel="stylesheet" /> 
<link href="Content/themes/FlyCnBlue/css/datepicker.css" rel="stylesheet" type="text/css" />
<!-----bootstrap css--->
    <link href="../Content/themes/FlyCnBlue/css/bootstrap.min.css" rel="stylesheet" /> 
    <link href="../Content/themes/FlyCnBlue/css/stylesheet.css" rel="stylesheet" />
 
<link href="../Content/themes/FlyCnBlue/css/selectize.css" rel="stylesheet" type="text/css" />
<link href="../Content/themes/FlyCnBlue/css/accodin.css" rel="stylesheet" type="text/css" />
<!-----main css--->
<link href="../Content/themes/FlyCnBlue/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Content/themes/FlyCnRed_Rad/TabStrip.FlyCnRed_Rad.css" rel="stylesheet" />
<!-----main css--->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
<div class="container" style="width:100%">
  
     <telerik:RadTabStrip ID="RadTabStrip1" runat="server"  Width="300px"  
             CausesValidation="false"   SelectedIndex="0" Skin="FlyCnRed_Rad" EnableEmbeddedSkins="false" >
            
            <Tabs>
                <telerik:RadTab Text="View" PageViewID="rpList" Value="1" Width="150px" runat="server" ImageUrl="~/Images/Icons/ListIcon.png" Selected="True" ></telerik:RadTab>
                 <telerik:RadTab Text="New" PageViewID="rpAddEdit" Value="2" Width="150px" runat="server" ImageUrl="~/Images/Icons/NewIcon.png"  ></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
    <div id="content"> 
        <div class="contentTopBar"></div>
    <uc1:ToolBar runat="server" ID="ToolBar" />
  <!-----FORM SECTION----> 
  <!---SECTION ONE--->
  <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="control-label col-lg-3" for="email3">Email address
            automatically</label>
          <div class="col-lg-9">
            <input type="email" class="form-control" id="email3" placeholder="Enter email">
          </div>
        </div>
      </form>
    </div>
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="control-label col-lg-3" for="email3">Email address
            automatically</label>
          <div class="col-lg-9">
            <textarea class="form-control" rows="5" id="comment"></textarea>
          </div>
        </div>
      </form>
    </div>
  </div>
  <!---SECTION ONE---> 
  
  <!---SECTION TWO--->
  <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="control-label col-lg-3" for="email3">Email address
            automatically</label>
          <div class="col-lg-9">
            <input type="email" class="form-control" id="email1" placeholder="Enter email">
          </div>
        </div>
      </form>
    </div>
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="control-label col-lg-3" for="email3">Email address
            automatically</label>
          <div class="col-lg-9">
            <div class="dropdown">
              <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Lorem Ipsum <span class="caret"></span></button>
              <ul class="dropdown-menu">
                <li><a href="#">HTML</a></li>
                <li><a href="#">CSS</a></li>
                <li><a href="#">JavaScript</a></li>
              </ul>
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
  <!---SECTION TWO---> 
  
  <!---SECTION THREE--->
  <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="control-label col-lg-3" for="email3">Email address
            automatically</label>
          <div class="col-lg-9">
            <select class="span1 col-md-1 form-control" id="language" name="language">
              <option value="en">en</option>
              <option value="ar">ar</option>
              <option value="az">az</option>
              <option value="bg">bg</option>
              <option value="bs">bs</option>
              <option value="ca">ca</option>
              <option value="cs">cs</option>
              <option value="cy">cy</option>
              <option value="da">da</option>
              <option value="de">de</option>
              <option value="el">el</option>
              <option value="en-GB">en-GB</option>
              <option value="es">es</option>
              <option value="et">et</option>
              <option value="eu">eu</option>
              <option value="fa">fa</option>
              <option value="fi">fi</option>
              <option value="fo">fo</option>
              <option value="fr">fr</option>
              <option value="gl">gl</option>
              <option value="he">he</option>
              <option value="hr">hr</option>
              <option value="hu">hu</option>
              <option value="hy">hy</option>
              <option value="id">id</option>
              <option value="is">is</option>
              <option value="it">it</option>
              <option value="ja">ja</option>
              <option value="ka">ka</option>
              <option value="kh">kh</option>
              <option value="kk">kk</option>
              <option value="kr">kr</option>
              <option value="lt">lt</option>
              <option value="lv">lv</option>
              <option value="mk">mk</option>
              <option value="ms">ms</option>
              <option value="nb">nb</option>
              <option value="nl">nl</option>
              <option value="nl-BE">nl-BE</option>
              <option value="no">no</option>
              <option value="pl">pl</option>
              <option value="pt-BR">pt-BR</option>
              <option value="pt">pt</option>
              <option value="ro">ro</option>
              <option value="rs">rs</option>
              <option value="rs-latin">rs-latin</option>
              <option value="ru">ru</option>
              <option value="sk">sk</option>
              <option value="sl">sl</option>
              <option value="sq">sq</option>
              <option value="sr">sr</option>
              <option value="sr-latin">sr-latin</option>
              <option value="sv">sv</option>
              <option value="sw">sw</option>
              <option value="th">th</option>
              <option value="tr">tr</option>
              <option value="uk">uk</option>
              <option value="vi">vi</option>
              <option value="zh-CN">zh-CN</option>
              <option value="zh-TW">zh-TW</option>
            </select>
          </div>
        </div>
      </form>
    </div>
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="control-label col-lg-3" for="email3">Email address
            automatically</label>
          <div class="col-lg-9">
            <div class="selectContainer has-feedback has-success">
              <select class="form-control" name="genre" data-fv-field="genre">
                <option value="">Choose a genre</option>
                <option value="action">Action</option>
                <option value="comedy">Comedy</option>
                <option value="horror">Horror</option>
                <option value="romance">Romance</option>
              </select>
              <small class="help-block" data-fv-validator="notEmpty" data-fv-for="genre" data-fv-result="VALID" style="display: none;">The genre is required</small></div>
          </div>
        </div>
      </form>
    </div>
  </div>
  <!---SECTION THREE---> 
  
  <!---SECTION FOUR--->
  <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="control-label col-lg-3" for="email3">Email address
            automatically</label>
          <div class="col-lg-9">
            <input type="email" class="form-control" id="email2" placeholder="Enter email">
          </div>
        </div>
      </form>
    </div>
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="control-label col-lg-3" for="email3">Email address
            automatically</label>
          <div class="col-lg-4">
            <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
              <input class="form-control" type="text" readonly />
              <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span> </div>
          </div>
          <div class="col-lg-5">
            <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
              <input class="form-control" type="text" readonly />
              <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span> </div>
          </div>
        </div>
      </form>
    </div>
  </div>
  <!---SECTION FOUR---> 
  
  <!---SECTION FIVE--->
  <div class="col-lg-12 Span-One">
    <div class="col-lg-6">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="control-label col-lg-3" for="email3">Email address
            automatically</label>
          <div class="col-lg-9">
            <div class="control-group">
              <select id="select-tools" multiple placeholder="Pick a tool...">
              </select>
            </div>
          </div>
        </div>
      </form>
    </div>
    <div class="col-lg-6"> </div>
  </div>
  <!---SECTION FIVE---> 
  
  <!---SECTION SIX--->
  <div class="col-lg-12 Span-One">
    <div class="col-lg-12">
      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label for="email3" class="control-label col-lg-2">Email address
            automatically</label>
          <div class="col-lg-10">
            <textarea class="form-control" rows="5" id="comment2"></textarea>
          </div>
        </div>
      </form>
    </div>
  </div>
  <!---SECTION SIX---> 
  
  <!---SECTION --->
  <div class="col-lg-12">
    <div class="col-lg-12">
      <div class="col-lg-2"></div>
      <div class="col-lg-10">
        <label class="checkbox-inline">
          <input type="checkbox" value="">
          1</label>
        <label class="checkbox-inline">
          <input type="checkbox" value="">
          2</label>
        <label class="checkbox-inline">
          <input type="checkbox" value="">
          3</label>
        <label class="radio-inline">
          <input type="radio" name="optradio">
          1</label>
        <label class="radio-inline">
          <input type="radio" name="optradio">
          2</label>
        <label class="radio-inline">
          <input type="radio" name="optradio">
          3</label>
      </div>
    </div>
  </div>
  <!---SECTION ---> 
  
  <!----SECTION ACCORDIN---->
  <div class="col-lg-12">
    <div class="col-lg-6">
      <div class="content white">
        <div class="accordion-container"> <a href="#" class="accordion-toggle">Lorem Ipsum is simply <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
          <div class="accordion-content">
            <form role="form" class="form-horizontal">
              <div class="form-group">
                <label for="email3" class="control-label col-lg-3">Email address
                  automatically</label>
                <div class="col-lg-9">
                  <input type="email" placeholder="Enter email" id="email4" class="form-control">
                </div>
              </div>
            </form>
            <form role="form" class="form-horizontal">
              <div class="form-group">
                <label for="email3" class="control-label col-lg-3">Email address
                  automatically</label>
                <div class="col-lg-9">
                  <div class="dropdown">
                    <button data-toggle="dropdown" type="button" class="btn btn-primary dropdown-toggle" aria-expanded="false">Lorem Ipsum <span class="caret caret1"></span></button>
                    <ul class="dropdown-menu">
                      <li><a href="#">HTML</a></li>
                      <li><a href="#">CSS</a></li>
                      <li><a href="#">JavaScript</a></li>
                    </ul>
                  </div>
                </div>
              </div>
            </form>
            <form role="form" class="form-horizontal">
              <div class="form-group">
                <label for="email3" class="control-label col-lg-3">Email address
                  automatically</label>
                <div class="col-lg-9">
                  <input type="email" placeholder="Enter email" id="email5" class="form-control">
                </div>
              </div>
            </form>
            <form role="form" class="form-horizontal">
              <div class="form-group">
                <label class="control-label col-lg-3" for="email3">Email address
                  automatically</label>
                <div class="col-lg-9">
                  <textarea id="comment3" rows="5" class="form-control"></textarea>
                </div>
              </div>
            </form>
          </div>
          <!--/.accordion-content--> 
        </div>
        <!--/.accordion-container-->
        <div class="accordion-container"> <a href="#" class="accordion-toggle">Lorem Ipsum has been the <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
          <div class="accordion-content"> Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. </div>
          <!--/.accordion-content--> 
        </div>
        <!--/.accordion-container-->
        <div class="accordion-container"> <a href="#" class="accordion-toggle">dummy text ever since <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
          <div class="accordion-content"> Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. </div>
          <!--/.accordion-content--> 
        </div>
        <!--/.accordion-container-->
        <div class="accordion-container"> <a href="#" class="accordion-toggle">It was popularised in the 1960s <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
          <div class="accordion-content"> Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. </div>
          <!--/.accordion-content--> 
        </div>
      </div>
    </div>
  </div>
  <!----SECTION ACCORDIN----> 
  
  <!-----SECTION TABLE---->
  <div class="col-lg-12"> 
    <!-- Nav tabs -->
    <ul id="tabs">
      <li><a href="#" name="tab1">TAB 01</a></li>
      <li><a href="#" name="tab2">TAB 02</a></li>
      <li><a href="#" name="tab3">TAB 03</a></li>
      <li><a href="#" name="tab4">TAB 04</a></li>
    </ul>
    <div id="content1">
      <div id="tab1">
        <div role="tabpanel" class="tab-pane active" id="home">
          <div class="table-responsive">
            <table class="table">
              <thead>
                <tr>
                  <th>Lorem Ipsum</th>
                  <th>NO</th>
                  <th>Lorem Ipsum</th>
                  <th>text</th>
                  <th>call</th>
                  <th>contact</th>
                  <th>y/n</th>
                  <th>name</th>
                  <th>lipsum</th>
                  <th>lorem</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">sms</th>
                  <td>01</td>
                  <td>hai</td>
                  <td>xxxxx</td>
                  <td>100</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <div id="tab2">
        <div role="tabpanel" class="tab-pane active" id="Div1">
          <div class="table-responsive">
            <table class="table">
              <thead>
                <tr>
                  <th>Lorem Ipsum</th>
                  <th>NO</th>
                  <th>Lorem Ipsum</th>
                  <th>text</th>
                  <th>call</th>
                  <th>contact</th>
                  <th>y/n</th>
                  <th>name</th>
                  <th>lipsum</th>
                  <th>lorem</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">sms</th>
                  <td>01</td>
                  <td>hai</td>
                  <td>xxxxx</td>
                  <td>100</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <div id="tab3">
        <div role="tabpanel" class="tab-pane active" id="Div2">
          <div class="table-responsive">
            <table class="table">
              <thead>
                <tr>
                  <th>Lorem Ipsum</th>
                  <th>NO</th>
                  <th>Lorem Ipsum</th>
                  <th>text</th>
                  <th>call</th>
                  <th>contact</th>
                  <th>y/n</th>
                  <th>name</th>
                  <th>lipsum</th>
                  <th>lorem</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">sms</th>
                  <td>01</td>
                  <td>hai</td>
                  <td>xxxxx</td>
                  <td>100</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <div id="tab4">
        <div role="tabpanel" class="tab-pane active" id="Div3">
          <div class="table-responsive">
            <table class="table">
              <thead>
                <tr>
                  <th>Lorem Ipsum</th>
                  <th>NO</th>
                  <th>Lorem Ipsum</th>
                  <th>text</th>
                  <th>call</th>
                  <th>contact</th>
                  <th>y/n</th>
                  <th>name</th>
                  <th>lipsum</th>
                  <th>lorem</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">sms</th>
                  <td>01</td>
                  <td>hai</td>
                  <td>xxxxx</td>
                  <td>100</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                  <td>01</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
                <tr>
                  <th scope="row">sms</th>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                  <td>Table cell</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
    <br>
    <br>
  </div>
  
  <!-----SECTION TABLE----> 
  
  <!-----FORM SECTION----> 
</div>
</div>

<!--<script src="js/jquery.js"></script>--> <script src="../Content/themes/FlyCnBlue/js/jquery.min.js"></script>
 
<script>
    $(document).ready(function () {
        $("#content").find("[id^='tab']").hide(); // Hide all content
        $("#tabs li:first").attr("id", "current"); // Activate the first tab
        $("#content #tab1").fadeIn(); // Show first tab's content

        $('#tabs a').click(function (e) {
            e.preventDefault();
            if ($(this).closest("li").attr("id") == "current") { //detection for current tab
                return;
            }
            else {
                $("#content").find("[id^='tab']").hide(); // Hide all content
                $("#tabs li").attr("id", ""); //Reset id's
                $(this).parent().attr("id", "current"); // Activate this
                $('#' + $(this).attr('name')).fadeIn(); // Show content for the current tab
            }
        });
    });
</script> 
<script type="text/javascript">
    $(document).ready(function () {
        $('.accordion-toggle').on('click', function (event) {
            event.preventDefault();
            // create accordion variables
            var accordion = $(this);
            var accordionContent = accordion.next('.accordion-content');
            var accordionToggleIcon = $(this).children('.toggle-icon');

            // toggle accordion link open class
            accordion.toggleClass("open");
            // toggle accordion content
            accordionContent.slideToggle(250);

            // change plus/minus icon
            if (accordion.hasClass("open")) {
                accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
            } else {
                accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
            }

        });
    });
</script>  
<script src="../Content/themes/FlyCnBlue/js/selectize.js"></script> 
<script src="../Content/themes/FlyCnBlue/js/index.js"></script> 
<script>
    var $select = $('#select-tools').selectize({
        maxItems: null,
        valueField: 'id',
        labelField: 'title',
        searchField: 'title',
        options: [
            { id: 1, title: 'Spectrometer', url: 'http://en.wikipedia.org/wiki/Spectrometers' },
            { id: 2, title: 'Star Chart', url: 'http://en.wikipedia.org/wiki/Star_chart' },
            { id: 3, title: 'Electrical Tape', url: 'http://en.wikipedia.org/wiki/Electrical_tape' }
        ],
        create: false
    });

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    var control = $select[0].selectize;

    $('#button-clear').on('click', function () {
        control.clear();
    });

    $('#button-clearoptions').on('click', function () {
        control.clearOptions();
    });

    $('#button-addoption').on('click', function () {
        control.addOption({
            id: 4,
            title: 'Something New',
            url: 'http://google.com'
        });
    });

    $('#button-additem').on('click', function () {
        control.addItem(2);
    });

    $('#button-setvalue').on('click', function () {
        control.setValue([2, 3]);
    });



				</script> 

<!-----bootstrap js---> 

<script src="../Content/themes/FlyCnBlue/js/bootstrap.min.js"></script> 
<script src="../Content/themes/FlyCnBlue/js/bootstrap-datepicker.js"></script> 
<script>
    $(function () {
        $("#datepicker").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());;
    });

</script> 
<script>
    $(function () {
        $("#datepicker1").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());;
    });

</script> 

<!-----bootstrap js--->
</asp:Content>
