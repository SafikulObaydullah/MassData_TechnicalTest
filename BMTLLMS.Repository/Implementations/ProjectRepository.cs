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
    public class ProjectRepository : IProjectRepo
    {
        private readonly RavenDBContext _db;
        public ProjectRepository(RavenDBContext db)
        {
            _db = db;
        }
        public SaveVM SaveProject(ProjectVM obj)
        {
            try
            {
                var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
                var Name = new SqlParameter
                {
                    ParameterName = "Name",
                    Value = obj.Name == null ? DBNull.Value : obj.Name
                };
                var ContactPerson = new SqlParameter
                {
                    ParameterName = "contactPerson",
                    Value = obj.contactPerson == null ? DBNull.Value : obj.contactPerson
                };
                var ContactPhone = new SqlParameter
                {
                    ParameterName = "contactPhone",
                    Value = obj.contactPhone == null ? DBNull.Value : obj.contactPhone
                };
                var ContactEmail = new SqlParameter
                {
                    ParameterName = "contactEmail",
                    Value = obj.contactEmail == null ? DBNull.Value : obj.contactEmail
                };
                var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
                var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
                var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateProject_SP  @ID,@Name,@contactPerson,@contactPhone,@contactEmail,@IsActive,@Creator",
                    ID, Name, ContactPerson, ContactPhone, ContactEmail, isActive, Creator).FirstOrDefault();
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
        public IEnumerable<ProjectVM> GetProject(long Id)
        {
            var parms = new SqlParameter("@ID", Id);
            var result = _db.Database.SqlQuery<ProjectVM>("GetProject_SP @ID", parms).ToList();
            return result;
        }
    }
}
