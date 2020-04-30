using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Common
{
    public class Paged<T> where T: class
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public long TotalCount { get; set; }

        public IList<T> Items { get; set; }
    }
}
