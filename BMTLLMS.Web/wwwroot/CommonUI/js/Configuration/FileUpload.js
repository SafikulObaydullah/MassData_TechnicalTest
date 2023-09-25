
var FileUploadDataList = []


$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {

   $("#txtFile").kendoUpload({
   }).data("kendoUpload");
   DocumentFileLoad();
});

function DocumentFileLoad(){

   $.ajax({
      url: "/DocUpload/GetFileUpload",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            FileUploadDataList = data.data;
            FileUploadDataBind(FileUploadDataList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}
function FileUploadDataBind(data) {
   var i = 1;
   _.map(FileUploadDataList, function (o) {
      o.sl = i;
      i++;
   });
   $("#gridTable").kendoGrid({
      dataSource: data,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["name"]
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
            width: 50,
            headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" },
            attributes: {
               style: "text-align: center;"
            }
         },
         {
            title: "File Name", 
            field: "file", width: 100,
            attributes: {
               style: "text-align: left;"
            },
            headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

         },
         {
            title: "ReferrenceNo",
            field: "referrenceNo",
            width: 150,
            attributes: {
               style: "text-align: left;"
            },
            headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "DocumentTypeId",
            field: "documentTypeId",
            width: 120,
            attributes: {
               style: "text-align: left;"
            },
            headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         }, 
         {
            title: "Action",
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
            field: "", width: 40,
            attributes: {
               style: "text-align: center;"
            },
            headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" },
         },
      ]
   });
}
var input = $('#name').val();
function validateNumber(input) {
   return /^\d+(\.\d+)?$/.test(input.value.trim());
}
function Save() {
   var o = new Object();
   var validate = true;
   validate = Validate();
   if (validate == true) {
      o.id = $('#spanParentID').html(); 
      o.file = $('#txtfile').val();
      o.referrenceNo = $('#txtReferrenceNo').val();
      o.documentTypeId = $('#txtdocumentTypeId').val(); 
      o.isActive = $('#isActive').is(':checked') ? true : false;

      $.ajax({
         url: "/DocUpload/UploadFile",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               DocumentFileLoad()();
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
   var FilterData = _.filter(FileUploadDataList, function (item) { return item.id == id });
   $('#txtfile').val(FilterData[0].file);
   $('#txtReferenceNo').val(FilterData[0].referrenceNo);
   $('#txtdocumentTypeId').val(FilterData[0].documentTypeId); 
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle')
   $('#staticBackdropLabel').text('Edit FileUpload Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#staticBackdropLabel').text('Create New FileUpload');
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#FileUploadLogo').val('');
   $('#websiteAddress').val('');
   $('#emailaddress').val('');
   $('#phoneNumber').val('');
   $('#physicalAddress').val('');
   $('#fax').val('');
   $('#locationLat').val('');
   $('#locationLng').val('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($('#name').val() == "") {
      $('#name').focus();
      toastr.warning('Please input FileUpload name');
      return false;
   }
   if ($('#FileUploadLogo').val() == "") {
      $('#FileUploadLogo').focus();
      toastr.warning('Please input FileUpload Logo', 'Warning');
      return false;
   }
   if ($('#websiteAddress').val() == "") {
      $('#websiteAddress').focus();
      toastr.warning('Please input valid Website Address');
      return false;
   }
   if ($('#emailaddress').val() == "") {
      $('#emailaddress').focus();
      toastr.warning('Please input Email Address');
      return false;
   }
   if ($('#phoneNumber').val() == "") {
      $('#phoneNumber').focus();
      toastr.warning('Please input Phone Number');
      return false;
   }
   if ($('#physicalAddress').val() == "") {
      $('#physicalAddress').focus();
      toastr.warning('Please input valid Physical Address');
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
