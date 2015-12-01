function AddMode(toolbar)
{
   
    var fname1 = toolbar + '_SetSaveVisible';
    window[fname1](true);

}
function EditMode(toolbar)
{

    var fname02 = toolbar + '_SetUpdateVisible';
    window[fname02](true);
    var fname = toolbar + '_SetAddVisible';
    window[fname](true);

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

function EnableButtonsForEditDocuments(toolbar) {   
    var fnname = toolbar + '_SetAddVisible';
    window[fnname](true);
    var fname4 = toolbar + '_SetEditVisible';
    window[fname4](true);
}
function DisableEditAndEnableUpdateForDocs(toolbar)
{
    var fname4 = toolbar + '_SetEditVisible';
    window[fname4](false);
    var fname2 = toolbar + '_SetUpdateVisible';
    window[fname2](true);
}

var PageSecurity=
{

    isReadOnly:false,
    isWriteOnly:false,
    isEditOnly:false,
    isAddOnly:false,
    isDelete:false,
    isDenied:false,
}

function PageSecurityCheck(security)
{
    if (security.indexOf("w") > -1)
        PageSecurity.isWriteOnly = true;
    else
        if (security.indexOf("e") > -1)
            PageSecurity.isEditOnly = true;
        else
            if (security.indexOf("a") > -1)
                PageSecurity.isAddOnly = true;
            else
                if (security.indexOf("r") > -1)
                    PageSecurity.isReadOnly = true;
                
    if(security.indexOf("d")>-1)
    {
        PageSecurity.isDelete = true;
    }
}
