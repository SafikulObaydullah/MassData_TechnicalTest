using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Contracts
{
    public interface ISampleTypeRepository
    {
        SaveVM SaveSampleType(SampleType obj);
        IEnumerable<SampleType> Get();
    }
}
