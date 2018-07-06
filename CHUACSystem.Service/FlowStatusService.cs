using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHUACSystem.Service
{
    public class FlowStatusService : IFlowStatusService
    {
        private IRepository<FlowStatus> _repository;

        public FlowStatusService(IRepository<FlowStatus> repository)
        {
            _repository = repository;
        }
        protected FlowStatusVM ConvertToViewModel(FlowStatus entity) => new FlowStatusVM
        {
            Id = entity.Id,
            SeqNo = entity.SeqNo,
            Name = entity.Name,
            Enable = entity.Enable
        };

        public IEnumerable<FlowStatusVM> GetAll()
        {
            return _repository.GetAll().Select(x => ConvertToViewModel(x));
        }

        public ReturnVM Update(FlowStatusVM model)
        {
            var result = new ReturnVM();
            try
            {
                var entity = _repository.GetById(model.Id);
                entity.ModifiedOn = DateTime.Now;
                entity.Enable = model.Enable;
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
        public ReturnVM Create(FlowStatusBM model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FlowStatusVM> Find(Func<FlowStatus, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public FlowStatusVM GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
