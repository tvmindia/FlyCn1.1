﻿/*Validation Methods are defined here*/


function IsNumeric(event)
{
    
   // if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
       // event.preventDefault();
   // }
    var re = new RegExp("^[0-9]*[.][0-9]+$");
  
    if (event.val().match(re))
    {
        //alert("Successful match");
        event.preventDefault();
    }
    else
    {
        alert("No match");
    }
}

function isNumberKey(sender, evt) {
    var txt = sender.value;
    var dotcontainer = txt.split('.');
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (!(dotcontainer.length == 1 && charCode == 46) && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}