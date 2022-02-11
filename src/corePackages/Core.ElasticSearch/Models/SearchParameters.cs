using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ElasticSearch.Models
{
    public class SearchParameters
    {
        public string IndexName { get; set; }
        public int From { get; set; } = 0;
        public int Size { get; set; } = 10;
    }
}
