var MachineList = []
var AttributeList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);


$(document).ready(function () {
   MachineLoad();
   LoadInitalData();
   $("#cmbAttribute").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Machine Type'
   });
   $(function () {
      $("[data-role=combobox]").each(function () {
         var widget = $(this).getKendoComboBox();
         widget.input.on("focus", function () {
            widget.open();
         });
      });
   });
});
function LoadInitalData() {
   $.ajax({
      url: "/Machine/GetInitialData",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            AttributeList = data.attribute;
            $("#cmbAttribute").data('kendoComboBox').dataSource.data([]);
            $('#cmbAttribute').data('kendoComboBox').dataSource.data(AttributeList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });
}

function MachineLoad() {
  
    $.ajax({
        url: "/Machine/GetMachine",
        method: "GET",
       dataType: "json",
       success: function (data) {
          MachineList = data;
          MachineDataBind();
          /*LoadInitalData();*/
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function MachineDataBind() {
    var i = 1;
    _.map(MachineList, function (o) {
        o.sl = i;
        i++;
    });

    $("#gridTable").kendoGrid({
        dataSource: MachineList,
        sortable: true,
        toolbar: ["search"],
        search: {
           fields: ["attributeName","name","JawType"]
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
              headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" },
              attributes: { style: "text-align: center;" }
            },
           {
              title: "Machine Type",
              field: "attributeName", width: 50,
              attributes: {
                 style: "text-align: left;"
              },
              headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
            },
            {
                title: "Machine Name",
                field: "name", width: 90,
               headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

            },
            {
                title: "Jaw Type",
                field: "jawType", width: 90,
               attributes: { style: "text-align: left;" },
               headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#C2DFFF" }

           }, 
            {
                title: "Action",
               template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 20,
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
       o.jawType = $('#JawType').val();
        o.machineTypeAttributeID = $('#cmbAttribute').val();
        o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
           url: "/Machine/MachineSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    MachineLoad();
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
   var FilterData = _.filter(MachineList, function (item) { return item.id == id });
   $('#name').val(FilterData[0].name);
   $('#cmbAttribute').data('kendoComboBox').value(FilterData[0].machineTypeAttributeID);
   $('#JawType').val(FilterData[0].jawType);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Machine Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}
function AddNew() {
    $('#staticBackdropLabel').text('Create New Machine');
    $('#btnSave').removeClass('btn btn-ghost-info active w-10');
    $('#spanParentID').html(0);
    $('#name').val('');
    $('#JawType').val('');
    $('#cmbAttribute').data('kendoComboBox').value('');
    $('#mdlUserReg').modal('toggle');
    $('#btnSave').text('Save');
    $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}
function Validate() {
   if ($("#cmbAttribute").data('kendoComboBox').value() == "" || $("#cmbAttribute").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbAttribute").data('kendoComboBox').focus();
      $("#cmbAttribute").data('kendoComboBox').open();
      toastr.warning('Please input Machine Type', "Warning");
      return false;
   }
    if ($('#name').val() == "") {
        $('#name').focus();
       toastr.warning('Please input Machine Name');
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
