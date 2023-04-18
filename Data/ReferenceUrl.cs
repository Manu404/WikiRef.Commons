namespace WikiRef.Commons.Data
{
    public class ReferenceUrl
    {
        public string Url { get; set; }
        public bool IsValid { get; set; }

        public ReferenceUrl() { }
        public ReferenceUrl(string Url) 
        {
            this.Url = Url;
        }
    }
}
