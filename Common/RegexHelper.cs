using System.Text.RegularExpressions;

namespace WikiRef.Commons
{
    public class RegexHelper
    {
        public Regex ExtractReferenceFromPageRegex { get; private set; }
        public Regex ExtractUrlFromReferenceRegex { get; private set; }
        public Regex ExtractYoutubeVideoNameFromPageRegex { get; private set; }
        public Regex ExtractYoutubeUrlFromEmbededVideoRegex { get; private set; }
        public Regex ExtractYoutubeVideoIdFromUrlRegex { get; private set; }
        public Regex ExtractMetaAndUrl { get; private set; }
        public Regex ExtractChannelName { get; private set; }
        public Regex ExtractUrlTimeCode { get; private set; }

        public RegexHelper()
        {
            BuildRegex();
        }

        private void BuildRegex()
        {
            string referenceContainingUrlExpression = @"([<]( *)(ref)( |.*?)([>])).*?(?:https?|www)?.*?([<]( *?)(/ref)( *?)[>])"; // regex developped with regex101, regex and the test datas available heree: https://regex101.com/r/oqL42I/1
            ExtractReferenceFromPageRegex = new Regex(referenceContainingUrlExpression, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string urlFilterExpression = @"\b(?<url>(https?:.//?|www\.).*?)(?:</ref>|[,]|[\]]|[ ]|[ ]|[<])"; // regex developped with regex101, regex and the test datas available heree: https://regex101.com/r/2lxQbx/1
            ExtractUrlFromReferenceRegex = new Regex(urlFilterExpression, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string titleFilterExpression = @"(<title>)(?<name>.*?)(</title>)"; // regex developped with regex101, regex and the test datas available heree: https://regex101.com/r/HOb95o/1
            ExtractYoutubeVideoNameFromPageRegex = new Regex(titleFilterExpression, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string embededYoutubeUrlExpression = "(<a href=\")(?<url>.*?)(\")"; // regex developped with regex101, regex and the test datas available heree: s https://regex101.com/r/aqcAnR/1
            ExtractYoutubeUrlFromEmbededVideoRegex = new Regex(embededYoutubeUrlExpression, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string youtubeUrlVideoIdFilder = @"(?<host>.*/)(?<watch>.*v=)?(?<videoid>[a-zA-Z0-9-_]+)"; // regex developped with regex101, regex and the test datas available heree:  https://regex101.com/r/xYS9aX/1
            ExtractYoutubeVideoIdFromUrlRegex = new Regex(youtubeUrlVideoIdFilder, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string extractMetaAndUrl = @"([<]( *)(ref)( |.*)([>]))(?<meta>.*?)(?<url>http.*?)?([<]( *)(/ref)( *)[>])"; // regex developped with regex101, regex and the test datas available heree:  https://regex101.com/r/Oo9JR2/1
            ExtractMetaAndUrl = new Regex(extractMetaAndUrl, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string extractChannelName = @"(<link itemprop=name content=)(?<name>.*?)(>)"; // regex developped with regex101, regex and the test datas available heree: https://regex101.com/r/gQ945i/1
            ExtractChannelName = new Regex(extractChannelName, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string extractUrlTimeCode = @"(t=)([0-9]*)(&|s)"; // regex developped with regex101, regex and the test datas available heree: https://regex101.com/r/Hr1T8I/1
            ExtractUrlTimeCode = new Regex(extractChannelName, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
    }
}
