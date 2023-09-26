using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Repository.Contracts;
using EntityFrameworkCore.RawSQLExtensions.Extensions;
using MassData.Domain.ViewModel.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Implementations
{
   public class DocUploadRepository : IDocUploadRepo
   {
      private readonly RavenDBContext _db;
      public DocUploadRepository(RavenDBContext db)
      {
         _db = db;
      }
      public SaveVM SaveDocUpload(DocUploadVM obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var TransactionTypeAttributeID = new SqlParameter
            {
               ParameterName = "TransactionTypeAttributeID",
               Value = obj.TransactionTypeAttributeID == null ? DBNull.Value : obj.TransactionTypeAttributeID
            };
            var TransactionID = new SqlParameter
            {
               ParameterName = "TransactionID",
               Value = obj.TransactionID == null ? DBNull.Value : obj.TransactionID
            };
            var DocName = new SqlParameter
            {
               ParameterName = "DocName",
               Value = obj.DocName == null ? DBNull.Value : obj.DocName
            };
            var DocExtension = new SqlParameter
            {
               ParameterName = "DocExtension",
               Value = obj.DocExtension == null ? DBNull.Value : obj.DocExtension
            };
            var FileName = new SqlParameter
            {
               ParameterName = "FileName",
               Value = obj.FileName == null ? DBNull.Value : obj.FileName
            };
            var isActive = new SqlParameter { ParameterName = "isActive", Value = obj.IsActive };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateDocUpload_SP  @ID,@TransactionTypeAttributeID,@TransactionID,@DocName,@DocExtension,@FileName,@IsActive,@Creator",
                ID, TransactionTypeAttributeID, TransactionID, DocName, DocExtension, FileName, isActive, Creator).FirstOrDefault();
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
      public IEnumerable<DocUploadVM> GetDocUpload(Int64 Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<DocUploadVM>("GetDocUpload_T_SP @ID", parms).ToList();
         return result;
      }
      public SaveVM GlobalFileUrl(GlobalFileUrl obj)
      {
         try
         {
            var ID = new SqlParameter { ParameterName = "ID", Value = obj.ID };
            var ReferrenceNo = new SqlParameter
            {
               ParameterName = "ReferrenceNo",
               Value = obj.ReferrenceNo == null ? DBNull.Value : obj.ReferrenceNo
            };
            var FileServerId = new SqlParameter
            {
               ParameterName = "FileServerId",
               Value = obj.FileServerId == null ? DBNull.Value : obj.FileServerId
            };
            var ReferenceDescription = new SqlParameter
            {
               ParameterName = "ReferenceDescription",
               Value = obj.ReferenceDescription == null ? DBNull.Value : obj.ReferenceDescription
            };
            var DocumentTypeId = new SqlParameter
            {
               ParameterName = "DocumentTypeId",
               Value = obj.DocumentTypeId == null ? DBNull.Value : obj.DocumentTypeId
            };
            var DocumentName = new SqlParameter
            {
               ParameterName = "DocumentName",
               Value = obj.DocumentName == null ? DBNull.Value : obj.DocumentName
            };
            var NumFileSize = new SqlParameter
            {
               ParameterName = "NumFileSize",
               Value = obj.NumFileSize == null ? DBNull.Value : obj.NumFileSize
            };
            var FileExtension = new SqlParameter
            {
               ParameterName = "FileExtension",
               Value = obj.FileExtension == null ? DBNull.Value : obj.FileExtension
            };
            var ServerLocation = new SqlParameter
            {
               ParameterName = "ServerLocation",
               Value = obj.ServerLocation == null ? DBNull.Value : obj.ServerLocation
            };
            var isActive = new SqlParameter { ParameterName = "isActive", Value = true };
            var Creator = new SqlParameter { ParameterName = "Creator", Value = obj.Creator };
            var result = _db.Database.SqlQuery<SaveVM>("InsertUpdateGlobalFileUrl_SP  @ID,@ReferrenceNo,@FileServerId,@ReferenceDescription,@DocumentTypeId,@DocumentName,@NumFileSize,@FileExtension,@ServerLocation,@IsActive,@Creator",
                ID, ReferrenceNo, FileServerId, ReferenceDescription, DocumentTypeId, DocumentName, NumFileSize, FileExtension, ServerLocation, isActive, Creator).FirstOrDefault();
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

      public IEnumerable<GlobalFileUrl> GetGlobalFileUrl(long Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<GlobalFileUrl>("GetGlobalFileUrl_SP @ID", parms).ToList();
         return result;
      }

      public IEnumerable<GlobalFileUrl> DeleteGlobalFileUrl(long Id)
      {
         var parms = new SqlParameter("@ID", Id);
         var result = _db.Database.SqlQuery<GlobalFileUrl>("DeleteGlobalFileUrl_SP @ID", parms).ToList();
         return result;
      }
   }
}
