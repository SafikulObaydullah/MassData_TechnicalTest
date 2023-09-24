using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Response.Login
{
    public class LoginResponse
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
       public loginUser? Data { get; set; }
        public string? Token { get; set; }
    }
    public class loginUser
    {
        public string? Name { get; set; }
        public string? Designation  {get; set; }
    public string?  Section { get; set; }
        public string? UUserType 
        {
            get; set;
        }
    }
}
