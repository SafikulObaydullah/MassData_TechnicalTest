
var SampleTypeList = []
var SampleCategoryList = []

$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

$(document).ready(function () {
   $("#ddlSampleCategory").kendoComboBox({
      dataTextField: "categoryName",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Sample Category Name'
   });
   SampleTypeLoad();
   LoadInitalData();
});

function LoadInitalData() {
   $.ajax({
      url: "/SampleType/GetInitialData",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            SampleCategoryList = data.sampleCategory;
            $("#ddlSampleCategory").data('kendoComboBox').dataSource.data([]);
            $('#ddlSampleCategory').data('kendoComboBox').dataSource.data(SampleCategoryList); 
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });
}

function SampleTypeLoad() {
    $.ajax({
        url: "/SampleType/GetSampleType",
        method: "GET",
        dataType: "json",
        success: function (data) {
            SampleTypeList = data;
            SampleTypeDataBind(SampleTypeList);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}

function SampleTypeDataBind(data) {

    var i = 1;
    _.map(SampleTypeList, function (o) {
        o.sl = i;
        i++;
    });
    $("#gridTable").kendoGrid({
        dataSource: data,
        sortable: true,
        toolbar: ["search"],
        search: {
           fields: ["categoryName","name"]
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
                width: 20,
              attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
           },
           {
              title: "Sample Category Name",
              field: "categoryName", width: 50,
              attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
           },
            {
                title: "Sample Name",
               field: "name", width: 50,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
           }, 
            {
                title: "Description",
               field: "description", width: 90,
               attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Action",
                template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 25,
               attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
            }
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
        o.sampleCategoryID = $('#ddlSampleCategory').val();
        o.description = $('#Description').val();
        o.isActive = $('#isActive').is(':checked') ? true : false;

        $.ajax({
            url: "/SampleType/SampleTypeSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    SampleTypeLoad();
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
    var FilterData = _.filter(SampleTypeList, function (item) { return item.id == id });
    $('#name').val(FilterData[0].name);
    $('#Description').val(FilterData[0].description);
    $('#ddlSampleCategory').data('kendoComboBox').value(FilterData[0].sampleCategoryID);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
    $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Sample Type Information');
    $('#btnSave').text('Update');
    $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#staticBackdropLabel').text('Create New Sample Type');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#name').val('');
    $('#ddlSampleCategory').data('kendoComboBox').value('');
    $('#Description').val('');
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($("#ddlSampleCategory").data('kendoComboBox').value() == "" || $("#ddlSampleCategory").data('kendoComboBox').selectedIndex == -1) {
      $("#ddlSampleCategory").data('kendoComboBox').focus();
      $("#ddlSampleCategory").data('kendoComboBox').open();
      toastr.warning('Please input Category Name', "Warning");
      return false;
   }
    if ($('#name').val() == "") {
        $('#name').focus();
        toastr.warning('Please input name');
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

