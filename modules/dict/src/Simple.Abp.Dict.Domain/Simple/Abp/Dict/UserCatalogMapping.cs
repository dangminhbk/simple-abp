using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Dict
{
    public class UserCatalogMapping : CreationAuditedEntity<Guid>
    {
        public Guid CatalogId { get; set; }

        protected UserCatalogMapping()
        {
        }

        public UserCatalogMapping(
            Guid id, 
            Guid catalogId
        ) : base(id)
        {
            CatalogId = catalogId;
        }
    }
}
