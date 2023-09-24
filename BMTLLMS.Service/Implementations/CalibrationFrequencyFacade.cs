using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
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
    public class CalibrationFrequencyFacade : ICalibrationFrequencyFacade
    {
        private readonly ICalibrationFrequencyRepository _calibrationFrequencyRepository;
        public CalibrationFrequencyFacade(ICalibrationFrequencyRepository calibrationFrequencyRepo)
        {
            this._calibrationFrequencyRepository = calibrationFrequencyRepo;
        }
        public SaveVM SaveCalibrationFrequency(CalibrationFrequencyVM obj)
        {
            return _calibrationFrequencyRepository.SaveCalibrationFrequency(obj);
        }
        public IEnumerable<CalibrationFrequencyVM> GetCalibrationFrequency()
        {
            return _calibrationFrequencyRepository.GetCalibrationFrequency();
        }
    }
}
