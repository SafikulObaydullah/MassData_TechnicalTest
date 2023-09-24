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
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly RavenDBContext _db;
        public CurrencyRepository(RavenDBContext ravenDBContext)
        {
            _db = ravenDBContext;
        }

        public IEnumerable<Currency> Get()
        {
            var paramList = new SqlParameter("ID", Convert.ToInt64(0));
            var results = _db.Database.SqlQuery<Currency>("GetCurrency_sp", paramList).ToList();
            return results;
        }

        public SaveVM SaveCurrency(Currency obj)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = obj.Id };
                var Name = new SqlParameter { ParameterName = "Name", Value = obj.Name == null ? DBNull.Value : obj.Name };
                var ShortName = new SqlParameter { ParameterName = "ShortName", Value = obj.ShortName == null ? DBNull.Value : obj.ShortName };
                var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
                var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateCurrency_SP  @ID,@Name,@ShortName,@IsActive,@Creator",
                    ID, Name, ShortName, isActive, Creator).FirstOrDefault();
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
