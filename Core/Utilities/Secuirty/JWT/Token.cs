using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Secuirty.JWT
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }//tokenin ne zaman sona ereceğini gösterir
    }
}
