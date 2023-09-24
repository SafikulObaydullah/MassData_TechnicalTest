using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Contracts
{
    public interface IProducerFacade
    {
        SaveVM SaveProducer(Producer obj);
        IEnumerable<Producer> Get();
    }
}
