using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexxon.Models.Security
{
    public class AuthenticationModel
    {
        #region Public members
        public string _lpUserName { get; set; }
        public string _lpPassword { get; set; }
        public string _lpProfile { get; set; }
        #endregion
    }
}
