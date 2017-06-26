using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SABISCollaborate.System.Data;
using Microsoft.EntityFrameworkCore;
using SABISCollaborate.SharedKernel.Interfaces;
using SABISCollaborate.System.Core.Model;

namespace SABISCollaborate.System.IntegrationTests
{
    [TestClass]
    public class SystemTests
    {
        private readonly string _connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SABISCollaborate;Data Source=JOSEPH-LENOVO";

        [TestMethod]
        public void Add_Department()
        {
            var dbContextOptions = new DbContextOptionsBuilder()
                                       .UseSqlServer(this._connectionString)
                                       .Options;

            using (SystemDbContext db = new SystemDbContext(dbContextOptions))
            {
                IGenericRepository<Department> departments = new DepartmentRepository(db);
                Department department = new Department("Software Development");
                departments.Add(department);
                departments.Save();

                Assert.IsTrue(department.Id != 0);
            }
        }

        [TestMethod]
        public void Add_Position()
        {
            var dbContextOptions = new DbContextOptionsBuilder()
                                       .UseSqlServer(this._connectionString)
                                       .Options;

            using (SystemDbContext db = new SystemDbContext(dbContextOptions))
            {
                IGenericRepository<Position> positions = new PositionRepository(db);
                Position position = new Position("Director");
                positions.Add(position);
                positions.Save();

                Assert.IsTrue(position.Id != 0);
            }
        }
    }
}
