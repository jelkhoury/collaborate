using Microsoft.EntityFrameworkCore;
using SABISCollaborate.SharedKernel;
using SABISCollaborate.System.Core.Model;

namespace SABISCollaborate.System.Data
{
    public class DepartmentRepository : GenericRepository<Department>
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
