using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiRef.Commons.Data
{
    public class YoutubeUrlData
    {
        [JsonProperty] public List<string> Urls { get; set; }
        [JsonProperty] public string VideoId { get; set; }
        [JsonProperty] public string Name { get;  set; }
        [JsonProperty] public string ChannelName { get; set; }
        [JsonProperty] public SourceStatus IsValid { get; set; }
        [JsonProperty] public bool IsPlaylist { get; set; }
        [JsonProperty] public bool IsUser { get;  set; }
        [JsonProperty] public bool IsCommunity { get; set; }
        [JsonProperty] public bool IsAbout { get; set; }
        [JsonProperty] public bool IsChannels { get; set; }
        [JsonProperty] public bool IsHome { get; set; }
        [JsonProperty] public bool IsVideo { get; set; }

        [JsonIgnore]
        public string AggregatedUrls => string.Join(" ", Urls);

        [JsonIgnore]
        public string VideoUrl => $"https://www.youtube.com/watch?v={VideoId}";
    }
}
