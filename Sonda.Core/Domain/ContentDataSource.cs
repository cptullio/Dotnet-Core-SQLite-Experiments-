using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonda.Core.Domain
{
    public class ContentDataSource : DomainBase
    {
        public string Chave { get; set; }
        public string Alvo { get; set; }
        public string Valor { get; set; }
        public virtual DataSource Datasource { get; set; }
    }
}
