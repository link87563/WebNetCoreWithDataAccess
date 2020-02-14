using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSampleWithDataAccess.Entities
{
    public class Token
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
        
        public int Expires { get; set; }
    }
}
