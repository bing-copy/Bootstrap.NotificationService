using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootstrap.Service.NotificationService.Models.ResponseModels
{
    public class SearchResponse<T> : DataResponse<IEnumerable<T>>
    {
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}