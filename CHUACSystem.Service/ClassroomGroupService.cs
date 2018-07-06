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
    public class ClassroomGroupService : IClassroomGroupService
    {
        private readonly IRepository<ClassroomGroup> _repository;

        public ClassroomGroupService(IRepository<ClassroomGroup> repository)
        {
            _repository = repository;
        }

        protected ClassroomGroupView ConvertToViewModel(ClassroomGroup entity) => new ClassroomGroupView
        {
            ClassroomGroupId = entity.Id,
            ClassroomGroupSeq = entity.Seq,
            ClassroomGroupName = entity.Name,
            ClassroomGroupImage = entity.Image,
            Classrooms = entity.Classrooms.OrderBy(x=>x.Seq).Select(c => new ClassroomView
            {
                ClassroomId = c.Id,
                ClassroomName = c.Name,
                ClassroomSeq = c.Seq,
                IsAcOn = c.IsAcOn,
                IsAuto = c.IsAuto,
                ModifiedOn = c.ModifiedOn
            })
        };

        public IEnumerable<ClassroomGroupView> GetAllClassrooms()
        {
            return _repository.GetQueryable()
                .Include(x => x.Classrooms)
                .ToList()
                .OrderBy(x => x.Seq)
                .Select(x => ConvertToViewModel(x));
        }
        // 以下用不到
        public ReturnVM Create(ClassroomGroupBase model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClassroomGroupView> Find(Func<ClassroomGroup, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClassroomGroupView> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClassroomGroupView GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Update(ClassroomGroupView model)
        {
            throw new NotImplementedException();
        }
    }
}
