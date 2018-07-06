using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class TemperatureHistoryService : ITemperatureHistoryService
    {
        private IRepository<TemperatureHistory> _repository;
        private int minuteInterval = 15; // n 分鐘以後才存新資料

        public TemperatureHistoryService(IRepository<TemperatureHistory> repository)
        {
            _repository = repository;
        }

        protected TemperatureHistoryView ConvertToViewModel(TemperatureHistory entity) => new TemperatureHistoryView
        {
            Name = entity.Name,
            Value = entity.Value,
            AddedOn = entity.AddedOn
        };

        public IEnumerable<TemperatureHistoryView> GetLatestTenByName(string name)
        {
            var oddestDt = DateTime.Now.AddHours(-4); // 為了效能所以只抓最近四個小時的資料
            return _repository.GetQueryable()
                .Where(x => x.Name == name && x.AddedOn >= oddestDt)
                .OrderBy(x => x.AddedOn)
                .ToList()
                .TakeLast(10)
                .Select(x => ConvertToViewModel(x));
        }

        public ReturnVM Create(TemperatureHistoryBase model)
        {
            var result = new ReturnVM();
            var now = DateTime.Now;
            var latestDateTime = now.AddMinutes(-minuteInterval);
            var hasOldTemps = _repository.GetQueryable()
                .Where(x => x.Name == model.Name && x.AddedOn >= latestDateTime)
                .Any();
            if(!hasOldTemps)
            {
                var entity = new TemperatureHistory
                {
                    Name = model.Name,
                    Value = model.Value,
                    AddedOn = now
                };
                _repository.Create(entity);
                result.IsSuccess = true;
                result.Message = $"{now.ToShortTimeString()}建立了{model.Name}的資料({entity.Id})";
            }
            else
            {
                result.Message = $"前{minuteInterval}分鐘以內已經有資料";
            }
            return result;
        }
        //以下用不到
        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemperatureHistoryView> Find(Func<TemperatureHistory, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemperatureHistoryView> GetAll()
        {
            throw new NotImplementedException();
        }

        public TemperatureHistoryView GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Update(TemperatureHistoryView model)
        {
            throw new NotImplementedException();
        }


    }
}
