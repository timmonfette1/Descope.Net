﻿namespace Descope.Models
{
    public class DescopeRole
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] PermissionNames { get; set; }
        public long CreatedTime { get; private set; }
    }
}
