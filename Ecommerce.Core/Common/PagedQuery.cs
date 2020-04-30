using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Common
{
    public class PagedQuery
    {
        private int _pageNumber = 1;

        private int _pageSize = 100;

        public int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                if (value > 0)
                {
                    _pageNumber = value;
                }
            } 
        }

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value > 0)
                {
                    _pageSize = value;
                }
            } 
        }
    }
}
