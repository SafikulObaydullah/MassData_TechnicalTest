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
   public class SampleReceiveFacade : ISampleReceiveFacade
   {
      private readonly ISampleReceiveRepo _sampleReceiveRepository;
      public SampleReceiveFacade(ISampleReceiveRepo SampleReceiveRepo)
      {
         this._sampleReceiveRepository = SampleReceiveRepo;
      }

      public IEnumerable<OrderDetailsListVM> GetOrderDetailList(SampleReceiveSearchListVM obj)
      {
         return _sampleReceiveRepository.GetOrderDetailList(obj);
      } 
      public SaveVM SaveSampleReceive(SampleReceiveVM obj)
      {
         return _sampleReceiveRepository.SaveSampleReceive(obj);
      }
   }
}
