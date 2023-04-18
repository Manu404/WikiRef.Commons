using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiRef.Commons.Data
{
    public class WikiPageData
    {
        [JsonProperty] public string Name { get; set; }
        [JsonProperty] public List<YoutubeUrlData> YoutubeUrls { get; set; }
        [JsonProperty] public List<Reference> References { get; set; }
        [JsonProperty] public string Content { get; set; }
    }
}
