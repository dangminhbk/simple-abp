using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Dict
{
    public class Catalog : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }

        public string Desc { get; set; }

        protected Catalog()
        {
        }

        public Catalog(
            Guid id, 
            string title, 
            string desc
        ) : base(id)
        {
            Title = title;
            Desc = desc;
        }
    }
}
