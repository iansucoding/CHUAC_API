using CHUACSystem.Data;
using CHUACSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CHUACSystem.Test
{
    [TestClass]
    public class DbContextTests
    {
        private readonly ACSystemDbContext _context;

        public DbContextTests()
        {
            var options = new DbContextOptionsBuilder<ACSystemDbContext>()
                .UseSqlServer("Data Source=.;Initial Catalog=CHUACSystemDb;Trusted_Connection=True;")
                .Options;
            _context = new ACSystemDbContext(options);
        }

        [TestMethod]
        public void AddFindRemoveElectricMeter()
        {

            //Arrange 
            var dt = DateTime.Now;
            var electricMeter = new PowerMeter { Name = "假資料(Test)", Value = 26, AddedOn = dt, ModifiedOn = dt };

            //Act(Add)
            _context.PowerMeter.Add(electricMeter);
            _context.SaveChanges();
            //Assert(Add)
            Assert.IsTrue(electricMeter.Id > 0);

            //Arrange(Find)
            var entity = _context.PowerMeter.Find(electricMeter.Id);

            //Assert(Find)
            Assert.IsNotNull(entity);

            //Act (Remove)
            _context.PowerMeter.Remove(entity);
            _context.SaveChanges();

            //Assert (Remove)
            Assert.IsNull(_context.PowerMeter.Find(electricMeter.Id));

        }

    }
}
