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
   public class PriceAgreementChildRepository : IPriceAgreementChildRepo
   {
      private readonly RavenDBContext _db;
      public PriceAgreementChildRepository(RavenDBContext db)
      {
         _db = db;
      }
      public SaveVM SavePriceAgreementChild(PriceAgreementChildVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var ParentID = new SqlParameter
            {
               ParameterName = "ParentID",
               Value = obj.ParentID == null ? DBNull.Value : obj.ParentID
            };
            var TestStandardID = new SqlParameter
            {
               ParameterName = "TestStandardID",
               Value = obj.TestStandardID == null ? DBNull.Value : obj.TestStandardID
            };
            var SampleTypeID = new SqlParameter
            {
               ParameterName = "SampleTypeID",
               Value = obj.SampleTypeID == null ? DBNull.Value : obj.SampleTypeID
            };
            var RegularPrice = new SqlParameter
            {
               ParameterName = "RegularPrice",
               Value = obj.RegularPrice == null ? DBNull.Value : obj.RegularPrice
            };
            var ExpressPrice = new SqlParameter
            {
               ParameterName = "ExpressPrice",
               Value = obj.ExpressPrice == null ? DBNull.Value : obj.ExpressPrice
            };
            var CurrencyID = new SqlParameter
            {
               ParameterName = "CurrencyID",
               Value = obj.CurrencyID == null ? DBNull.Value : obj.CurrencyID
            };
            var Note = new SqlParameter
            {
               ParameterName = "Note",
               Value = obj.Note == null ? DBNull.Value : obj.Note
            };
            var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdatePriceAgreementChild_SP  @ID,@ParentID,@TestStandardID,@SampleTypeID,@RegularPrice,@ExpressPrice,@CurrencyID,@Note,@IsActive,@Creator",
                ID, ParentID, TestStandardID, SampleTypeID, RegularPrice, ExpressPrice, CurrencyID, Note,isActive, Creator).FirstOrDefault();
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
      public IEnumerable<PriceAgreementChildVM> GetPriceAgreementChild(long Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<PriceAgreementChildVM>("GetPriceAgreementChild @ID", parms).ToList();
         return result;
      }
   }
}
