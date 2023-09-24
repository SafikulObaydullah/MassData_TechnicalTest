using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
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
   public class PriceAgreementSearchRepository : IPriceAgreementSearchRepo
   {
      private readonly RavenDBContext _db;
      public PriceAgreementSearchRepository(RavenDBContext db)
      {
         _db = db;
      }

      
      public IEnumerable<PriceAgreementSearchListVM> PriceAgreementSearch(PriceAgreementSearchVM obj)
      {
         var CustomerID = new SqlParameter
         {
            ParameterName = "CustomerID",
            Value = obj.CustomerID
         };
         var AgreementDate = new SqlParameter
         {
            ParameterName = "AgreementFromDate",
            Value = obj.AgreementDate
         };
         var AgreementToDate = new SqlParameter
         {
            ParameterName = "AgreementToDate",
            Value = obj.AgreementDate
         };
         var EffectiveDateFrom = new SqlParameter
         {
            ParameterName = "EffectiveFromDate",
            Value = obj.EffectiveDateFrom
         };
         var EffectiveDateTo = new SqlParameter
         {
            ParameterName = "EffectiveToDate",
            Value = obj.EffectiveDateTo
         };
         var SPname = "PriceAgreementSearch_SP " + obj.CustomerID + ",'" + obj.AgreementDate + "','" + obj.AgreementToDate + "','" + obj.EffectiveDateFrom + "','" + obj.EffectiveDateTo + "'";

         var result = _db.Database.SqlQuery<PriceAgreementSearchListVM>(SPname).ToList();

         return result;
      }
      public IEnumerable<PriceAgreementParentAndChildVM> GetPriceAgreementChildDetails(long Id)
      {
         var ID = new SqlParameter("@ID", Id); 
         var result = _db.Database.SqlQuery<PriceAgreementParentAndChildVM>("GetPriceAgreementParentAndChild_SP  @ID", ID).ToList();
         return result;
      } 
   }
}
