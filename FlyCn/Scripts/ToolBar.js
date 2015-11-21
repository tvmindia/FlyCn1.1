function AddMode(toolbar)
{
    //var fnname = toolbar + '_SetAddVisible';   
    //window[fnname](false);
    var fname1 = toolbar + '_SetSaveVisible';
    window[fname1](true);
    //var fname2 = toolbar + '_SetUpdateVisible';
    //window[fname2](false);
    //var fname3 = toolbar + '_SetDeleteVisible';
    //window[fname3](false);
    //var fname4 = toolbar + '_SetEditVisible';
    //window[fname4](false);
    //var fname5 = toolbar + '_SetApproveVisible';
    //window[fname5](false);
    //var fname6 = toolbar + '_SetDeclineVisible';
    //window[fname6](false);
    //var fname7 = toolbar + '_SetRejectVisible';
    //window[fname7](false);
}
function EditMode(toolbar)
{
    //debugger;
    //var fnname0 = toolbar + '_SetAddVisible';
    //window[fnname0](false);
    //var fname01 = toolbar + '_SetSaveVisible';
    //window[fname01](false);
    var fname02 = toolbar + '_SetUpdateVisible';
    window[fname02](true);
    var fname = toolbar + '_SetAddVisible';
    window[fname](true);
    //var fname03 = toolbar + '_SetDeleteVisible';
    //window[fname03](false);
    //var fname04 = toolbar + '_SetEditVisible';
    //window[fname04](false);
    //var fname05 = toolbar + '_SetApproveVisible';
    //window[fname05](false);
    //var fname06 = toolbar + '_SetDeclineVisible';
    //window[fname06](false);
    //var fname07 = toolbar + '_SetRejectVisible';
    //window[fname07](false);
}
function DisableAll(toolbar)
{
    var fnname = toolbar + '_SetAddVisible';
    window[fnname](false);
    var fname1 = toolbar + '_SetSaveVisible';
    window[fname1](false);
    var fname2 = toolbar + '_SetUpdateVisible';
    window[fname2](false);
    var fname3 = toolbar + '_SetDeleteVisible';
    window[fname3](false);
    var fname4 = toolbar + '_SetEditVisible';
    window[fname4](false);
    var fname5 = toolbar + '_SetApproveVisible';
    window[fname5](false);
    var fname6 = toolbar + '_SetDeclineVisible';
    window[fname6](false);
    var fname7 = toolbar + '_SetRejectVisible';
    window[fname7](false);

}
function EnableButtonsWithDelete(toolbar)
{
    var fname = toolbar + '_SetDeleteVisible';
    window[fname](true);
}