var CustomerList = []
var TestStandardList = []
var TestStandardPriceList = []
var CurrencyList = []
var EffectiveDateVar; 
var PriceAgreementSearchList = []
var PriceAgreementParentAndChildList = []
var PriceAgreementDetailsList = []

var currentDate = new Date();
var year = currentDate.getFullYear();
var month = (currentDate.getMonth() + 1).toString().padStart(2, '0'); 
var day = currentDate.getDate().toString().padStart(2, '0'); 
var formattedDate = month + "-" + day + "-" + year;


$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () { 
   /*LoadPriceAgreementParentAndChildDetails();*/
  
   $("#btnSearch").click(function () { 
      $("html, body").animate({ scrollTop:700 }, "slow");
   });
   $("#btnClear").click(function () {
      $("html, body").animate({ scrollTop: 700 }, "slow");
   });
   $("#ddlSearchCustomer").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Customer',
      delay: 100
   }).data("kendoComboBox");
   var comboBox = $("#ddlCustomer").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Customer',
      delay: 100
   }).data("kendoComboBox");
   comboBox.input.on("keydown", function (e) {
      if (e.keyCode === kendo.keys.DOWN || e.keyCode === kendo.keys.UP || e.keyCode === kendo.keys.ENTER || e.keyCode === kendo.keys.BACKSPACE) {
         return;
      }
      var maxLength = 5;
      if (comboBox.text().length >= maxLength) {
         e.preventDefault();
         comboBox.input.blur();
         return;
      }
      comboBox.open();
   });
   $(function () {
      $("[data-role=ddlBox]").each(function () {
         var widget = $(this).getKendoComboBox();
         widget.input.on("focus", function () {
            widget.open();
         });
      });
   }); 

   var comboBox = $("#ddlTestStandard").kendoComboBox({
      dataTextField: "testStandardName",
      dataValueField: "testStandardID",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select TestStandard Name',
      delay: 100
   }).data("kendoComboBox");
   comboBox.input.on("keydown", function (e) {
      if (e.keyCode === kendo.keys.DOWN || e.keyCode === kendo.keys.UP || e.keyCode === kendo.keys.ENTER || e.keyCode === kendo.keys.BACKSPACE) {
         return;
      }
      var maxLength = 5;
      if (comboBox.text().length >= maxLength) {
         e.preventDefault();
         comboBox.input.blur();
         return;
      }
      comboBox.open();
   }); 
   var comboBox = $("#ddlCurrency").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Currency',
      delay: 100
   }).data("kendoComboBox");
   comboBox.input.on("keydown", function (e) {
      if (e.keyCode === kendo.keys.DOWN || e.keyCode === kendo.keys.UP || e.keyCode === kendo.keys.ENTER || e.keyCode === kendo.keys.BACKSPACE) {
         return;
      }
      var maxLength = 4;
      if (comboBox.text().length >= maxLength) {
         e.preventDefault();
         comboBox.input.blur();
         return;
      }
      comboBox.open();
   });
   
   $(".Kdatepicker").bind("focus", function () {
      $(this).data("kendoDatePicker").open();
   });
   $("#txtDateOfAgreement").kendoDatePicker();
   $("#txtDateOfAgreement").val(formattedDate);
   $("#txtEffectiveFrom").val(formattedDate);
   $("#txtEffectiveTo").kendoDatePicker();
   SetMinimumDateForEffectiveToDate();
   $("#txtEffectiveFrom").kendoDatePicker({
      change: function () {
         EffectiveDateVar = this.value();
         $('#txtEffectiveTo').val('');
         SetMinimumDateForEffectiveToDate();
      }
   });
   $("#txtSearchAgreementFromDate").kendoDatePicker();
   $("#txtSearchAgreementToDate").kendoDatePicker();
   $("#txtSearchEffectiveFromDate").kendoDatePicker();
   $("#txtSearchEffectiveToDate").kendoDatePicker();
   LoadInitalData(); 
   LoadPriceAgreementSearchData();
});
function LoadPriceAgreementSearchData() {
   $.ajax({
      url: "/PriceAgreement/GetSearchData",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            PriceAgreementDetailsList = data.searchList;
            BindPriceAgreementList(PriceAgreementDetailsList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });
}
function LoadInitalData() {
   $.ajax({
      url: "/PriceAgreement/GetInitialData",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") { 
            CustomerList = data.customer;
            $("#ddlCustomer").data('kendoComboBox').dataSource.data([]);
            $('#ddlCustomer').data('kendoComboBox').dataSource.data(CustomerList);
            $("#ddlSearchCustomer").data('kendoComboBox').dataSource.data([]);
            $('#ddlSearchCustomer').data('kendoComboBox').dataSource.data(CustomerList);
            TestStandardList = data.testStandard;
            $("#ddlTestStandard").data('kendoComboBox').dataSource.data([]);
            $('#ddlTestStandard').data('kendoComboBox').dataSource.data(TestStandardList);
            CurrencyList = data.currency; 
            $("#ddlCurrency").data('kendoComboBox').dataSource.data([]);
            $('#ddlCurrency').data('kendoComboBox').dataSource.data(CurrencyList); 
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });
}

function AddPriceAgreement() { 
   var o = new Object();
   var validate = true;
   validate = PriceAgreementValidate();
   if (validate == true) {
      o.ParentID = $("#txtId").val() == "" ? 0 : $("#txtId").val();
      o.TestStandardID = $('#ddlTestStandard').data('kendoComboBox').value();
      o.TestStandardName = $('#ddlTestStandard').data('kendoComboBox').text();
      o.CurrencyID = $('#ddlCurrency').data('kendoComboBox').value();
      o.CurrencyName = $('#ddlCurrency').data('kendoComboBox').text();
      o.RegularPrice = 0;
      o.ExpressPrice = 0;
      o.SampleTypeID = 1
      o.note = 'eee',
      o.isActive = true;
      o.creator = 1;
      o.creationDate = '08-21-2023'
      var FilterData = _.filter(TestStandardPriceList, function (item) {
         return item.TestStandardID == o.TestStandardID &&
            item.CurrencyID == o.CurrencyID

      });
      if (FilterData.length > 0) {
         toastr.warning("Already Added", "Waring");
      }
      else {
         TestStandardPriceList.push(o); 
         BindTestStandardPriceTable(TestStandardPriceList);
      }
   }
}
function PriceAgreementValidate()
{
   if ($("#ddlCurrency").data('kendoComboBox').value() == "" || $("#ddlCurrency").data('kendoComboBox').selectedIndex == -1) {
      $("#ddlCurrency").data('kendoComboBox').focus();
      $("#ddlCurrency").data('kendoComboBox').open();
      toastr.warning('Please input Currency', "Warning");
      return false;
   }
   if ($("#ddlTestStandard").data('kendoComboBox').value() == "" || $("#ddlTestStandard").data('kendoComboBox').selectedIndex == -1) {
      $("#ddlTestStandard").data('kendoComboBox').focus();
      $("#ddlTestStandard").data('kendoComboBox').open();
      toastr.warning('Please input TestStandard Name', "Warning");
      return false;
   }
   return true;
}
  
function BindTestStandardPriceTable(data) {
   
   $("#divtestStandard").html('');
   var sl = 1;
   var html = '<table class="table table-vcenter card-table">' +
      ' <tr><th>SL</th><th>Currency</th><th> Test Standard</th><th>Regular Price</th><th>ExpressPrice</th><th>Action</th>' +
      '</tr>';
   for (var i = 0; i < data.length; i++) {
      html += "<tr><td id='slNo' style='width:0%;text-align:center;'>" + sl + "</td>" +
         "<td style='width:10%;text-align:left;'>" + data[i].CurrencyName + "</td>" +
         "<td style='width:10%;text-align:left;'>" + data[i].TestStandardName + "</td>" +
         "<td style='width:10%;text-align:left;' ><input type='number' class='form-control' id='txtregular_"+i+"' onblur = 'PriceUpdate(" + i + "," + data[i].TestStandardID + ")' value = " + data[i].RegularPrice +" ></td > " +
         " <td style='width:10%;text-align:left;'><input type='number' class='form-control' id='txtexpressPrice_"+i+"' onblur='PriceUpdate(" + i + "," + data[i].TestStandardID + ")' value=" + data[i].ExpressPrice+"></td>" +
         " <td style='width:10%;text-align:left;'><button  class='btn btn-success ' onclick='DeletePriceAgreement(" + data[i].TestStandardID + ")'>Delete</button></td>" +
         "</tr>";
     
      sl = sl + 1;
   }
   html+='</table>'
   $("#divtestStandard").html(html);
}
var regularId = 0;
var expressId = 0;
function PriceUpdate(pos, Val) {
    regularId = "#txtregular_" + pos;
    expressId = "#txtexpressPrice_" + pos;
   for (var i = 0; i < TestStandardPriceList.length; i++) {
      if (TestStandardPriceList[i].TestStandardID == Val) {
         TestStandardPriceList[i].RegularPrice = $(regularId).val();
         TestStandardPriceList[i].ExpressPrice = $(expressId).val();
      }
   }

}
function DeletePriceAgreement(id) {
   var indexToDelete = TestStandardPriceList.findIndex(function (obj) {
      return obj.TestStandardID == id;
   });
   if (indexToDelete !== -1) {
      TestStandardPriceList.splice(indexToDelete, 1); 
   } 
   BindTestStandardPriceTable(TestStandardPriceList); 
   
}

function LoadPriceAgreementParentAndChildDetails(id) {
   
   $.ajax({
      url: "/PriceAgreementSearch/GetPriceAgreementParentAndChildDetails?id=" + id,
      type: "POST",
      dataType: "json",
      data: {},
         success: function (data) {
            PriceAgreementParentAndChildList = data;
            PriceAgreementDataBind(PriceAgreementParentAndChildList);
            
         }
      }); 
}
function SearchValidate() {
   if ($("#ddlSearchCustomer").data('kendoComboBox').value() == "" || $("#ddlSearchCustomer").data('kendoComboBox').selectedIndex == -1) {
      $("#ddlSearchCustomer").data('kendoComboBox').focus();
      $("#ddlSearchCustomer").data('kendoComboBox').open();
      toastr.warning('Please input Customer Name', "Warning");
      return false;
   }
   else if ($('#txtSearchAgreementFromDate').val() == "") {
      $('#txtSearchAgreementFromDate').focus();
      toastr.warning('Please input Agreement From Date', "Warning");
      return false;
   }

   else if ($('#txtSearchAgreementToDate').val() == "") {
      $('#txtSearchAgreementToDate').focus();
      toastr.warning('Please input Agreement To Date', "Warning");
      return false;
   }
   else if ($('#txtSearchEffectiveFromDate').val() == "") {
      $('#txtSearchEffectiveFromDate').focus();
      toastr.warning('Please input Effective From Date', "Warning");
      return false;
   }
   else if ($('#txtSearchEffectiveToDate').val() == "") {
      $('#txtSearchEffectiveToDate').focus();
      toastr.warning('Please input Effective To Date', "Warning");
      return false;
   }
   return true;
}
function GetPriceAgreementBySearchList() {
   var o = new Object(); 
      o.customerID = $("#ddlSearchCustomer").data('kendoComboBox').value();
      o.agreementDate = $("#txtSearchAgreementFromDate").val();
      o.AgreementToDate = $("#txtSearchAgreementToDate").val();
      o.effectiveDateFrom = $("#txtSearchEffectiveFromDate").val();
      o.effectiveDateTo = $("#txtSearchEffectiveToDate").val();
      $.ajax({
         url: "/PriceAgreementSearch/PriceAgreementBySearch",
         method: "GET",
         dataType: "json",
         data: o,
         success: function (data) {
            PriceAgreementSearchList = data;
            BindPriceAgreementList(PriceAgreementSearchList);
         }
      }); 
}

function BindPriceAgreementList(data) { 
   var i = 1;
   _.map(PriceAgreementSearchList, function (obj) {
      obj.sl = i;
      i++;
   });
   $("#gridSearch").kendoGrid({
      dataSource: {
         data: data
      },  
      height: 550,
      sortable: true,
      pageable: {
         pageSize: 15,
         pageSizes: [15, 30, 50, "all"],
         numeric: false
      },
      columns: [
         {
            field: "sl", width: 30,
            title: "SL",
            attributes: {
               style: "text-align:center;"
            },
            headerAttributes: { style: "text-align:center;font-weight: bold;background-color:#00bcd4" },
         },
         {
            field: "id", width: 40,
            title: "Ref. No",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            field: "customerName", width: 50,
            title: "Customer Name",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            field: "agreementDate", width: 50,
            title: "Agreement From Date",
            template: "#= new Date(agreementDate?.toString()).getFullYear() == 1 ? '':moment(agreementDate).format('MMM Do YYYY') #",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            field: "agreementDate", width: 50,
            title: "Agreement To Date",
            template: "#= new Date(agreementDate?.toString()).getFullYear() == 1 ? '' :  moment(agreementDate).format('MMM Do YYYY') #",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            title: "Effective From Date",
            field: "effectiveDateFrom", width: 50, 
            template: "#= new Date(effectiveDateFrom?.toString()).getFullYear() == 1 ? '' :  moment(effectiveDateFrom).format('MMM Do YYYY') #",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            title: "Effective To Date",
            field: "effectiveDateTo", 
            template: "#= new Date(effectiveDateTo?.toString()).getFullYear() == 1 ? '' :  moment(effectiveDateTo).format('MMM Do YYYY') #",
            width: 50,
            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            template: function (x) {
               if (x.testtr == null || x.testtr == "") {
                  return "Pending"
               }
               else {
                  return "Done"
               }
            },
            width: 40,
            title: "Sample Status",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            title: "Action",
            template: function (x) { 
               return "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='LoadPriceAgreementParentAndChildDetails("+x.id+")'><span class='k-icon k-i-edit'></span></button>"
            } ,
            field: "", width: 40,
            attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#00bcd4" }
         }

      ]
   });
}

function PriceAgreementDataBind(PriceAgreementParentAndChildList) {
   var FilterData = PriceAgreementParentAndChildList[0];
   $('#ddlCustomer').data('kendoComboBox').value(FilterData.customerID);
   $('#ddlTestStandard').data('kendoComboBox').value(FilterData.testStandardID);
   $('#ddlCurrency').data('kendoComboBox').value(FilterData.currencyID);
   $('#txtDateOfAgreement').val(moment(FilterData.agreementDate).format('MM/DD/YYYY')); 
   $('#txtEffectiveFrom').val(moment(FilterData.effectiveDateFrom).format('MM/DD/YYYY'));
   $('#txtEffectiveTo').val(moment(FilterData.effectiveDateTo).format('MM/DD/YYYY'));
   $('#txtId').val(FilterData.id);
   $('#txtChildId').val(FilterData.childID);
   TestStandardPriceList = [];
   for (var i = 0; i < PriceAgreementParentAndChildList.length; i++) {
      var o = new Object();
      o.ChildID = PriceAgreementParentAndChildList[i].childID;
      o.ParentID = PriceAgreementParentAndChildList[i].parentID;
      o.TestStandardID = PriceAgreementParentAndChildList[i].testStandardID;
      o.TestStandardName = PriceAgreementParentAndChildList[i].testStandardName;
      o.CurrencyName = PriceAgreementParentAndChildList[i].currencyName;
      o.CurrencyID = PriceAgreementParentAndChildList[i].currencyID;
      o.RegularPrice = PriceAgreementParentAndChildList[i].regularPrice;
      o.ExpressPrice = PriceAgreementParentAndChildList[i].expressPrice;
      /*o.SampleTypeID = PriceAgreementParentAndChildList[i].sampleTypeID;*/
      o.SampleTypeID = 1;

      TestStandardPriceList.push(o);
   }
   
   BindTestStandardPriceTable(TestStandardPriceList);
   /*$('#btnSave').text("Update");*/  
}

function SaveAgreement() {
   var requestObj = new Object();
   var validate = true;
   validate = Validate();
   if (validate == true) {
      requestObj.ID = $("#txtId").val() == "" ? 0 : $("#txtId").val();
      requestObj.CustomerID = $("#ddlCustomer").data('kendoComboBox').value();
      requestObj.AgreementDate = $("#txtDateOfAgreement").val();
      requestObj.EffectiveDateFrom = $("#txtEffectiveFrom").val(); 
      requestObj.EffectiveDateTo = $('#txtEffectiveTo').val() == "" ? "" : moment($('#txtEffectiveTo').val()).format('YYYY-MM-DD');
      requestObj.Description = $("#txtRemarks").val();
      requestObj.Signee_id = $("#txtSigneeID").val() == "" ? "" : $("#txtSigneeID").val();
      requestObj.customerSideSigneeName = "";
      requestObj.customerSideSigneeDesignation = "";
      requestObj.isActive = true;
      requestObj.PriceAgreementChildList = TestStandardPriceList; 
      $.ajax({
         url: "/PriceAgreement/PriceAgreementSave",
         type: "POST",
         dataType: "json",
         data: requestObj,
         success: function (data) { 
            if (data.statusCode == 200) {
               toastr.success(data.message, 'Success'); 
               LoadPriceAgreementSearchData();
               PriceAgreementDetailsList = data.data;
               PriceAgreementDataBind(PriceAgreementDetailsList);
               
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
function Validate() {
   if ($("#ddlCustomer").data('kendoComboBox').value() == "" || $("#ddlCustomer").data('kendoComboBox').selectedIndex == -1) {
      $("#ddlCustomer").data('kendoComboBox').focus();
      $("#ddlCustomer").data('kendoComboBox').open();
      toastr.warning('Please input Customer Name', "Warning");
      return false;
   }
   else if ($('#txtDateOfAgreement').val() == "") {
      $('#txtDateOfAgreement').focus();
      toastr.warning('Please input Date Of Agreement', "Warning");
      return false;
   }

   else if (($('#txtEffectiveFrom').val() == "" || $('#txtEffectiveFrom').val() == "1/1/0001 12:00:00 AM")) {
      $('#txtEffectiveFrom').focus();
      toastr.warning('Please input Effective From', "Warning");
      return false;
   }
   else if ($('#txtEffectiveTo').val() == "") {
      $('#txtEffectiveTo').focus();
      toastr.warning('Please input Effective To', "Warning");
      return false;
   } 
   else if ($("#ddlCurrency").data('kendoComboBox').value() == "" || $("#ddlCurrency").data('kendoComboBox').selectedIndex == -1) {
      $("#ddlCurrency").data('kendoComboBox').focus();
      $("#ddlCurrency").data('kendoComboBox').open();
      toastr.warning('Please input Currency', "Warning");
      return false;
   }
   else if ($("#ddlTestStandard").data('kendoComboBox').value() == "" || $("#ddlTestStandard").data('kendoComboBox').selectedIndex == -1) {
      $("#ddlTestStandard").data('kendoComboBox').focus();
      $("#ddlTestStandard").data('kendoComboBox').open();
      toastr.warning('Please input TestStandard Name', "Warning");
      return false;
   }
   else if (TestStandardPriceList.length == 0) {
      toastr.warning('Please Add Atleast one TestStandardPrice List', "Warning");
      return false;
   }
   else if ($('#txtregular_').val() == "") {
      $('#txtregular_').focus();
      toastr.warning('Please input Regular Price', "Warning");
      return false;
   }
   var regularPriceValue = $(regularId).val() == undefined ? 0 : $(regularId).val();
   var expressPriceValue = $(expressId).val() == undefined ? 0 : $(expressId).val();
   var numberPattern = /^[0-9]+$/;

   if (!numberPattern.test(regularPriceValue)) {
      $('#txtregular_').focus();
      toastr.warning('Invalid input. Please enter a valid Regular Price', "Warning");
      return false;
   } 

   if ($('#txtexpressPrice_').val() == "") {
      $('#txtexpressPrice_').focus();
      toastr.warning('Please input Express Price', "Warning");
      return false;
   }
   var expressinputValue = $('#txtexpressPrice_').val();

   if (!numberPattern.test(expressPriceValue)) {
      $('#txtregular_').focus();
      toastr.warning('Invalid input. Please enter a valid Express Price', "Warning");
      return false;
   } 
   return true;
}
function SetMinimumDateForEffectiveToDate() {
   var fromDate = $('#txtEffectiveFrom').val();
   if (fromDate == '') {
      $("#txtEffectiveTo").kendoDatePicker({
         min: new Date()
      });
   } else {
      $("#txtEffectiveTo").kendoDatePicker({
         min: kendo.parseDate(fromDate)
      });
   }
}
function ClearAll() {
   $('#ddlSearchCustomer').data('kendoComboBox').value('');
   $('#txtSearchAgreementFromDate').data('kendoDatePicker').value('');
   $('#txtSearchAgreementToDate').data('kendoDatePicker').value('');
   $('#txtSearchEffectiveFromDate').data('kendoDatePicker').value('');
   $('#txtSearchEffectiveToDate').data('kendoDatePicker').value('');
}
function ClearAgreement() {
   $("#txtId").val('');
   $("#ddlCustomer").data('kendoComboBox').value('');
   $('#txtDateOfAgreement').data('kendoDatePicker').value('');
   $("#txtDateOfAgreement").data('kendoDatePicker').value('');
   $("#txtEffectiveFrom").data('kendoDatePicker').value('');
   $('#txtEffectiveTo').data('kendoDatePicker').value('');
   $("#txtRemarks").val('');
   $("#txtSigneeID").val('');
   $("#ddlCurrency").data('kendoComboBox').value('');
   $("#ddlTestStandard").data('kendoComboBox').value('');
   TestStandardList = []
   BindTestStandardPriceTable(TestStandardList);
}