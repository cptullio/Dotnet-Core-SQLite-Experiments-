using System.Collections.Generic;

namespace Sonda.Core.Domain
{
    public class DataSource : DomainBase
    {
        public string Name { get; set; }
        public virtual Test Test { get; set; }
        public virtual IList<ContentDataSource> ContentDataSourceList { get; set; }
        public DataSource()
        {
            ContentDataSourceList = new List<ContentDataSource>();
        }
    }
}