using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Models.UserViewModels
{
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Holds the current user password
        /// </summary>
        public string Current { get; set; }

        /// <summary>
        /// Holds the new password
        /// </summary>
        public string New { get; set; }
    }
}
