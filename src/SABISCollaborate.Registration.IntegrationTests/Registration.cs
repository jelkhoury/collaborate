using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SABISCollaborate.Registration.Core.Model;
using SABISCollaborate.Registration.Core.Repositories;
using SABISCollaborate.Registration.Core.Services;
using SABISCollaborate.Registration.Data;
using System;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.IntegrationTests
{
    [TestClass]
    public class Registration
    {
        private readonly string _connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SABISCollaborate;Data Source=JOSEPH-LENOVO";

        [TestMethod]
        public void SetPorfilePicture_OnRegister()
        {
            var dbContextOptions = new DbContextOptionsBuilder()
                                       .UseSqlServer(this._connectionString)
                                       .Options;

            using (RegistrationDbContext db = new RegistrationDbContext(dbContextOptions))
            {
                //db.Database.EnsureCreated();

                IUserRepository repository = new EFUserRepository(db);
                RegistrationService registration = new RegistrationService(repository);

                UserProfile profile = new UserProfile("unit2", "Unit2", "Test2", DateTime.Now);
                List<UserPosition> positions = new List<UserPosition>()
                {
                    new UserPosition(1,1),
                    new UserPosition(2,1)
                };
                EmploymentInfo employmentInfo = new EmploymentInfo(DateTime.Now, positions);
                profile.EmploymentInfo = employmentInfo;

                User user = registration.Register("ut2", "2", "a2@b.com", profile);

                Assert.IsTrue(user.Id != 0);
            }
        }
    }
}
