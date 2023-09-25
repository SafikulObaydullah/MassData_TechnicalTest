﻿using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Contracts
{
   public interface IPriceAgreementSearchRepo
   { 
      IEnumerable<PriceAgreementSearchListVM> PriceAgreementSearch(PriceAgreementSearchVM obj); 
      IEnumerable<PriceAgreementParentAndChildVM> GetPriceAgreementChildDetails(Int64 Id); 
   }
}