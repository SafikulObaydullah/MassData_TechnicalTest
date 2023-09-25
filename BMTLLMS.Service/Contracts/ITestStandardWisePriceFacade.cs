﻿using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Contracts
{
   public interface ITestStandardWisePriceFacade
   {
      SaveVM SaveTestStandardWisePrice(TestStandardWisePriceVM obj);
      IEnumerable<TestStandardWisePriceVM> GetTestStandardWisePrice(Int64 Id); 
   }
}