using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Contracts
{
    public interface IUserFacade
    {
      SaveVM SaveUser(UserVM obj);
      IEnumerable<UserVM> GetUser(Int64 Id);
      public SaveVM ChangePassword(UserVM obj);
   }
}
