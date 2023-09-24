using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Repository.Contracts;
using BMTLLMS.Repository.Implementations;
using BMTLLMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Implementations
{
   public class DocUploadFacade : IDocUploadFacade
   {
      private readonly IDocUploadRepo _docUploadRepository;
      public DocUploadFacade(IDocUploadRepo docUploadRepo)
      {
         this._docUploadRepository = docUploadRepo;
      }
      public SaveVM SaveDocUpload(DocUploadVM obj)
      {
         return _docUploadRepository.SaveDocUpload(obj);
      }
      public IEnumerable<DocUploadVM> GetDocUpload(Int64 Id)
      {
         return _docUploadRepository.GetDocUpload(Id);
      } 
   }
}
