
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
   public interface IProjectFacade
   {
      SaveVM SaveProject(ProjectVM obj);
      IEnumerable<ProjectVM> GetProject(Int64 Id);
   }
}
