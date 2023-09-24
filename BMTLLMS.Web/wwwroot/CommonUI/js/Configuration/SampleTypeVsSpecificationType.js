
var SampleTypeVsSpecificationTypeList = []
var SampleTypeList = []
var SpecificationHeadList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
    SampleTypeVsSpecificationTypeLoad();
    $("#cmbSampleType").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select sample'
    });


    $("#cmbSpecificationHead").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select specification head'
    });




});

function SampleTypeVsSpecificationTypeLoad() {

    $.ajax({
        url: "/SampleTypeVsSpecificationType/GetSampleTypeVsSpecificationType",
        method: "GET",
        dataType: "json",
        success: function (data) {
            SampleTypeVsSpecificationTypeList = data.smapleTypeVsSpecificationTypeList;
            SampleTypeList = data.sampleTypeList;
            SpecificationHeadList = data.specificationHeadList;
            //console.log("calll", SampleTypeVsSpecificationTypeList)
            console.log("calll", SampleTypeList)
            console.log("calll 22", SpecificationHeadList)
            $("#cmbSampleType").data('kendoComboBox').dataSource.data([]);
            $('#cmbSampleType').data('kendoComboBox').dataSource.data(SampleTypeList);


            $("#cmbSpecificationHead").data('kendoComboBox').dataSource.data([]);
            $('#cmbSpecificationHead').data('kendoComboBox').dataSource.data(SpecificationHeadList);
            SampleTypeVsSpecificationTypeDataBind(SampleTypeVsSpecificationTypeList);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function SampleTypeVsSpecificationTypeDataBind(data) {
    var i = 1;
    _.map(SampleTypeVsSpecificationTypeList, function (o) {
        o.sl = i;
        i++;
    });
    $("#gridTable").kendoGrid({
        dataSource: data,
        sortable: true,
        toolbar: ["search"],
        search: {
            fields: ["sampleTypeName", "specificationHeadName"]
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
                title: "Sample Type",
                field: "sampleTypeName", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            },
            {
                title: "Specification Head",
                field: "specificationHeadName", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            }, 
            {
                title: "Action",
                template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 20,
               attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            }
        ]
    });
}

function Save() {
    comboBox = $("#cmbSampleType").data("kendoComboBox");
    comboBox = $("#cmbSpecificationHead").data("kendoComboBox");
    var o = new Object();
    var validate = true;
    validate = Validate();
    if (validate == true) {
        o.id = $('#spanParentID').html();
        o.sampleTypeID = $('#cmbSampleType').data('kendoComboBox').value();
        o.specificationHeadID = $('#cmbSpecificationHead').data('kendoComboBox').value();
        o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
            url: "/SampleTypeVsSpecificationType/SampleTypeVsSpecificationTypeSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    SampleTypeVsSpecificationTypeLoad();
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
    var FilterData = _.filter(SampleTypeVsSpecificationTypeList, function (item) { return item.id == id });
    $('#cmbSampleType').data('kendoComboBox').value(FilterData[0].sampleTypeID);
    $('#cmbSpecificationHead').data('kendoComboBox').value(FilterData[0].specificationHeadID);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
    $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Sample Type VS Specification Type Information');
    $('#btnSave').text('Update');
    $('#btnSave').addClass('btn btn-ghost-info active w-10');
}


function AddNew() {
   $('#staticBackdropLabel').text('Sample Type Vs. Specification Type');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
    if ($("#cmbSampleType").data('kendoComboBox').value() == "" || $("#cmbSampleType").data('kendoComboBox').selectedIndex == -1) {
       $('#cmbSampleType').data('kendoComboBox').focus();
       $('#cmbSampleType').data('kendoComboBox').open();
       toastr.warning('Please input sample type', "Warning");
        return false;
    }
    if ($("#cmbSpecificationHead").data('kendoComboBox').value() == "" || $("#cmbSpecificationHead").data('kendoComboBox').selectedIndex == -1) {
       $('#cmbSpecificationHead').data('kendoComboBox').focus();
       $('#cmbSpecificationHead').data('kendoComboBox').open();
       toastr.warning('Please input head specification', "Warning");
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
