using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Core
{
    public class CoreResponse<T>
    {
        public bool Success { get; set; }

        public T Result { get; set; }

        public string Message { get; set; }
    }
}
