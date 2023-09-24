
var MeasurementUnitList = []

$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

$(document).ready(function () {
   MeasurementUnitLoad();
});

function MeasurementUnitLoad() {

   $.ajax({
      url: "/MeasurementUnit/GetMeasurementUnit",
      method: "GET",
      dataType: "json",
      success: function (data) {
         console.log(MeasurementUnitList);
         if (data.statusCode = "200") {
            MeasurementUnitList = data.data;
            MeasurementUnitDataBind(MeasurementUnitList);

         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}

function MeasurementUnitDataBind(data) {
    var i = 1;
    _.map(MeasurementUnitList, function (o) {
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
               width: 20,
             attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
           }
         ,

         {
            title: "Measurement Name",
            field: "name", width: 90,
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
      o.name = $('#name').val();
      o.description = $('#Description').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
      
      $.ajax({
         url: "/MeasurementUnit/MeasurementUnitSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               MeasurementUnitLoad();
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
   var FilterData = _.filter(MeasurementUnitList, function (item) { return item.id == id });
   $('#name').val(FilterData[0].name);
   $('#Description').val(FilterData[0].description);
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Measurement Unit Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#staticBackdropLabel').text('Create New Measuremnet Unit');
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#Description').val('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($('#name').val() == "") {
      $('#name').focus();
      toastr.warning('Please input Measurement Unit name');
      return false;
   } 
   return true;
}

function checkEmptyInput(inputElement) {
    if (inputElement.value.trim() === "") {
        inputElement.style.border = "1px solid red";
    } else {
        inputElement.style.border = "1px solid #ced4da"; 
    }
}
