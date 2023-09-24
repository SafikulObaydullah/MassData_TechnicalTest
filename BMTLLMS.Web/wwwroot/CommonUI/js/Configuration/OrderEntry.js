var CustomerList = [];
var ProjectList = [];
var CurrencyList = [];
var TestStandardList = [];
var SampleInfo = [];
var FilteredList = [];

var TestStandardfilteredList = [];
var ProducerList = [];
var PaymentMethodList = [];
var MeasurementUnitList = [];
var SaveDataList = [];
var qtyPerSample = 0
var reqNumberOfSamplePcs = 0;
var deliveryType = 0;
var SampleInfoArrayList = [];
//var Tolal = 0;
var sum = 0;
var netOrderVal = 0;
var todayDate = kendo.toString(kendo.parseDate(new Date()), 'MM/dd/yyyy');

var GID = 0;


$(document).ready(function () {

    LoadInitialData();

    $(function () {
        $("[data-role=combobox]").each(function () {
            var widget = $(this).getKendoComboBox();
            widget.input.on("focus", function () {
                widget.open();
            });
        });
    });




    //Retrieve the ID from the URL query parameter start

    // Get the ID from the URL query parameter
    const urlParams = new URLSearchParams(window.location.search);
    GID = urlParams.get('id');

    // Check if the ID exists and use it as needed
    if (GID) {
        LoadorderDetail();

    } else {
        console.log("ID not found in the URL.");
    }


    //Retrieve the ID from the URL query parameter end







    //stepper start




    stepperOrder = $("#stepper").kendoStepper({

        linear: false,
        steps: [{
            label: "General Info",
            icon: "user",
            selected: true
        }, {
            label: "Test Sample Info",
            icon: "info"

        }, {
            label: "Order Summery",
            icon: "flip-vertical"


        }]
    });


    $("#stepper1_Next").click(function () {


        // validateFirstStepper for next button

        var stepperValidate = true;
        stepperValidate = ValidateFirstStepper();
        if (stepperValidate == true) {
            var stepper = $("#stepper").data("kendoStepper");
            stepper.next();
            showStepDiv(2);
        }
        else {
            showStepDiv(1);
        }

    });

    $("#stepper2_Prev").click(function () {
        var stepper = $("#stepper").data("kendoStepper");
        stepper.previous();
        showStepDiv(1);
    });
    $("#stepper2_Next").click(function () {
        var stepper = $("#stepper").data("kendoStepper");
        stepper.next();
        showStepDiv(3);
    });
    $("#stepper3_Prev").click(function () {
        var stepper = $("#stepper").data("kendoStepper");
        stepper.previous();
        showStepDiv(2);
    });
    // Show the div for the initially selected step
    showStepDiv(1);

    // Event handler for the click event of the stepper steps
    $("#stepper").on("click", ".k-step", function () {

        var stepperValidate = true;
        stepperValidate = ValidateFirstStepper();
        if (stepperValidate == true) {
         
            //api call
            // SampleInfoData();

            var selectedStep = $(this).index() + 1;
            if (selectedStep == 2) {
                SampleInfoData();
            }
            showStepDiv(selectedStep);

        } else {
            var stepper = $("#stepper").data("kendoStepper");
            stepper.previous();
            showStepDiv(1);
        }


    });

    function showStepDiv(step) {



        // Hide all step divs
        $(".stepDiv").hide();

        // Show the div for the currently selected step
        $("#step" + step + "Div").show();


    }
    //stepper end




    //next button start
    const steps = $('.stepDiv');
    const nextButton = $('#nextButton');
    let currentStep = 0;

    nextButton.click(function () {
        steps.eq(currentStep).hide(); // Hide current step
        currentStep = (currentStep + 1) % steps.length; // Increment and loop back

        steps.eq(currentStep).show(); // Show next stepstepper
        var upperStepsCount = currentStep + 1;
        stepper.select(upperStepsCount);
    });

    // Show the first step initially
    steps.eq(currentStep).show();

    //next button end


    //--------------------------first stepper kendo function--------------------------------

    //Customer combo
    $("#cmbCustomer").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select customer ',
        change: function () {
            var selectedCustomerId = this.value(); // Get the selected customer ID

            // Find the selected customer in the CustomerList array
            var selectedCustomer = CustomerList.find(function (customer) {
                return customer.id == selectedCustomerId;
            });

            if (selectedCustomer) {
                // Populate the related form fields
                $("#contactPersonName").val(selectedCustomer.contactPersonName);
                $("#contactAddress").val(selectedCustomer.contactAddress);
                $("#contactEmail").val(selectedCustomer.contactEmail);
                $("#contactPhone").val(selectedCustomer.contactPhone);
            }
        }

    });

    //project combo

    $("#cmbProject").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select project ',
    });

    //currency combo
    $("#cmbCurrency").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select currency'
    });



    //$(".Kdatepicker").bind("focus", function () {
    //    $(this).data("kendoDatePicker").open();
    //});
    //$("#orderDate").kendoDatePicker({
    //    dateInput: true,
    //    format: "dd-MM-yyyy"
    //});


    $(".Kdatepicker").bind("focus", function () {
        $(this).data("kendoDatePicker").open();
    });


    $("#orderDate").kendoDatePicker();
    $("#orderDate").data("kendoDatePicker").value(todayDate);





    //------------------------------------2nd stepper kendo function------------------------



    $("#cmbSampleName").kendoComboBox({
        dataSource: [],
        dataTextField: "sampleCategoryName",
        dataValueField: "sampleCategoryId",
        change: function () {
            var selectedValue = this.value();
            console.log(selectedValue);
            updateSampleTypeComboBox(selectedValue);
        }
    });
    $("#cmbSampleType").kendoComboBox({
        dataSource: [],
        dataTextField: "sampleTypeName",
        dataValueField: "sampleTypeID",
        change: function () {
            var selectedValue = this.value();
            updateTestStandardComboBox(selectedValue);
        }
    });


    //$("#cmbTestStandard").kendoComboBox({
    //    dataTextField: "testStandardName",
    //    dataValueField: "testStandardID",
    //    dataSource: [],
    //    filter: "contains",
    //    suggest: true,
    //    placeholder: 'Select test standard ',
    //    change: function () {
    //        var selectedValue = this.value();
    //        getTestType(selectedValue);
    //    }
    //});

    //multi select

    $("#cmbTestStandard").kendoMultiSelect({
        dataTextField: "testStandardName",
        dataValueField: "testStandardID",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select test standard ',
        downArrow: true,
        noDataTemplate: $("#noDataTemplate").html(),
        change: function () {
            var selectedValue = this.value();
            getTestType(selectedValue);
        }
    });



    $("#cmbProducer").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: [],
        filter: "contains",
        suggest: true,
        placeholder: 'Select producer ',
    });
    deliveryType = 1;


});


