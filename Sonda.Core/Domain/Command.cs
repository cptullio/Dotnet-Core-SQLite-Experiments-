using System;

namespace Sonda.Core.Domain
{
    public class Command : DomainBase
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public byte CommandType { get; set; }
        public string Target { get; set; }
        public byte SearchTargetType { get; set; }
        public string Value { get; set; }
        public bool? CanBeIgnored { get; set; }
        public bool? IsFromDatasource { get; set; }
        public bool? IsFromService { get; set; }
        public string UrlService { get; set; }
        public virtual Test Test { get; set; }

    }
}