/*Validation Methods are defined here*/


function IsNumeric(e) {
    var specialKeys = new Array();
    specialKeys.push(8); //Backspace
    specialKeys.push(46);//dot operator
    var keyCode = e.which ? e.which : e.keyCode
    var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);//ascii key checking
    return ret;
}