using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
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
    public class SampleTypeRepository : ISampleTypeRepository
    {
        private readonly RavenDBContext _db;
        public SampleTypeRepository(RavenDBContext ravenDBContext)
        {
            _db = ravenDBContext;
        }

        public IEnumerable<SampleType> Get()
        {
            var paramList = new SqlParameter("ID", Convert.ToInt64(0));
            var results = _db.Database.SqlQuery<SampleType>("GetSample_Type_sp", paramList).ToList();
            return results;
        }

        public SaveVM SaveSampleType(SampleType obj)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = obj.Id };
                var Name = new SqlParameter { ParameterName = "Name", Value = obj.Name == null ? DBNull.Value : obj.Name };
                var SampleCategoryID = new SqlParameter { ParameterName = "SampleCategoryID", Value = obj.SampleCategoryID == null ? DBNull.Value : obj.SampleCategoryID };
                var Description = new SqlParameter { ParameterName = "Description", Value = obj.Description == null ? DBNull.Value : obj.Description };
                var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.isActive };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
                var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateSample_Type_SP  @ID,@Name,@SampleCategoryID,@Description,@IsActive,@Creator",
                    ID, Name, SampleCategoryID, Description, isActive, Creator).FirstOrDefault();
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
                    ID = obj.Id,
                    Code = (int)ProjectCodes.Error,
                    Message = ex.Message,
                    IsSuccess = false
                };
                return result;
            }


        }
    }
}
