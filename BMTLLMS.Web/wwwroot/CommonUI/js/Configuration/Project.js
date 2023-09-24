
var ProjectList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
   ProjectLoad();
});

function ProjectLoad() {

   $.ajax({
      url: "/Project/GetProject",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            ProjectList = data.data;
            ProjectDataBind(ProjectList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}
function ProjectDataBind(data) {
   var i = 1;
   _.map(ProjectList, function (o) {
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
            field: "sl", width: 30,
            attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
         },

         {
            title: "Project Name",
            field: "name", width: 90,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

         },
         {
            title: "Contact Person",
            field: "contactPerson", width: 90,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Contact Phone",
            field: "contactPhone", width: 120,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Contact Email",
            field: "contactEmail", width: 120,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Action",
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
            field: "", width: 80,
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
      o.contactPerson = $('#contactPerson').val();
      o.contactPhone = $('#contactPhone').val();
      o.contactEmail = $('#contactEmail').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
      $.ajax({
         url: "/Project/ProjectSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               ProjectLoad();
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
   var FilterData = _.filter(ProjectList, function (item) { return item.id == id });
   $('#name').val(FilterData[0].name);
   $('#contactPerson').val(FilterData[0].contactPerson);
   $('#contactPhone').val(FilterData[0].contactPhone);
   $('#contactEmail').val(FilterData[0].contactEmail);
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit Project Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#staticBackdropLabel').text('Create New Project');
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#contactPerson').val('');
   $('#contactPhone').val('');
   $('#contactEmail').val('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($('#name').val() == "") {
      $('#name').focus();
      toastr.warning('Please input Project name');
      return false;
   }
   if ($('#contactPerson').val() == "") {
      $('#contactPerson').focus();
      toastr.warning('Please input Contact Person');
      return false;
   }
   if ($('#contactPhone').val() == "") {
      $('#ContactPhone').focus();
      toastr.warning('Please input valid Contact Phone');
      return false;
   }
   if ($('#contactEmail').val() == "") {
      $('#contactEmail').focus();
      toastr.warning('Please input Contact Email');
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
