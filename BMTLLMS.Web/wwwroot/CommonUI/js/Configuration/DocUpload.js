var DocUploadList = []
var AttributeList = []
var SampleTypeList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
   DocUploadLoad();
   AttributeLoad();
   SampleTypeLoad();
   $("#cmbAttribute").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Attribute Name'
   });
   $("#cmbSampleType").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select SampleType Name'
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
function SampleTypeLoad() {
   $.ajax({
      url: "/SampleType/GetSampleType",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            SampleTypeList = data;
            $("#cmbSampleType").data('kendoComboBox').dataSource.data([]);
            $('#cmbSampleType').data('kendoComboBox').dataSource.data(SampleTypeList);
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
         console.log(AttributeList);
         if (data.statusCode = "200") {
            AttributeList = data.data;
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

function DocUploadLoad() {

   $.ajax({
      url: "/DocUpload/GetDocUPload",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            DocUploadList = data.data;
            $("#cmbAttribute").data('kendoComboBox').dataSource.data([]);
            $('#cmbAttribute').data('kendoComboBox').dataSource.data(DocUploadList);
            $("#cmbSampleType").data('kendoComboBox').dataSource.data([]);
            $('#cmbSampleType').data('kendoComboBox').dataSource.data(DocUploadList);
            DocUploadDataBind(DocUploadList);
            AttributeLoad();
            SampleTypeLoad();
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}

function DocUploadDataBind(data) {
   var i = 1;
   _.map(DocUploadList, function (o) {
      o.sl = i;
      i++;
   });
   $("#gridTable").kendoGrid({
      dataSource: data,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["docName","attributeName"]
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
            title: "Attribute Name",
            field: "attributeName", width: 80,
            attributes: {style:"text-align: left;"}, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "SampleType Name",
            field: "sampleTypeName", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "DocName",
            field: "docName", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "DocExtension",
            field: "docExtension", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "FileName",
            field: "fileName",
            width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Action",
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
            field: "", width: 20,
            attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
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
      o.transactionTypeAttributeID = $('#cmbAttribute').val();
      o.transactionID = $('#cmbSampleType').val();
      o.docName = $('#DocName').val();
      o.docExtension = $('#DocExtension').val();
      o.fileName = $('#FileName').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
      $.ajax({
         url: "/DocUpload/DocUploadSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               DocUploadLoad();
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
   console.log(DocUploadList);
   $('#spanParentID').html(id);
   var FilterData = _.filter(DocUploadList, function (item) { return item.id == id });
   $('#cmbAttribute').data('kendoComboBox').value(FilterData[0].transactionTypeAttributeID);
   $('#cmbSampleType').data('kendoComboBox').value(FilterData[0].transactionID);
   $('#DocName').val(FilterData[0].docName);
   $('#DocExtension').val(FilterData[0].docExtension);
   $('#FileName').val(FilterData[0].fileName);
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#DocName').val('');
   $('#DocExtension').val('');
   $('#FileName').val('');
   $("#cmbAttribute").data('kendoComboBox').value('');
   $("#cmbSampleType").data('kendoComboBox').value('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($("#cmbAttribute").data('kendoComboBox').value() == "" || $("#cmbAttribute").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbAttribute").data('kendoComboBox').focus();
      $("#cmbAttribute").data('kendoComboBox').open();
      toastr.warning('Please input Attribute Name', "Warning");
      return false;
   }
   if ($("#cmbSampleType").data('kendoComboBox').value() == "" || $("#cmbSampleType").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbSampleType").data('kendoComboBox').focus();
      $("#cmbSampleType").data('kendoComboBox').open();
      toastr.warning('Please input SampleType Name', "Warning");
      return false;
   }
   if ($('#DocName').val() == "") {
      $('#DocName').focus();
      toastr.warning('Please input Document Name', "Warning");
      return false;
   }
   if ($('#DocExtension').val() == "") {
      $('#DocExtension').focus();
      toastr.warning('Please input Document Extension', "Warning");
      return false;
   }
   if ($('#FileName').val() == "") {
      $('#FileName').focus();
      toastr.warning('Please input FileName', "Warning");
      return false;
   }

   return true;
}