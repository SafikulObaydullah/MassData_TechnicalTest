using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Domain.ViewModel.Response.API
{
    public class TestEntryDashboardResponse
    {
        public int TestDataEntryPending { get; set; }
        public int ReturnByTechnicalManager { get; set; }
        public int TestDataNotYetSubmit { get; set; }
    }
}
