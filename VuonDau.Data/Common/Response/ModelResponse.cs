using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace VuonDau.Data.Common.Response
{
    public class ModelResponse
    {
        public class ModelsResponse<T>
        {
            public PagingMetadata Metadata { get; set; }
            public List<T> Data { get; set; }
        }
    }
    public class PagingMetadata
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
}