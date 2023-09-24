


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
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Implementations
{
    public class CalibrationFrequencyRepository : ICalibrationFrequencyRepository
    {
        private readonly RavenDBContext _db;
        public CalibrationFrequencyRepository(RavenDBContext db)
        {
            _db = db;
        }
        public SaveVM SaveCalibrationFrequency(CalibrationFrequencyVM obj)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
                var MachineID = new SqlParameter
                {
                    ParameterName = "MachineID",
                    Value = obj.MachineID == 0 ? DBNull.Value : obj.MachineID
                };
                var CorrectionFactor = new SqlParameter
                {
                    ParameterName = "CorrectionFactor",
                    Value = obj.CorrectionFactor == null ? DBNull.Value : obj.CorrectionFactor
                };
                var MeasurementUnitID = new SqlParameter
                {
                    ParameterName = "MeasurementUnitID",
                    Value = obj.MeasurementUnitID == 0 ? DBNull.Value : obj.MeasurementUnitID
                };
                var EffectiveDate = new SqlParameter
                {
                    ParameterName = "EffectiveDate",
                    Value = obj.EffectiveDate == null ? DBNull.Value : obj.EffectiveDate
                };

                var CalibrationFrequencyInDays = new SqlParameter
                {
                    ParameterName = "CalibrationFrequencyInDays",
                    Value = obj.CalibrationFrequencyInDays == null ? DBNull.Value : obj.CalibrationFrequencyInDays
                };
                var CalibrationFrequencyInTestNumber = new SqlParameter
                {
                    ParameterName = "CalibrationFrequencyInTestNumber",
                    Value = obj.CalibrationFrequencyInTestNumber == null ? DBNull.Value : obj.CalibrationFrequencyInTestNumber
                };
                var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
                var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateCalibrationFrequency_SP  @ID,@MachineID,@CorrectionFactor,@MeasurementUnitID,@EffectiveDate,@CalibrationFrequencyInDays,@CalibrationFrequencyInTestNumber,@IsActive, @Creator",
                    ID, MachineID, CorrectionFactor, MeasurementUnitID, EffectiveDate, CalibrationFrequencyInDays, CalibrationFrequencyInTestNumber, isActive, Creator).FirstOrDefault();
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
        public IEnumerable<CalibrationFrequencyVM> GetCalibrationFrequency()
        {

            var parms = new SqlParameter("ID", Convert.ToInt64(0));
            var result = _db.Database.SqlQuery<CalibrationFrequencyVM>("GetCalibrationFrequency_SP @ID", parms).ToList();
            return result;
        }
    }
}
