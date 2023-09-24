using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.Models.Request
{
    public class MLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }
    }
}
