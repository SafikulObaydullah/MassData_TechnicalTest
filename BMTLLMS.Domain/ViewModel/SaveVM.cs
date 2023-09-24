using BMTLLMS.Domain.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel
{
    public class SaveVM
    {
        public Int64 ID { get; set; }
        public string GID { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
