
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
   public class MachineRepository : IMachinRepo
   {
      private readonly RavenDBContext _db;
      public MachineRepository(RavenDBContext db)
      {
         _db = db;
      }
      public SaveVM SaveMachine(MachineVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var Name = new SqlParameter
            {
               ParameterName = "Name",
               Value = obj.Name == null ? DBNull.Value : obj.Name
            };
            var JawType = new SqlParameter
            {
               ParameterName = "JawType",
               Value = obj.JawType == null ? DBNull.Value : obj.JawType
            };
            var MachineTypeAttributeID = new SqlParameter
            {
               ParameterName = "MachineTypeAttributeID",
               Value = obj.MachineTypeAttributeID == null ? DBNull.Value : obj.MachineTypeAttributeID
            };
            var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateMachine_SP  @ID,@Name,@JawType,@MachineTypeAttributeID,@IsActive,@Creator",
                ID, Name, JawType, MachineTypeAttributeID,isActive, Creator).FirstOrDefault();
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
      public IEnumerable<MachineVM>GetMachine(long Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<MachineVM>("GetMachine_SP @ID", parms).ToList();
         return result;
      }

   }
}
