using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tcc1_api.Dtos.Colecao
{
    public class ColecaoStatisticsDto
    {
        public int TotalSeries { get; set; }
        public int TotalEditoras { get; set; }
        public int TotalGeneros { get; set; }
        public int TotalEdicoes { get; set; }
        public int TotalExemplares { get; set; }
        
        // Most popular entities
        public string? MostPopularRoteirista { get; set; }
        public string? MostPopularDesenhista { get; set; }
        public string? MostPopularMangaka { get; set; }
        public string? MostPopularGenero { get; set; }
        public string? MostPopularEditora { get; set; }
        public string? MostPopularDemografia { get; set; }
    }
}
