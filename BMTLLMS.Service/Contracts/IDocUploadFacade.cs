﻿using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using MassData.Domain.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Contracts
{
   public interface IDocUploadFacade
   {
      SaveVM SaveDocUpload(DocUploadVM obj);
      SaveVM GlobalFileUrl(GlobalFileUrl obj);
      IEnumerable<DocUploadVM> GetDocUpload(Int64 Id);
      IEnumerable<GlobalFileUrl> GetGlobalFileUrl(Int64 Id);
      IEnumerable<GlobalFileUrl> DeleteGlobalFileUrl(Int64 Id);
   }
}
