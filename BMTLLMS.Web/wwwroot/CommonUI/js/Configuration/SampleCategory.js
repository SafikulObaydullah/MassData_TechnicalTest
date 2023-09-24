
var SampleCategoryList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
    SampleCategoryLoad();

});

function SampleCategoryLoad() {

    $.ajax({
        url: "/SampleCategory/GetSampleCategory",
        method: "GET",
        dataType: "json",
        success: function (data) {
            SampleCategoryList = data;
            SampleCategoryDataBind(SampleCategoryList);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function SampleCategoryDataBind(data) {
    var i = 1;
    _.map(SampleCategoryList, function (o) {
        o.sl = i;
        i++;
    });
    // centerGridHeaders();
    $("#gridTable").kendoGrid({
        dataSource: data,
        sortable: true,
        toolbar: ["search"],
        search: {
            fields: ["categoryName"]
        },
     
        pageable: {
            pageSize: 15,
            pageSizes: [15, 30, 50, "all"],
            numeric: false
        },
        columns: [
            {
                title: "SL No",
                field: "sl", width: 5,
                attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
              
            },

            {
                title: "Sample Category",
                field: "categoryName", width: 40,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            },

            {
                title: "Action",
                template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 10,
               attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }

            },
        ],
       
    });
  
}

function Save() {
    var o = new Object();
    var validate = true;
    validate = Validate();
    if (validate == true) {
        o.id = $('#spanParentID').html();
        o.categoryName = $('#categoryName').val();
        o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
            url: "/SampleCategory/SampleCategorySave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    SampleCategoryLoad();
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
    var FilterData = _.filter(SampleCategoryList, function (item) { return item.id == id });
    $('#categoryName').val(FilterData[0].categoryName);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
    $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Sample Category Information');
    $('#btnSave').text('Update');
    $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
    $('#staticBackdropLabel').text('Create New Sample Category');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#categoryName').val('');
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
    if ($('#categoryName').val() == "") {
        $('#categoryName').focus();
        toastr.warning('Please input sample category');
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
