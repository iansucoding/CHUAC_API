using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class OutTempSettingService : IOutTempSettingService
    {
        private IRepository<OutTempSetting> _repository;

        public OutTempSettingService(IRepository<OutTempSetting> repository)
        {
            _repository = repository;
        }
        protected OutTempSettingView ConvertToViewModel(OutTempSetting entity) => new OutTempSettingView
        {
            Id = entity.Id,
            Start = entity.Start,
            End = entity.End,
            Name = entity.Name
        };

        public IEnumerable<OutTempSettingView> GetAll()
        {
            return _repository.GetAll().Select(x => ConvertToViewModel(x));
        }


        public ReturnVM Update(OutTempSettingView model)
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
        //以下用不到

        public ReturnVM Create(OutTempSettingBase model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OutTempSettingView> Find(Func<OutTempSetting, bool> predicate)
        {
            throw new NotImplementedException();
        }



        public OutTempSettingView GetById(long id)
        {
            throw new NotImplementedException();
        }


    }
}
