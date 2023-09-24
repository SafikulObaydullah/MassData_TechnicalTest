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
   public class CompanyRepository : ICompanyRepo
   {
      private readonly RavenDBContext _db;
      public CompanyRepository(RavenDBContext db)
      {
         _db = db;
      }
      public SaveVM SaveCompany(Company obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.Id };
            var Name = new SqlParameter
            {
               ParameterName = "Name",
               Value = obj.Name == null ? DBNull.Value : obj.Name
            };
            var Logo = new SqlParameter
            {
               ParameterName = "Logo",
               Value = obj.Logo == null ? DBNull.Value : obj.Logo
            };
            var WebsiteAddress = new SqlParameter
            {
               ParameterName = "WebsiteAddress",
               Value = obj.WebsiteAddress == null ? DBNull.Value : obj.WebsiteAddress
            };
            var EmailAddress = new SqlParameter
            {
               ParameterName = "EmailAddress",
               Value = obj.EmailAddress == null ? DBNull.Value : obj.EmailAddress
            };
            var PhoneNumber = new SqlParameter
            {
               ParameterName = "PhoneNumber",
               Value = obj.PhoneNumber == null ? DBNull.Value : obj.PhoneNumber
            };
            var PhysicalAddress = new SqlParameter
            {
               ParameterName = "PhysicalAddress",
               Value = obj.PhysicalAddress == null ? DBNull.Value : obj.PhysicalAddress
            };
            var Fax = new SqlParameter
            {
               ParameterName = "Fax",
               Value = obj.Fax == null ? DBNull.Value : obj.Fax
            };
            var LocationLat = new SqlParameter
            {
               ParameterName = "LocationLat",
               Value = obj.LocationLat == null ? DBNull.Value : obj.LocationLat
            };
            var LocationLng = new SqlParameter
            {
               ParameterName = "LocationLng",
               Value = obj.LocationLng == null ? DBNull.Value : obj.LocationLng
            };
            var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.isActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateCompany_SP  @ID,@Name,@Logo,@WebsiteAddress,@EmailAddress,@PhoneNumber,@PhysicalAddress,@Fax,@LocationLat,@LocationLng,@IsActive,@Creator",
                ID, Name, Logo, WebsiteAddress, EmailAddress, PhoneNumber, PhysicalAddress, Fax, LocationLat, LocationLng, isActive, Creator).FirstOrDefault();
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
      public IEnumerable<Company> GetCompany (Int64 Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<Company>("GetCompany_SP @ID", parms).ToList();
         return result;
      }

   }
}
