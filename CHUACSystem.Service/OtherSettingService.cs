using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class OtherSettingService : IOtherSettingService
    {
        private IRepository<OtherSetting> _repository;

        public OtherSettingService(IRepository<OtherSetting> repository)
        {
            _repository = repository;
        }
        protected OtherSettingView ConvertToViewModel(OtherSetting entity) => new OtherSettingView
        {
            Id = entity.Id,
            Name = entity.Name,
            Value = entity.Value
        };

        public OtherSettingView GetPumpDelayTime()
        {
            var result =  _repository.GetQueryable().Where(x => x.Name == "區域泵浦延遲停止時間").FirstOrDefault();
            if (result != null)
            {
                return ConvertToViewModel(result);
            }
            return null;
        }

        public ReturnVM Update(OtherSettingView model)
        {
            var result = new ReturnVM();
            try
            {
                var entity = _repository.GetById(model.Id);
                entity.ModifiedOn = DateTime.Now;
                entity.Value = model.Value;
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
        public ReturnVM Create(OtherSettingBase model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OtherSettingView> Find(Func<OtherSetting, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OtherSettingView> GetAll()
        {
            throw new NotImplementedException();
        }

        public OtherSettingView GetById(long id)
        {
            throw new NotImplementedException();
        }


    }
}
