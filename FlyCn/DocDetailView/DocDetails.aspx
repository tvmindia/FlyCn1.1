 <%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="DocDetails.aspx.cs" Inherits="FlyCn.Content.DocDetailView.DocDetails" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%--  <script src="../Scripts/jquery-1.8.2.js"></script>
      <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.24.js"></script>
    <script src="../Scripts/jquery-ui-1.8.24.min.js"></script>
        <script src="../Content/themes/FlyCnBlue/jquery.js"></script>   --%>
       <script src="../Scripts/jquery-1.8.2.min.js"></script>   
       <script src="../Scripts/jquery-ui-1.8.24.js"></script>
       <link href="../themes/base/jquery-ui.css" rel="stylesheet" />
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
            //if (accordion.hasClass("open")) {
            //    accordionToggleIcon.html("<i class='fa fa-minus-circle'></i>");
            //} else {
            //    accordionToggleIcon.html("<i class='fa fa-plus-circle'></i>");
            //}

        });
    });
</script>
     
    <style>
        .head{
            color:black;
            font-size:large;
        }
    </style>
    <div class="container" style="width:100%">
        <div id="content"> 
        <div class="contentTopBar"></div>
             
 <p>

    <asp:Label ID="lblHeader" runat="server" Text="Document Details" CssClass="head" ></asp:Label></p>
    <div>
 
           <div class="col-md-12 Span-One">
                <div class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblDocNo" CssClass="control-label col-md-5" runat="server" Text="Document Number"></asp:Label>
                    <asp:Label ID="lblDocumntNo"  CssClass="control-label col-md-7" runat="server" Text=""></asp:Label>
                   

                   <asp:Label ID="lblDocumentType" CssClass="control-label col-md-5"  runat="server" Text="Document Type"></asp:Label>
                    <asp:Label ID="lblType" CssClass="control-label col-md-7" runat="server" Text=""></asp:Label>            
                <div class="form-group">
               <asp:Label ID="lblCreatedBy"  CssClass="control-label col-md-5" runat="server" Text="Created By"></asp:Label>
                   
                    
               <asp:Label ID="lblCreated" CssClass="control-label col-md-7" runat="server" Text=""></asp:Label>
      </div>  </div></div>
    <div class="col-md-6">
                <div class="form-group">
                     <asp:Label ID="lblClientNo" CssClass="control-label col-md-5" runat="server" Text="Client DocumentNo"></asp:Label>
                    <asp:Label ID="lblClientDocNo" CssClass="control-label col-md-7"  runat="server" Text=""></asp:Label>
               <asp:Label ID="lblCreatedDate" CssClass="control-label col-md-5" runat="server" Text="Created Date"></asp:Label>
                        
               <asp:Label ID="lblDate" CssClass="control-label col-md-7" runat="server" Text='<%# Eval("Date", "{0:D}")%>' ></asp:Label>
                              
        
               <asp:Label ID="lblLatestStatus" CssClass="control-label col-md-5"  runat="server" Text="Status"></asp:Label>
               <asp:Label ID="lblStatus" CssClass="control-label col-md-7"  runat="server" Text=""></asp:Label>
              </div>
          
                 </div>   </div>
        
     </div>
                       <br />    
      <div class="accordion-container"> <a href="#" class="accordion-toggle">Details <span class="toggle-icon"><i class="fa fa-plus-circle"></i></span></a>
          <div class="accordion-content"> 
             <div id="divList">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <telerik:RadGrid ID="dtDocDetailGrid" runat="server" AllowPaging="true" AllowSorting="true"  PageSize="7" OnNeedDataSource="dtDocDetailGrid_NeedDataSource"
                         OnItemCommand="dtDocDetailGrid_ItemCommand" OnItemDataBound="dtDocDetailGrid_ItemDataBound"
                        Skin="Silk" CssClass="outerMultiPage" OnPreRender="dtDocDetailGrid_PreRender">
                    
                          <MasterTableView DataKeyNames="RevisionID,ProjectNo"></MasterTableView>
                    </telerik:RadGrid>

               </div>  
    
     </div>                
            
    </div>
         </div>
        </div>
</asp:Content>
 