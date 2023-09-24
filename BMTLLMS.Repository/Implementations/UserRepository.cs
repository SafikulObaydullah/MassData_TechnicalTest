using BMTLLMS.Common;
using BMTLLMS.Common.Security;
using BMTLLMS.Domain;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Repository.Contracts;
using EntityFrameworkCore.RawSQLExtensions.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Implementations
{
   public class UserRepository : IUserRepository
   {
      private readonly RavenDBContext _db;
      IConfiguration _configurations;
      public UserRepository(RavenDBContext db, IConfiguration configuration)
      {
         _db = db;
         _configurations = configuration;
      }
      public IEnumerable<UserVM> GetUser(long Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<UserVM>("GetUser_SP @ID", parms).ToList();
         return result;
      }

      public SaveVM SaveUser(UserVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var Name = new SqlParameter
            {
               ParameterName = "Name",
               Value = obj.Name == null ? DBNull.Value : obj.Name
            };
            var UserName = new SqlParameter
            {
               ParameterName = "UserName",
               Value = obj.UserName == null ? DBNull.Value : obj.UserName
            };
            var Email = new SqlParameter
            {
               ParameterName = "Email",
               Value = obj.Email == null ? DBNull.Value : obj.Email
            };
            object strpassword = "";
            if (obj.Password != "" || obj.Password != null)
            {
               strpassword = TextEncryptionDecryption.Encrypt(obj.Password, _configurations["EncryptionKeys:Key2"].ToString());
            }
            //var EncToken = context.HttpContext.Request.Cookies["_userauthorizetoken"];
            //var token = TextEncryptionDecryption.Decrypt(EncToken, config["EncryptionKeys:Key4"].ToString());
            var Password = new SqlParameter
            {
               ParameterName = "Password",
               Value = strpassword == "" ? DBNull.Value : strpassword
            };
            //var Password = new SqlParameter
            //{
            //   ParameterName = "Password",
            //   Value = obj.Password == null ? DBNull.Value : obj.Password
            //};
            var Designation = new SqlParameter
            {
               ParameterName = "Designation",
               Value = obj.Designation == null ? DBNull.Value : obj.Designation
            };
            var UserTypeAttributeID = new SqlParameter
            {
               ParameterName = "UserTypeAttributeID",
               Value = obj.UserTypeAttributeID == null ? DBNull.Value : obj.UserTypeAttributeID
            };
            var UserSectionID = new SqlParameter
            {
               ParameterName = "UserSectionID",
               Value = obj.UserSectionID == null ? DBNull.Value : obj.UserSectionID
            };
            var PasswordChange = new SqlParameter
            {
               ParameterName = "PasswordChange",
               Value = 0
            };
            var isActive = new SqlParameter { ParameterName = "IsActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateUserInfo_SP  @ID,@Name,@UserName,@Email,@Password,@PasswordChange,@Designation,@UserTypeAttributeID,@UserSectionID,@IsActive,@Creator",
                ID, Name, UserName, Email, Password, PasswordChange, Designation,UserTypeAttributeID, UserSectionID,isActive, Creator).FirstOrDefault();
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
      public SaveVM ChangePassword(UserVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var Name = new SqlParameter
            {
               ParameterName = "Name",
               Value = obj.Name == null ? DBNull.Value : obj.Name
            };
            object strpassword = "";
            if (obj.Password != "" || obj.Password != null)
            {
               strpassword = TextEncryptionDecryption.Encrypt(obj.Password, _configurations["EncryptionKeys:Key2"].ToString());
            }
            //var EncToken = context.HttpContext.Request.Cookies["_userauthorizetoken"];
            //var token = TextEncryptionDecryption.Decrypt(EncToken, config["EncryptionKeys:Key4"].ToString());
            var Password = new SqlParameter
            {
               ParameterName = "Password",
               Value = strpassword == "" ? DBNull.Value : strpassword
            };
            var PasswordChange = new SqlParameter
            {
               ParameterName = "PasswordChange",
               Value = 1
            };
            var UserName = new SqlParameter
            {
               ParameterName = "UserName",
               Value = ""
            };
            var Email = new SqlParameter
            {
               ParameterName = "Email",
               Value = ""
            };
            var Designation = new SqlParameter
            {
               ParameterName = "Designation",
               Value = ""
            };
            var UserTypeAttributeID = new SqlParameter
            {
               ParameterName = "UserTypeAttributeID",
               Value = ""
            };
            var UserSectionID = new SqlParameter
            {
               ParameterName = "UserSectionID",
               Value = ""
            };
            var isActive = new SqlParameter { ParameterName = "IsActive", Value = 1 };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = 1 };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateUserInfo_SP  @ID,@Name,@UserName,@Email,@Password,@PasswordChange,@Designation,@UserTypeAttributeID,@UserSectionID,@IsActive,@Creator",
                ID, Name, UserName, Email, Password, PasswordChange, Designation, UserTypeAttributeID, UserSectionID, isActive, Creator).FirstOrDefault();

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
