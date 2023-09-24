using Microsoft.Extensions.DependencyInjection;
using BMTLLMS.Repository.Contracts;
using BMTLLMS.Repository.Implementations;
using BMTLLMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BMTLLMS.Service.Implementations
{
    public class FacadeRegistration : IFacadeRegistration
    {
        public static IRepositoryRegistration Registration { get; set; } = new RepositoryRegistration();

        public void AddInfrastucture(IServiceCollection services, string conStr)
        {
            Registration.AddInfrastucture(services, conStr);

            services.AddTransient<IUserFacade, UserFacade>();
            services.AddTransient<ICompanyFacade, CompanyFacade>();
            services.AddTransient<IAttributeFacade, AttributeFacade>();
            services.AddTransient<IMachineFacade, MachineFacade>();
            services.AddTransient<IMeasurementUnitFacade, MeasurementUnitFacade>();
            services.AddTransient<IProjectFacade, ProjectFacade>();
            services.AddTransient<ICustomerFacade, CustomerFacade>();
            services.AddTransient<ICurrencyFacade, CurrencyFacade>();
            services.AddTransient<IProducerFacade, ProducerFacade>();
            services.AddTransient<IPaymentMethodFacade, PaymentMethodFacade>();
            services.AddTransient<ISampleTypeFacade, SampleTypeFacade>();
            services.AddTransient<ISpecificationHeadFacade, SpecificationHeadFacade>();
            services.AddTransient<IAttributeTypeFacade, AttributeTypeFacade>();

            #region =====================Obaydullah==========================

            services.AddTransient<ITestFacade, TestFacade>();
            services.AddTransient<ITestStandardFacade, TestStandardFacade>();
            services.AddTransient<ITestStandardWisePriceFacade, TestStandardWisePriceFacade>();
            services.AddTransient<IPriceAgreementFacade, PriceAgreementFacade>();
            services.AddTransient<IPriceAgreementChildFacade, PriceAgreementChildFacade>();
            services.AddTransient<ITestFacade, TestFacade>();
            services.AddTransient<ITestStandardFacade, TestStandardFacade>();
            services.AddTransient<IDocUploadFacade, DocUploadFacade>();
            services.AddTransient<ISampleReceiveFacade, SampleReceiveFacade>();
            services.AddTransient<IAccountFacade, AccountFacade>();
            services.AddTransient<IPriceAgreementSearchFacade, PriceAgreementSearchFacade>();








            #endregion ==================Obaydullah==========================

            #region =====================Iftekhar==========================
            services.AddTransient<ISampleCategoryFacade, SampleCategoryFacade>();
            services.AddTransient<ISectionFacade, SectionFacade>();
            services.AddTransient<ICalibrationFrequencyFacade, CalibrationFrequencyFacade>();
            services.AddTransient<ISampleTypeVsSpecificationTypeFacade, SampleTypeVsSpecificationTypeFacade>();
            services.AddTransient<ISampleTypeVsTestStandardFacade, SampleTypeVsTestStandardFacade>();
            services.AddTransient<ITestStandardVsMachineFacade, TestStandardVsMachineFacade>();
            services.AddTransient<ITestSampleInfoFacade, TestSampleInfoFacade>();
            services.AddTransient<IOrderEntryFacade, OrderEntryFacade>();
            services.AddTransient<IOrderEntrySearchFacade, OrderEntrySearchFacade>();











            #endregion ==================Iftekhar==========================

        }
    }
}
