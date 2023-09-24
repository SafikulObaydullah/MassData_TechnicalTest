var TestReportStatus = [
   {
      statusID: 0,
      statusName: 'Pending'
   },
   {
      statusID: 1,
      statusName: "Done"
   },
   {
      statusID: -1,
      statusName: "All"
   },
   
]
var SamplesSpecificationHeadList = [];
var SampleReceive = [];
SamplePhysicalConditionList = [];
var OrderDetailsList = []
var tempArray = []
var CustomerList = [];
var currentDate = new Date();
var year = currentDate.getFullYear();
var month = (currentDate.getMonth() + 1).toString().padStart(2, '0'); // Adding 1 because months are zero-based
var day = currentDate.getDate().toString().padStart(2, '0');
var formattedDate = month + "/" + day + "/" + year;
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
   LoadInitalData(); 
   var start = new Date();
   var end = new Date(start.getFullYear(), start.getMonth(), start.getDate() - 60);

   $("#orderDateFrom").kendoDatePicker();
   $("#orderDateTo").kendoDatePicker();
   $("#deliveryDateFrom").kendoDatePicker();
   $("#deliveryDateTo").kendoDatePicker();

   //$("#orderDateFrom").val(formattedDate);
   //$("#orderDateTo").val(formattedDate);
   //$("#deliveryDateFrom").val(formattedDate);
   //$("#deliveryDateTo").val(formattedDate);

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
   $("#ddlCustomer").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Customer',
      delay: 100
   }).data("kendoComboBox");  
   $("#ddlSampleStatus").kendoComboBox({
      dataTextField: "statusName",
      dataValueField: "statusID",
      placeholder: "Select Test Report Status...",
      dataSource: TestReportStatus,
   }); 
   $("#ddlSampleStatus").data("kendoComboBox").select(0);
   $("#sampleReceiveTime").kendoTimePicker({
      dateInput: true
   });
}); 
function LoadInitalData() {
   $.ajax({
      url: "/SampleReceive/GetInitialData",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            SamplePhysicalConditionList = data.samplePhysicalCondtion;
            SampleReceive = data.specificationHead;
            CustomerList = data.customer;
            OrderDetailsList = data.orderList;
            console.log("dddd",OrderDetailsList);
            $("#ddlCustomer").data('kendoComboBox').dataSource.data([]);
            $('#ddlCustomer').data('kendoComboBox').dataSource.data(CustomerList);
            BindTestListGrid(); 
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });
}
function AddNew() {
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0); 
   $('#orderSampleReceiveModal').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}
