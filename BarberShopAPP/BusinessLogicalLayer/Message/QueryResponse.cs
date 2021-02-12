using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Message
{
    public class QueryResponse<T> : Response
    {
        public List<T> Data { get; set; }
    }
}
