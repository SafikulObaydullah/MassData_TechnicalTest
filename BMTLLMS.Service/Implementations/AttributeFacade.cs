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
   public class AttributeFacade : IAttributeFacade
   {
      private readonly IAttributeRepo _attributeRepository;
      public AttributeFacade(IAttributeRepo attributeRepo)
      {
         this._attributeRepository = attributeRepo;
      }
      public SaveVM SaveAttribute(AttributeVM obj)
      {
         return _attributeRepository.SaveAttribute(obj);
      }
      public IEnumerable<AttributeVM> GetAttribute(Int64 Id, Int64 TypeID)
      {
         return _attributeRepository.GetAttribute(Id,TypeID);
      } 
   }
}
