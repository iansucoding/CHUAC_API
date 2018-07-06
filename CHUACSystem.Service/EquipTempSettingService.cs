using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class EquipTempSettingService : IEquipTempSettingService
    {
        private IRepository<EquipTempSetting> _repository;

        public EquipTempSettingService(IRepository<EquipTempSetting> repository)
        {
            _repository = repository;
        }

        protected EquipTempSettingVM ConvertToViewModel(EquipTempSetting entity) => new EquipTempSettingVM
        {
            Id = entity.Id,
            Name = entity.Name,
            Start = entity.Start,
            End = entity.End,
        };

        public IEnumerable<EquipTempSettingVM> GetAll()
        {
            return _repository.GetAll().Select(x => ConvertToViewModel(x));
        }

        public ReturnVM Update(EquipTempSettingVM model)
        {
            var result = new ReturnVM();
            try
            {
                var entity = _repository.GetById(model.Id);
                entity.ModifiedOn = DateTime.Now;
                entity.Start = model.Start;
                entity.End = model.End;
                _repository.Update(entity);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        // 以下用不到
        public ReturnVM Create(EquipTempSettingBM model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipTempSettingVM> Find(Func<EquipTempSetting, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public EquipTempSettingVM GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
