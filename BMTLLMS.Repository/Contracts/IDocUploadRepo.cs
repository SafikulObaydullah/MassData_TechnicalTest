﻿using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using MassData.Domain.ViewModel.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Repository.Contracts
{
   public interface IDocUploadRepo
   {
      SaveVM SaveDocUpload(DocUploadVM obj);
      IEnumerable<DocUploadVM> GetDocUpload(Int64 Id);
      SaveVM GlobalFileUrl(GlobalFileUrl obj);
      IEnumerable<GlobalFileUrl> GetGlobalFileUrl(Int64 Id);
      IEnumerable<GlobalFileUrl> DeleteGlobalFileUrl(Int64 Id);
   }
}
