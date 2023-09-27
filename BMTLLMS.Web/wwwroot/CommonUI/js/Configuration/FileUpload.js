
var FileUploadDataList = []
var UserName = "";
var UserTypeId = "";
//var UserId = "";
//var UserDesignation = "";
//var UserSectionId = "";
//var user = User.Claims.ToList();
//if (user.Count > 0) {
//   UserName = user[0].Value;
//   UserId = user[1].Value;
//   UserDesignation = user[2].Value;
//   UserTypeId = user[3].Value;
//   UserSectionId = user[4].Value;
//} 


$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () { 
   if (UserTypeId == 2) {
      $("#btnDelete").hide();
   }
   LoadInitialData();
});
function DeleteGlobalFileUrl(id) { 
   $.ajax({
      url: "/DocUpload/DeleteGlobalFileUrl?id=" + id,
      type: "POST",
      dataType: "json",
      data: {},
      success: function (data) {
         toastr.success(data.message, 'Deleted Successfully'); 
         LoadInitialData(); 
      }
   });
}
function LoadInitialData() {
   $.ajax({
      url: "/DocUpload/GetInitialData",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            FileUploadDataList = data.globalFileUrl;
            console.log(FileUploadDataList);
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
  
   var picdata = data;
   console.log(picdata);   
   var i = 1; 
   _.map(data, function (o) {
      o.sl = i;
      i++;
   });
   $("#gridTable").kendoGrid({
      dataSource: data,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["referrenceNo"]
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
            
            field: "documentName", title: "Image", template: '<img src="/Images/#=documentName#">',
            width: 100,
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
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button><button id='btnDelete' class='btn btn-ghost-info active w-10'  title='Delete' onclick='DeleteGlobalFileUrl(#:id#)'><span class='k-icon k-i-delete'></span></button>",
            field: "", width: 80,
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
   var obj = new Object();
      obj.id = $('#spanParentID').html(); 
      obj.referrenceNo = $('#txtReferrenceNo').val();
      obj.documentTypeId = $('#txtdocumentTypeId').val();
      obj.isActive = $('#isActive').is(':checked') ? true : false; 
      var fileUpload = $("#files").get(0);
      var files = fileUpload.files;
      var data = new FormData();
      for (var i = 0; i < files.length; i++) {
         data.append(files[i].name, files[i]); 
      } 
      $.ajax({
         type: "POST",
         url: "/DocUpload/UploadFilesAjax",
         contentType: false,
         processData: false,
         data: data, 
         success: function (data) {
            console.log("Data value = ",data);
            toastr.success(data.message, 'File Upload Successfully'); 
            $('#mdlUserReg').modal('hide')
            LoadInitialData();
         },
         error: function () {
            alert("There was error uploading files!");
         }
      });
}
//function Save() {
//   debugger;
//   var o = new Object();
//   //const ID = document.querySelector('#spanParentID');
//   //const fileInput = document.querySelector('#txtFile');
//   //const ReferrenceNo = document.querySelector('#txtReferrenceNo');
//   //const documentTypeId = document.querySelector('#txtdocumentTypeId');
//   //const isActive = document.querySelector('#isActive');

//   //const formData = new FormData();
//   ////formData.append('ID', ID.files[0]);
//   //formData.append('files', fileInput.files[0]);
//   //formData.append('ReferrenceNo', ReferrenceNo.files[0]);
//   //formData.append('documentTypeId', documentTypeId.files[0]);
//   //formData.append('isActive', isActive.files[0]);



//   var fileUpload = $("#txtFile").get(0);
//   var files = fileUpload.files;
//   var data = new FormData();
//   for (var i = 0; i < files.length; i++) {
//      data.append(files[i].files, files[i]);
//   }


//   var validate = true;
//   validate = Validate();
//   if (validate == true) {
//      //o.id = $('#spanParentID').html();
//      //o.files = $('#txtFile').val();
//      //o.referrenceNo = $('#txtReferrenceNo').val();
//      //o.documentTypeId = $('#txtdocumentTypeId').val();
//      //o.isActive = $('#isActive').is(':checked') ? true : false;

//      $.ajax({
//         url: "/DocUpload/UploadFile",
//         type: "POST",
//         dataType: "json",
//         processData: false,
//         contentType: false,
//         cache: false,
//         enctype: 'multipart/form-data',
//         async: false,
//         data: data,
//         success: function (data) {
//            if (data.code == 200) {
//               toastr.success(data.message, 'Success');
//               DocumentFileLoad();
//               $('#mdlUserReg').modal('hide')
//            } else {
//               toastr.warning(data.message, "Waring");
//            }
//         },
//         error: function (xhr, textStatus, errorThrown) {
//            toastr.error('Error Saving', 'Error');
//         }
//      });

//   }
//}
function Edit(id) {
 
   $('#spanParentID').html(id);
   var FilterData = _.filter(FileUploadDataList, function (item) { return item.id == id });
   //$('#files').val(FilterData[0].documentName);
   $('#txtReferrenceNo').val(FilterData[0].referrenceNo);
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

   if ($('#txtFile').val() == "") {
      $('#txtFile').focus();
      toastr.warning('Please input FileUpload Logo', 'Warning');
      return false;
   }
   if ($('#txtReference').val() == "") {
      $('#txtReference').focus();
      toastr.warning('Please input valid Reference');
      return false;
   }
   if ($('#txtdocumentTypeId').val() == "") {
      $('#txtdocumentTypeId').focus();
      toastr.warning('Please input documentTypeId');
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
