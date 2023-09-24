using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.Models
{
    internal class ErrorLog
    {
        public Int64 Id { get; set; }
        public string? ErrorMsg { get; set; }
        public string? SpName { get; set; }
        public string? ErrorMsgCode { get; set; }
        public string? ErrorMsgFull { get; set; }
        public DateTime? ErrorTime { get; set; }
        public string? controller { get; set; }
        public Int64 UserId { get; set; }
    }
}
