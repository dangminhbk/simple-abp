using System;
using System.ComponentModel;
namespace Simple.Abp.Dict.Dtos
{
    [Serializable]
    public class CreateUpdateUserAssignmentDto
    {
        public int WordCount { get; set; }

        public int PhraseCount { get; set; }

        public int SentenceCount { get; set; }
    }
}