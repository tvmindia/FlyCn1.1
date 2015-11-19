/*Validation Methods are defined here*/


function IsNumeric(e) {
    var specialKeys = new Array();
    var count = 0;
    specialKeys.push(8); //Backspace
    specialKeys.push(46);//dot operator
    var keyCode = e.which ? e.which : e.keyCode
    if (keyCode == '46') {
        count++;
    }
    if (count != 2) {
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
    }
    else {
        ret = false;
    }
    return ret;
}