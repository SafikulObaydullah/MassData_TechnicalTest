
var TestStandardVsMachineList = []
var TestStandardList = []
var MachineList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
    TestStandardVsMachineLoad();
    $("#cmbTestStandard").kendoComboBox({
        dataTextField: "testStandardName",
        dataValueField: "testStandardID",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select test standard'
    });


    $("#cmbMachine").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select machine'
    });




});

function TestStandardVsMachineLoad() {

    $.ajax({
        url: "/TestStandardVsMachine/GetTestStandardVsMachine",
        method: "GET",
        dataType: "json",
        success: function (data) {
            TestStandardVsMachineList = data.testStandardVsMachineList;
            TestStandardList = data.testStandardList;
            MachineList = data.machineList;
            console.log("calll", TestStandardVsMachineList)
            console.log("calll 11", TestStandardList)
            console.log("calll 22", MachineList)
            $("#cmbTestStandard").data('kendoComboBox').dataSource.data([]);
            $('#cmbTestStandard').data('kendoComboBox').dataSource.data(TestStandardList);


            $("#cmbMachine").data('kendoComboBox').dataSource.data([]);
            $('#cmbMachine').data('kendoComboBox').dataSource.data(MachineList);
            TestStandardVsMachineDataBind(TestStandardVsMachineList);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function TestStandardVsMachineDataBind(data) {
    var i = 1;
    _.map(TestStandardVsMachineList, function (o) {
        o.sl = i;
        i++;
    });
    $("#gridTable").kendoGrid({
        dataSource: data,
        sortable: true,
        toolbar: ["search"],
        search: {
            fields: ["testStandardName", "machineName"]
        },
        pageable: {
            pageSize: 15,
            pageSizes: [15, 30, 50, "all"],
            numeric: false
        },
        columns: [
            {
                title: "SL No",
                field: "sl", width: 15 ,
              attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            },
            {
                title: "Test Standard Name",
                field: "testStandardName", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            },
            {
                title: "Machine Name",
                field: "machineName", width: 90,
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
    comboBox = $("#cmbTestStandard").data("kendoComboBox");
    comboBox = $("#cmbMachine").data("kendoComboBox");
    var o = new Object();
    var validate = true;
    validate = Validate();
    if (validate == true) {
        o.id = $('#spanParentID').html();
        o.testStandardID = $('#cmbTestStandard').data('kendoComboBox').value();
        o.machineID = $('#cmbMachine').data('kendoComboBox').value();
        o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
            url: "/TestStandardVsMachine/TestStandardVsMachineSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    TestStandardVsMachineLoad();
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
    var FilterData = _.filter(TestStandardVsMachineList, function (item) { return item.id == id });
    console.log(FilterData);
    $('#cmbTestStandard').data('kendoComboBox').value(FilterData[0].testStandardID);
    $('#cmbMachine').data('kendoComboBox').value(FilterData[0].machineID);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
    $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit TestStandard VS Machine Information');
    $('#btnSave').text('Update');
    $('#btnSave').addClass('btn btn-ghost-info active w-10');
}


function AddNew() {
   $('#staticBackdropLabel').text('Create New TestStandard Vs. Machine');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#mdlUserReg').modal('toggle');
    $('#cmbTestStandard').data('kendoComboBox').value('');
    $('#cmbMachine').data('kendoComboBox').value('');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
    if ($("#cmbTestStandard").data('kendoComboBox').value() == "" || $("#cmbTestStandard").data('kendoComboBox').selectedIndex == -1) {
       $('#cmbTestStandard').data('kendoComboBox').focus();
       $('#cmbTestStandard').data('kendoComboBox').open();
        toastr.warning('Please input Test standard Name.');
        return false;
    }
    if ($("#cmbMachine").data('kendoComboBox').value() == "" || $("#cmbMachine").data('kendoComboBox').selectedIndex == -1) {
         $('#cmbMachine').data('kendoComboBox').focus();
         $('#cmbMachine').data('kendoComboBox').open();
        toastr.warning('Please input Machine Name.');
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

