using Microsoft.EntityFrameworkCore;
using SABISCollaborate.SharedKernel;
using SABISCollaborate.System.Core.Model;

namespace SABISCollaborate.System.Data
{
    public class PositionRepository : GenericRepository<Position>
    {
        public PositionRepository(DbContext context) : base(context)
        {
        }
    }
}
