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
    public class TemporaryClassService : ITemporaryClassService
    {
        private IRepository<TemporaryClass> _repository;

        public TemporaryClassService(IRepository<TemporaryClass> repository)
        {
            _repository = repository;
        }
        protected TemporaryClassView ConvertToViewModel(TemporaryClass entity) => new TemporaryClassView
        {
            Id = entity.Id,
            Date = entity.Date,
            Classroom = entity.Classroom,
            Sections = entity.Sections,
            AddedOn = entity.AddedOn,
            Remark = entity.Remark
        };
        public TemporaryClassView GetById(long id)
        {
            var entity = _repository.GetById(id);
            if(entity != null)
            {
                return ConvertToViewModel(entity);
            }
            return null;
        }
        public IEnumerable<TemporaryClassView> GetAll()
        {
            return _repository.GetQueryable()
                .OrderBy(x => x.Id)
                .ToList()
                .Select(x => ConvertToViewModel(x));
        }
        public ReturnVM Create(TemporaryClassBase model)
        {
            var result = new ReturnVM();
            try
            {
                var entity = new TemporaryClass
                {
                    Date = model.Date,
                    Times = model.Times,
                    Classroom = model.Classroom,
                    Sections = model.Sections,
                    Remark = model.Remark,
                    AddedOn = DateTime.Now
                };
                _repository.Create(entity);
                result.Message = entity.Id.ToString();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnVM Delete(long id)
        {
            var result = new ReturnVM();
            try
            {
                var entity = new TemporaryClass { Id = id };
                _repository.Delete(entity);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
        //以下用不到
        public IEnumerable<TemporaryClassView> Find(Func<TemporaryClass, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Update(TemporaryClassView model)
        {
            throw new NotImplementedException();
        }
    }
}
