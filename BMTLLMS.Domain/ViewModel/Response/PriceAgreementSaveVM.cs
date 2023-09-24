using BMTLLMS.Domain.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Response
{
    public class PriceAgreementSaveVM
   {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public IEnumerable<PriceAgreementParentAndChildVM> data { get; set; }
    }
}
