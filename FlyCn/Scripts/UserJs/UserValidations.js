/*Validation Methods are defined here*/


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
    //else portion
    return true;
}

//removes blank space left and right
function trimString(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}



//function to validate Excel file extension
function validateExcelExtension(ext) {
    if (!/(\xls|\xlsx|\XLS|\XLSX)$/i.test(ext)) {
        return false;
    }
    return true;
}



function DisableGrid(gridCtrl) {
   
    gridCtrl.get_element().disabled = "disabled";
    gridCtrl.ClientSettings.Selecting.AllowRowSelect = false;
    gridCtrl.ClientSettings.Resizing.AllowColumnResize = false;
    gridCtrl.ClientSettings.Resizing.AllowRowResize = false;
    gridCtrl.ClientSettings.AllowColumnsReorder = false;
    gridCtrl.ClientSettings.AllowDragToGroup = false;
    gridCtrl.ClientSettings.EnablePostBackOnRowClick = false;
    var links = gridCtrl.get_element().getElementsByTagName("a");
    var images = gridCtrl.get_element().getElementsByTagName("img");
    var inputs = gridCtrl.get_element().getElementsByTagName("input");
    var sortButtons = gridCtrl.get_element().getElementsByTagName("span");
    for (var i = 0; i < links.length; i++) {
        links[i].href = "";
        links[i].onclick = function () {
            return false;
        }
    }
    for (var i = 0; i < images.length; i++) {
        images[i].onclick = function () {
            return false;
        }
    }
    for (var i = 0; i < sortButtons.length; i++) {
        sortButtons[i].onclick = function () {
            return false;
        }
    }
    for (var i = 0; i < inputs.length; i++) {
        switch (inputs[i].type) {
            case "button":
                inputs[i].onclick = function () {
                    return false;
                }
                break;
            case "checkbox":
                inputs[i].disabled = "disabled";
                break;
            case "radio":
                inputs[i].disabled = "disabled";
                break;
            case "text":
                inputs[i].disabled = "disabled";
                break;
            case "password":
                inputs[i].disabled = "disabled";
                break;
            case "image":
                inputs[i].onclick = function () {
                    return false;
                }
                break;
            case "file":
                inputs[i].disabled = "disabled";
                break;
            default:
                break;
        }
    }
    var scrollArea = gridCtrl.GridDataDiv;
    if (scrollArea) {
        scrollArea.disabled = "disabled";
    }
   
}