


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
    public class SampleTypeVsTestStandardRepository : ISampleTypeVsTestStandardRepository
    {
        private readonly RavenDBContext _db;
        public SampleTypeVsTestStandardRepository(RavenDBContext db)
        {
            _db = db;
        }
        public SaveVM SaveSampleTypeVsTestStandard(SampleTypeVsTestStandardVM obj)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };

                var SampleTypeID = new SqlParameter
                {
                    ParameterName = "SampleTypeID",
                    Value = obj.SampleTypeID == 0 ? DBNull.Value : obj.SampleTypeID
                };

                var TestStandardId = new SqlParameter
                {
                    ParameterName = "TestStandardId",
                    Value = obj.TestStandardID == 0 ? DBNull.Value : obj.TestStandardID
                };

                var ReqNumberOfSamplePcs = new SqlParameter
                {
                    ParameterName = "ReqNumberOfSamplePcs",
                    Value = obj.ReqNumberOfSamplePcs == 0 ? DBNull.Value : obj.ReqNumberOfSamplePcs
                };
                var QtyPerSample = new SqlParameter
                {
                    ParameterName = "QtyPerSample",
                    Value = obj.QtyPerSample == 0 ? DBNull.Value : obj.QtyPerSample
                };
                var ReqSampleDescription = new SqlParameter
                {
                    ParameterName = "ReqSampleDescription",
                    Value = obj.ReqSampleDescription == null ? DBNull.Value : obj.ReqSampleDescription
                };


                var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };

                var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateSampleTypeVsTestStandard_SP  @ID,@SampleTypeID,@TestStandardID,@ReqNumberOfSamplePcs,@QtyPerSample,@ReqSampleDescription,@IsActive,@Creator",
                    ID, SampleTypeID, TestStandardId, ReqNumberOfSamplePcs, QtyPerSample, ReqSampleDescription, isActive, Creator).FirstOrDefault();
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
        public IEnumerable<SampleTypeVsTestStandardVM> GetSampleTypeVsTestStandard()
        {

            var parms = new SqlParameter("ID", Convert.ToInt64(0));
            var result = _db.Database.SqlQuery<SampleTypeVsTestStandardVM>("GetSampleTypeVsTestStandard_SP @ID", parms).ToList();
            return result;
        }
    }
}
