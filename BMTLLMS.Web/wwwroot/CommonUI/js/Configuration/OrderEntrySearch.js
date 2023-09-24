
var OrderEntryListBySearch = []
var CustomerList = []

$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
    CustomerLoad();
    GetOrderEntryListtBySearch();




});



function CustomerLoad() {

    $.ajax({
        url: "/Customer/GetCustomer",
        method: "GET",
        dataType: "json",
        success: function (data) {
            if (data.statusCode = "200") {
                CustomerList = data.data;
                console.log("CustomerList", CustomerList);
                if (CustomerList.length > 0) {
                    $("#cmbCustomer").kendoComboBox({
                        dataTextField: "name",
                        dataValueField: "id",
                        dataSource: CustomerList,
                        filter: "contains",
                        suggest: true,
                        placeholder: 'Select Customer',
                        delay: 100
                    }).data("kendoComboBox");
                }


            }
            else {

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error:", textStatus, errorThrown);
        }
    });

}




function GetOrderEntryListtBySearch() {

    debugger
    var o = new Object();
    var validate = true;
    //validate = SearchValidate();
    if (validate == true) {
        o.OrderCode = $("#orderCode").val();
        o.CustomerID = ($("#cmbCustomer").data('kendoComboBox') == undefined ? '' : $("#cmbCustomer").data('kendoComboBox').value());
        o.OrderDateFrom = $("#orderDateFrom").val();
        o.OrderDateTo = $("#orderDateTo").val();
        o.DeliveryDateFrom = $("#deliveryDateFrom").val();
        o.DeliveryDateTo = $("#deliveryDateTo").val();

        $.ajax({
            url: "/OrderEntrySearch/OrderEntryBySearch",
            method: "GET",
            dataType: "json",
            data: o,
            success: function (data) {
                OrderEntryListBySearch = data;


                console.log(OrderEntryListBySearch)
                BindOrderEntrySerachList(OrderEntryListBySearch)

            }
        });

    }
}




function BindOrderEntrySerachList(data) {
    debugger
    var i = 1;
    _.map(OrderEntryListBySearch, function (obj) {
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
                field: "sl", width: 10,
                title: "SL",
                attributes: {
                    style: "text-align:center;"
                },
                headerAttributes: { style: "text-align:center;font-weight: bold;background-color:#00bcd4" },
            },
            {
                field: "orderCode", width: 20,
                title: "Order Code",
                attributes: {
                    style: "text-align:left;"
                },
                headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
            },
            {
                field: "orderDate", width: 30,
                title: "Order Date",
                // template: "#= new Date(orderDate.toString()).getFullYear() == 1 ? '' :  moment(orderDate).format('MMM Do YYYY') #",
                template: "#= orderDate ? kendo.toString(new Date(orderDate), 'MMM dd, yyyy') : '' #",
                attributes: {
                    style: "text-align:left;"
                },
                headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
            },
            {
                field: "customerName", width: 40,
                title: "Customer Name",
                attributes: {
                    style: "text-align:left;"
                },
                headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
            },
            //{
            //    field: "deliveryDate", width: 30,
            //    title: "Delivery Date",
            //    template: "#= new Date(deliveryDate?.toString()).getFullYear() == 1 ? '':moment(deliveryDate).format('MMM Do YYYY') #",
            //    attributes: {
            //        style: "text-align:left;"
            //    },
            //    headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
            //},
            {
                field: "totalPrice", width: 40,
                title: "Total Price",
                attributes: {
                    style: "text-align:left;"
                },
                headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
            },
            {
                field: "description", width: 40,
                title: "Description",
                attributes: {
                    style: "text-align:left;"
                },
                headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
            },
            {
                field: "sampleStatus", width: 40,
                title: "Sample Status",
                attributes: {
                    style: "text-align:left;"
                },
                headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
            },
            {
                field: "paymentInfo", width: 40,
                title: "Payment Info",
                attributes: {
                    style: "text-align:left;"
                },
                headerAttributes: { style: "text-align:left;font-weight: bold;background-color:#00bcd4" }
            },
            {
                title: "Action",
                template: function (x) {
                    console.log(x)
                    return "<button class='btn btn-ghost-info active w-10' title='Edit' onclick='GetOrderEntryParentChildDetails(" + x.orderCode + ")'>Edit</button>" +
                        '<span style="margin-left: 10px;"></span>' +
                        "<button class='btn btn-view active w-10' title='View'  onclick='GetOrderEntryParentChildDetails(" + x.id + ")'>View</button>";
                },
                field: "", width: 40,
                attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#00bcd4" }
            }
            //{
            //    title: "Action",
            //    template: '<button class="btn btn-ghost-info active w-10"     onclick='GetOrderEntryParentChildDetails("+x.id+")' >Edit</button>' +
            //        '<span style="margin-left: 10px;"></span>' +
            //        '<button class="btn btn-view active w-10" >View</button>',
            //      /*  "<button class='btn btn-ghost-info active w-10'  title='Edit' ><span class='k-icon k-i-edit'></span></button>",*/
            //    field: "", width: 40,
            //    attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#00bcd4" }
            //}


        ]
    });
}


function GetOrderEntryParentChildDetails(orderCode) {
    debugger
    FilteredData = OrderEntryListBySearch.find(item => item.orderCode === orderCode);
    var GID = FilteredData.gid;

    window.location.href = `https://localhost:7137/OrderEntry/Index?id=${GID}`;


}




