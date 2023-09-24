var UserList = []
var AttributeList = []
var SectionList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () { 
   LoadInitalData();
   $("#ddlUserTypeAttribute").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select UserType'
   });
   $("#ddlUserSection").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Section'
   });  

   $("#txtddlUserTypeAttribute").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select UserType'
   });
   $("#txtddlUserSection").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Section'
   });
});
 
function LoadInitalData() {
   $.ajax({
      url: "/User/GetInitialData",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            UserList = data.users;
            AttributeList = data.attributes;
            console.log(AttributeList);
            $("#ddlUserTypeAttribute").data('kendoComboBox').dataSource.data([]);
            $('#ddlUserTypeAttribute').data('kendoComboBox').dataSource.data(AttributeList);
            $("#txtddlUserTypeAttribute").data('kendoComboBox').dataSource.data([]);
            $('#txtddlUserTypeAttribute').data('kendoComboBox').dataSource.data(AttributeList);
            SectionList = data.sections;
            $("#ddlUserSection").data('kendoComboBox').dataSource.data([]);
            $('#ddlUserSection').data('kendoComboBox').dataSource.data(SectionList); 
            $("#txtddlUserSection").data('kendoComboBox').dataSource.data([]);
            $('#txtddlUserSection').data('kendoComboBox').dataSource.data(SectionList); 
            UserDataBind(UserList); 
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });
}


