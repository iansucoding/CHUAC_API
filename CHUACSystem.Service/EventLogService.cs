using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class EventLogService : IEventLogService
    {
        private readonly IRepository<EventLog> _repository;

        public EventLogService(IRepository<EventLog> repository)
        {
            _repository = repository;
        }

        protected EventLogView ConvertToViewModel(EventLog entity) => new EventLogView
        {
            Id = entity.Id,
            SystemName = entity.SystemName,
            EventType = entity.EventType,
            Content = entity.Content,
            AddedOn = entity.AddedOn,
        };

        public IEnumerable<EventLogView> GetAll()
        {
            return _repository.GetAll().Select(x => ConvertToViewModel(x)).OrderByDescending(x => x.AddedOn);
        }

        public ReturnVM Delete(long id)
        {
            var result = new ReturnVM();
            try
            {
                var entity = new EventLog { Id = id };
                _repository.Delete(entity);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
        // 以下用不到
        public ReturnVM Create(EventLogBase model)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<EventLogView> Find(Func<EventLog, bool> predicate)
        {
            throw new NotImplementedException();
        }



        public EventLogView GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Update(EventLogView model)
        {
            throw new NotImplementedException();
        }
    }
}
