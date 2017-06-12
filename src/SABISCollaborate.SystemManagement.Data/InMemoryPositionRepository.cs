using System.Collections.Generic;
using System;
using SABISCollaborate.SystemManagement.Core.Repositories;
using SABISCollaborate.SystemManagement.Core.Model;

namespace SABISCollaborate.SystemManagement.Data
{
    public class InMemoryPositionRepository : IPositionRepository
    {
        private List<Position> _positions = new List<Position>();

        public InMemoryPositionRepository()
        {
            this._positions.Add(new Position("Software Developer"));
            this._positions.Add(new Position("QA"));
            this._positions.Add(new Position("Solution Manager"));
            for (int i = 0; i < this._positions.Count; i++)
            {
                this._positions[i].Id = i + 1;
            }
        }

        public List<Position> GetAll()
        {
            return this._positions;
        }
    }
}
