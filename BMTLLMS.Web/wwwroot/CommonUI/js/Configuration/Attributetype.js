
var AttributeTypeList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
   AttributeTypeLoad();
});

function AttributeTypeLoad() {

   $.ajax({
      url: "/AttributeType/GetAttributeType",
      method: "GET",
      dataType: "json",
      success: function (data) { 
         if (data.statusCode = "200") {
            AttributeTypeList = data.data;
            AttributeDataBind(AttributeTypeList);
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
   _.map(AttributeTypeList, function (o) {
      o.sl = i;
      i++;
   });
   $("#gridTable").kendoGrid({
      dataSource: data,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["attributeTypeName"]
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
            title: "AttributeType Name",
            field: "attributeTypeName", width: 90,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Action",
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:typeId#)'><span class='k-icon k-i-edit'></span></button>",
            field: "", width: 80,
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
      o.typeId = $('#spanParentID').html();
      o.attributeTypeName = $('#name').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
      
      $.ajax({
         url: "/AttributeType/AttributeTypeSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               AttributeTypeLoad();
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
   var FilterData = _.filter(AttributeTypeList, function (item) { return item.typeId == id });
   $('#name').val(FilterData[0].attributeTypeName);
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit AttributeType Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#staticBackdropLabel').text('Create New Attribute Type');
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($('#name').val() == "") {
      $('#name').focus();
      toastr.warning('Please input Attribute Type name',"Warning");
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
