using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Common
{
   public enum ProjectCodes
   {
      None = 0,
      Success = 200,
      BadRequest = 400,
      Unauthorized = 401,
      NotFound = 404,
      Error = 500
   }
   public enum StatusMessage
   {
      [EnumMember(Value = "Success")]
      Success,
      [EnumMember(Value = "Error")]
      Error,
   }
}
