using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class PowerMeterService : IPowerMeterService
    {
        private readonly IRepository<PowerMeter> _repository;

        public PowerMeterService(IRepository<PowerMeter> repository)
        {
            _repository = repository;
        }

        protected PowerMeterVM ConvertToViewModel(PowerMeter entity) => new PowerMeterVM
        {
            Id = entity.Id,
            Name = entity.Name,
            Value = entity.Value,
            AddedOn = entity.AddedOn
        };

        public ReturnVM Create(PowerMeterBM model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PowerMeterVM> Find(Func<PowerMeter, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PowerMeterVM> GetAll()
        {
            return _repository.GetAll().Select(entity => ConvertToViewModel(entity)); 
        }

        public PowerMeterVM GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Update(PowerMeterVM model)
        {
            throw new NotImplementedException();
        }




    }
}
