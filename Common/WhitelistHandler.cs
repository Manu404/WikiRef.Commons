using System;
using System.Collections.Generic;

namespace WikiRef.Commons
{
    public class WhitelistHandler
    {
        // some website avoid crawling pages, those are blackliste to avoid false positive
        private List<string> WhitelistWebsite = new List<string>() { "linkedin.com" };

        public bool CheckIfWebsiteIsWhitelisted(string url)
        {
            foreach (var website in WhitelistWebsite)
                if (url.Contains(website, StringComparison.InvariantCultureIgnoreCase))
                    return false;
            return true;
        }
    }
}
