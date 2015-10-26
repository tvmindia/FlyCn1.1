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

    <%-- <style type="text/css">
        .ui-dialog-title {
            padding-left: 15em;
            color: white;
        }

        .ui-dialog-titlebar {
            background: transparent;
            border: none;
        }

        .ui-dialog .ui-dialog-titlebar-close {
            right: 0;
        }

        .ui-dialog {
            box-shadow: 0px 2px 7px #292929;
            -moz-box-shadow: 0px 2px 7px #292929;
            -webkit-box-shadow: 0px 2px 7px #292929;
            border-radius: 15px;
            -moz-border-radius: 15px;
            -webkit-border-radius: 15px;
            background: #f2f2f2;
            z-index: 50;
            /*background:transparent;*/
            /*background: rgba(34,34,34,0.75);*/
            background: rgba(36,85,99,.9);
            border: 1px solid #fff;
        }
        </style>

 <script type="text/javascript">  
     $(document).ready(function () {

         OpenNewProjectWizard();

     });
        function OpenNewProjectWizard() {
            try {
                $("#modal_dialog").dialog({

                    title: "Document Details",
                    width: 780,
                    height: 700,
                    buttons: {}, modal: true
                });
                //$(".ui-dialog-titlebar").hide();
                //  $("#modal_dialog").dialog('widget').find(".ui-dialog-titlebar-close").show();
                return false;
            }
            catch (X) {
                alert(X.message);
            }
        }
     
     </script>--%>
        <%--  <div id="modal_dialog" style="width: 1000px!important; height: 700px!important; overflow: hidden; overflow-x: hidden;">--%>
    <br />
    <div>
           <div class="col-md-12 Span-One">
                <div class="col-md-6">
                <div class="form-group">
               <asp:Label ID="lblDocumentType" CssClass="control-label col-md-3"  runat="server" Text="Document Type"></asp:Label>
                        
               <asp:Label ID="lblType" CssClass="control-label col-md-3" runat="server" Text=""></asp:Label>
                            </div>
                      <div class="col-md-9">
                <div class="form-group">
               <asp:Label ID="lblCreatedBy"  CssClass="control-label col-md-3" runat="server" Text="Created By"></asp:Label>
                   
                    
               <asp:Label ID="lblCreated" CssClass="control-label col-md-3" runat="server" Text=""></asp:Label>
        </div></div></div>
    <div class="col-md-6">
                <div class="form-group">
               <asp:Label ID="lblCreatedDate" CssClass="control-label col-md-3" runat="server" Text="Created Date"></asp:Label>
                        
               <asp:Label ID="lblDate" CssClass="control-label col-md-3" runat="server" Text=""></asp:Label>
                              </div>
          <div class="col-md-9">
               <asp:Label ID="lblLatestStatus" CssClass="control-label col-md-3"  runat="server" Text="Status"></asp:Label>
               <asp:Label ID="lblStatus" CssClass="control-label col-md-3"  runat="server" Text=""></asp:Label>
              </div>
           </div>
                    </div>
        </div>
                       <br />                    
                <div id="divList">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <telerik:RadGrid ID="dtDocDetailGrid" runat="server" AllowPaging="true" AllowSorting="true"  PageSize="7" OnNeedDataSource="dtDocDetailGrid_NeedDataSource"
                         OnItemCommand="dtDocDetailGrid_ItemCommand"
                        Skin="Silk" CssClass="outerMultiPage" OnPreRender="dtDocDetailGrid_PreRender">
                    
                          <MasterTableView DataKeyNames="RevisionID,ProjectNo"></MasterTableView>
                    </telerik:RadGrid>


      </div>

     
<%--            </div>--%>
</asp:Content>
 