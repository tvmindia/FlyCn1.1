<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MasterPopupGridview.aspx.cs" Inherits="FlyCn.UserControls.MasterPopupGridview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>gvPopup</title>
      <script>
     
        function passSelectedGridviewRowBankName(selectedRowName, selectedRowCode, textboxID, divID, iframeDiv)
        {
            //alert("hi");
            //debugger;

            parent.SetTextBox(selectedRowName, textboxID, divID, iframeDiv);         

            parent.setHiddenfield(selectedRowCode);
        }

      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:GridView ID="gvTableDetails" runat="server" OnSelectedIndexChanged="gvTableDetails_SelectedIndexChanged" Height="16px" Width="285px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Images/Lb2.png"    >
                
<ItemStyle Width="25px"></ItemStyle>
                
                </asp:CommandField>
  </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
