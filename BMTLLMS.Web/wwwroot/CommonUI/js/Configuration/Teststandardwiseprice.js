var TestStandardWisePriceList = []
var TestStandardList = []
var CurrencyList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
   TestStandardWisePriceLoad();
   TestStandardLoad();
   CurrencyLoad();
   $("#cmbTestStandard").kendoComboBox({
      dataTextField: "testStandardName",
      dataValueField: "testStandardID",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select TestStandard Name'
   });
   $("#cmbCurrency").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Currency Name'
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
   $("#EffectiveDateFrom").kendoDatePicker();
   $("#EffectiveDateTo").kendoDatePicker();
});
function CurrencyLoad() {
   $.ajax({
      url: "/Currency/GetCurrency",
      method: "GET",
      dataType: "json",
      success: function (data) { 
         if (data.statusCode = "200") {
            CurrencyList = data; 
            $("#cmbCurrency").data('kendoComboBox').dataSource.data([]);
            $('#cmbCurrency').data('kendoComboBox').dataSource.data(CurrencyList);
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
            $("#cmbTestStandard").data('kendoComboBox').dataSource.data([]);
            $('#cmbTestStandard').data('kendoComboBox').dataSource.data(TestStandardList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}

function TestStandardWisePriceLoad() {

   $.ajax({
      url: "/TestStandardWisePrice/GetTestStandardWisePrice",
      method: "GET",
      dataType: "json",
      success: function (data) { 
         if (data.statusCode = "200") {
            TestStandardWisePriceList = data.data;
            $("#cmbTestStandard").data('kendoComboBox').dataSource.data([]);
            $('#cmbTestStandard').data('kendoComboBox').dataSource.data(TestStandardWisePriceList);
            $("#cmbCurrency").data('kendoComboBox').dataSource.data([]);
            $('#cmbCurrency').data('kendoComboBox').dataSource.data(TestStandardWisePriceList);
            TestStandardWisePriceDataBind(TestStandardWisePriceList);
            TestStandardLoad();
            CurrencyLoad();
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}

function TestStandardWisePriceDataBind(data) {
   var i = 1;
   _.map(TestStandardWisePriceList, function (o) {
      o.sl = i;
      i++;
   });
   $("#gridTable").kendoGrid({
      dataSource: data,
      sortable: true,
      toolbar: ["search"],
      search: {
         fields: ["testStandardName", "testStandardWiseName","currencyWiseName"]
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
            title: "Test Standard Name",
            field: "testStandardWiseName", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Currency Name",
            field: "currencyWiseName", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Regular Delivery Days",
            field: "regularDeliveryDays", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Express Delivery Days",
            field: "expressDeliveryDays", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Regular Price",
            field: "regularPrice", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Express Price",
            field: "expressPrice", width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Effective Date From",
            field: "effectiveDateFrom",
            template: "#= new Date(effectiveDateFrom.toString()).getFullYear() == 1 ? '' :  moment(effectiveDateFrom).format('MMM Do YYYY') #",
            width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Effective Date To",
            field: "effectiveDateTo",
            template: "#= new Date(effectiveDateTo.toString()).getFullYear() == 1 ? '' :  moment(effectiveDateTo).format('MMM Do YYYY') #",
            width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
         },
         {
            title: "Action",
            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:testStandardWisePriceID#)'><span class='k-icon k-i-edit'></span></button>",
            field: "", width: 25,
            attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
         }
      ]
   });
}
function forceLimit(e) {
   var limit = e.target.getAttribute("max");
   if (e.target.value > limit)
      e.target.value = limit;
}

function handleLimitChange(e) {
   var limit = e.target.value;
   var fieldOne = document.querySelector('#ExpressDeliveryDays');
   if (fieldOne.value > limit) {
      fieldOne.value = limit;
   }
   fieldOne.setAttribute('max', limit);
}
function RegularPriceforceLimit(e) {
   var limit = e.target.getAttribute("max");
   if (e.target.value > limit)
      e.target.value = limit;
}

function ExpressPricehandleLimitChange(e) {
   var limit = e.target.value;
   var fieldOne = document.querySelector('#RegularPrice');
   if (fieldOne.value > limit) {
      fieldOne.value = limit;
   }
   fieldOne.setAttribute('max', limit);
}
function Save() {
   var o = new Object();
   var validate = true;
   validate = Validate();
   if (validate == true) {
      o.testStandardWisePriceID = $('#spanParentID').html();
      o.testStandardWiseID = $('#cmbTestStandard').val();
      o.currencyWiseID = $('#cmbCurrency').val(); 
      o.regularDeliveryDays = $('#RegularDeliveryDays').val();
      o.ExpressDeliveryDays = $('#ExpressDeliveryDays').val();
      o.regularPrice = $('#RegularPrice').val();
      o.expressPrice = $('#ExpressPrice').val();
      o.effectiveDateFrom = $('#EffectiveDateFrom').val();
      o.effectiveDateTo = $('#EffectiveDateTo').val() == "" ? "" : moment($('#EffectiveDateTo').val()).format('MM/DD/YYYY');
      o.isActive = $('#isActive').is(':checked') ? true : false;
      
      $.ajax({
         url: "/TestStandardWisePrice/TestStandardWisePriceSave",
         type: "POST",
         dataType: "json",
         data: o,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               TestStandardWisePriceLoad();
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
   var FilterData = _.filter(TestStandardWisePriceList, function (item) { return item.testStandardWisePriceID == id });
   $('#cmbTestStandard').data('kendoComboBox').value(FilterData[0].testStandardWiseID);
   $('#cmbCurrency').data('kendoComboBox').value(FilterData[0].currencyWiseID);
   $('#RegularDeliveryDays').val(FilterData[0].regularDeliveryDays);
   $('#ExpressDeliveryDays').val(FilterData[0].expressDeliveryDays); 
   $('#RegularPrice').val(FilterData[0].regularPrice);
   $('#ExpressPrice').val(FilterData[0].expressPrice);
   $('#EffectiveDateFrom').val(moment(FilterData[0].effectiveDateFrom).format('MM/DD/YYYY'));
   $('#EffectiveDateTo').val(moment(FilterData[0].effectiveDateTo).format('MM/DD/YYYY'));
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit TestStandard Wise Price Information');
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}

function AddNew() {
   $('#staticBackdropLabel').text('Create New TestStandard Wise Price');
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#name').val('');
   $('#RegularDeliveryDays').val('');
   $('#ExpressDeliveryDays').val('');
   $('#RegularPrice').val('');
   $('#ExpressPrice').val('');
   $('#EffectiveDateFrom').val('');
   $('#EffectiveDateTo').val('');
   $("#cmbTestStandard").data('kendoComboBox').value('');
   $('#cmbCurrency').data('kendoComboBox').value('');
   $('#mdlUserReg').modal('toggle');
   $('#staticBackdropLabel').text('Edit TestStandard Wise Price Information');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($("#cmbTestStandard").data('kendoComboBox').value() == "" || $("#cmbTestStandard").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbTestStandard").data('kendoComboBox').focus();
      $("#cmbTestStandard").data('kendoComboBox').open();
      toastr.warning('Please input TestStandard Name', "Warning");
      return false;
   }
   else if ($("#cmbCurrency").data('kendoComboBox').value() == "" || $("#cmbCurrency").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbCurrency").data('kendoComboBox').focus();
      $("#cmbCurrency").data('kendoComboBox').open();
      toastr.warning('Please input Currency Name', "Warning");
      return false;
   }
   else if ($('#RegularDeliveryDays').val() == "") {
      $('#RegularDeliveryDays').focus();
      toastr.warning('Please input Regular Delivery Days',"Warning");
      return false;
   }
   else if ($('#ExpressDeliveryDays').val() > $('#RegularDeliveryDays').val()) {
      $('#ExpressDeliveryDays').focus();
      toastr.warning('Please input Express Delivery Days must be less than Regular Delivery Days', "Warning");
      return false;
   }
   else if ($('#RegularDeliveryDays').val() == "") {
      $('#ExpressDeliveryDays').focus();
      toastr.warning('Please input Express Delivery Days', "Warning");
      return false;
   }
   else if($('#RegularPrice').val() == "") {
      $('#RegularPrice').focus();
      toastr.warning('Please input Regular Price', "Warning");
      return false;
   }
   else if ($('#ExpressPrice').val() == "") {
      $('#ExpressPrice').focus();
      toastr.warning('Please input Express Price', "Warning");
      return false;
   }
   else if ($('#RegularPrice').val() > $('#ExpressPrice').val()) {
      $('#RegularPrice').focus();
      toastr.warning('Please input Regular Price must be less than Express Price', "Warning");
      return false;
   }
   else if ($('#EffectiveDateFrom').val() == "") {
      $('#EffectiveDateFrom').focus();
      toastr.warning('Please input Effective Date From', "Warning");
      return false;
   } 
   
   return true;
}