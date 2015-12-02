<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="ImportStatus.aspx.cs" Inherits="FlyCn.ExcelImport.ImportStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
<head>
  <title></title>
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <form role="form">
            <h2>Import Status

            </h2>
                  <asp:ScriptManager ID="ScriptManager2" runat="server" />
                         <asp:Timer runat="server" id="Timer4" interval="1000" />
        <asp:UpdatePanel runat="server" id="UpdatePanel7" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="Timer4" eventname="Tick" />
            </Triggers>
            <ContentTemplate>
            <div class="form-group">
                <div class="col-sm-10">
                 <asp:Label ID="lbl_ProjNo" runat="server" Text="Project Number"></asp:Label>
                
                 <asp:Label ID="lbl_ProjNo1" runat="server"></asp:Label>
                </div>
                </div>
                 <div class="form-group">
                     <div class="col-sm-10">
         <asp:Label ID="lbl_FileName" runat="server" Text="File Name"></asp:Label>
                
       <asp:Label ID="lbl_FileName1" runat="server"></asp:Label>
                </div>
                </div>
            <div class="form-group">
                <div class="col-sm-10">
               <asp:Label ID="lbl_TableName" runat="server" Text="Table Name"></asp:Label>
                
                <asp:Label ID="lbl_TableName1" runat="server"></asp:Label>
                </div>
                </div>
            <div class="form-group">
                 <div class="col-sm-10">
                 <asp:Label ID="lbl_TotalCount" runat="server" Text="Total Count"></asp:Label>
               
                 <asp:Label ID="lbl_TotalCount1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10">
                <asp:Label ID="lbl_StartTime" runat="server" Text="Start Time"></asp:Label>
                
                <asp:Label ID="lbl_StartTime1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10">
               <asp:Label ID="lbl_InsertCount" runat="server" Text="Insert Count"></asp:Label>
                
                  <asp:Label ID="lbl_InsertCount1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                 <div class="col-sm-10">
                  <asp:Label ID="lbl_UpdateCount" runat="server" Text="Update Count"></asp:Label>
               
                <asp:Label ID="lbl_UpdateCount1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                  <div class="col-sm-10">
                 <asp:Label ID="lbl_ErrorCount" runat="server" Text="Error Count"></asp:Label>
              
                 <asp:Label ID="lbl_ErrorCount1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                 <div class="col-sm-10">
                 <asp:Label ID="lbl_LastUpdatedTime" runat="server" Text="Last Updated Time"></asp:Label>
               
                  <asp:Label ID="lbl_LastUpdatedTime1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10">
                <asp:Label ID="lbl_TimeRemaining" runat="server" Text="Time Remaining"></asp:Label>
                
                 <asp:Label ID="lbl_TimeRemaining1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                  <div class="col-sm-10">
               <asp:Label ID="lbl_UserName" runat="server" Text="User Name"></asp:Label>
              
                <asp:Label ID="lbl_UserName1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                   <div class="col-sm-10">
               <asp:Label ID="lbl_InsertStatus" runat="server" Text="Insert Status"></asp:Label>
             
                <asp:Label ID="lbl_InsertStatus1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                 <div class="col-sm-10">
                 <asp:Label ID="lbl_Remarks" runat="server" Text="Remarks"></asp:Label>
               
              <asp:Label ID="lbl_Remarks1" runat="server"></asp:Label>
                    </div>
            </div>
            <div class="form-group">
                 <div class="col-sm-10">
                 <asp:Label ID="lbl_Timeelapsed" runat="server" Text="Time Elapsed"></asp:Label>
               
                <asp:Label ID="lbl_TimeElapsed1" runat="server" ></asp:Label>
                    </div>
            </div>
           
            </div>
                 </ContentTemplate>
        </asp:UpdatePanel>
            </form>
        </div>
    </body>
        </html>
</asp:Content>
