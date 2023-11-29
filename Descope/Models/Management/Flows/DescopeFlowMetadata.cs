namespace Descope.Models
{
    public class DescopeFlowMetadata
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object Dsl { get; set; }
        public long ModifiedTime { get; set; }
        public string ETag { get; set; }
        public bool Disabled { get; set; }
        public bool Translate { get; set; }
        public string TranslateConnectorId { get; set; }
        public string TranslateSourceLang { get; set; }
        public IEnumerable<string> TranslateTargetLangs { get; set; }
        public bool Fingerprint { get; set; }
    }
}
