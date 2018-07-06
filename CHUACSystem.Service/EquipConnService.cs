using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class EquipConnService: IEquipConnService
    {
        private IRepository<EquipConn> _repository;

        public EquipConnService(IRepository<EquipConn> repository)
        {
            _repository = repository;
        }
        protected EquipConnView ConvertToViewModel(EquipConn entity) => new EquipConnView
        {
            Id = entity.Id,
            Name = entity.Name,
            Enable = entity.Enable
        };

        public IEnumerable<EquipConnView> GetAll()
        {
            return _repository.GetAll().Select(x => ConvertToViewModel(x));
        }

        public ReturnVM Update(EquipConnView model)
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

        public ReturnVM Create(EquipConnBase model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipConnView> Find(Func<EquipConn, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public EquipConnView GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
