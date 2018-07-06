using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class EquipmentGroupService : IEquipmentGroupService
    {
        private readonly IRepository<EquipmentGroup> _repository;

        public EquipmentGroupService(IRepository<EquipmentGroup> repository)
        {
            _repository = repository;
        }
        protected EquipmentGroupView ConvertToViewModel(EquipmentGroup entity) => new EquipmentGroupView
        {
            EquipmentGroupId = entity.Id,
            EquipmentGroupSeq = entity.Seq,
            EquipmentGroupName = entity.Name,
            Equipments = entity.Equipments.OrderBy(x => x.Seq).Select(c => new EquipmentView
            {
                EquipmentId = c.Id,
                EquipmentName = c.Name,
                EquipmentSeq = c.Seq,
                Desc = c.Desc,
                Value = c.Value,
                ModifiedOn = c.ModifiedOn.HasValue ? c.ModifiedOn.Value.ToString("yyyy/MM/dd HH:mm:ss"): null,
            })
        };

        public IEnumerable<EquipmentGroupView> GetAllEquipments()
        {
            return _repository.GetQueryable()
                .Include(x => x.Equipments)
                .ToList()
                .OrderBy(x => x.Seq)
                .Select(x => ConvertToViewModel(x));
        }

        // 以下用不到
        public ReturnVM Create(EquipmentGroupBase model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipmentGroupView> Find(Func<EquipmentGroup, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EquipmentGroupView> GetAll()
        {
            throw new NotImplementedException();
        }

        public EquipmentGroupView GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Update(EquipmentGroupView model)
        {
            throw new NotImplementedException();
        }
    }
}
