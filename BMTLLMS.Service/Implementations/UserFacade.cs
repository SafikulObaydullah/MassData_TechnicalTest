using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Repository.Contracts;
using BMTLLMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Implementations
{ 
   public class UserFacade: IUserFacade
    {
      private readonly IUserRepository _userRepository;
      public UserFacade(IUserRepository userRepository)
      {
         this._userRepository = userRepository;
      } 
      public IEnumerable<UserVM> GetUser(long Id)
      {
         return _userRepository.GetUser(Id);
      } 
      public SaveVM SaveUser(UserVM obj)
      {
         return _userRepository.SaveUser(obj);
      }
      public SaveVM ChangePassword(UserVM obj)
      {
         return _userRepository.ChangePassword(obj);
      }
   }
}
