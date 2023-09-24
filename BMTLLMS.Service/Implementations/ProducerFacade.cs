using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Repository.Contracts;
using BMTLLMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Implementations
{
    public class ProducerFacade : IProducerFacade 
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerFacade(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;

        }

        public IEnumerable<Producer> Get()
        {
            return _producerRepository.Get();

        }

        public SaveVM SaveProducer(Producer producer)
        {
            return _producerRepository.SaveProducer(producer);
        }
    }
}
