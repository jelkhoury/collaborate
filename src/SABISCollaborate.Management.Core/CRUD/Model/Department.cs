using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Management.Core.CRUD.Model
{
    public class Department : Entity
    {
        public string Title { get; set; }

        public Department(string title)
        {
            this.Title = title;
        }
    }
}
