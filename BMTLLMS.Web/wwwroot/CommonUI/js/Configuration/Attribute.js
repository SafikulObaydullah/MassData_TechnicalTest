
var AttributeList = []
var AttributeTypeList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
   AttributeLoad();
   AttributeTypeLoad();
   $("#cmbAttributeType").kendoComboBox({
      dataTextField: "attributeTypeName",
      dataValueField: "typeId",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Group Name'
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
function AttributeTypeLoad() {
   $.ajax({
      url: "/AttributeType/GetAttributeType",
      method: "GET",
      dataType: "json",
      success: function (data) { 
         if (data.statusCode = "200") {
            AttributeTypeList = data.data; 
            $("#cmbAttributeType").data('kendoComboBox').dataSource.data([]);
            $('#cmbAttributeType').data('kendoComboBox').dataSource.data(AttributeTypeList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}

function AttributeLoad() {
   $.ajax({
      url: "/Attribute/GetAttribute",
      method: "GET",
      dataType: "json",
      success: function (data) { 
         if (data.statusCode = "200") {
            AttributeList = data.data;
            $("#cmbAttributeType").data('kendoComboBox').dataSource.data([]);
            $('#cmbAttributeType').data('kendoComboBox').dataSource.data(AttributeList);
            AttributeDataBind(AttributeList);
            AttributeTypeLoad();
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}

function AttributeDataBind(data) {
   var i = 1;
   _.map(AttributeList, function (o) {
      o.sl = i;
      i++;
   });
   $("#gridTable").kendoGrid({
      dataSource: data,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["name", "typeName"]
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
            headerAttributes: {
               style: "text-align: center;font-weight: bold;background-color:#C2DFFF"
            },
            attributes: { style: "text-align: center;" }
         }, 
         {
            title: "Group Name",
            field: "typeName", width: 90,
            attributes: {
               style: "text-align: left;"
            },
            headerAttributes: {
               style: "text-align: left;font-weight: bold;background-color:#C2DFFF"
            }
         },
         {
            title: "Attribute Name",
            field: "name", width: 90,
            attributes: {
               style: "text-align: left;"
            },
            headerAttributes: {
               style: "text-align: left;font-weight: bold;background-color:#C2DFFF"
            }
         },
         {
            title: "Action",
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
            field: "", width: 20,
            headerAttributes: {
               style: "text-align: center;font-weight: bold;background-color:#C2DFFF"
            },
            attributes: {
               style: "text-align: center;"
            }
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
      o.attributeTypeID = $('#cmbAttributeType').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
      
      $.ajax({
         url: "/Attribute/AttributeSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               AttributeLoad();
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
   var FilterData = _.filter(AttributeList, function (item) { return item.id == id });
   $('#name').val(FilterData[0].name);
   $('#cmbAttributeType').data('kendoComboBox').value(FilterData[0].attributeTypeID);
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Attribute Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#staticBackdropLabel').text('Create New Attribute');
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#cmbAttributeType').data('kendoComboBox').value('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($("#cmbAttributeType").data('kendoComboBox').value() == "" || $("#cmbAttributeType").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbAttributeType").data('kendoComboBox').focus();
      $("#cmbAttributeType").data('kendoComboBox').open();
      toastr.warning('Please input Group Name', "Warning");
      return false;
   }
   if ($('#name').val() == "") {
      $('#name').focus();
      toastr.warning('Please input Attribute name',"Warning");
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

