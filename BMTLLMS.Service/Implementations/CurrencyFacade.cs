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
    public class CurrencyFacade : ICurrencyFacade
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyFacade(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;

        }

        public IEnumerable<Currency> Get()
        {
            return _currencyRepository.Get();

        }

        public SaveVM SaveCurrency(Currency currency)
        {
            return _currencyRepository.SaveCurrency(currency);
        }
    }
}
