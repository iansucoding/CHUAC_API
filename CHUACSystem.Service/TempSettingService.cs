using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class TempSettingService : ITempSettingService
    {
        private IRepository<TempSetting> _repository;

        public TempSettingService(IRepository<TempSetting> repository)
        {
            _repository = repository;
        }
        protected TempSettingView ConvertToViewModel(TempSetting entity) => new TempSettingView
        {
            Id = entity.Id,
            SeqNo = entity.SeqNo,
            Name = entity.Name,
            Adjust = entity.Adjust
        };
        public IEnumerable<TempSettingView> GetAll()
        {
            return _repository.GetAll().OrderBy(x=>x.Sequence).Select(x => ConvertToViewModel(x));
        }

        public ReturnVM Update(TempSettingView model)
        {
            var result = new ReturnVM();
            try
            {
                var entity = _repository.GetById(model.Id);
                entity.ModifiedOn = DateTime.Now;
                entity.Adjust = model.Adjust;
                _repository.Update(entity);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
        //以下用不到

        public ReturnVM Create(TempSettingBase model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TempSettingView> Find(Func<TempSetting, bool> predicate)
        {
            throw new NotImplementedException();
        }
        public TempSettingView GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