function BindTestListGrid() {
   
   var i = 1;
   _.map(OrderDetailsList, function (obj) {
      obj.sl = i;
      i++;
   });
   $("#gridSearch").kendoGrid({
      dataSource: {
         data: OrderDetailsList
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
            field: "sl",
            title: "SL",
            width: 35,
            headerAttributes: {
               style: "text-align: center;font-weight: bold;background-color:#00bcd4"
            },
            attributes: { style: "text-align: center;" }
         }, 
        
         {
            field: "customerName", width: 120,
            title: "Customer",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            field: "id", width: 60,
            title: "Order ID",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            field: "sampleType", width: 70,
            title: "Sample Type",
            template: "#= sampleCategory + ' (' + sampleType +')' #",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            field: "qtyPerSample", width: 60,
            title: "Min. Req. Quantity",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            width: 200,
            field: "description",
            title: "Description",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            //template: function (TestReportStatus,x) { 
            //   if (x.StatusID == 2) {
            //      return "Done"
            //   }
            //   else {
            //      return "Pending"
            //   }
            //},
            width: 70,
            field:"statusName",
            title: "Sample Status",
            attributes: {
               style: "text-align:left;"
            },
            headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
         },
         {
            template: function (x) {
               return "<button class='k-button k-primary' style='cursor:pointer;background-color:#7ea700;border-color:#7ea700' onclick='SearchPanel(" + x.id + "," + x.sampleTypeID + ")'>Receive</button>"
            },
            width: 90,
            title: "Action",
            attributes: {
               style: "text-align:center;"
            },
            headerAttributes: { style: "text-align:center;font-weight: bold;background-color:#00bcd4" }
         }

      ]
   });
} 
function AddSampleSpecification() {
   console.log("SampleReceive value",SampleReceive);
   $("#spanSpecification").html('');
   tempArray = [];
   debugger;
   for (var i = 0; i < SampleReceive.length; i++) {
      console.log($("#check_" + SampleReceive[i].id).is(":checked"));
      console.log($("#txt_" + SampleReceive[i].id).val());
      if ((($("#check_" + SampleReceive[i].id).is(":checked") === true) && (($("#txt_" + SampleReceive[i].id).val() === "") || ($("#txt_" + SampleReceive[i].id).val() === null)))) {
         toastr.warning("Please input " + SampleReceive[i].name, "Warning");
         $('#sampleSpecificationModal').modal('show');
         return false;
      }
   } 

   //for (var i = 0; i < SampleReceive.length; i++) {
   //   // var isChecked = $("#check_" + SampleReceive[i].id).is(":checked");
   //   $('#id').is(':checked')
   //   console.log("Check value = ", document.querySelector('input[name="E1019"]:checked') ? true : false);
   //      toastr.warning("Please input " + SampleReceive[i].name, "Warning");
   //      $('#sampleSpecificationModal').modal('show');
   //      return false;
   //}
   
   

   for (var i = 0; i < SampleReceive.length; i++) {
      // if ((($("#check_" + SampleReceive[i].id).is(":checked") === true) && (($("#txt_" + SampleReceive[i].id).val() !== "") || ($("#txt_" + SampleReceive[i].id).val() !== null)))) {
       //if ((($("#check_" + SampleReceive[i].id).is(":checked") === true))) {
            var obj = new Object();
            obj.namevalue = $("#txt_" + SampleReceive[i].id).val();
            obj.name = SampleReceive[i].name;
            obj.measurementUnitName = SampleReceive[i].measurementUnitName;  
            tempArray.push(obj); 
       //}
   }
   debugger;
   console.log(tempArray);
var SampleHtml = "";
      for (var i = 0; i < tempArray.length; i++) { 
         if (i < tempArray.length - 1) {
            SampleHtml += tempArray[i].name + " "+ tempArray[i].namevalue + " " + tempArray[i].measurementUnitName + ' , ';
         }
         else {
            SampleHtml += tempArray[i].name +" "+ tempArray[i].namevalue + " " + tempArray[i].measurementUnitName;
         } 
      }
     $("#spanSpecification").html(SampleHtml);
     
      if (tempArray.length > 0) {
         $('#sampleSpecificationModal').modal('hide');
      } 
      //GetSamplesSpecificationList();
   GetSamplesSpecificationList(tempArray);
}
function CloseModal() {
   $('#mdlSearchPanel').modal('toggle');
}
function Search() {
   var o = new Object();
   var validate = true;
   validate = SearchValidate();
   if (validate == true) {
      o.orderRefNo = $("#txtOrderRefNo").val();
      o.orderDateFrom = $("#orderDateFrom").val() == "" ? "" : moment($('#orderDateFrom').val()).format('YYYY-MM-DD');
      o.orderDateTo = $("#orderDateTo").val() == "" ? "" : moment($('#orderDateTo').val()).format('YYYY-MM-DD');
      o.customerID = $("#ddlCustomer").data('kendoComboBox').value() == "" ? 0 : $("#ddlCustomer").data('kendoComboBox').value();
      o.statusID = $("#ddlSampleStatus").data('kendoComboBox').value() == "" ? 2 : $("#ddlSampleStatus").data('kendoComboBox').value();
      o.deliveryDateFrom = $("#deliveryDateFrom").val() == "" ? "" : moment($('#deliveryDateFrom').val()).format('YYYY-MM-DD');
      o.deliveryDateTo = $("#deliveryDateTo").val() == "" ? "" : moment($('#deliveryDateTo').val()).format('YYYY-MM-DD');
      $.ajax({
         url: "/SampleReceive/SearchResult",
         method: "GET",
         dataType: "json",
         data: o,
         success: function (data) {
            OrderDetailsList = data;
            console.log("OrderDetailsList == ", OrderDetailsList);
            BindTestListGrid();
         }
      });
   }
}
function SearchPanel(id, sampleTypeID) {
   console.log("OrderDetailsList data value set",OrderDetailsList);
   var FilterData = _.filter(OrderDetailsList, function (item) { return item.id == id && item.sampleTypeID == sampleTypeID });
   $('#spanOrderRef').text(FilterData[0].id);
   $('#spanCustomer').text(FilterData[0].customerName);
   $('#spanSampleCategory').text(FilterData[0].sampleCategory);
   $('#spanSampleType').text(FilterData[0].sampleType);
   $('#spanSampleID').text(FilterData[0].sampleID);
   $('#spanSpecificationID').text(FilterData[0].specificationID);
   $('#spanReqNumberOfSamplePcs').text(FilterData[0].reqNumberOfSamplePcs);
   $('#spanMeasurementUnit').text(FilterData[0].measurementUnitName);
   $('#spanMinimumReqQuantity').text(FilterData[0].qtyPerSample);
   $('#spanTestStandard').text(FilterData[0].description);
   SamplePhysicalCondition();
   $('#orderSampleReceiveModal').modal('toggle');
}
function CloseModal() {
   $('#orderSampleReceiveModal').modal('toggle');
}
function SampleSpecification() {
   $("#mainContent").html(''); 
   var html = ""; 
   for (var i = 0; i < SampleReceive.length; i++) {
      html += "<div class='row g-3 mt-0' style='justify-content:left;'><span id='spanSampleSpecificationParentID' style='display:none'>0</span>" +
         "<div class='col-md-3' style='margin-top:28px'>" +
         "<input id='check_" + SampleReceive[i].id + "' name='E1019' style='margin-right:5px;' type='Checkbox'/><span>" + SampleReceive[i].name + "</span>" +
         "</div>" +
         "<div class='col-md-6'>" +
         "<input id='txt_" + SampleReceive[i].id + "' role='' type='number' class='form-control' style='width:100%' onblur='checkEmptyInput(this)'/>" +
          "</div>"+
        "</div>";
   }
    $("#mainContent").append(html);
    $('#sampleSpecificationModal').modal('toggle');
}
function SamplePhysicalCondition() {
   $("#divphysicalCondition").html('');
   var html = "";
   for (var i = 0; i < SamplePhysicalConditionList.length; i++) {
      html += '<label class="checkbox-inline">' +
         '<input name="samplePhysicalCondition" value="' + SamplePhysicalConditionList[i].id +'" id="check_' + SamplePhysicalConditionList[i].id + '" style = "margin-right:5px" type ="radio" /><span style = "margin-right:9px">' + SamplePhysicalConditionList[i].name + '</span>' +
         '</label>';
   }///*value="' + SamplePhysicalConditionList[i].id+'"*/
   $("#divphysicalCondition").html(html);
}
function checkEmptyInput(inputElement) {
    if (inputElement.value.trim() === "") {
        inputElement.style.border = "1px solid red";
    } else {
        inputElement.style.border = "1px solid #ced4da"; 
    }
}
function SearchValidate() {
   //if ($('#orderDateFrom').val() == "") {
   //    $('#orderDateFrom').focus();
   //   toastr.warning('Please input Order Date From', "Warning");
   //   return false;
   //  }
    if (($('#orderDateTo').val() == "") && ($('#orderDateFrom').val() !== "")) {
      $('#orderDateTo').focus();
      toastr.warning('Please input Order Date To', "Warning");
      return false;
     }
   //else if (($('#deliveryDateFrom').val() == "") && ($('#orderDateTo').val() == "")) {
   //    $('#deliveryDateFrom').focus();
   //    toastr.warning('Please input Delivery Date From', "Warning");
   //   return false;
   // }
     else if (($('#deliveryDateTo').val() == "") && ($('#deliveryDateFrom').val() != "")) {
       $('#deliveryDateTo').focus();
       toastr.warning('Please input Delivery Date To', "Warning");
      return false;
   }
   return true;
}
function SaveSampleReceive() {
   var obj = new Object();
   var validate = true;
   validate = Validate();
   if (validate == true) {
      obj.id = $('#spanParentID').html();
      obj.SampleID = $('#spanSampleID').text();
      obj.SpecificationID = $('#spanSpecificationID').text();
      obj.SampleConditionID = document.querySelector('input[name="samplePhysicalCondition"]:checked').value;
      obj.NumberOfSamplePcs = $('#spanReceivingNoOfPcs').val();
      obj.QtyPerSample = $('#spanReceivingQtyPerSample').val();
      obj.Note = $('#txtNote').val(); 
      obj.isActive = true; //$('#isActive').is(':checked') ? true : false;
      debugger;
      obj.SamplesSpecificationList = SamplesSpecificationHeadList;
      $.ajax({
         url: "/SampleReceive/SaveSampleReceive",
         type: "POST",
         dataType: "json",
         data: obj,
         success: function (data) {
            if (data.code == 200) {
               toastr.success(data.message, 'Success');
               $('#orderSampleReceiveModal').modal('hide');
               LoadInitalData();
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
var SampleArray = [];
function GetSamplesSpecificationList(data) {
   var o = new Object(); 
      o.SampleID = $("#spanSampleID").text();
      o.SpecificationID = $('#spanSpecificationID').text();
      //o.SpecificationValue = $("#txt_" + SampleReceive[0].id).val();
      o.Creator = 1;
      o.CreationDate = '08-21-2023'
   for (var i = 0; i < data.length; i++) {
      debugger;
      console.log(document.querySelector('input[name="E1019"]:checked'));
      //if (document.querySelector('input[name="E1019"]:checked').value === true) {
      //if (($("#check_" + data[i].id).is(":checked") === true)) {

          console.log($("#txt_" + data[i].namevalue).val());
            //SampleArray[i] = $("#txt_" + data[i].namevalue).val();
            SampleArray[i] = data[i].namevalue;
            //SamplesSpecificationHeadList[i] = $("#txt_" + SampleReceive[i].id).val();
         //}   
      }
      o.Specifications = SampleArray;
      SamplesSpecificationHeadList.push(o);
      console.log(SamplesSpecificationHeadList);

      //var FilterData = _.filter(SamplesSpecificationHeadList, function (item) {
      //   return item.TestStandardID == o.TestStandardID &&
      //      item.CurrencyID == o.CurrencyID

      //});
      //if (FilterData.length > 0) {
      //   toastr.warning("Already Added", "Waring");
      //}
      /*else {*/
         //SamplesSpecificationHeadList.push(o);
         //BindTestStandardPriceTable(SamplesSpecificationHeadList);
      //}
}
function SampleSpecificationValidate() {

   return true
}
function Validate() {
   if ($('#spanReceivingNoOfPcs').val() == "") {
      $('#spanReceivingNoOfPcs').focus();
      toastr.warning('Please input Receiving No. of (Pcs)', "Warning");
      return false;
   }
   else if ($('#spanReceivingQtyPerSample').val() == "") {
      $("#spanReceivingQtyPerSample").focus();
      toastr.warning("Please input Receiving Qty per Sample", "Warning");
      return false;
   }
   else if (document.querySelector('input[name="samplePhysicalCondition"]:checked') == null) {
      toastr.warning("Please input Physical Condition of Sample", "Warning");
      return false;
   }
   else if (document.querySelector('input[name="samplePhysicalCondition"]:checked').value == "") {
      toastr.warning("Physical condition of Sample is empty");
      return false;
   }
   return true;

}

function ClearAll() {
   $("#spanReceivingNoOfPcs").val('');
   $("#spanReceivingQtyPerSample").val('');
   $("#txtSampleReceiveNote").val('');
}



