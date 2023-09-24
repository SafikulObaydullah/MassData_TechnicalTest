using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
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
    public class TestSampleInfoRepository : ITestSampleInfoRepository
    {
        private readonly RavenDBContext _db;
        public TestSampleInfoRepository(RavenDBContext db)
        {
            _db = db;
        }
        public IEnumerable<TestSampleInfoVM> GetTestSampleInfo(Int64 CustomerId, Int64 CurrencyCde)
        {

            var CustomerID = new SqlParameter
            {
                ParameterName = "CustomerId",
                Value = CustomerId
            };
            var CurrencyCode = new SqlParameter
            {
                ParameterName = "CurrencyCode",
                Value = CurrencyCde
            };


            var result = _db.Database.SqlQuery<TestSampleInfoVM>("GetTestSampleInfo @CustomerID, @CurrencyCode", CustomerID, CurrencyCode).ToList();
            return result;
        }
    }
}
