using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.Models.Request;
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
   public class AccountRepository : IAccountRepo
   {
      private readonly RavenDBContext _db;
      public AccountRepository(RavenDBContext db)
      {
         _db = db;
      }
      public IEnumerable<LoginUser> GetAuthenticUserData(Login o)
      {
         string SP = "AuthenticateUserData_SP '" + o.Username + "','" + o.Password + "'";
         var result = _db.Database.SqlQuery<LoginUser>(SP).ToList();
         return result;
      }
        public async Task<IEnumerable<LoginUser>> GetAuthenticUserDataAsync(MLogin o)
        {
            string SP = "AuthenticateUserData_SP '" + o.UserName + "','" + o.Password + "'";
            var result = await  _db.Database.SqlQuery<LoginUser>(SP).ToListAsync();
            return  result;
        }



      public IEnumerable<LoginUser> GetAllUserData(long id)
      {
         string SP = "GetAllUserData_SP " + id;
         var result = _db.Database.SqlQuery<LoginUser>(SP).ToList();
         return result;
      }
      public IEnumerable<SaveVM> SaveUser(LoginUser o)
      {
         string SP = "InsertUpdateUserInfo_SP '" + o.ID + "','" + o.Name + "','" + o.UserName + "','" + o.Password + "'," + o.Email + ",'" + o.Designation + "'," + o.UserTypeAttributeID + "," + o.UserSectionID + "," + o.IsActive + "," + o.Creator + "";
         var result = _db.Database.SqlQuery<SaveVM>(SP).ToList();
         return result;
      }
   }
}
