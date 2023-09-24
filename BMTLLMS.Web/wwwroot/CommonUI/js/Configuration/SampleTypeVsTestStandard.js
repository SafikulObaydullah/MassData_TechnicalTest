
var SampleTypeVsTestStandardList = []
var SampleTypeList = []
var TestStandardList = []
//$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
    SampleTypeVsTestStandardLoad();
    $("#cmbSampleType").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select sample'
    });

    $("#cmbTestStandard").kendoComboBox({
        dataTextField: "testStandardName",
        dataValueField: "testStandardID",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select test standard'
    });




});

function SampleTypeVsTestStandardLoad() {

    $.ajax({
        url: "/SampleTypeVsTestStandard/GetSampleTypeVsTestStandard",
        method: "GET",
        dataType: "json",
        success: function (data) {
            SampleTypeVsTestStandardList = data.sampleTypeVsTestStandardList;
            SampleTypeList = data.sampleTypeList; 
            TestStandardList = data.testStandardList;
            console.log("calll", SampleTypeVsTestStandardList)
            console.log("calll 22", SampleTypeList)
            console.log("calll 33", TestStandardList)
            $("#cmbSampleType").data('kendoComboBox').dataSource.data([]);
            $('#cmbSampleType').data('kendoComboBox').dataSource.data(SampleTypeList);


            $("#cmbTestStandard").data('kendoComboBox').dataSource.data([]);
            $('#cmbTestStandard').data('kendoComboBox').dataSource.data(TestStandardList);
            SampleTypeVsTestStandardDataBind(SampleTypeVsTestStandardList);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function SampleTypeVsTestStandardDataBind(data) {
    var i = 1;
    _.map(SampleTypeVsTestStandardList, function (o) {
        o.sl = i;
        i++;
    });
    $("#gridTable").kendoGrid({
        dataSource: data,
        sortable: true,
        toolbar: ["search"],
        search: {
           fields: ["sampleTypeName", "testStandardName"]
        },
        pageable: {
            pageSize: 15,
            pageSizes: [15, 30, 50, "all"],
            numeric: false
        },
        columns: [
            {
                title: "SL. No.",
                field: "sl", width: 30,
              attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            },
            {
                title: "Sample Name",
                field: "sampleTypeName", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            },
            {
                title: "Test Standard Name",
                field: "testStandardName", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Number of Sample Piece",
                field: "reqNumberOfSamplePcs", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Quantity Per Sample",
                field: "qtyPerSample", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            },
            {
                title: "Req Sample Description",
                field: "reqSampleDescription", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            }, 
            {
                title: "Action",
                template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 30,
               attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            }
        ]
    });
}

function Save() {
    comboBox = $("#cmbSampleType").data("kendoComboBox");
    comboBox = $("#cmbTestStandard").data("kendoComboBox");
    var o = new Object();
    var validate = true;
    validate = Validate();
    if (validate == true) {
        o.id = $('#spanParentID').html();
        o.sampleTypeID = $('#cmbSampleType').data('kendoComboBox').value();
        o.testStandardID = $('#cmbTestStandard').data('kendoComboBox').value();
        o.reqNumberOfSamplePcs = $('#reqNumberOfSamplePcs').val();
        o.qtyPerSample = $('#qtyPreSample').val();
        o.reqSampleDescription = $('#reqSampleDescription').val();
        o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
            url: "/SampleTypeVsTestStandard/SampleTypeVsTestStandardSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    SampleTypeVsTestStandardLoad();
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
    var FilterData = _.filter(SampleTypeVsTestStandardList, function (item) { return item.id == id });
    console.log("jj", FilterData);
    $('#cmbSampleType').data('kendoComboBox').value(FilterData[0].sampleTypeID);
    $('#cmbTestStandard').data('kendoComboBox').value(FilterData[0].testStandardID);
    $('#reqNumberOfSamplePcs').val(FilterData[0].reqNumberOfSamplePcs);
    $('#qtyPreSample').val(FilterData[0].qtyPerSample);
    $('#reqSampleDescription').val(FilterData[0].reqSampleDescription);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
    $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Sample Type VS TestStanard Information');
    $('#btnSave').text('Update');
    $('#btnSave').addClass('btn btn-ghost-info active w-10');
} 
function AddNew() {
   $('#staticBackdropLabel').text('Create New Sample Type Vs. Test Standard');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#cmbSampleType').data('kendoComboBox').value('');
    $('#cmbTestStandard').data('kendoComboBox').value('');
    $('#reqNumberOfSamplePcs').val('');
    $('#qtyPreSample').val('');
    $('#reqSampleDescription').val('');
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
    if ($("#cmbSampleType").data('kendoComboBox').value() == "" || $("#cmbSampleType").data('kendoComboBox').selectedIndex == -1) {
        $("#cmbSampleType").data('kendoComboBox').focus();
        $("#cmbSampleType").data('kendoComboBox').open();
        toastr.warning('Please input sample type', "Warning");
        return false;
    }
    if ($("#cmbTestStandard").data('kendoComboBox').value() == "" || $("#cmbTestStandard").data('kendoComboBox').selectedIndex == -1) {
       $("#cmbTestStandard").data('kendoComboBox').focus();
       $("#cmbTestStandard").data('kendoComboBox').open();
       toastr.warning('Please input head specification', "Warning");
        return false;
    }

    if ($('#reqNumberOfSamplePcs').val() == "") {
        $('#reqNumberOfSamplePcs').focus();
        toastr.warning('Please input Req. Number of Sample Pcs!!', "Warning");
        return false;
    }
    if ($('#qtyPreSample').val() == "") {
        $('#qtyPreSample').focus();
       toastr.warning('Please input quantity per sample!!', "Warning");
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
