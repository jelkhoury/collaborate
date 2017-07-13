using Microsoft.EntityFrameworkCore;
using SABISCollaborate.SharedKernel;
using SABISCollaborate.System.Core.Model;
using SABISCollaborate.System.Core.Repositories;

namespace SABISCollaborate.System.Data
{
    public class EFPositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public EFPositionRepository(SystemDbContext context) : base(context)
        {
        }
    }
}
