using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public Guid CreatedById { get; set; }
    }
}
