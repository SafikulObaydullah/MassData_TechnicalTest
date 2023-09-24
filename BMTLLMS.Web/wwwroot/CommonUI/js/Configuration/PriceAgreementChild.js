var PriceAgreementChildList = []
var PriceAgreementParentList = []
var TestStandardList = []
var SampleTypeList = []
var CurrencyList = []
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);


$(document).ready(function () {
   PriceAgreementChildLoad();
   PriceAgreementParentLoad();
   TestStandardLoad();
   SampleTypeLoad();
   CurrencyLoad();
   $("#cmbPriceAgreementParent").kendoComboBox({
      dataTextField: "customerSideSigneeName",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Customer Name'
   });
   $("#cmbTestStandard").kendoComboBox({
      dataTextField: "testStandardName",
      dataValueField: "testStandardID",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select TestStandard Name'
   });
   $("#cmbSampleType").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Sample Type'
   });
   $("#cmbCurrency").kendoComboBox({
      dataTextField: "name",
      dataValueField: "id",
      dataSource: [],
      filter: "contains",
      suggest: true,
      placeholder: 'Select Currency '
   });
   $(function () {
      $("[data-role=combobox]").each(function () {
         var widget = $(this).getKendoComboBox();
         widget.input.on("focus", function () {
            widget.open();
         });
      });
   });
});
function PriceAgreementParentLoad() {
   $.ajax({
      url: "/PriceAgreementParent/GetPriceAgreementParent",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            PriceAgreementParentList = data; 
            $("#cmbPriceAgreementParent").data('kendoComboBox').dataSource.data([]);
            $('#cmbPriceAgreementParent').data('kendoComboBox').dataSource.data(PriceAgreementParentList);
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
function SampleTypeLoad() {
   $.ajax({
      url: "/SampleType/GetSampleType",
      method: "GET",
      dataType: "json",
      success: function (data) {
         if (data.statusCode = "200") {
            SampleTypeList = data; 
            $("#cmbSampleType").data('kendoComboBox').dataSource.data([]);
            $('#cmbSampleType').data('kendoComboBox').dataSource.data(SampleTypeList);
         }
         else {

         }
      },
      error: function (jqXHR, textStatus, errorThrown) {
         console.log("Error:", textStatus, errorThrown);
      }
   });

}
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
function PriceAgreementChildLoad() {
    $.ajax({
       url: "/PriceAgreementChild/GetPriceAgreementChild",
        method: "GET",
       dataType: "json",
       success: function (data) {
          PriceAgreementChildList = data; 
          PriceAgreementChildDataBind();
          PriceAgreementParentLoad();
          TestStandardLoad();
          SampleTypeLoad();
          CurrencyLoad();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}
function PriceAgreementChildDataBind() {
    var i = 1;
    _.map(PriceAgreementChildList, function (o) {
        o.sl = i;
        i++;
    });

    $("#gridTable").kendoGrid({
        dataSource: PriceAgreementChildList,
        sortable: true,
        toolbar: ["search"],
        search: {
           fields: ["testStandardName","sampleTypeName"]
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
              title: "Test Standard Name",
              field: "testStandardName", width: 50,
              headerAttributes: { style: "text-align: left;" },
              attributes: { style: "text-align: left;" }

           },
           {
              title: "SampleType Name",
              field: "sampleTypeName", width: 50,
              headerAttributes: { style: "text-align: left;" },
              attributes: { style: "text-align: left;" }
           },
           {
              title: "RegularPrice",
              field: "regularPrice",
              width: 50,
              headerAttributes: { style: "text-align: left;" },
              attributes: { style: "text-align: left;" }
           },
           {
              title: "ExpressPrice",
              field: "expressPrice",
              width: 50,
              headerAttributes: { style: "text-align: left;" },
              attributes: { style: "text-align: left;" }
           },
           {
              title: "Currency Name",
              field: "currencyName",
              width: 50,
              headerAttributes: { style: "text-align: left;" },
              attributes: { style: "text-align: left;" }
           },
           {
              title: "Note",
              field: "note", width: 50,
              headerAttributes: { style: "text-align: left;" },
              attributes: { style: "text-align: left;" }
           },
            {
               title: "Action",
               template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
               field: "", width: 20,
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
      o.parentID = $('#cmbPriceAgreementParent').val();
      o.currencyID = $('#cmbCurrency').val();
      o.testStandardID = $('#cmbTestStandard').val();
      o.sampleTypeID = $('#cmbSampleType').val();
      o.regularPrice = $('#RegularPrice').val();
      o.expressPrice = $('#ExpressPrice').val();
      o.note = $('#Note').val();
      o.isActive = $('#isActive').is(':checked') ? true : false;
        $.ajax({
           url: "/PriceAgreementChild/PriceAgreementChildSave",
            type: "POST",
            dataType: "json",
            data: o,
            success: function (data) {
                if (data.code == 200) {
                    toastr.success(data.message, 'Success');
                    PriceAgreementChildLoad();
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
   var FilterData = _.filter(PriceAgreementChildList, function (item) { return item.id == id });
   $('#cmbPriceAgreementParent').data('kendoComboBox').value(FilterData[0].customerSideSigneeName);
   $('#cmbCurrency').data('kendoComboBox').value(FilterData[0].currencyID);
   $('#cmbTestStandard').data('kendoComboBox').value(FilterData[0].testStandardID);
   $('#cmbSampleType').data('kendoComboBox').value(FilterData[0].sampleTypeID);
   $('#RegularPrice').val(FilterData[0].regularPrice); 
   $('#ExpressPrice').val(FilterData[0].expressPrice); 
   $('#Note').val(FilterData[0].note);
   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
   $('#mdlUserReg').modal('toggle')
   $('#btnSave').text('Update');
   $('#btnSave').addClass('btn btn-ghost-info active w-10');
}


function AddNew() {
   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
   $('#spanParentID').html(0);
   $('#RegularPrice').val(''); 
   $('#ExpressPrice').val(''); 
   $('#Note').val('');
   $('#cmbPriceAgreementParent').data('kendoComboBox').value('');
   $('#cmbCurrency').data('kendoComboBox').value('');
   $('#cmbTestStandard').data('kendoComboBox').value('');
   $('#cmbSampleType').data('kendoComboBox').value('');
   $('#mdlUserReg').modal('toggle');
   $('#btnSave').text('Save');
   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
}

function Validate() {
   if ($('#RegularPrice').val() == "") {
      $('#RegularPrice').focus();
      toastr.warning('Please input RegularPrice');
      return false;
    } 
   if ($('#ExpressPrice').val() == "") {
      $('#ExpressPrice').focus();
      toastr.warning('Please input ExpressPrice');
      return false;
   } 
   if ($('#Note').val() == "") {
      $('#Note').focus();
      toastr.warning('Please input Note');
      return false;
   }
   if ($("#cmbPriceAgreementParent").data('kendoComboBox').value() == "" || $("#cmbPriceAgreementParent").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbPriceAgreementParent").data('kendoComboBox').focus();
      $("#cmbPriceAgreementParent").data('kendoComboBox').open();
      toastr.warning('Please input PriceAgreementParent Name', "Warning");
      return false;
   }
   if ($("#cmbTestStandard").data('kendoComboBox').value() == "" || $("#cmbTestStandard").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbTestStandard").data('kendoComboBox').focus();
      $("#cmbTestStandard").data('kendoComboBox').open();
      toastr.warning('Please input TestStandard Name', "Warning");
      return false;
   }
   if ($("#cmbSampleType").data('kendoComboBox').value() == "" || $("#cmbSampleType").data('kendoComboBox').selectedIndex == -1) {
      $("#cmbSampleType").data('kendoComboBox').focus();
      $("#cmbSampleType").data('kendoComboBox').open();
      toastr.warning('Please input SampleType Name', "Warning");
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
