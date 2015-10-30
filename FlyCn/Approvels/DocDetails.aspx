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
         id = document.getElementById('IDAccordion');

         OpenDetailAccordion(id);

         $('.accordion-toggle').on('click', function (event) {

             event.preventDefault();
             OpenDetailAccordion(this);
         });

     });



     function OpenDetailAccordion(id) {
         if (id != undefined)//accordion called from accordion click functionjs
         {
             var accordion = $(id);
             var accordionContent = accordion.next('.accordion-content');
             var accordionToggleIcon = accordion.children('.toggle-icon');

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
         }
         if (id == undefined)//accordion called from code behind scrpt register after BoqHeaderSave
         {
             id = document.getElementById('IDAccordion');
             var accordion = $(id);
             var accordionContent = accordion.next('.accordion-content');
             var accordionToggleIcon = accordion.children('.toggle-icon');

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
         }
     }
</script>
     
    <style>
        .head{
            color:black;
            font-size:large;
        }
    </style>
   <%-- <div class="container" style="width:100%">--%>
       <div id="bodyDiv">
        <div class="contentTopBar"></div>
  
 
           <div class="col-md-12 Span-One">
                <div class="col-md-6">
                
                    <asp:Label ID="lblDocNo" CssClass="control-label col-md-5" runat="server" Text="Document Number"></asp:Label>
                    <asp:Label ID="lblDocumntNo"  CssClass="control-label col-md-7" runat="server" Text=""></asp:Label>
                   

                   <asp:Label ID="lblDocumentType" CssClass="control-label col-md-5"  runat="server" Text="Document Type"></asp:Label>
                    <asp:Label ID="lblType" CssClass="control-label col-md-7" runat="server" Text=""></asp:Label>            
                <div class="form-group">
               <asp:Label ID="lblCreatedBy"  CssClass="control-label col-md-5" runat="server" Text="Created By"></asp:Label>
                   
                    
               <asp:Label ID="lblCreated" CssClass="control-label col-md-7" runat="server" Text=""></asp:Label>
      </div>  </div>
    <div class="col-md-6">
                
                     <asp:Label ID="lblClientNo" CssClass="control-label col-md-5" runat="server" Text="Client DocumentNo"></asp:Label>
                    <asp:Label ID="lblClientDocNo" CssClass="control-label col-md-7"  runat="server" Text=""></asp:Label>
               <asp:Label ID="lblCreatedDate" CssClass="control-label col-md-5" runat="server" Text="Created Date"></asp:Label>
                        
               <asp:Label ID="lblDate" CssClass="control-label col-md-7" runat="server" Text='<%# Eval("Date", "{0:D}")%>' ></asp:Label>
                              
        
               <asp:Label ID="lblLatestStatus" CssClass="control-label col-md-5"  runat="server" Text="Status"></asp:Label>
               <asp:Label ID="lblStatus" CssClass="control-label col-md-7"  runat="server" Text=""></asp:Label>
              </div>
          
                   </div>
        
     </div>
                       <br />    

        <a href="#"  id="IDAccordion">
            <asp:Label ID="lblheader" runat="server" Text="Details" style="font-size:large"></asp:Label> <%--<span class="toggle-icon"><i class="fa fa-plus-circle"></i></span>--%></a>
          <div class="contentTopBar"> 
             <div id="divList">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                 <br />
                 <div>
                    <telerik:RadGrid ID="dtDocDetailGrid" runat="server" AllowPaging="true" AllowSorting="true"  PageSize="7" OnNeedDataSource="dtDocDetailGrid_NeedDataSource"
                         OnItemCommand="dtDocDetailGrid_ItemCommand" OnItemDataBound="dtDocDetailGrid_ItemDataBound"
                        Skin="Silk" CssClass="outerMultiPage" OnPreRender="dtDocDetailGrid_PreRender">
                    
                          <MasterTableView DataKeyNames="RevisionID,ProjectNo"></MasterTableView>
                    </telerik:RadGrid>
                 </div>
               </div>   
    
     </div>              
            

     
        
</asp:Content>