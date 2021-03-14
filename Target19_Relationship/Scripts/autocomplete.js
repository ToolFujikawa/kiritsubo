$(function () {
    $('#mainFullName').autocomplete({
        source: '/Choice/StaffName'
    });
    $('#mainResponsibleStaff').autocomplete({
        source: '/Choice/StaffName'
    });
    $('#mainCommonName').autocomplete({
        source: '/Choice/BusinessPartnerName'
    });
    $('#mainCustomer').autocomplete({
        source: '/Choice/BusinessPartnerName'
    });
    $('#mainHelperName').autocomplete({
        source: '/Choice/HelperName'
    });
    $('#mainHelper').autocomplete({
        source: '/Choice/HelperName'
    });
    $('#mainLocationName').autocomplete({
        source: '/Choice/DeliveryPlaceName'
    });
    //
    $('input[name$="Product"]').autocomplete({
        source: '/Choice/ProductList',
        minLength: 2
    });
    $('input[name$="ProductName"]').autocomplete({
        source: '/Choice/ProductName',
        minLength: 2
    });
    $('#searchtext').autocomplete({
        source: '/Choice/ProductName',
        minLength: 2
    });
    $('#Customer').autocomplete({
        source: '/Choice/BusinessPartnerName'
    });
    $('#Supplier').autocomplete({
        source: '/Choice/BusinessPartnerName'
    });
    $('#ResponsibleStaff').autocomplete({
        source: '/Choice/StaffName'
    });
});