﻿using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Profile.Core.Model
{
    public class Role : Entity
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }


        private Role()
        {

        }
    }
}
