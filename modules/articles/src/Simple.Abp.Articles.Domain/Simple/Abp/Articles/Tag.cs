using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Articles
{
    public class Tag:CreationAuditedEntity<Guid>
    {
        public string Name { get; set; }
        protected Tag()
        {
        }

        public Tag(
            Guid id,
            string name
        ) : base(id)
        {
            Name = name;
        }
    }
}
