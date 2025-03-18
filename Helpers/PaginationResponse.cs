using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tcc1_api.Helpers
{
    public class PaginationResponse<T>
    {
       public List<T> Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        
        public PaginationResponse(List<T> data, int pageNumber, int pageSize, int totalCount)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        } 
    }
}