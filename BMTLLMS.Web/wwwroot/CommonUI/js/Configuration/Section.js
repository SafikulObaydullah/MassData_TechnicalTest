
var SectionList = []
var CompanyList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
    SectionLoad();
    $("#cmbCompany").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select company'
    });

});

function SectionLoad() {

    $.ajax({
        url: "/Section/GetSection",
        method: "GET",
        dataType: "json",
        success: function (data) {

            SectionList = data.sectionList;
            CompanyList = data.companyList;
            $("#cmbCompany").data('kendoComboBox').dataSource.data([]);
            $('#cmbCompany').data('kendoComboBox').dataSource.data(CompanyList);
            SectionDataBind(SectionList);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function SectionDataBind(data) {
    var i = 1;
    _.map(SectionList, function (o) {
        o.sl = i;
        i++;
    });
    $("#gridTable").kendoGrid({
        dataSource: data,
        sortable: true,
        toolbar: ["search"],
        search: {
           fields: ["companyName","name"]
        },
        pageable: {
            pageSize: 15,
            pageSizes: [15, 30, 50, "all"],
            numeric: false
        },
        columns: [
            {
                title: "SL No",
                field: "sl", width: 20,
              attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            },
            {
              title: "Compnay Name",
              field: "companyName", width: 90,
              attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Section Name",
                field: "name", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            }, 
            {
                title: "Action",
                template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 15,
               attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            },
        ]
    });
}

function Save() {
    comboBox = $("#cmbCompany").data("kendoComboBox");
    var o = new Object();
    var validate = true;
    validate = Validate();
    if (validate == true) {
        o.id = $('#spanParentID').html();
        o.name = $('#name').val();
        o.companyID = $('#cmbCompany').data('kendoComboBox').value();
        o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
            url: "/Section/SectionSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    SectionLoad();
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
    console.log(SectionList);
    var FilterData = _.filter(SectionList, function (item) { return item.id == id });
    $('#name').val(FilterData[0].name);
    $('#cmbCompany').data('kendoComboBox').value(FilterData[0].companyID);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
    $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Section Information');
    $('#btnSave').text('Update');
    $('#btnSave').addClass('btn btn-ghost-info active w-10');
} 
function AddNew() {
   $('#staticBackdropLabel').text('Create New Section');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#name').val('');
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($("#cmbCompany").data('kendoComboBox').value() == "" || $("#cmbCompany").data('kendoComboBox').selectedIndex == -1) {
      $('#cmbCompany').data('kendoComboBox').focus();
      $('#cmbCompany').data('kendoComboBox').open();
      toastr.warning('Please input Company Name', "Warning");
      return false;
   }
    if ($('#name').val() == "") {
        $('#name').focus();
       toastr.warning('Please input Section Name', "Warning");
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
