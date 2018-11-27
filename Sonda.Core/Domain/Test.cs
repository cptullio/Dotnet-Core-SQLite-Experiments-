using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonda.Core.Domain
{
    public class Test : DomainBase
    {
        public String Name { get; set; }

        public String UrlTest { get; set; }

        public DateTime? ExecutionBegin { get; set; }

        public DateTime? ExecutionEnd { get; set; }

        public int IntervalExecution { get; set; }

        public int IntervalDataSourceItem { get; set; }

        public virtual IList<Command> CommandList { get; set; }

        public virtual IList<DataSource> DataSourceList { get; set; }
        public Test()
        {
            CommandList = new List<Command>();
            DataSourceList = new List<DataSource>();
        }
    }
}
