
var CalibrationFrequencyList = []
var MachineList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
    CalibrationFrequencyLoad();
    $("#cmbMachine").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select machine'
    });


    $("#cmbMeasurementUnit").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select measurement unit'
    });
   $(".Kdatepicker").bind("focus", function () {
      $(this).data("kendoDatePicker").open();
   });
    $("#effectiveDate").kendoDatePicker();



});

function CalibrationFrequencyLoad() {

    $.ajax({
        url: "/CalibrationFrequency/GetCalibrationFrequency",
        method: "GET",
        dataType: "json",
        success: function (data) {
            CalibrationFrequencyList = data.calibrationFrequencyList;
            MachineList = data.machineLiast;
            MeasurementUnitList = data.measurementUnitList;
            console.log("calll", CalibrationFrequencyList)
            console.log("calll", MachineList)
            $("#cmbMachine").data('kendoComboBox').dataSource.data([]);
            $('#cmbMachine').data('kendoComboBox').dataSource.data(MachineList);


            $("#cmbMeasurementUnit").data('kendoComboBox').dataSource.data([]);
            $('#cmbMeasurementUnit').data('kendoComboBox').dataSource.data(MeasurementUnitList);
            CalibrationFrequencyDataBind(CalibrationFrequencyList);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function CalibrationFrequencyDataBind(data) {
    var i = 1;
    _.map(CalibrationFrequencyList, function (o) {
        o.sl = i;
        i++;
    });
    $("#gridTable").kendoGrid({
        dataSource: data,
        sortable: true,
        toolbar: ["search"],
        search: {
           fields: ["machineName", "measurementUnitName"]
        },
        pageable: {
            pageSize: 15,
            pageSizes: [15, 30, 50, "all"],
            numeric: false
        },
        columns: [
            {
                title: "SL No",
                field: "sl", width: 30,
              attributes: {
                 style: "text-align: center;"
              },
              headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            },

            {
                title: "Machine",
                field: "machineName", width: 90,
               attributes: {
                  style: "text-align: left;"
               },
               headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            },
            
           {
              title: "Correction Factor",width:90,
              template: "#= correctionFactor + ' ' + measurementUnitName #",
              attributes: {
                 style: "text-align: left;"
              },
              headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
              
           },
            {
                field: "effectiveDate",
                title: "Effective Date",
                template: "#= effectiveDate ? kendo.toString(new Date(effectiveDate), 'MMM dd, yyyy') : '' #",
                width: 50,
                attributes: {
                  style: "text-align: left;"
                },
                headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
           }, 
            {
                title: "Calibration frequency In Days",
                field: "calibrationFrequencyInDays", width: 90,
                attributes: {
                    style: "text-align: left;"
               },
               headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Cal. Freq. Test Number",
                field: "calibrationFrequencyInTestNumber", width: 90,
                attributes: {
                    style: "text-align: left;"
               },
               headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Action",
                template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 30,
                attributes: {
                    style: "text-align: center;"
                },
               headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            },
        ]
    });
}

function Save() {
    comboBox = $("#cmbMachine").data("kendoComboBox");
    comboBox = $("#cmbMeasurementUnit").data("kendoComboBox");
    var o = new Object();
    var validate = true;
    validate = Validate();
    if (validate == true) {
        o.id = $('#spanParentID').html();
        o.machineID = $('#cmbMachine').data('kendoComboBox').value();
        o.correctionFactor = $('#correctionFactor').val();
        o.measurementUnitID = $('#cmbMeasurementUnit').data('kendoComboBox').value();
        o.effectiveDate = $('#effectiveDate').val();
        o.calibrationFrequencyInDays = $('#calibrationFrequencyInDays').val();
        o.calibrationFrequencyInTestNumber = $('#calibrationFrequencyInTestNumber').val();
        o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
            url: "/CalibrationFrequency/CalibrationFrequencySave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    CalibrationFrequencyLoad();
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
    var FilterData = _.filter(CalibrationFrequencyList, function (item) { return item.id == id });
    console.log("111", FilterData)
    $('#cmbMachine').data('kendoComboBox').value(FilterData[0].machineID);
    $('#correctionFactor').val(FilterData[0].correctionFactor);
    $('#cmbMeasurementUnit').data('kendoComboBox').value(FilterData[0].measurementUnitID);
    var formattedDate = FilterData[0].effectiveDate ? kendo.toString(kendo.parseDate(FilterData[0].effectiveDate), 'yyyy-MM-dd') : '';
    $('#effectiveDate').val(formattedDate);

    $('#calibrationFrequencyInDays').val(FilterData[0].calibrationFrequencyInDays);
    $('#calibrationFrequencyInTestNumber').val(FilterData[0].calibrationFrequencyInTestNumber);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Calibration Frequency Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}


function AddNew() {
   $('#staticBackdropLabel').text('Create New Calibration Frequency');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#correctionFactor').val('');
    $('#effectiveDate').val('');
    $('#calibrationFrequencyInDays').val('');
    $('#calibrationFrequencyInTestNumber').val('');
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-priamry active w-10');
}

function Validate() {
    if ($("#cmbMachine").data('kendoComboBox').value() == "" || $("#cmbMachine").data('kendoComboBox').selectedIndex == -1) {
       $('#cmbMachine').data('kendoComboBox').focus();
       $('#cmbMachine').data('kendoComboBox').open();
       toastr.warning('Please input machine', "Warning");
        return false;
    }
   if ($('#correctionFactor').val() == "") {
       $('#correctionFactor').css('border-color', 'red');
       $('#correctionFactor').focus(); 
       toastr.warning('Please input correction factor', "Warning");
        return false;
    } 

    if ($("#cmbMeasurementUnit").data('kendoComboBox').value() == "" || $("#cmbMeasurementUnit").data('kendoComboBox').selectedIndex == -1) {
       $('#cmbMeasurementUnit').data('kendoComboBox').focus();
       $('#cmbMeasurementUnit').data('kendoComboBox').open();
       toastr.warning('Please input measurement unit', "Warning");
        return false;
    }

   if ($('#calibrationFrequencyInDays').val() == "") {
        $('#calibrationFrequencyInDays').css('border-color', 'red');
        $('#calibrationFrequencyInDays').focus(); 
       toastr.warning('Please input calibration frequency in days', "Warning");
        return false;
   }
   if ($('#effectiveDate').val() == "") {
      $('#effectiveDate').css('border-color', 'red');
      $('#effectiveDate').focus(); 
      toastr.warning('Please input Effective Date', "Warning");
        return false;
    } 

   if ($('#calibrationFrequencyInTestNumber').val() == "") {
        $('#calibrationFrequencyInTestNumber').css('border-color', 'red');
        $('#calibrationFrequencyInTestNumber').focus(); 
        toastr.warning('Please input calibration frequency in test number',"Warning");
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
