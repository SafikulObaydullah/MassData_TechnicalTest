using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.Models.Request;
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
   public class AccountFacade : IAccountFacade
   {
      private readonly IAccountRepo _accountRepo;
      public AccountFacade(IAccountRepo accountRepo)
      {
         this._accountRepo = accountRepo;
      }
      public IEnumerable<LoginUser> GetAuthenticUserData(Login o)
      {
         return _accountRepo.GetAuthenticUserData(o);
      }
      //public IEnumerable<LoginUser> GetAllUserData(long id)
      //{
      //   return _accountRepo.GetAllUserData(id);
      //}
      public IEnumerable<SaveVM> SaveUser(LoginUser o)
      {
         return _accountRepo.SaveUser(o);
      }
      public async Task<IEnumerable<LoginUser>> GetAuthenticUserDataAsync(MLogin o)
        {
            return await _accountRepo.GetAuthenticUserDataAsync(o);
        }
   }
}
