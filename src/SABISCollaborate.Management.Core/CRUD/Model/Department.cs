using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Registration.Core.CRUD.Model
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
