

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
   public class MeasurementUnitFacade : IMeasurementUnitFacade
   {
      private readonly IMeasurementUnitRepo _measurementRepository;
      public MeasurementUnitFacade(IMeasurementUnitRepo measurementRepo)
      {
         this._measurementRepository = measurementRepo;
      }
      public SaveVM SaveMeasurementUnit(MeasurementUnitVM obj)
      {
           return _measurementRepository.SaveMeasurementUnit(obj);
      }
      public IEnumerable<MeasurementUnitVM> GetMeasurementUnit(long Id)
      {
         return _measurementRepository.GetMeasurement(Id);
      }
   }
}
