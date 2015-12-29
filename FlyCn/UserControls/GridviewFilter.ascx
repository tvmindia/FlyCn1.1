<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridviewFilter.ascx.cs" Inherits="FlyCn.UserControls.GridviewFilter" %>




<html>
<head>
  

    <script>
    function SlideToggle()
        {
           
            $("#searchIcon").css("display", "inline");

            $("#searchIcon").click(function () {

                $("#searchIcon").css("display", "none");
                $("#paneldiv").slideDown("slow");

                $("#UpIcon").css("display", "inline");
            });

            $("#UpIcon").click(function () {
                $("#paneldiv").slideUp("slow", function () {
                    
                    //$("#searchIcon").css("display", "inline");

                    $("#searchIcon").fadeIn("slow");
                    $("#UpIcon").css("display", "none");
                })

            });
        }

        $(document).ready(function () {
            debugger;
            
            $("#paneldiv").css("display", "none");

            $("#UpIcon").css("display", "none");

            $("#searchIcon").click(function () {

                $("#searchIcon").css("display", "none");
                $("#paneldiv").slideDown("slow");

                $("#UpIcon").css("display", "inline");


                $("#UpIcon").click(function () {
                    $("#paneldiv").slideUp("slow", function () {

                        //$("#searchIcon").css("display", "inline");

                        $("#searchIcon").fadeIn("slow");
                        $("#UpIcon").css("display", "none");
                    })

                });
            });


        });



      var prm = Sys.WebForms.PageRequestManager.getInstance();
        var a = 0;

        if (prm != null) {
            
            prm.add_endRequest(function (sender, e) {
                debugger;
           
              var hiddenPostBackValue = $("#" + '<%=hdnPostbackOnItemCommand.ClientID%>').val();
                
         //var hiddenPostBackValue = $find("#" + '<%=hdnPostbackOnItemCommand.ClientID%>').val();
               

//Item command event triggered

                if (hiddenPostBackValue == "True")
                {
                    //a = 1;
                    //hiddenPostBackValue == "False";

                    $("#searchIcon").css("display", "inline");
                    $("#UpIcon").css("display", "none");
                    
                    $("#paneldiv").css("display", "none");

                    $("#searchIcon").click(function () {

                        $("#searchIcon").css("display", "none");
                        $("#paneldiv").slideDown("slow");

                        $("#UpIcon").css("display", "inline");


                        $("#UpIcon").click(function () {
                            $("#paneldiv").slideUp("slow", function () {

                                //$("#searchIcon").css("display", "inline");

                                $("#searchIcon").fadeIn("slow");
                                $("#UpIcon").css("display", "none");
                            })

                        });
                    });
 }
               

 //Selected index changed event triggered

                    if (hiddenPostBackValue == "False") {
                     
                        $("#searchIcon").css("display", "none");

                        $("#searchIcon").click(function () {

                            $("#searchIcon").css("display", "none");
                            $("#paneldiv").slideDown("slow");

                            $("#UpIcon").css("display", "inline");
                        });

                            $("#UpIcon").click(function () {
                                $("#paneldiv").slideUp("slow", function () {
                                   
                                    //$("#searchIcon").css("display", "inline");

                                    $("#searchIcon").fadeIn("slow");
                                    $("#UpIcon").css("display", "none");
                                })

                            });
                        
                    }
               
            

            });

        };


//tested
        if (a == 1) {
            $("#paneldiv").css("display", "inline");
            $("#searchIcon").css("display", "none");
            $("#UpIcon").css("display", "none");

            $("#UpIcon").click(function () {
                $("#paneldiv").slideUp("slow", function () {

                    //$("#searchIcon").css("display", "inline");

                    $("#searchIcon").fadeIn("slow");
                    $("#UpIcon").css("display", "none");
                })

                $("#searchIcon").click(function () {

                    $("#searchIcon").css("display", "none");
                    $("#paneldiv").slideDown("slow");

                    $("#UpIcon").css("display", "inline");
                });


            });

        }

    </script>

    <script>
        //$("#ddlColumnName").on("blur", function () {

        //    PageMethods.MakeDropdownlistIntoPreviousFormAfterClickingAddButton();

        //});
   </script>

   

    <script>

        //$(function () {

        //    $(document).tooltip();

        //    //$(imgbtnRefresh).hover(function () {
        //    //   $(this).attr('title','Refresh');
        //    //});

        //});

    </script>





    <style>
        #panel, #flip {
            padding: 5px;
            text-align: right;
        }

        #panel {
            padding: 13px;
            display: none;
            background-color: #e5eecc;
            margin-top: 16px;
            margin-right: 40px;
        }
    </style>
