using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.System.Core.Model
{
    public class Position : Entity
    {
        public int Id { get; protected set; }

        public string Title { get; set; }

        private Position()
        {

        }

        public Position(string title) : this()
        {
            this.Title = title;
        }
    }
}
