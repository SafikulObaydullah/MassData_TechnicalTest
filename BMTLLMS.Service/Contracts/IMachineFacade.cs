

using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Contracts
{
   public interface IMachineFacade
   {
      SaveVM SaveMachine(MachineVM obj);
      IEnumerable<MachineVM> GetMachine(Int64 Id);
   }
}