//var ProjectList = []
//$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
//$(document).ready(function () {
//   ProjectLoad();
//});

//function ProjectLoad() {

//   $.ajax({
//      url: "/Project/GetProject",
//      method: "GET",
//      dataType: "json",
//      success: function (data) {
//         if (data.statusCode = "200") {
//            ProjectList = data.data;
//            ProjectDataBind(ProjectList);
//         }
//         else {

//         }
//      },
//      error: function (jqXHR, textStatus, errorThrown) {
//         console.log("Error:", textStatus, errorThrown);
//      }
//   });

//}
//function ProjectDataBind(data) {
//   var i = 1;
//   _.map(ProjectList, function (o) {
//      o.sl = i;
//      i++;
//   });
//   $("#gridTable").kendoGrid({
//      dataSource: data,
//      sortable: true,
//      toolbar: ["search"],
//      search: {
//         fields: ["name"]
//      },
//      pageable: {
//         pageSize: 15,
//         pageSizes: [15, 30, 50, "all"],
//         numeric: false
//      },
//      columns: [
//         {
//            title: "SL No",
//            field: "sl", width: 30,
//            attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
//         },

//         {
//            title: "Project Name",
//            field: "name", width: 90,
//            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }

//         },
//         {
//            title: "Contact Person",
//            field: "contactPerson", width: 90,
//            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
//         },
//         {
//            title: "Contact Phone",
//            field: "contactPhone", width: 120,
//            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
//         },
//         {
//            title: "Contact Email",
//            field: "contactEmail", width: 120,
//            attributes: { style: "text-align: left;" }, headerAttributes: { style: "text-align: left;font-weight: bold;background-color:#C2DFFF" }
//         },
//         {
//            title: "Action",
//            template: "<button class='btn btn-ghost-info active w-10'  title='Edit' onclick='Edit(#:id#)'><span class='k-icon k-i-edit'></span></button>",
//            field: "", width: 80,
//            attributes: { style: "text-align: center;" }, headerAttributes: { style: "text-align: center;font-weight: bold;background-color:#C2DFFF" }
//         },
//      ]
//   });
//}
//function Save() {
//   var o = new Object();
//   var validate = true;
//   validate = Validate();
//   if (validate == true) {
//      o.id = $('#spanParentID').html();
//      o.name = $('#name').val();
//      o.contactPerson = $('#contactPerson').val();
//      o.contactPhone = $('#contactPhone').val();
//      o.contactEmail = $('#contactEmail').val();
//      o.isActive = $('#isActive').is(':checked') ? true : false;
//      $.ajax({
//         url: "/Project/ProjectSave",
//         type: "POST",
//         dataType: "json",
//         data: o,
//         success: function (data) {
//            if (data.code == 200) {
//               toastr.success(data.message, 'Success');
//               ProjectLoad();
//               $('#mdlUserReg').modal('hide')
//            } else {
//               toastr.warning(data.message, "Waring");
//            }
//         },
//         error: function (xhr, textStatus, errorThrown) {
//            toastr.error('Error Saving', 'Error');
//         }
//      });

//   }
//}
//function Edit(id) {
//   $('#spanParentID').html(id);
//   var FilterData = _.filter(ProjectList, function (item) { return item.id == id });
//   $('#name').val(FilterData[0].name);
//   $('#contactPerson').val(FilterData[0].contactPerson);
//   $('#contactPhone').val(FilterData[0].contactPhone);
//   $('#contactEmail').val(FilterData[0].contactEmail);
//   FilterData[0].isActive == false ? $('#isActive').prop('checked', false) : $('#isActive').prop('checked', true)
//   $('#mdlUserReg').modal('toggle');
//   $('#staticBackdropLabel').text('Edit Project Information');
//   $('#btnSave').text('Update');
//   $('#btnSave').addClass('btn btn-ghost-info active w-10');
//}

//function AddNew() {
//   $('#staticBackdropLabel').text('Create New Project');
//   $('#btnSave').removeClass('btn btn-ghost-info active w-10');
//   $('#spanParentID').html(0);
//   $('#name').val('');
//   $('#contactPerson').val('');
//   $('#contactPhone').val('');
//   $('#contactEmail').val('');
//   $('#mdlUserReg').modal('toggle');
//   $('#btnSave').text('Save');
//   $('#btnSave').addClass('btn btn-ghost-primary active w-10');
//}

//function Validate() {
//   if ($('#name').val() == "") {
//      $('#name').focus();
//      toastr.warning('Please input Project name');
//      return false;
//   }
//   if ($('#contactPerson').val() == "") {
//      $('#contactPerson').focus();
//      toastr.warning('Please input Contact Person');
//      return false;
//   }
//   if ($('#contactPhone').val() == "") {
//      $('#ContactPhone').focus();
//      toastr.warning('Please input valid Contact Phone');
//      return false;
//   }
//   if ($('#contactEmail').val() == "") {
//      $('#contactEmail').focus();
//      toastr.warning('Please input Contact Email');
//      return false;
//   }
//   return true;
//}

//function checkEmptyInput(inputElement) {
//    if (inputElement.value.trim() === "") {
//        inputElement.style.border = "1px solid red";
//    } else {
//        inputElement.style.border = "1px solid #ced4da"; // Reset border to default
//    }
//}
