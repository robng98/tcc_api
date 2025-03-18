using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tcc1_api.Helpers
{
    public class ContribuidorQueryObject
    {
        public string? Nome { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortBy { get; set; } = "Id";
        public bool IsDescending { get; set; } = false;
    }
}