using System.Text;
using System.Collections.Generic;
namespace TugasMinggu1.Domain
{
    public class PaginationParams
    {
        /* public const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int _pageSize = 10;
        public int PageSize
        {
            get {
                return _pageSize; 
            }
            set { 
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }*/
        public const int _maxItemsPerPage = 50;
        public int itemsPerPage;
        public int Page { get; set; } = 1;
        public int ItemsPerPage
        {
            get => itemsPerPage;
            set=>  itemsPerPage = value> _maxItemsPerPage ? _maxItemsPerPage : value;
        }
        
    }
}
