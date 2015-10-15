 <%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="DocDetails.aspx.cs" Inherits="FlyCn.Content.DocDetailView.DocDetails" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/ToolBar.ascx" TagPrefix="uc1" TagName="ToolBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style type="text/css">
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

        //function OnClientTabSelecting(sender, eventArgs) {
        //    var tab = eventArgs.get_tab();
        //    if (tab.get_value() == '2') {

        //        eventArgs.set_cancel(true);
        //        OpenNewProjectWizard();
        //    }

     //}
     $(document).ready(function () {

         OpenNewProjectWizard();

     });



        function OpenNewProjectWizard() {
            try {
                $("#modal_dialog").dialog({

                    title: "Project Wizard",
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
     </script>
          <div id="modal_dialog" style="display: none; width: 1000px!important; height: 700px!important; overflow: hidden; overflow-x: hidden;">

                   <telerik:RadPageView ID="rpList" runat="server">
                <div id="divList">


                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
                    </asp:ScriptManager>

                    <telerik:RadGrid ID="dtDocDetailGrid" runat="server" AllowPaging="true" AllowSorting="true"  PageSize="7" OnNeedDataSource="dtDocDetailGrid_NeedDataSource"
                         OnItemCommand="dtDocDetailGrid_ItemCommand"
                        Skin="Silk" CssClass="outerMultiPage"
                        OnPreRender="dtgPersonnelGrid_PreRender">
                          <MasterTableView DataKeyNames="RevisionID,ProjectNo"></MasterTableView>
                    </telerik:RadGrid>


                </div>

            </telerik:RadPageView>

            </div>
</asp:Content>
 