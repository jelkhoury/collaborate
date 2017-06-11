using SABISCollaborate.SystemManagement.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.SystemManagement.Core.Repositories
{
    public interface IPositionRepository
    {
        List<Position> GetAll();
    }
}
