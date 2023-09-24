
var CustomerList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
   CustomerLoad();
});

function CustomerLoad() {

   $.ajax({
      url: "/Customer/GetCustomer",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            CustomerList = data.data;
            CustomerDataBind(CustomerList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}
function CustomerDataBind(data) {
   var i = 1;
   _.map(CustomerList, function (o) {
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
            title: "SL No",
            field: "sl", width: 40,
            attributes: {
               style: "text-align: center;"
            },
            headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Customer Name",
            field: "name", width: 90,
            attributes: {
               style: "text-align: left;"
            },
            headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Contact Name",
            field: "contactPersonName", width: 90,
            attributes: {
               style: "text-align: left;"
            },
            headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
           }, 
         {
            title: "Contact Email",
            field: "contactEmail", width: 120,
            attributes: {
               style: "text-align: left;"
            },
            headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Contact Address",
            field: "contactAddress", width: 120,
            attributes: {style:"text-align: left;"}, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Contact Phone",
            field: "contactPhone", width: 120,
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
      o.contactPersonName = $('#ContactPersonName').val();
      o.contactEmail = $('#ContactEmail').val();
      o.contactAddress = $('#ContactAddress').val();
      o.contactPhone = $('#ContactPhone').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
      
      $.ajax({
         url: "/Customer/CustomerSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               CustomerLoad();
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
   var FilterData = _.filter(CustomerList, function (item) { return item.id == id });
   $('#name').val(FilterData[0].name);
   $('#ContactPersonName').val(FilterData[0].contactPersonName);
   $('#ContactEmail').val(FilterData[0].contactEmail);
   $('#ContactAddress').val(FilterData[0].contactAddress);
   $('#ContactPhone').val(FilterData[0].contactPhone);
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Customer Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#staticBackdropLabel').text('Create New Customer');
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#ContactPersonName').val('');
   $('#ContactEmail').val('');
   $('#ContactAddress').val('');
   $('#ContactPhone').val('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($('#name').val() == "") {
      $('#name').focus();
      toastr.warning('Please input Customer name');
      return false;
   }
   if ($('#ContactPersonName').val() == "") {
      $('#ContactPersonName').focus();
      toastr.warning('Please input ContactPersonName');
      return false;
   }
   if ($('#ContactEmail').val() == "") {
      $('#ContactEmail').focus();
      toastr.warning('Please input valid Contact Email');
      return false;
   }
   if ($('#ContactAddress').val() == "") {
      $('#ContactAddress').focus();
      toastr.warning('Please input ContactAddress');
      return false;
   }
   if ($('#ContactPhone').val() == "") {
      $('#ContactPhone').focus();
      toastr.warning('Please input Contact Phone');
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
