using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.Models.Request;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Contracts
{
   public interface IAccountRepo
   {
      IEnumerable<LoginUser> GetAuthenticUserData(Login o);
      IEnumerable<LoginUser> GetAllUserData(long id);
      IEnumerable<SaveVM> SaveUser(LoginUser o);
      Task<IEnumerable<LoginUser>> GetAuthenticUserDataAsync(MLogin o);
   }
}
