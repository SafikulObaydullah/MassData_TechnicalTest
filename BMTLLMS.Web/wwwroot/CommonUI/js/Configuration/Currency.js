var CurrencyList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);




$(document).ready(function () {
    CurrencyLoad();
});

function CurrencyLoad() {
    $.ajax({
        url: "/Currency/GetCurrency",
        method: "GET",
        dataType: "json",
        success: function (data) {
            CurrencyList = data;
            CurrencyDataBind();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function CurrencyDataBind() {
    var i = 1;
    _.map(CurrencyList, function (o) {
        o.sl = i;
        i++;
    });

    $("#gridTable").kendoGrid({
        dataSource: CurrencyList,
        sortable: true,
        toolbar: ["search"],
        search: {
            fields: ["name"]
        },
        pageable: {
            pageSize: 15,
            pageSizes: [15, 30, 50, "all"],
            numeric: false
        },
        columns: [ 
            {
                field: "sl",
                title: "SL No",
                width: 15,
                attributes: { style: "text-align: center;"},headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            },

            {
                title: "Currency Name",
                field: "name", width: 120,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },

            {
                title: "Currency Short Name",
                field: "shortName", width: 120,
                attributes: {  style: "text-align: left;"}, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },

            {
                title: "Action",
                template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 20,
                attributes: { style: "text-align: center;" },headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            },
        ]
    });
}


function Save() {
    var o = new Object();
    var validate = true;
    validate = Validate();
    if (validate == true) {
        o.id = $('#spanParentID').html();
        o.name = $('#name').val();
        o.shortName = $('#shortName').val();
        o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
            url: "/Currency/CurrencySave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                console.log(data)
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    CurrencyLoad();
                    $('#mdlUserReg').modal('hide')
                } else {
                    toastr.warning(data.message, "Waring");
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                toastr.error('Error Saving', 'Error');
            }
        });

    }
}

function Edit(id) {
   console.log("edit dddddd")
   console.log(CurrencyList)
    $('#spanParentID').html(id);
    var FilterData = _.filter(CurrencyList, function (item) { return item.id == id });
    $('#name').val(FilterData[0].name);
   $('#shortName').val(FilterData[0].shortName);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Currency Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}


function AddNew() {
   $('#staticBackdropLabel').text('Create New Currency');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#name').val('');
    $('#shortName').val('');
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
    if ($('#name').val() == "") {
        $('#name').focus();
        toastr.warning('Please input name');
        return false;
    }
    if ($('#shortName').val() == "") {
        $('#shortName').focus();
        toastr.warning('Please input short name');
        return false;
    }
    return true;
}

function checkEmptyInput(inputElement) {
    if (inputElement.value.trim() === "") {
        inputElement.style.border = "1px solid red";
    } else {
        inputElement.style.border = "1px solid #ced4da"; // Reset border to default
    }
}
