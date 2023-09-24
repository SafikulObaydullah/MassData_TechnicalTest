using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Repository.Contracts;
using EntityFrameworkCore.RawSQLExtensions.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Implementations
{
    public class OrderEntrySearchRepository : IOrderEntrySearchRepository
    {
        private readonly RavenDBContext _db;
        public OrderEntrySearchRepository(RavenDBContext db)
        {
            _db = db;
        }


        public IEnumerable<OrderEntrySearchListVM> OrderEntrySearch(OrderEntrySearchVM obj)
        {
            var OrderCode = new SqlParameter
            {
                ParameterName = "OrderCode",
                Value = obj.OrderCode
            };
            var CustomerID = new SqlParameter
            {
                ParameterName = "CustomerID",
                Value = obj.CustomerID
            };
            var OrderDateFrom = new SqlParameter
            {
                ParameterName = "OrderDateFrom",
                Value = obj.OrderDateFrom
            };
            var OrderDateTo = new SqlParameter
            {
                ParameterName = "OrderDateTo",
                Value = obj.OrderDateTo
            };
            var DeliveryDateFrom = new SqlParameter
            {
                ParameterName = "DeliveryDateFrom",
                Value = obj.DeliveryDateFrom
            };
            var DeliveryDateTo = new SqlParameter
            {
                ParameterName = "DeliveryDateTo",
                Value = obj.DeliveryDateTo
            };

            var SPname = "OrderEntrySearch " + obj.OrderCode + ",'" + obj.CustomerID + "','" + obj.OrderDateFrom + "','" + obj.OrderDateTo + "','" + obj.DeliveryDateFrom + "','" + obj.DeliveryDateTo + "'";

            var result = _db.Database.SqlQuery<OrderEntrySearchListVM>(SPname).ToList();

            return result;
        }

    }
}
