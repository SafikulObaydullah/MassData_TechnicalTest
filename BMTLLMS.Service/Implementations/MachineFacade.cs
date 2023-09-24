
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
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
   public class MachineFacade : IMachineFacade
   {
      private readonly IMachinRepo _machineRepository;
      public MachineFacade(IMachinRepo machineRepo)
      {
         this._machineRepository = machineRepo;
      }
      public SaveVM SaveMachine(MachineVM obj)
      {
         return _machineRepository.SaveMachine(obj);
      }
      public IEnumerable<MachineVM> GetMachine(long Id)
      {
         return _machineRepository.GetMachine(Id);
      }
   }
}