</head>
<body>
     
     

   
    <asp:PlaceHolder ID="phFilter" runat="server">
        <asp:UpdatePanel ID="updatepanel" runat="server">
            <ContentTemplate>


                <div id="flip">

                    <table style="border-spacing: 10px; width: 100%;">
                         


                        <tr>

                            <td style="width: 40%"></td>
                            <td style="width: 60%;">

                                 

                                <table style="width:100%;" ><tr>
                                    <td >
                                         <div id="paneldiv" >
                                             <table>
                                                 <tr>
                                                     <td style="width:15%;text-align:left" >
                                                         <asp:Label ID="lblColumnName" runat="server" Text="Column Name" ></asp:Label></td>
                                                     <td style="width:1%"></td>
                                                     <td style="width:5%">
                                                         <asp:DropDownList ID="ddlColumnName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlColumnName_SelectedIndexChanged1">
                                                         </asp:DropDownList></td>

                                                     <td style="width:1%"></td>
                                                     <td style="width:6%">
                                                         <asp:Label ID="lblOperator" runat="server" Text="Operator"></asp:Label></td>
                                                     <td style="width:1%"></td>
                                                     <td style="width:5%">
                                                         <asp:DropDownList ID="ddlOperator" runat="server"  AutoPostBack="True"></asp:DropDownList></td>
                                                     <td style="width:1%"></td>

                                                     <td style="width:5%">
                                                         <asp:Label ID="lblvalue" runat="server" Text="Value"></asp:Label></td>
                                                     <td style="width:1%"></td>
                                                     <td style="width:25%">
                                                         <asp:TextBox ID="txtValueToFilter" runat="server" Width="100%"></asp:TextBox></td>
                                                     <td style="width:1%"></td>

                                                     <td><asp:DropDownList ID="ddlANDorOR" runat="server">
                                                             <asp:ListItem>AND</asp:ListItem>
                                                             <asp:ListItem>OR</asp:ListItem>
                                                            

                                                         </asp:DropDownList></td>

                                                     <td style="width:1%"></td>

                                                     <td style="width:2%">
                                                         <asp:ImageButton ID="imgAddIcon" runat="server" ImageUrl="../Images/plus1.png" OnClick="imgAddIcon_Click" align="right" Style="cursor: pointer; width: 15px; height: 15px;"/>
                                                     </td>
                                                     <td style="width:1%"></td>

                                                     <td style="width:1%"></td>
                                                     <td style="width:2%">
                                                       <asp:ImageButton ID="imgRemove" runat="server" ImageUrl="../Images/Minus.png"  align="right" Style="cursor: pointer; width: 15px; height: 15px;" OnClick="imgRemove_Click"/> 
                                                     </td>
                                                     <td style="width:1%"></td>

                                                     <td style="width:2%">
                                                         <asp:ImageButton ID="imgbtnSearch" runat="server" OnClick="imgbtnSearch_Click1" ImageUrl="../Images/Search.png" Style="cursor: pointer; width: 15px; height: 15px;" ToolTip="Search" />
                                                     </td>
                                             <td style="width:1%"></td>

                                                     <td style="width:2%">
                                                         <asp:ImageButton ID="imgbtnRefresh" runat="server" OnClick="imgbtnRefresh_Click" ImageUrl="../Images/RefreshSearch.png" Style="cursor: pointer; width: 15px; height: 15px;" title="Refresh" />
                                                     </td>
                                                  </tr>
                                                 <tr>
                                                     <td colspan="22">

                                                         <%--  <div style="padding-left: 320px">--%>
                                                         <asp:GridView ID="gvSearch" runat="server"  GridLines="None" >
         <%--<Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnChange" Text="Change" runat="server"  OnClick="btnChange_Click"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>--%>
                                                            <%-- <RowStyle HorizontalAlign="right" />--%>
                                                         </asp:GridView>

                                                         <%--</div>--%>


                                                     </td>
                                                     <td style="width:30%">
                                                         <asp:Label ID="lblResultReturnedCount" runat="server" Text="Label"></asp:Label></td>
                                                     
                                                 </tr>
                                             </table>


                                         </div>


                                    </td>
                                     
                                     <td style="width:1%">   
                                         <img src="../Images/HideSearch.png" id="UpIcon" style="cursor: pointer;" title="Hide search box" width="15" height="15" />
                                         <img src="../Images/Search.png" width="20" height="20" id="searchIcon" style="cursor: pointer" title="Click to filter" align="right" />
                                    </td>
                                       </tr>

                                </table>

                             
  
                            </td>
                        </tr>



                       
                    </table>

                    <%-- <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />--%>




                    <asp:HiddenField ID="hdnClickedOrNot" runat="server" Value="false" />
                    <asp:HiddenField ID="hdnPostbackOnItemCommand" runat="server" value="False"/>
                    <asp:HiddenField ID="hdnRemoveClicked" runat="server" Value="notClicked" />
                </div>
                
  </ContentTemplate>
     
        </asp:UpdatePanel>
    </asp:PlaceHolder>

    <%-- <asp:Label ID="m_TimeLabel" runat="server" Text="Label"></asp:Label>--%>
</body>
</html>



               


