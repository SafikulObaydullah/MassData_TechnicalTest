var PriceAgreementParentList = []
var CustomerList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);


$(document).ready(function () {
   PriceAgreementParentLoad();
   CustomerLoad();
   $("#cmbCustomer").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Attribute'
   });
   $(function () {
      $("[data-role=combobox]").each(function () {
         var widget = $(this).getKendoComboBox();
         widget.input.on("focus", function () {
            widget.open();
         });
      });
   });
   $(".Kdatepicker").bind("focus", function () {
      $(this).data("kendoDatePicker").open();
   });
   $("#AgreementDate").kendoDatePicker();
   $("#EffectiveDateFrom").kendoDatePicker();
   $("#EffectiveDateTo").kendoDatePicker();
});
function CustomerLoad() {
   $.ajax({
      url: "/Customer/GetCustomer",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            CustomerList = data.data; 
            $("#cmbCustomer").data('kendoComboBox').dataSource.data([]);
            $('#cmbCustomer').data('kendoComboBox').dataSource.data(CustomerList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}
function PriceAgreementParentLoad() {
  
    $.ajax({
       url: "/PriceAgreementParent/GetPriceAgreementParent",
        method: "GET",
       dataType: "json",
       success: function (data) {
          PriceAgreementParentList = data; 
          PriceAgreementParentDataBind();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function PriceAgreementParentDataBind() {
    var i = 1;
    _.map(PriceAgreementParentList, function (o) {
        o.sl = i;
        i++;
    });

    $("#gridTable").kendoGrid({
        dataSource: PriceAgreementParentList,
        sortable: true,
        toolbar: ["search"],
        search: {
           fields: ["customerName"]
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
              headerAttributes: {
                    style: "text-align: center;"
              },
              attributes: { style: "text-align: center;" }
            },
            {
                title: "Customer Name",
                field: "customerName", width: 50,
                headerAttributes: { style: "text-align: left;" }

           },
           //{
           //   title: "ContactPersonName",
           //   field: "contactPersonName", width: 50,
           //   headerAttributes: { style: "text-align: left;" }

           //},
           //{
           //   title: "ContactEmail",
           //   field: "contactEmail", width: 50,
           //   headerAttributes: { style: "text-align: left;" }

           //},
           //{
           //   title: "ContactAddress",
           //   field: "contactAddress", width: 50,
           //   headerAttributes: { style: "text-align: left;" }

           //},
            {
                title: "AgreementDate",
               field: "agreementDate",
               template: "#= new Date(agreementDate.toString()).getFullYear() == 1 ? '' :  moment(agreementDate).format('MMM Do YYYY') #",
               width: 90,
               attributes: { style: "text-align: left;" }

           },
           {
              title: "EffectiveDateFrom",
              field: "effectiveDateFrom",
              template: "#= new Date(effectiveDateFrom.toString()).getFullYear() == 1 ? '' :  moment(effectiveDateFrom).format('MMM Do YYYY') #",
              width: 50,
              attributes: {
                 style: "text-align: left;"
           }
           },
           {
              title: "EffectiveDateTo",
              field: "effectiveDateTo",
              template: "#= new Date(effectiveDateTo.toString()).getFullYear() == 1 ? '' :  moment(effectiveDateTo).format('MMM Do YYYY') #",
              width: 50,
              attributes: {
                 style: "text-align: left;"
              }
           },
           {
              title: "Description",
              field: "description", width: 50,
              attributes: {
                 style: "text-align: left;"
              }
           },
           {
              title: "Signee_id",
              field: "signee_id", width: 50,
              attributes: {
                 style: "text-align: left;"
              }
           },
           {
              title: "CustomerSideSigneeName",
              field: "customerSideSigneeName", width: 50,
              attributes: {
                 style: "text-align: left;"
              }
           },
           {
              title: "CustomerSideSigneeDesignation",
              field: "customerSideSigneeDesignation", width: 50,
              attributes: {
                 style: "text-align: left;"
              }
           },
            {
                title: "Action",
               template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
                field: "", width: 25,
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
      o.customerID = $('#cmbCustomer').val();
      o.agreementDate = $('#AgreementDate').val();
      o.effectiveDateFrom = $('#EffectiveDateFrom').val();
      o.effectiveDateTo = $('#EffectiveDateTo').val();
      o.description = $('#Description').val();
      o.attachementAgreement = $('#AttachementAgreement').val();
      o.signee_id = $('#Signee_id').val();
      o.customerSideSigneeName = $('#CustomerSideSigneeName').val();
      o.customerSideSigneeDesignation = $('#CustomerSideSigneeDesignation').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
           url: "/PriceAgreementParent/PriceAgreementParentSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    PriceAgreementParentLoad();
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
    var FilterData = _.filter(PriceAgreementParentList, function (item) { return item.id == id });
   $('#cmbCustomer').data('kendoComboBox').value(FilterData[0].customerID);
   $('#AgreementDate').val(moment(FilterData[0].agreementDate).format('MM/DD/YYYY'));
   $('#EffectiveDateFrom').val(moment(FilterData[0].effectiveDateFrom).format('MM/DD/YYYY'));
   $('#EffectiveDateTo').val(moment(FilterData[0].effectiveDateTo).format('MM/DD/YYYY'));
   $('#Description').val(FilterData[0].description);
   $('#AttachementAgreement').val(FilterData[0].attachementAgreement);
   $('#Signee_id').val(FilterData[0].signee_id);
   $('#CustomerSideSigneeName').val(FilterData[0].customerSideSigneeName);
   $('#CustomerSideSigneeDesignation').val(FilterData[0].customerSideSigneeDesignation);
    FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle')
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}
function AddNew() {
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#AgreementDate').val('');
   $('#EffectiveDateFrom').val('');
   $('#EffectiveDateTo').val('');
   $('#Description').val('');
   $('#AttachementAgreement').val('');
   $('#Signee_id').val('');
   $('#CustomerSideSigneeName').val('');
   $('#CustomerSideSigneeDesignation').val('');
   $('#cmbCustomer').data('kendoComboBox').value('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($("#cmbCustomer").data('kendoComboBox').value() == "" || $("#cmbCustomer").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbCustomer").data('kendoComboBox').focus();
      $("#cmbCustomer").data('kendoComboBox').open();
      toastr.warning('Please input Customer Name', "Warning");
      return false;
   }
   if ($('#AgreementDate').val() == "") {
      $('#AgreementDate').focus();
      toastr.warning('Please input AgreementDate', "Warning");
        return false;
    }

   if ($('#EffectiveDateFrom').val() == "") {
      $('#EffectiveDateFrom').focus();
      toastr.warning('Please input EffectiveDateFrom', "Warning");
        return false;
   }
   if ($('#EffectiveDateTo').val() == "") {
      $('#EffectiveDateTo').focus();
      toastr.warning('Please input EffectiveDateTo', "Warning");
      return false;
   } 
   if ($('#Signee_id').val() == "") {
      $('#Signee_id').focus();
      toastr.warning('Please input Valid Agreement Number(Code)', "Warning");
      return false;
   }
   var inputValue = $('#Signee_id').val();
   var numberPattern = "/^[0-9]+$/";

   if (!inputValue.match(numberPattern)) {
      $('#Signee_id').focus();
      toastr.warning('Invalid input. Please enter a valid Agreement Number(Code)', "Warning");
      return false;
   }
   //else {
   //   $('#result').text('Invalid input. Please enter a valid number.');
   //}

   if ($('#CustomerSideSigneeName').val() == "") {
      $('#CustomerSideSigneeName').focus();
      toastr.warning('Please input CustomerSideSigneeName', "Warning");
      return false;
   }
   if ($('#CustomerSideSigneeDesignation').val() == "") {
      $('#CustomerSideSigneeDesignation').focus();
      toastr.warning('Please input CustomerSideSigneeDesignation',"Warning");
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
