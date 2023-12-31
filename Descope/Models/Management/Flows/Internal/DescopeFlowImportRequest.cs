﻿namespace Descope.Models
{
    internal class DescopeFlowImportRequest
    {
        public string FlowId { get; set; }
        public DescopeFlowMetadata Flow { get; set; }
        public IEnumerable<DescopeScreen> Screens { get; set; }
    }
}
