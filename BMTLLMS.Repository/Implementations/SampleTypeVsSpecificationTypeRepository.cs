


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
    public class SampleTypeVsSpecificationTypeRepository : ISampleTypeVsSpecificationTypeRepository
    {
        private readonly RavenDBContext _db;
        public SampleTypeVsSpecificationTypeRepository(RavenDBContext db)
        {
            _db = db;
        }
        public SaveVM SaveSampleTypeVsSpecificationType(SampleTypeVsSpecificationTypeVM obj)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };

                var SampleTypeID = new SqlParameter
                {
                    ParameterName = "SampleTypeID",
                    Value = obj.SampleTypeID == 0 ? DBNull.Value : obj.SampleTypeID
                };

                var SpecificationHeadID = new SqlParameter
                {
                    ParameterName = "SpecificationHeadID",
                    Value = obj.SpecificationHeadID == 0 ? DBNull.Value : obj.SpecificationHeadID
                };


                var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
                var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateSampleTypeVsSpecificationType_SP  @ID,@SampleTypeID,@SpecificationHeadID,@IsActive,@Creator",
                    ID, SampleTypeID, SpecificationHeadID, isActive, Creator).FirstOrDefault();
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
        public IEnumerable<SampleTypeVsSpecificationTypeVM> GetSampleTypeVsSpecificationType()
        {

            var parms = new SqlParameter("ID", Convert.ToInt64(0));
            var result = _db.Database.SqlQuery<SampleTypeVsSpecificationTypeVM>("GetSampleTypeVsSpecificationType_SP @ID", parms).ToList();
            return result;
        }
    }
}
