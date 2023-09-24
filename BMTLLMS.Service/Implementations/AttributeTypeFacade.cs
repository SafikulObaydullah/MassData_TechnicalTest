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
   public class AttributeTypeFacade : IAttributeTypeFacade
   {
      private readonly IAttributeTypeRepo _attributeTypeRepository;
      public AttributeTypeFacade(IAttributeTypeRepo attributeTypeRepo)
      {
         this._attributeTypeRepository = attributeTypeRepo;
      }
      public SaveVM SaveAttributeType(AttributTypeVM obj)
      {
         return _attributeTypeRepository.SaveAttributeType(obj);
      }

      public IEnumerable<AttributTypeVM> GetAttributeType(long Id)
      {
         return _attributeTypeRepository.GetAttributeType(Id);
      } 
   }
}
