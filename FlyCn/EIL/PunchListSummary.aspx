<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/IframePage.Master" AutoEventWireup="true" CodeBehind="PunchListSummary.aspx.cs" Inherits="FlyCn.EIL.PunchListSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"   >
     <script type="text/javascript" src="https://www.google.com/jsapi"></script> 
    <style type="text/css">
    .submit {
        
        border-radius: 5px;
        color: black;
        padding: 5px 10px 5px 20px;
        background-image: url(../Images/Download-202-WF.png);
        background-repeat:no-repeat;
        background-position-y: 465px;
        background-position-x: 5px;
      
    }
 body 
 {
     
      height:1200px;
      
 }

 html {width:100%; height:100%; overflow:auto; }

</style>
     <script type="text/javascript">

          // Load the Visualization API and the piechart package.
          google.load('visualization', '1.0', {'packages':['corechart']});

          // Set a callback to run when the Google Visualization API is loaded.
          google.setOnLoadCallback(drawChart);
          google.setOnLoadCallback(drawPunchListSummary);
          // Callback that creates and populates a data table,
          // instantiates the pie chart, passes in the data and
          // draws it.
          function drawChart() {

            // Create the data table.
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Topping');    
            data.addColumn('number', 'Employee');
            data.addColumn('number', 'Welders');
            data.addRows([
             ['0', 0, 0]
              
            ]);
            // Create the data table.
          
            // Set chart options
            var options = { 'title': 'Project-Manpower Graph', backgroundColor: 'bisque', vAxis: { title: 'Count', viewWindow: { max: 50, min: 0 }, gridlines: { count: 10 } }, hAxis: { title: 'Category' } };

            // Instantiate and draw our chart, passing in some options.
            var chart = new google.visualization.ColumnChart(document.getElementById('columnchart_material1'));
            chart.draw(data, options);
           

          }

          function drawPunchListSummary() {

              // Create the data table.
              var data = new google.visualization.DataTable();
              data.addColumn('string', 'Month-Year');
              data.addColumn('number', 'Total');
              data.addColumn('number', 'Open');
              data.addColumn('number', 'Closed');
              data.addRows([
               ['0', 0, 0,0]

              ]);
              // Create the data table.

              // Set chart options
              var options = { 'title': 'Monthly Punchlist Summary', backgroundColor: '#fff2e6', vAxis: { title: 'Count Of Items', viewWindow: { max: 50, min: 0 }, gridlines: { count: 10 } }, hAxis: { title: 'Month-Year' } };

              // Instantiate and draw our chart, passing in some options.
              var chart = new google.visualization.ColumnChart(document.getElementById('columnchart_material'));
              chart.draw(data, options);


          }
        </script>
    
 &nbsp;&nbsp; <asp:Label ID="lblTitle" runat="server" Text="DashBoard" CssClass="PageHeading"></asp:Label>
     <div class="importWizardContainer" style="height:1200px">
          <asp:Literal ID="ltScripts" runat="server"></asp:Literal> 
          <asp:Literal ID="ltManpowerScripts" runat="server"></asp:Literal>  
         <asp:Literal ID="ltProjectByArea" runat="server"></asp:Literal>  
         <div class="col-md-12">
             <div class="col-md-5">
    <div id="columnchart_material" style="width: 500px; height: 500px;background-color:#fff2e6; box-shadow: 0 0 3px 3px #d0e1e1;">      
             </div>  
       <div style="width: 500px; height: 23px;background-color:#fff2e6;box-shadow:  3px 3px 3px 0 #d0e1e1;">    
           <div style="margin-left:90%;" > 
       <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Download-202-WF.png" ToolTip="Download" OnClick="ImageButton1_Click"  /> 
   </div>  </div>
                 </div> <div class="col-md-1"></div>
             <div class="col-md-6">
          <div id="columnchart_material1" style="width: 500px; height: 500px;background-color:bisque; box-shadow:  0 0 3px 3px #d0e1e1;">        
             </div>  
                <div style="width: 500px; height: 23px;background-color:#f0f0f5; box-shadow:  3px 3px 3px 0 #d0e1e1;">    
           <div style="margin-left:90%;" > 
       <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Download-202-WF.png" ToolTip="Download" OnClick="ImageButton2_Click"  /> 
   </div>  </div>   
     </div> 
       </div> 
          <div class="col-md-12" style="height:20px;"></div>
         <div class="col-md-12">
             <div class="col-md-5">
                  <div id="columnchart_material2" style="width: 500px; height: 500px;background-color:#f4f4d7; box-shadow: 0 0 3px 3px #d0e1e1;">      
             </div>  
                   <div style="width: 500px; height: 23px;background-color:#f4f4d7;box-shadow:  3px 3px 3px 0 #d0e1e1;">    
           <div style="margin-left:90%;" > 
       <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Download-202-WF.png" ToolTip="Download" OnClick="ImageButton3_Click"  /> 
   </div>  </div>  
                 </div>
             <div class="col-md-1"></div>
             <div class="col-md-6">
                 </div>
             </div>
         </div>
       
</asp:Content>
