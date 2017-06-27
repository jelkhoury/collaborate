using Microsoft.EntityFrameworkCore;
using SABISCollaborate.SharedKernel;
using SABISCollaborate.System.Core.Model;
using SABISCollaborate.System.Core.Repositories;

namespace SABISCollaborate.System.Data
{
    public class EFDepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public EFDepartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
