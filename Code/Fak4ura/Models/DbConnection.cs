using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fak4ura.Models
{
    public class DbConnection
    {
        public string ConnString { get; } = "DATA SOURCE=217.173.198.135/tpdb;" +
         "PERSIST SECURITY INFO=True;USER ID=s98307; password=s98307SPK; Pooling = False; ";

    }
}