function SampleInfoData(isSearch) {
    
    var obj = new Object();
    obj.CustomerId = $("#cmbCustomer").data('kendoComboBox').value();
    obj.CurrencyCode = $("#cmbCurrency").data('kendoComboBox').value();

    $.ajax({
        url: "/OrderEntry/GetSampleInfoByParam",
        method: "POST",
        dataType: "json",
        data: obj,
        success: function (data) {
            if (data.statusCode = "200") {

                SampleInfo = data.sampleInfo;
                console.log("SampleInfo", SampleInfo);

                //producer combo data source update
                $("#cmbProducer").data('kendoComboBox').dataSource.data([]);
                $('#cmbProducer').data('kendoComboBox').dataSource.data(ProducerList);



                //SampleInfo combo data source update
                var uniqListCategory = _.uniq(SampleInfo, item => item.sampleCategoryId);
                //$("#qtyPerSample").val(uniqListCategory[0].qtyPerSample);
                $("#cmbSampleName").data("kendoComboBox").setDataSource(uniqListCategory);

            }
            else {

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    }).done(function (data, textStatus, jqXHR) {

        if (isSearch == 1) {
            debugger
            //SaveDataList
            $("#cmbSampleName").data('kendoComboBox').value(SaveDataList[0].sampleCategoryID);
            updateSampleTypeComboBox(SaveDataList[0].sampleCategoryID);
           // var sampleCategoryID = SaveDataList[0].sampleCategoryID
           // updateSampleTypeComboBox(sampleCategoryID);
         

            updateTestStandardComboBox(SaveDataList[0].sampleTypeID);

        }


        //console.log("done", data);
        //updateSampleTypeComboBox();
        //updateTestStandardComboBox

    });

}


function LoadInitialData() {

    $.ajax({
        url: "/OrderEntry/GetInitalData",
        method: "GET",
        dataType: "json",
        success: function (data) {
            if (data.statusCode = "200") {
                CustomerList = data.customer;
                console.log(CustomerList)
                CurrencyList = data.currency;
                ProjectList = data.project;
                ProducerList = data.producer;
                PaymentMethodList = data.paymentMethod;
                MeasurementUnitList = data.measurement;


                //SampleInfo = data.sampleInfo;
                //console.log("SampleInfo", SampleInfo);

                ComboDataSourceUpdate();

            }
            else {

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });
}

function LoadorderDetail() {
    debugger

    $.ajax({
        url: "/OrderEntry/GetOrderDetail?GID="+GID,
        method: "POST",
        dataType: "json",
        success: function (data) {
            if (data.statusCode = "200") {

                SaveDataList = data.data

                UIBind(SaveDataList);
            }
            else {

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}




function ComboDataSourceUpdate() {

    console.log("CurrencyList", CurrencyList)
    //Customer combo data source update
    $("#cmbCustomer").data('kendoComboBox').dataSource.data([]);
    $('#cmbCustomer').data('kendoComboBox').dataSource.data(CustomerList);

    //Currency combo data source update
    $("#cmbCurrency").data('kendoComboBox').dataSource.data([]);
    $('#cmbCurrency').data('kendoComboBox').dataSource.data(CurrencyList);

    //Project combo data source update
    $("#cmbProject").data('kendoComboBox').dataSource.data([]);
    $('#cmbProject').data('kendoComboBox').dataSource.data(ProjectList);




}

function updateSampleTypeComboBox(selectedValue) {
   
    FilteredList = _.filter(SampleInfo, item => item.sampleCategoryId == selectedValue);
    var uniqListType = _.uniq(FilteredList, item => item.sampleTypeID);
    $("#cmbSampleType").data("kendoComboBox").setDataSource([]);
    $("#cmbSampleType").data("kendoComboBox").setDataSource(uniqListType);
    if (SaveDataList.length > 0) {
        $("#cmbSampleType").data('kendoComboBox').value(SaveDataList[0].sampleTypeName);
    }

}

function updateTestStandardComboBox(selectedValue) {
   
    console.log(FilteredList, selectedValue)
    TestStandardfilteredList = _.filter(FilteredList, item => item.sampleTypeID == selectedValue);
    //var uniqListStandard = _.uniq(TestStandardfilteredList, item => item.testStandardId);
    $("#cmbTestStandard").data("kendoMultiSelect").setDataSource([]);
    $("#cmbTestStandard").data("kendoMultiSelect").setDataSource(TestStandardfilteredList);
    console.log("777", TestStandardfilteredList);
    var arrayStnd = [];
    if (SaveDataList.length > 0) {
        for (var i = 0; i < SaveDataList.length; i++) {
            arrayStnd.push(SaveDataList[i].testStandardID)
        }
        $("#cmbTestStandard").data("kendoMultiSelect").value(arrayStnd);
    }
}

function getTestType(selectedValue) {

    qtyPerSample = 0;
    reqNumberOfSamplePcs = 0;
    //console.log("hello", selectedValue);
    for (var i = 0; i < selectedValue.length; i++) {
        TestList = _.filter(TestStandardfilteredList, item => item.testStandardID == selectedValue[i]);
        qtyPerSample = qtyPerSample + TestList[0].qtyPerSample;
        reqNumberOfSamplePcs = reqNumberOfSamplePcs + TestList[0].reqNumberOfSamplePcs;
        $("#QtyPersample").html(qtyPerSample);
        $("#minsamplePcs").html(reqNumberOfSamplePcs);
        $("#MessurementUnit").html(TestList[0].unitName);



        var myDiv = document.getElementById("myDiv");
        var myDiv0 = document.getElementById("myDiv0");
        var minsamplePcsValue = $("#minsamplePcs").html();
        console.log("rrrrrrr", minsamplePcsValue)

        if (minsamplePcsValue > 0) {
            myDiv.style.display = "block";
            myDiv0.style.display = "block";
        }


    }


    //var cmbMeasurementUnit = $("#cmbMeasurementUnit").data("kendoComboBox");

    // Set the value of the ComboBox
    //cmbMeasurementUnit.value(TestList[0].defaultMeasurementUnitId);
    //$("#reqNumberOfSamplePcs").val(TestList[0].reqNumberOfSamplePcs);
    //$("#qtyPerSample").val(TestList[0].qtyPerSample);


}





function AddSampleInfo() {
 

    //var obj = new Object()
    //obj.SampleCategoryId = $('#cmbSampleName').data('kendoComboBox').value();
    //debugger
    //obj.SampleCategoryName = $('#cmbSampleName').data('kendoComboBox').text();
    //obj.SampleTypeId = $('#cmbSampleType').data('kendoComboBox').value();
    //obj.SampleTypeName = $('#cmbSampleType').data('kendoComboBox').text();
    //obj.Producer = $('#cmbProducer').data('kendoComboBox').value();
    //obj.BatchLot = $('#batchLot').val();
    //obj.TestStandardId = $('#cmbTestStandard').data('kendoComboBox').value();
    //obj.TestStandardName = $('#cmbTestStandard').data('kendoComboBox').text();
    //obj.MeasurementUnitId = $('#cmbMeasurementUnit').data('kendoComboBox').value();
    //obj.TestId = TestList[0].testNameID;
    //obj.TestName = TestList[0].testName;
    //obj.RegularPrice = TestList[0].regularPrice;
    //obj.QtyPerSample = $("#qtyPerSample").val();
    //obj.ReqNumberOfSamplePcs = $("#reqNumberOfSamplePcs").val();
    //obj.Id = 0;
    //obj.ParentId = 0;

    //var FilterData = _.filter(SampleInfoArrayList, function (item) {
    //    return item.TestStandardId == obj.TestStandardId && item.SampleTypeId == obj.SampleTypeId &&  item.SampleCategoryId == obj.SampleCategoryId;
    //    // item.SampleTypeID == obj.SampleTypeId

    //});

    //if (FilterData.length > 0) {
    //    toastr.warning("Already Added", "Waring");
    //}
    //else {
    //    SampleInfoArrayList.push(obj);
    //    BindSampleInfoArrayTable(SampleInfoArrayList);
    //}
    //old--------------------


    var validate = true;
    validate = Validate();
    if (validate == true) {

        var testStandardIds = $("#cmbTestStandard").data("kendoMultiSelect").value();
        var sampleCategoryId = $('#cmbSampleName').data('kendoComboBox').value();
        var sampleTyepID = $('#cmbSampleType').data('kendoComboBox').value();
        var count = 0;
        for (var i = 0; i < testStandardIds.length; i++) {

            var filteredData = _.filter(SampleInfo, function (item) {
                return item.testStandardID == testStandardIds[i] && item.sampleCategoryId == sampleCategoryId && item.sampleTypeID == sampleTyepID;
            });
            var SampleInfoArrayListCheck = _.filter(SampleInfoArrayList, function (item) {
                return item.TestStandardId == filteredData[0].testStandardID && item.SampleCategoryId == filteredData[0].sampleCategoryId
                    && item.SampleTypeId == filteredData[0].sampleTypeID;
            });

            if (SampleInfoArrayListCheck.length > 0) {
                if (count < 1) {
                    alert("Already Added")
                }

                count++;
            }
            else {

                var obj = new Object()
                obj.BatchLot = $('#batchLot').val();
                obj.Producer = $('#cmbProducer').data('kendoComboBox').value();
                obj.TestStandardId = filteredData[0].testStandardID;
                obj.TestStandardName = filteredData[0].testStandardName;
                obj.SampleCategoryId = filteredData[0].sampleCategoryId;
                obj.SampleCategoryName = filteredData[0].sampleCategoryName;
                obj.SampleTypeName = filteredData[0].sampleTypeName;
                obj.SampleTypeId = filteredData[0].sampleTypeID;
                obj.TestName = filteredData[0].testName;
                obj.TestId = filteredData[0].testNameID;
                obj.Note = $('#note').val();
                var orderDate = $("#orderDate").val();


                if (deliveryType == 1) {
                    obj.Price = filteredData[0].regularPrice;
                    obj.DeliveryDate = moment(orderDate, "MM/DD/YYYY").add(filteredData[0].regularDeliveryDays, 'days').format("YYYY-MM-DD");

                }
                else {
                    obj.Price = filteredData[0].expressPrice;
                    obj.DeliveryDate = moment(orderDate, "MM/DD/YYYY").add(filteredData[0].expressDeliveryDays, 'days').format("YYYY-MM-DD");
                }

                obj.QtyPerSample = filteredData[0].qtyPerSample;
                obj.QtyPerSample = 1
                obj.SampleID = 0;
                obj.Id = 0;
                obj.ParentId = 0;
                SampleInfoArrayList.push(obj);
            }
        }
        BindSampleInfoArrayTable(SampleInfoArrayList, deliveryType);



    }

}

function BindSampleInfoArrayTable(data, deliveryOption) {

    $("#divtestSampleInfoArrBind").html('');
    var sl = 1;
    var sum = 0;
    var html = '<table class="table table-vcenter card-table">' +
        ' <tr><th></th><th >SL</th><th >Sample</th><th>Test Name</th><th>Delivery Date</th><th>Quantity</th><th>Rate</th><th>Total (Tk.)</th>' +
        '</tr>';
    for (var i = 0; i < data.length; i++) {

        html += "<tr>" +
            " <td  style='width:5%;text-align:left;'>" +
            "<button class='btn btn-ghost-info active w-10'  onclick='Delete(" + data[i].sampleCategoryId + ")'  >" +
            "<span class='k-icon k-i-x-circle'></span>" +
            "</button>" +
            "</td>" +
            "<td style='width:5%;text-align:left;'>" + sl + "</td>" +
            "<td style='width:25%;text-align:left;'>" + data[i].SampleCategoryName + "(" + data[i].SampleTypeName + ")</td>" +
            "<td style='width:25%;text-align:left;'>" + data[i].TestName + "(" + data[i].TestStandardName + ")</td>" +
            "<td style='width:10%;text-align:left;'>" + data[i].DeliveryDate + "</td>" +
            "<td style='width:5%;text-align:left;'>" + data[i].QtyPerSample + "</td>" +
            "<td style='width:10%;text-align:left;'>" + data[i].Price + "</td>" +
            "<td style='width:15%;text-align:left;'>" + data[i].QtyPerSample * data[i].Price + "</td>" +

            "</tr>";
        sl = sl + 1;
        sum = sum + data[i].QtyPerSample * data[i].Price;

    }
    html += "<tr><td colspan='7' style='text-align: right;'  >Total (Tk.)</td><td id='sumId'>" + sum + "</td></tr>";
    html += "<tr ><td colspan='5' style='text - align: right;'></td><td colspan='3''> Delivery Type ";
    html += "<label class='form-check form-check-inline'>";
    var check1 = "";
    var Check2 = "";
    if (deliveryOption == 1) {
        check1 = "checked";
        Check2 = "";
    }
    else {
        check1 = "";
        Check2 = "checked";
    }

    html += "<input class='form-check-input' type = 'radio' name = 'radios-inline'  onchange='deliveryTypeChange(this);' value='1' " + check1 + " >";
    html += "<span class='form-check-label'>Regular</span>";
    html += "</label>";

    html += "<label class='form-check form-check-inline'>";
    html += "<input class='form-check-input' type = 'radio' name = 'radios-inline' onchange='deliveryTypeChange(this);' value='2' " + Check2 + " >";
    html += "<span class='form-check-label'>Express</span>";
    html += "</label>";

    html += "</td>";
    html += "</tr > ";

    //Table
    html += '<tr > <td colspan="5" style="text-align: right;"> Discount</td><td colspan="3"><input type="number" id="percentageVal" onblur="Calculation(true)" min="0" max="100"  oninput="maxLengthCheck(this)"  style="width:40%" >%<input type="number" id="discountVal" onblur="Calculation(false)"   style="width:56%" oninput="discountMaxLengthCheck(this)"></td></tr>'
    html += '<tr > <td colspan="5" style="text-align: right;"> Net Order Value</td><td colspan="3"><input type="number" id="netOrder" style="width:100%"  readonly></td></tr>'
    html += '<tr > <td colspan="5" style="text-align: right;"> Payment Mode</td><td colspan="3"><input type="text" id="cmbPaymentMode" style="width:100%"></td></tr>'
    html += '<tr > <td colspan="5" style="text-align: right;">Reference No</td><td colspan="3"><input type="number" id="#"  style="width:100%"></td></tr>'
    html += '<tr > <td colspan="5" style="text-align: right;">Payment Amount</td><td colspan="3"><input type="number" id="payment"  onblur="Calculation(true)" style="margin-right: 10px;"><input type="checkbox" id="checkBoxInput"  onclick="Calculation(true)"  >Full Payment</td></tr>'
    html += '<tr > <td colspan="5" style="text-align: right;"> Balance Payable</td><td colspan="3"><input type="number" id="payable" style="width:100%"></td></tr>'

    html += "</td>";
    html += "</tr > ";



    html += '</table>'
    $("#divtestSampleInfoArrBind").html(html);
    //Customer combo
    $("#cmbPaymentMode").kendoComboBox({
        dataTextField: "name",
        dataValueField: "id",
        dataSource: PaymentMethodList,
        filter: "contains",
        suggest: true,
        placeholder: 'Select Payment Method ',


    });
    Calculation(false, false);


}

function maxLengthCheck(object) {
    // debugger;
    if (+object.value <= +object.max)
        return object.value;
    else
        $('#percentageVal').val('');

}


function discountMaxLengthCheck(object) {

    var totalOrderAmount = $("#sumId").html();
    if (+object.value <= totalOrderAmount)
        return object.value;
    else
        $('#discountVal').val(totalOrderAmount);
}


function deliveryTypeChange(src) {
    //var regularPriceList = [];
    for (var i = 0; i < SampleInfoArrayList.length; i++) {
        var filteredData = _.filter(SampleInfo, function (item) {
            return item.testStandardID == SampleInfoArrayList[i].TestStandardId && item.sampleCategoryId == SampleInfoArrayList[i].SampleCategoryId && item.sampleTypeID == SampleInfoArrayList[i].SampleTypeId;
        });
        if (src.value == 2) {
            SampleInfoArrayList[i].Price = filteredData[0].expressPrice;


        }
        else {
            SampleInfoArrayList[i].Price = filteredData[0].regularPrice;

        }
    }
    deliveryType = src.value;
    BindSampleInfoArrayTable(SampleInfoArrayList, src.value);
    //alert(src.value);
}

//function showMe( ) {
//    var inputValue = document.getElementById("inputField").value;


//    var result = ((sum * inputValue) / 100);
//    document.getElementById("percentage").value = result;
//    var deductedVal = sum - result;
//    document.getElementById("deducted").value = deductedVal;


//    //net order value after applying percentage
//    netOrderVal = deductedVal;

//}


function Calculation(isPercentage) {

    var totalOrderAmount = $("#sumId").html();
    var discountAmount = 0;
    var paymentAmount = 0;
    var discountPercentage = 0;
    var netOrderAmount = 0;
    var netBalance = 0;
    if (isPercentage) {
        var percentageVal = $("#percentageVal").val();
        discountAmount = ((totalOrderAmount * percentageVal) / 100);
    }
    else {
        discountAmount = $("#discountVal").val();
        discountPercentage = ((discountVal * 100) / totalOrderAmount);

    }
    $("#discountVal").val(discountAmount)
    netOrderAmount = totalOrderAmount - discountAmount;
    $('#netOrder').val(netOrderAmount);
    if ($("#payment").val() != '') {
        paymentAmount = $("#payment").val();
    }
    var isfullAdvance = $('#checkBoxInput').is(":checked")




    if (isfullAdvance) {
        paymentAmount = netOrderAmount
        $("#payment").val(paymentAmount);

    }
    else {
        //$("#payment").val(0);
        // paymentAmount = 0;
    }

    netBalance = netOrderAmount - paymentAmount

    $("#payable").val(netBalance);




    //check box validation start
    //if ($('#checkBoxInput:checked').length) {
    //    $('#payment').attr('readonly', true); // On Load, should it be read only?
    //}

    //$('#checkBoxInput').change(function () {
    //    if ($('#checkBoxInput:checked').length) {
    //        $('#payment').attr('readonly', true); //If checked - Read only
    //    } else {
    //        $('#payment').attr('readonly', false);//Not Checked - Normal
    //    }
    //});

    //check box validation end




}





function Delete(id) {
    var indexToDelete = SampleInfoArrayList.findIndex(function (obj) {
        return obj.sampleCategoryId == id;
    });
    // If the index is found, delete the object using splice
    if (indexToDelete !== -1) {
        SampleInfoArrayList.splice(indexToDelete, 1);
    }
    BindSampleInfoArrayTable(SampleInfoArrayList);
}





function SaveOrderEntry() {
    debugger
    console.log($("#cmbCurrency").data('kendoComboBox'), $("#cmbCurrency"), $("#cmbCustomer").data('kendoComboBox')._cascadedValue);
    var requestObj = new Object();
    var validate = true;
    validate = Validate();
    if (validate == true) {

        requestObj.ID = $("#txtId").html() == "" ? 0 : $("#txtId").html();
        requestObj.CustomerId = $("#cmbCustomer").data('kendoComboBox').value();
        requestObj.ContactName = $("#contactPersonName").val();
        requestObj.ContactAddress = $("#contactAddress").val();
        requestObj.ContactMobile = $("#contactPhone").val();
        requestObj.ContactEmail = $("#contactEmail").val();
        requestObj.ProjectId = $("#cmbProject").data('kendoComboBox').value();
        requestObj.ProjectRefNo = $("#projectRefNo").val();
        requestObj.Description = $("#remarks").val();
        requestObj.CurrencyCode = $("#cmbCurrency").data('kendoComboBox')._cascadedValue;
        requestObj.OrderDate = $("#orderDate").val();
        requestObj.PaymentMode = $("#cmbPaymentMode").data("kendoComboBox").value();
        requestObj.DiscountAmount = $("#discountVal").val();




        requestObj.OrderEntryChildList = SampleInfoArrayList;
        $.ajax({
            url: "/OrderEntry/OrderEntrySave",
            type: "POST",
            dataType: "json",
            data: requestObj,
            success: function (data) {
                if (data.statusCode == 200) {
                    SaveDataList = data.data;
                    console.log("update data", SaveDataList)
                    UIBind(SaveDataList);
                    toastr.success(data.message, 'Success');

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

function UIBind(data) {
    debugger
    SampleInfoArrayList = [];
    
    
    for (var i = 0; i < data.length; i++) {
        var obj = new Object()
        obj.BatchLot = data[i].lotNo;
        obj.Producer = data[i].producerID;
        obj.TestStandardId = data[i].testStandardID;
        obj.TestStandardName = data[i].testStandardName;
        obj.SampleCategoryId = data[i].sampleCategoryID;
        obj.SampleCategoryName = data[i].sampleCategoryName;
        obj.SampleTypeId = data[i].sampleTypeID;
        obj.SampleTypeName = data[i].sampleTypeName;
        obj.TestId = data[i].testNameID;
        obj.TestName = data[i].testName;
        obj.Price = data[0].unitPrice;
        //obj.RegularPrice = filteredData[0].regularPrice;
        // obj.ExpressPrice = filteredData[0].expressPrice;
        obj.QtyPerSample = data[i].qtyPreSample;
        obj.ReqNumberOfSamplePcs = data[i].reqNumberOfSamplePcs;
        obj.SampleID = data[i].sampleID;
        obj.Id = 0;
        obj.ParentId = 0;
        const originalDate = data[0].deliveryDate;
        const formattedDate = moment(originalDate).format("MMMM D, YYYY");
        obj.DeliveryDate = formattedDate;
      
       // obj.DeliveryDate = data[i].deliveryDate;
        SampleInfoArrayList.push(obj);
        
    }


    //added for update
    console.log(data);
    SampleInfoData(1);

    $('#txtId').html(data[0].id);
    $("#cmbCustomer").data('kendoComboBox').value(data[0].customerID)
    $('#contactPersonName').val(data[0].contactName);
    $('#contactAddress').val(data[0].contactAddress);
    $('#contactEmail').val(data[0].contactEmail);
    $('#contactPhone').val(data[0].contactMobile);
    $("#cmbProject").data('kendoComboBox').value(data[0].projectID);
    $("#cmbCurrency").data('kendoComboBox').value(data[0].currencyCode);
    $('#remarks').val(data[0].description);

    const originalDate = data[0].orderDate;
    const formattedDate = moment(originalDate).format("MM/DD/YYYY");
    $('#orderDate').val(formattedDate);
    //$('#orderDate').val(data[0].orderDate);
    //2nd stepper
    $("#cmbSampleName").data('kendoComboBox').value(data[0].sampleCategoryID);
 
  //  updateSampleTypeComboBox(data[0].sampleCategoryID);
    $("#cmbSampleType").data('kendoComboBox').value(data[0].sampleTypeID);
  //  updateTestStandardComboBox(data[0].sampleTypeID);
    $('#batchLot').val(data[0].lotNo);
  
    $("#cmbProducer").data('kendoComboBox').value(data[0].producerID)
    $("#txtId").prop("disabled", true);
    
    BindSampleInfoArrayTable(SampleInfoArrayList);
}


function Validate() {

    if ($("#cmbSampleName").data('kendoComboBox').value() == "" || $("#cmbSampleName").data('kendoComboBox').selectedIndex == -1) {
        $("#cmbSampleName").data('kendoComboBox').focus();
        $("#cmbSampleName").data('kendoComboBox').open();
        toastr.warning('Please input Sample Category', "Warning");
        return false;
    }
    if ($("#cmbSampleType").data('kendoComboBox').value() == "" || $("#cmbSampleType").data('kendoComboBox').selectedIndex == -1) {
        $("#cmbSampleType").data('kendoComboBox').focus();
        $("#cmbSampleType").data('kendoComboBox').open();
        toastr.warning('Please input Sample Type', "Warning");
        return false;
    }

    if ($("#cmbProducer").data('kendoComboBox').value() == "" || $("#cmbProducer").data('kendoComboBox').selectedIndex == -1) {
        $("#cmbProducer").data('kendoComboBox').focus();
        $("#cmbProducer").data('kendoComboBox').open();
        toastr.warning('Please input Producer', "Warning");
        return false;
    }

    if ($("#cmbTestStandard").data('kendoMultiSelect').value() == "" || $("#cmbTestStandard").data('kendoMultiSelect').selectedIndex == -1) {
        $("#cmbTestStandard").data('kendoMultiSelect').focus();
        $("#cmbTestStandard").data('kendoMultiSelect').open();
        toastr.warning('Please input Test Standard', "Warning");
        return false;
    }




    return true;

}


function ValidateFirstStepper() {
    if ($("#cmbCustomer").data('kendoComboBox').value() == "" || $("#cmbCustomer").data('kendoComboBox').selectedIndex == -1) {
        $("#cmbCustomer").data('kendoComboBox').focus();
        $("#cmbCustomer").data('kendoComboBox').open();
        toastr.warning('Please input Customer', "Warning");
        return false;
    }

    if ($("#cmbCurrency").data('kendoComboBox').value() == "" || $("#cmbCurrency").data('kendoComboBox').selectedIndex == -1) {
        $("#cmbCurrency").data('kendoComboBox').focus();
        $("#cmbCurrency").data('kendoComboBox').open();
        toastr.warning('Please input Currency', "Warning");
        return false;
    }


    return true;

}




//next
//const steps = document.querySelectorAll('.stepDiv');
//const nextButton = document.getElementById('nextButton');
//let currentStep = 0;

//nextButton.addEventListener('click', () => {
//    steps[currentStep].style.display = 'none'; // Hide current step
//    currentStep++;

//    if (currentStep >= steps.length) {
//        currentStep = 0; // Loop back to the first step if at the end
//    }

//    steps[currentStep].style.display = 'block'; // Show next step
//});

//// Show the first step initially
//steps[currentStep].style.display = 'block';







