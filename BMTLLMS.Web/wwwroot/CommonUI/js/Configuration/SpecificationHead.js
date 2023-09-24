
var SpecificationHeadList = []
var MeasurementUnitList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
    SpecificationHeadLoad();
    $("#cmbMeasurement").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select measurement unit'
    });
});

function SpecificationHeadLoad() {

    $.ajax({
        url: "/SpecificationHead/GetSpecificationHead",
        method: "GET",
        dataType: "json",
        success: function (data) {

            SpecificationHeadList = data.headSpecification;
            MeasurementUnitList = data.measurementList;
            $("#cmbMeasurement").data('kendoComboBox').dataSource.data([]);
            $('#cmbMeasurement').data('kendoComboBox').dataSource.data(MeasurementUnitList);
            SpecificationHeadDataBind(SpecificationHeadList);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function SpecificationHeadDataBind(data) {
    var i = 1;
    _.map(SpecificationHeadList, function (o) {
        o.sl = i;
        i++;
    });
    $("#gridTable").kendoGrid({
        dataSource: data,
        sortable: true,
        toolbar: ["search"],
        search: {
           fields: ["name", "measurementUnitName"]
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
              title: "Measurement Unit",
              field: "measurementUnitName", width: 90,
              attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Head Specification Name",
                field: "name", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            }, 
            {
                title: "Action",
                template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 15,
               attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            }
        ]
    });
}

function Save() {
    comboBox = $("#cmbMeasurement").data("kendoComboBox");
    var o = new Object();
    var validate = true;
    validate = Validate();
    if (validate == true) {
        o.id = $('#spanParentID').html();
        o.name = $('#name').val();
        o.measurementUnitID = $('#cmbMeasurement').data('kendoComboBox').value();
        o.isActive = $('#isActive').is(':checked') ? true : false;

        $.ajax({
            url: "/SpecificationHead/SpecificationHeadSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    SpecificationHeadLoad();
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
    var FilterData = _.filter(SpecificationHeadList, function (item) { return item.id == id });
    $('#name').val(FilterData[0].name);
    $('#cmbMeasurement').data('kendoComboBox').value(FilterData[0].measurementUnitID);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Edit Specification Head Information');
    $('#btnSave').text('Upadate');
    $('#btnSave').addClass('btn btn-ghost-info active w-10');
}
function AddNew() {
   $('#staticBackdropLabel').text('Create New Specification Head');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#name').val('');
    $('#cmbMeasurement').data('kendoComboBox').value('');
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
    if ($("#cmbMeasurement").data('kendoComboBox').value() == "" || $("#cmbMeasurement").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbMeasurement").data('kendoComboBox').focus();
      $("#cmbMeasurement").data('kendoComboBox').open();
      toastr.warning('Please input Measurement Unit Name', "Warning");
      return false;
    }
    if ($('#name').val() == "") {
        $('#name').focus();
       toastr.warning('Please input Head Specification Name', "Warning");
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
