using System;
using System.Collections.Generic;
using System.Text;

namespace TechCodeLib.DTOS
{
    public class LoggedInAppUser
    {
        public DateTime CurrentTokenExpiry { get; set; }
        public bool IsAdmin { get; set; }

        public string Token { get; set; }
    }


}
