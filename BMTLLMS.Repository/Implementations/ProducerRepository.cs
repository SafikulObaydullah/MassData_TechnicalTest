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
    public class ProducerRepository : IProducerRepository
    {
        private readonly RavenDBContext _db;
        public ProducerRepository(RavenDBContext ravenDBContext)
        {
            _db = ravenDBContext;
        }

        public IEnumerable<Producer> Get()
        {
            var paramList = new SqlParameter("ID", Convert.ToInt64(0));
            var results = _db.Database.SqlQuery<Producer>("GetProducer_sp", paramList).ToList();
            return results;
        }

        public SaveVM SaveProducer(Producer obj)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = obj.Id };
                var Name = new SqlParameter { ParameterName = "Name", Value = obj.Name == null ? DBNull.Value : obj.Name };
                var Address = new SqlParameter { ParameterName = "Address", Value = obj.Address == null ? DBNull.Value : obj.Address };
                var ContactPerson = new SqlParameter { ParameterName = "ContactPerson", Value = obj.ContactPerson == null ? DBNull.Value : obj.ContactPerson };
                var Phone = new SqlParameter { ParameterName = "Phone", Value = obj.Phone == null ? DBNull.Value : obj.Phone };
                var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.isActive };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
                var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateProducer_SP  @ID,@Name,@Address,@ContactPerson,@Phone,@IsActive,@Creator",
                    ID, Name, Address, ContactPerson, Phone, isActive, Creator).FirstOrDefault();
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
