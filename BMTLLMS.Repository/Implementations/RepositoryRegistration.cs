using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BMTLLMS.Domain;
using BMTLLMS.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BMTLLMS.Repository.Implementations
{
    public class RepositoryRegistration : IRepositoryRegistration
    {
        public void AddInfrastucture(IServiceCollection services, string conStr)
        {
            services.AddDbContext<RavenDBContext>(options =>
            {
                options.UseSqlServer(conStr);
            });
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICompanyRepo, CompanyRepository>();
            services.AddTransient<IAttributeRepo, AttributeRepository>();
            services.AddTransient<IMachinRepo, MachineRepository>();
            services.AddTransient<IMeasurementUnitRepo, MeasurementRepository>();
            services.AddTransient<IProjectRepo, ProjectRepository>();
            services.AddTransient<ICustomerRepo, CustomerRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IPaymentMethodRepo, PaymentMethodRepository>();
            services.AddTransient<ISampleTypeRepository, SampleTypeRepository>();
            services.AddTransient<ISpecificationHeadRepository, SpecificationHeadRepository>();
            services.AddTransient<IAttributeTypeRepo, AttributeTypeRepository>();

            #region =====================Obaydullah==========================

            services.AddTransient<ITestRepo, TestRepository>();
            services.AddTransient<ITestStandardRepo, TestStandardRepository>();
            services.AddTransient<ITestStandardWisePriceRepo, TestStandardWisePriceRepository>();
            services.AddTransient<IPriceAgreementRepo, PriceAgreementRepository>();
            services.AddTransient<IPriceAgreementChildRepo, PriceAgreementChildRepository>();
            services.AddTransient<ITestRepo, TestRepository>();
            services.AddTransient<ITestStandardRepo, TestStandardRepository>();
            services.AddTransient<ITestStandardWisePriceRepo, TestStandardWisePriceRepository>();
            services.AddTransient<IDocUploadRepo, DocUploadRepository>();
            services.AddTransient<ISampleReceiveRepo, SampleReceiveRepository>();
            services.AddTransient<IAccountRepo, AccountRepository>();
            services.AddTransient<IPriceAgreementSearchRepo, PriceAgreementSearchRepository>();









            #endregion ==================Obaydullah==========================

            #region =====================Iftekhar==========================
            services.AddTransient<ISampleCategoryRepository, SampleCategoryRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<ICalibrationFrequencyRepository, CalibrationFrequencyRepository>();
            services.AddTransient<ISampleTypeVsSpecificationTypeRepository, SampleTypeVsSpecificationTypeRepository>();
            services.AddTransient<ISampleTypeVsTestStandardRepository, SampleTypeVsTestStandardRepository>();
            services.AddTransient<ITestStandardVsMachineRepository, TestStandardVsMachineRepository>();
            services.AddTransient<ITestSampleInfoRepository, TestSampleInfoRepository>();
            services.AddTransient<IOrderEntryRepo, OrderEntryRepository>();
            services.AddTransient<IOrderEntrySearchRepository, OrderEntrySearchRepository>();


















            #endregion ==================Iftekhar==========================

        }

    }
}
