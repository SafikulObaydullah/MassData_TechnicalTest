using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Response
{
    public class OrderEntrySaveVM
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public IEnumerable<OrderDetailVM> data { get; set; }
    }
}
