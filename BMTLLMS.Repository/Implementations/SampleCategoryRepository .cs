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
    public class SampleCategoryRepository : ISampleCategoryRepository
    {
        private readonly RavenDBContext _db;
        public SampleCategoryRepository(RavenDBContext ravenDBContext)
        {
            _db = ravenDBContext;
        }

        public IEnumerable<SampleCategoryVM> Get()
        {
            var paramList = new SqlParameter("ID", Convert.ToInt64(0));
            var results = _db.Database.SqlQuery<SampleCategoryVM>("GetSample_Category_sp", paramList).ToList();
            return results;
        }

        public SaveVM SaveSampleCategory(SampleCategoryVM obj)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
                var CategoryName = new SqlParameter { ParameterName = "CategoryName", Value = obj.CategoryName == null ? DBNull.Value : obj.CategoryName };

                var IsActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
                var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateSampleCategory_SP  @ID,@CategoryName,@IsActive,@Creator",
                    ID, CategoryName, IsActive, Creator).FirstOrDefault();
                if (result.IsSuccess == false)
                {
                    result.Code = (int)ProjectCodes.Error;
                }
                else
                {
                    result.Code = (int)ProjectCodes.Success;
                }
                var resultFinal = new SaveVM
                {
                    ID = result.ID,
                    IsSuccess = result.IsSuccess,
                    Code = result.Code,
                    Message = result.Message,
                };

                return resultFinal;
            }
            catch (Exception ex)
            {
                var result = new SaveVM
                {
                    ID = obj.ID,
                    Code = (int)ProjectCodes.Error,
                    Message = ex.Message,
                    IsSuccess = false
                };
                return result;
            }


        }
    }
}
