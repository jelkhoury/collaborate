using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.SystemManagement.Core.Model
{
    public class Position : Entity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Position()
        {

        }

        public Position(string title) : this()
        {
            this.Title = title;
        }
    }
}