function UserDataBind(data) {
   var i = 1;
   _.map(UserList, function (o) {
      o.sl = i;
      i++;
   });
   $("#gridTable").kendoGrid({
      dataSource: data,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["name,","userName"]
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
         },
         {
            title: "Name",
            field: "name", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "User Name",
            field: "userName", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Designation",
            field: "designation", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "UserType",
            field: "userTypeAttributeName", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Section",
            field: "userSectionName", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         }, 
         {
            title: "Action",
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button><button class='btn btn-ghost-info active w-10'  title='Change Password' onclick='ChangeNew(#:id#)'><span class='fas fa-key'></span></button>",
            field: "", width: 50,
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
      o.name = $('#name').val();
      o.userName = $('#UserName').val();
      o.email = $('#Email').val();
      o.designation = $('#Designation').val();
      o.password = $('#Password').val() == "" ? "" : $('#Password').val();
      o.userTypeAttributeID = $('#ddlUserTypeAttribute').val();
      o.userSectionID = $('#ddlUserSection').val(); 
      o.userTypeAttributeID = $('#ddlUserTypeAttribute').val();
      o.userSectionID = $('#ddlUserSection').val(); 
      o.isActive = $('#isActive').is(':checked') ? true : false;
      $.ajax({
         url: "/User/UserSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               LoadInitalData();
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

function Update() {
   var o = new Object();
   var validate = true;
   validate = EditValidate();
   if (validate == true) {
      o.id = $('#editParentID').html();
      o.name = $('#txtName').val();
      o.userName = $('#txtUserName').val();
      o.email = $('#txtEmail').val();
      o.designation = $('#txtDesignation').val(); 
      o.userTypeAttributeID = $('#txtddlUserTypeAttribute').val();
      o.userSectionID = $('#txtddlUserSection').val();
      o.userTypeAttributeID = $('#txtddlUserTypeAttribute').val();
      o.userSectionID = $('#txtddlUserSection').val();
      o.isActive = $('#rdisActive').is(':checked') ? true : false;
      $.ajax({
         url: "/User/UserSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               LoadInitalData();
               $('#editModal').modal('hide')
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
   $('#editParentID').html(id); 
   var FilterData = _.filter(UserList, function (item) { return item.id == id });
   console.log(UserList);
   $('#txtddlUserTypeAttribute').data('kendoComboBox').value(FilterData[0].userTypeAttributeID);
   $('#txtddlUserSection').data('kendoComboBox').value(FilterData[0].userSectionID);
   $('#txtName').val(FilterData[0].name);
   $('#txtUserName').val(FilterData[0].userName);
   $('#txtEmail').val(FilterData[0].email);
   $('#txtDesignation').val(FilterData[0].designation); 
   FilterData[0].isActive == false ? $('#rdisActive').prop('checked', false) : $('#rdisActive').prop('checked', true)
   $('#editModal').modal('toggle');
   $('#EditBtnSave').text('Update');
   $('#EditBtnSave').addClass('btn btn-ghost-info active w-10');
}

function ChangePassword() {
   var o = new Object();
   var validate = true;
   validate = ChangePasswordValidate();
   if (validate == true) {
      o.id = $('#spanChangeParentID').html();
      o.name = $('#txtChangeName').val();
      o.password = $('#txtChangePassword').val();
      o.userName = "";
      o.email = "";
      $.ajax({
         url: "/User/ChangePassword",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               LoadInitalData();
               $('#ChangPasswordModal').modal('hide')
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
function AddNew() {
   $('#staticBackdropLabel').text('Create New User');
   $('#EditBtnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val(''); 
   $('#UserName').val('');
   $('#Email').val('');
   $('#Password').val('');
   $('#Designation').val('');
   $("#ddlUserTypeAttribute").data('kendoComboBox').value('');
   $('#ddlUserSection').data('kendoComboBox').value('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}
function ChangeNew(id) { 
   $('#EditBtnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanChangeParentID').html(id);
   var FilterData = _.filter(UserList, function (item) { return item.id == id });
   console.log(UserList); 
   $('#txtChangeName').val(FilterData[0].name);   
   $('#txtChangePassword').val('');  
   $('#ChangPasswordModal').modal('toggle');
   $('#BtnChange').text('Change Password');
   $('#BtnChange').addClass('btn btn-ghost-primary active w-10');
}
function Validate() {
   if ($('#name').val() == "") {
      $('#name').focus();
      toastr.warning('Please input Name', "Warning");
      return false;
   }
   if ($('#UserName').val() == "") {
      $('#UserName').focus();
      toastr.warning('Please input Username', "Warning");
      return false;
   }
   if ($('#Email').val() == "") {
      $('#Email').focus();
      toastr.warning('Please input Email', "Warning");
      return false;
   }
   if ($('#Designation').val() == "") {
      $('#Designation').focus();
      toastr.warning('Please input Designation', "Warning");
      return false;
   }
   if ($('#Password').val() == "") {
      $('#Password').focus();
      toastr.warning('Please input Password', "Warning");
      return false;
   }
   if ($("#ddlUserTypeAttribute").data('kendoComboBox').value() == "" || $("#ddlUserTypeAttribute").data('kendoComboBox').selectedIndex == -1) {
      $("#ddlUserTypeAttribute").data('kendoComboBox').focus();
      $("#ddlUserTypeAttribute").data('kendoComboBox').open();
      toastr.warning('Please input UserType', "Warning");
      return false;
   }
   if ($("#ddlUserSection").data('kendoComboBox').value() == "" || $("#ddlUserSection").data('kendoComboBox').selectedIndex == -1) {
      $("#ddlUserSection").data('kendoComboBox').focus();
      $("#ddlUserSection").data('kendoComboBox').open();
      toastr.warning('Please input Section', "Warning");
      return false;
   }  
   return true;
}
function EditValidate() {
   if ($('#txtName').val() == "") {
      $('#txtName').focus();
      toastr.warning('Please input Name', "Warning");
      return false;
   }
   if ($('#txtUserName').val() == "") {
      $('#txtUserName').focus();
      toastr.warning('Please input Username', "Warning");
      return false;
   }
   if ($('#txtEmail').val() == "") {
      $('#txtEmail').focus();
      toastr.warning('Please input Email', "Warning");
      return false;
   }
   if ($('#txtDesignation').val() == "") {
      $('#txtDesignation').focus();
      toastr.warning('Please input Designation', "Warning");
      return false;
   } 
   if ($("#txtddlUserTypeAttribute").data('kendoComboBox').value() == "" || $("#txtddlUserTypeAttribute").data('kendoComboBox').selectedIndex == -1) {
      $("#txtddlUserTypeAttribute").data('kendoComboBox').focus();
      $("#txtddlUserTypeAttribute").data('kendoComboBox').open();
      toastr.warning('Please input UserType', "Warning");
      return false;
   }
   if ($("#txtddlUserSection").data('kendoComboBox').value() == "" || $("#txtddlUserSection").data('kendoComboBox').selectedIndex == -1) {
      $("#txtddlUserSection").data('kendoComboBox').focus();
      $("#txtddlUserSection").data('kendoComboBox').open();
      toastr.warning('Please input Section', "Warning");
      return false;
   }
   return true;
}
function ChangePasswordValidate() {
   if ($('#txtChangeName').val() == "") {
      $('#txtChangeName').focus();
      toastr.warning('Please input Name', "Warning");
      return false;
   }
   if ($('#txtChangePassword').val() == "") {
      $('#txtChangePassword').focus();
      toastr.warning('Please input Password', "Warning");
      return false;
   } 
   return true;
}