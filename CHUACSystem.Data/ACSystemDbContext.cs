using CHUACSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CHUACSystem.Data
{
    public class ACSystemDbContext : DbContext
    {
        public ACSystemDbContext()
        {

        }
        public ACSystemDbContext(DbContextOptions<ACSystemDbContext> options) : base(options)
        {

        }

        public DbSet<PowerMeter> PowerMeter { get; set; }
        public DbSet<Host> Host { get; set; }
        public DbSet<HostGroup> HostGroup { get; set; }
        public DbSet<HostSchedule> HostSchedule { get; set; }
        public DbSet<EquipTempSetting> EquipTempSetting { get; set; }
        public DbSet<FlowStatus> FlowStatus { get; set; }
        public DbSet<EquipConn> EquipConn { get; set; }
        public DbSet<TempSetting> TempSetting { get; set; }
        public DbSet<OutTempSetting> OutTempSetting { get; set; }
        public DbSet<OtherSetting> OtherSetting { get; set; }
        public DbSet<ClassroomGroup> ClassroomGroup { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<TemporaryClass> TemporaryClass { get; set; }
        public DbSet<TemperatureHistory> TemperatureHistory { get; set; }
        public DbSet<EquipmentGroup> EquipmentGroup { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<User> User { get; set; }
    }
}
