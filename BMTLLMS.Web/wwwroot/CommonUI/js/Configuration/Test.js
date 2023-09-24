
var TestList = []
var AttributeList = []
/*$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);*/
$(document).ready(function () {
   TestLoad();
   //AttributeLoad();
   LoadInitalData();
   $("#cmbAttribute").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
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
function LoadInitalData() {
   $.ajax({
      url: "/Test/GetInitialData",
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
//function AttributeLoad() {
//   $.ajax({
//      url: "/Attribute/GetAttribute",
//      method: "GET",
//      dataType: "json",
//      success: function (data) {
//         if (data.statusCode = "200") {
//            AttributeList = data.data;
//            $("#cmbAttribute").data('kendoComboBox').dataSource.data([]);
//            $('#cmbAttribute').data('kendoComboBox').dataSource.data(AttributeList);
//         }
//         else {

//         }
//      },
//      error: function (jqXHR, textStatus, errorThrown) {
//         console.log("Error:", textStatus, errorThrown);
//      }
//   });

//}

function TestLoad() {
   $.ajax({
      url: "/Test/GetTest",
      method: "GET",
      dataType: "json",
      success: function (data) {
         console.log(TestList);
         if (data.statusCode = "200") {
            TestList = data.data;
            $("#cmbAttribute").data('kendoComboBox').dataSource.data([]);
            $('#cmbAttribute').data('kendoComboBox').dataSource.data(TestList);
            TestDataBind(TestList);
            //AttributeLoad();
            LoadInitalData();
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}

function TestDataBind(data) {
   var i = 1;
   _.map(TestList, function (o) {
      o.sl = i;
      i++;
   });
   $("#gridTable").kendoGrid({
      dataSource: data,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["attributeName","testName"]
      },
      pageable: {
         pageSize: 15,
         pageSizes: [15, 30, 50, "all"],
         numeric: false
      },
      columns: [
         {
            title: "SL No",
            field: "sl", width: 3,
            attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Group Name",
            field: "attributeName", width: 20,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Test Name",
            field: "testName", width: 20,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Action",
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
            field: "", width: 3,
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
      o.testName = $('#name').val();
      o.testGroupAttributeID = $('#cmbAttribute').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
      $.ajax({
         url: "/Test/TestSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               TestLoad();
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
   var FilterData = _.filter(TestList, function (item) { return item.id == id });
   $('#name').val(FilterData[0].testName);
   $('#cmbAttribute').data('kendoComboBox').value(FilterData[0].testGroupAttributeID);
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Test Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}
function AddNew() {
   $('#staticBackdropLabel').text('Create New Test');
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#cmbAttribute').data('kendoComboBox').value('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($("#cmbAttribute").data('kendoComboBox').value() == "" || $("#cmbAttribute").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbAttribute").data('kendoComboBox').focus();
      $("#cmbAttribute").data('kendoComboBox').open();
      toastr.warning('Please input Group Name', "Warning");
      return false;
   }
   if ($('#name').val() == "") {
      $('#name').focus();
      toastr.warning('Please input Test name',"Warning");
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
