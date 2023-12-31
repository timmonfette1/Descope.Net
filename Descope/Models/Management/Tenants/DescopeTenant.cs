﻿namespace Descope.Models
{
    public class DescopeTenant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> SelfProvisioningDomains { get; set; }
        public object CustomAttributes { get; set; }
    }
}
