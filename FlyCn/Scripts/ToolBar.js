function AddMode(toolbar)
{
    var fnname = toolbar + '_SetAddVisible';   
    window[fnname](false);
    var fname1 = toolbar + '_SetSaveVisible';
    window[fname1](true);
    var fname2 = toolbar + '_SetUpdateVisible';
    window[fname2](false);
    var fname3 = toolbar + '_SetDeleteVisible';
    window[fname3](false);
    var fname4 = toolbar + 'SetEditVisible';
    window[fname4](false);
    var fname5 = toolbar + 'SetApproveVisible';
    window[fname5](false);
    var fname6 = toolbar + 'SetDeclineVisible';
    window[fname6](false);
    var fname7 = toolbar + 'SetRejectVisible';
    window[fname7](false);
}