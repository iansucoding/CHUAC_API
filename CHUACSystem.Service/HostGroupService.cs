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
    public class HostGroupService : IHostGroupService
    {
        private readonly IRepository<HostGroup> _repository;
        private readonly IRepository<Host> _hRepository;
        private readonly IRepository<HostSchedule> _hsRepository;

        public HostGroupService(
            IRepository<HostGroup> repository,
            IRepository<Host> hRepository,
            IRepository<HostSchedule> hsRepository)
        {
            _repository = repository;
            _hRepository = hRepository;
            _hsRepository = hsRepository;
        }

        protected HostGroupVM ConvertToViewModel(HostGroup entity) => new HostGroupVM
        {
            HostGroupId = entity.Id,
            HostGroupName = entity.Name,
            Hosts = entity.Hosts.Select(host=> new HostVM
            {
                HostId = host.Id,
                HostName = host.Name,
                HostHeaderName = host.HeaderName,
                Enable = host.Enable,
                Week0 = host.Week0,
                Week1 = host.Week1,
                Week2 = host.Week2,
                Week3 = host.Week3,
                Week4 = host.Week4,
                Week5 = host.Week5,
                Week6 = host.Week6,
            }),
            HostSchedules = entity.HostSchedules.Select(sehedule => new HostScheduleVM
            {
                HostScheduleId = sehedule.Id,
                HostScheduleName = sehedule.Name,
                Week0 = sehedule.Week0,
                Week1 = sehedule.Week1,
                Week2 = sehedule.Week2,
                Week3 = sehedule.Week3,
                Week4 = sehedule.Week4,
                Week5 = sehedule.Week5,
                Week6 = sehedule.Week6,
            })
        };
        protected HostGroup ConvertToEntity(HostGroupVM model) => new HostGroup
        {
            Id = model.HostGroupId,
            Name = model.HostGroupName,
            Hosts = model.Hosts.Select(host => new Host
            {
                Id = host.HostId,
                Name = host.HostName,
                HeaderName = host.HostHeaderName,
                Enable = host.Enable,
                Week0 = host.Week0,
                Week1 = host.Week1,
                Week2 = host.Week2,
                Week3 = host.Week3,
                Week4 = host.Week4,
                Week5 = host.Week5,
                Week6 = host.Week6,
            }).ToList(),
            HostSchedules = model.HostSchedules.Select(sehedule => new HostSchedule
            {
                Id = sehedule.HostScheduleId,
                Name = sehedule.HostScheduleName,
                Week0 = sehedule.Week0,
                Week1 = sehedule.Week1,
                Week2 = sehedule.Week2,
                Week3 = sehedule.Week3,
                Week4 = sehedule.Week4,
                Week5 = sehedule.Week5,
                Week6 = sehedule.Week6,
            }).ToList()
        };

        public IEnumerable<HostGroupVM> GetAll()
        {
            var data = _repository.GetQueryable().Include(x => x.Hosts).Include(x => x.HostSchedules).ToListAsync().Result;
            var result = data.Select(x => ConvertToViewModel(x));
            return result;
        }
        public ReturnVM Update(HostGroupVM model)
        {
            var result = new ReturnVM();
            try
            {
                var entityToUpdate = ConvertToEntity(model);
                _repository.Update(entityToUpdate);
                entityToUpdate.Hosts.ForEach(h=>_hRepository.Update(h));
                entityToUpdate.HostSchedules.ForEach(hs => _hsRepository.Update(hs));
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        //// 以下方法用不到 ////

        public ReturnVM Create(HostGroupBM model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HostGroupVM> Find(Func<HostGroup, bool> predicate)
        {
            throw new NotImplementedException();
        }



        public HostGroupVM GetById(long id)
        {
            throw new NotImplementedException();
        }



    }
}
