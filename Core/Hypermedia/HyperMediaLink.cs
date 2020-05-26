namespace Core.Hypermedia
{
    public class HyperMediaLink
    {
        public string Action { get; set; }
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Type { get; set; }

        public HyperMediaLink(string action, string href, string rel, string type)
        {
            Action = action;
            Href = href;
            Rel = rel;
            Type = type;
        }
    }
}
