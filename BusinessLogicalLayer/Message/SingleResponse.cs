using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Message
{
    public class SingleResponse<T> : Response
    {
        public T SingleData { get; set; }
    }
}
