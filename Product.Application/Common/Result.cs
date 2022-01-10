using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Common
{
    public class Result<T>
    {
        public bool Ok { get; set; }
        public T Response { get; set; }
        public string ExceptionMessage { get; set; }

    }
}
