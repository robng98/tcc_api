using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tcc1_api.Helpers
{
    public class MangaQueryObject
    {
        public string? NomeJap { get; set; } = null;
        public string? Demografia { get; set; } = null;
        public int SerieId { get; set; } = -1;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}