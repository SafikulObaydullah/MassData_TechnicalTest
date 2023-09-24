
var TestStandardList = []
var TestNameList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
   TestStandardLoad();
   TestNameLoad();
   $("#cmbTestName").kendoComboBox({
      dataTextField: "testName",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Test Name'
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
function TestNameLoad() {
   $.ajax({
      url: "/Test/GetTest",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            TestNameList = data.data; 
            $("#cmbTestName").data('kendoComboBox').dataSource.data([]);
            $('#cmbTestName').data('kendoComboBox').dataSource.data(TestNameList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}

function TestStandardLoad() {

   $.ajax({
      url: "/TestStandard/GetTestStandard",
      method: "GET",
      dataType: "json",
      success: function (data) { 
         if (data.statusCode = "200") {
            TestStandardList = data.data;
            $("#cmbTestName").data('kendoComboBox').dataSource.data([]);
            $('#cmbTestName').data('kendoComboBox').dataSource.data(TestStandardList);
            TestStandardDataBind(TestStandardList);
            TestNameLoad();
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}

function TestStandardDataBind(data) {
   var i = 1;
   _.map(TestStandardList, function (o) {
      o.sl = i;
      i++;
   });
   $("#gridTable").kendoGrid({
      dataSource: data,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["testName","testStandardName"]
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
            attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Test Name",
            field: "testName", width: 90,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Test Standard Name",
            field: "testStandardName", width: 90,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         }, 
         {
            title: "Action",
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:testStandardID#)'><span class='k-icon k-i-edit'></span></button>",
            field: "", width: 20,
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
      o.testStandardID = $('#spanParentID').html();
      o.testStandardName = $('#name').val();
      o.testNameID = $('#cmbTestName').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
      
      $.ajax({
         url: "/TestStandard/TestStandardSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               TestStandardLoad();
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
   var FilterData = _.filter(TestStandardList, function (item) { return item.testStandardID == id });
   $('#name').val(FilterData[0].testStandardName);
   $('#cmbTestName').data('kendoComboBox').value(FilterData[0].testNameID);
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit TestStandard Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#staticBackdropLabel').text('Create New TestStandard');
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#cmbTestName').data('kendoComboBox').value('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($("#cmbTestName").data('kendoComboBox').value() == "" || $("#cmbTestName").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbTestName").data('kendoComboBox').focus();
      $("#cmbTestName").data('kendoComboBox').open();
      toastr.warning('Please input Test Name', "Warning");
      return false;
   }
   if ($('#name').val() == "") {
      $('#name').focus();
      toastr.warning('Please input Test Standard Name',"Warning");
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
