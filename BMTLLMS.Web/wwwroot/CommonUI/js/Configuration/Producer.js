var ProducerList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

$(document).ready(function () {
    ProducerLoad();
});

function ProducerLoad() {
    $.ajax({
        url: "/Producer/GetProducer",
        method: "GET",
        dataType: "json",
        success: function (data) {
            ProducerList = data;
            console.log(ProducerList);
            ProducerDataBind();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function ProducerDataBind() {
    var i = 1;
    _.map(ProducerList, function (o) {
        o.sl = i;
        i++;
    });

    console.log()
    $("#gridTable").kendoGrid({
        dataSource: ProducerList,
        sortable: true,
        toolbar: ["search"],
        search: {
            fields: ["name","address","contactPerson","phone"]
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
                width: 25,
                attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            },

            {
                title: "Name",
                field: "name", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },

            {
                title: "Address",
                field: "address", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            },
            {
                title: "Contact Person",
                field: "contactPerson", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Phone",
                field: "phone", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Action",
               template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 40,
                headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
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
        o.address = $('#address').val();
        o.contactPerson = $('#contactPerson').val();
        o.phone = $('#phone').val();
        o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
            url: "/Producer/ProducerSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                console.log(data)
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    ProducerLoad();
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
    $('#spanParentID').html(id);
    var FilterData = _.filter(ProducerList, function (item) { return item.id == id });
    $('#name').val(FilterData[0].name);
    $('#address').val(FilterData[0].address);
    $('#contactPerson').val(FilterData[0].contactPerson);
    $('#phone').val(FilterData[0].phone);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
    $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Producer Information');
    $('#btnSave').text('Update');
    $('#btnSave').addClass('btn btn-ghost-info active w-10');
}


function AddNew() {
    $('#staticBackdropLabel').text('Create New Producer');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#name').val('');
    $('#address').val('');
    $('#contactPerson').val('');
    $('#phone').val('');
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
    if ($('#name').val() == "") {
        $('#name').focus();
        toastr.warning('Please input Producer name');
        return false;
    }

    if ($('#address').val() == "") {
        $('#address').focus();
        toastr.warning('Please input Address');
        return false;
    }
    if ($('#contactPerson').val() == "") {
        $('#contactPerson').focus();
        toastr.warning('Please input Contact Person');
        return false;
    }
    if ($('#phone').val() == "") {
        $('#phone').focus();
        toastr.warning('Please input Phone');
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
