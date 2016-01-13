<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ImportStatus.aspx.cs" Inherits="FlyCn.ExcelImport.ImportStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <script>
              function CallParentJs(statvalue)
              {
                  parent.ChangeStatusMsg(statvalue);
              }
             
          </script>
    <html>
<head>
  <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script> 
<style type="text/css">
    .jumbotron{
    	margin: 50px;
    }
	/* Fix alignment issue of label on extra small devices in Bootstrap 3.2 */
    .form-horizontal .control-label{
        padding-top: 7px;
    }
</style>
</head>
<body>
   <div style="overflow-y:hidden;">
       <%-- <form role="form-horizontal">--%>
            <div style="margin-left:100px ; text-decoration-color: red";>
            <h2 style="font-family: 'Times New Roman', Times, serif; text-align:left; font-size: xx-large; font-weight: lighter; font-style: normal; color: #800000; right: 72px; bottom: 12px; text-decoration: underline;"> Import Status

            </h2>
                </div>
                  <asp:ScriptManager ID="ScriptManager2" runat="server" />
                         <asp:Timer runat="server" id="Timer4" interval="1000"  ontick="UpdateTimer2_Tick" />
        <asp:UpdatePanel runat="server" id="UpdatePanel7" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="Timer4" eventname="Tick" />
            </Triggers>
            <ContentTemplate>
                
            <div class="form-group"  style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter; font-variant: normal; text-transform: capitalize; color: #000066">       
                   
                  <div class="form-group"  style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter; font-variant: normal; text-transform: capitalize; color: #000066">             
                 <asp:Label ID="lbl_TableName" runat="server" Text="Module Name" class="control-label col-xs-6"></asp:Label>               
                 <div class="col-xs-6">
                <asp:Label ID="lblModuleName" runat="server"></asp:Label>
                </div>
                </div>


                <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">                
               <asp:Label ID="lbl_TotalRecords" runat="server" Text="Total Records" class="control-label col-xs-6"></asp:Label>
               <div class="col-xs-6">
               <asp:Label ID="lbl_TotalRecords1" runat="server"></asp:Label>
               </div>
               </div>



                 <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">               
               <asp:Label ID="lbl_InsertRecords" runat="server" Text="Inserted Records" class="control-label col-xs-6"></asp:Label>
               <div class="col-xs-6">
               <asp:Label ID="lbl_InsertRecords1" runat="server"></asp:Label>
               </div>
               </div>


                  <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">              
                  <asp:Label ID="lbl_UpdateCount" runat="server" Text="Updated Records" class="control-label col-xs-6"></asp:Label>
                  <div class="col-xs-6">
                  <asp:Label ID="lbl_UpdateRecords1" runat="server"></asp:Label>
                  </div>
                  </div>



                  <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">                 
                 <asp:Label ID="lbl_ErrorCount" runat="server" Text="Error Count" class="control-label col-xs-6"></asp:Label>
                  <div class="col-xs-6">
                 <asp:Label ID="lbl_ErrorCount1" runat="server"></asp:Label>
                    </div>
                   </div>


                  <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">               
               <asp:Label ID="lbl_InsertStatus" runat="server" Text="Import Status" class="control-label col-xs-6"></asp:Label>
                <div class="col-xs-6">
                <asp:Label ID="lbl_InsertStatus1" runat="server"></asp:Label>
                 </div>
                 </div>



                 <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">            
                <asp:Label ID="lbl_StartTime" runat="server" Text="Start Time" class="control-label col-xs-6"></asp:Label>
                <div class="col-xs-6">
                <asp:Label ID="lbl_StartTime1" runat="server"></asp:Label>
                </div>
                </div>


                  <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">                 
                 <asp:Label ID="lbl_Timeelapsed" runat="server" Text="Time Elapsed" class="control-label col-xs-6"></asp:Label>
                 <div class="col-xs-6">
                 <asp:Label ID="lbl_TimeElapsed1" runat="server" ></asp:Label>
                    </div>
                    </div>



                 <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter; font-variant: normal; text-transform: capitalize; color: #000066">              
                <asp:Label ID="lbl_TimeRemaining" runat="server" Text="Time Remaining" class="control-label col-xs-6"></asp:Label>
                <div class="col-xs-6">
                 <asp:Label ID="lbl_TimeRemaining1" runat="server"></asp:Label>
                    </div>
                   </div>



                 <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">                 
                 <asp:Label ID="lbl_LastUpdatedTime" runat="server" Text="Last Updated Time" class="control-label col-xs-6"></asp:Label>
                 <div class="col-xs-6">
                  <asp:Label ID="lbl_LastUpdatedTime1" runat="server"></asp:Label>
                   </div>
                  </div>


                 <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">                 
                 <asp:Label ID="lbl_Remarks" runat="server" Text="Remarks" class="control-label col-xs-6"></asp:Label>
                 <div class="col-xs-6">
                 <asp:Label ID="lbl_Remarks1" runat="server"></asp:Label>
                 </div>
                 </div>

                                    
                               
                 <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter; font-variant: normal; text-transform: capitalize; color: #000066">                     
                 <asp:Label ID="lbl_FileName" runat="server" Text="File Name" class="control-label col-xs-6"></asp:Label>              
                 <div class="col-xs-6">
                 <asp:Label ID="lbl_FileName1" runat="server"></asp:Label>
                </div>
                </div>

             
               <div class="form-group" style="font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-size: large; font-weight: lighter;  font-variant: normal; text-transform: capitalize; color: #000066">                 
               <asp:Label ID="lbl_UserName" runat="server" Text="User Name" class="control-label col-xs-6"></asp:Label>
              <div class="col-xs-6">
              <asp:Label ID="lbl_UserName1" runat="server"></asp:Label>
              </div>
              </div>

          
          
            </div>
                 </ContentTemplate>
        </asp:UpdatePanel>
           <%-- </form>--%>
        </div>
    </body>
        </html>
</asp:Content>
