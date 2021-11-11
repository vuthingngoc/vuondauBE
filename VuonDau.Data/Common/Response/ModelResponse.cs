using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace VuonDau.Data.Common.Response
{
    public class ModelsResponse<T>
    {
        public List<T> Data { get; set; }
    }
}