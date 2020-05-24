using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Helpers
{
    public static class ObjectExetensions
    {
        public static void AssertPermissionAccess(this bool result)
        {
            if (!result)
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}
