using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Dict
{
    public class UserAssignment : FullAuditedEntity<Guid>
    {
        public int WordCount { get; set; }

        public int PhraseCount { get; set; }

        public int SentenceCount { get; set; }

        protected UserAssignment()
        {
        }

        public UserAssignment(
            Guid id, 
            int wordCount, 
            int phraseCount, 
            int sentenceCount
        ) : base(id)
        {
            WordCount = wordCount;
            PhraseCount = phraseCount;
            SentenceCount = sentenceCount;
        }
    }
}
