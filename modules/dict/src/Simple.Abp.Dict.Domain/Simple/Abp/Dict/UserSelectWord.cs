using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Dict
{
    public class UserSelectWord: CreationAuditedEntity<Guid>
    {
        public Guid WordId { get; set; }

        protected UserSelectWord()
        {
        }

        public UserSelectWord(
            Guid id, 
            Guid wordId
        ) : base(id)
        {
            WordId = wordId;
        }
    }
}
