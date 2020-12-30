using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Dict
{
    public class CatalogWordMapping : CreationAuditedEntity<Guid>
    {
        public Guid CatalogId { get; set; }

        public Guid WordId { get; set; }

        protected CatalogWordMapping()
        {
        }

        public CatalogWordMapping(
            Guid id, 
            Guid catalogId, 
            Guid wordId
        ) : base(id)
        {
            CatalogId = catalogId;
            WordId = wordId;
        }
    }
}
