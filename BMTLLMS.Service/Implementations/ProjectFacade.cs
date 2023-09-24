using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Repository.Contracts;
using BMTLLMS.Repository.Implementations;
using BMTLLMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMTLLMS.Service.Implementations
{
    public class ProjectFacade : IProjectFacade
    {
         private readonly IProjectRepo _projectRepository;
         public ProjectFacade(IProjectRepo projectRepo)
         {
            this._projectRepository = projectRepo;
         }
         public SaveVM SaveProject(ProjectVM obj)
         {
            return _projectRepository.SaveProject(obj);
         }
         public IEnumerable<ProjectVM> GetProject (Int64 Id)
         {
            return _projectRepository.GetProject(Id);
         }
    }
}
