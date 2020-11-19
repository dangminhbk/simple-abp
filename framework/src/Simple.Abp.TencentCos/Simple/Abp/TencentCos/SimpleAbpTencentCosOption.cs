using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Abp.TencentCos
{
    public class SimpleAbpTencentCosOption
    {
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
        public SimpleAbpUploadOption Upload { get; set; }
    }

    public class SimpleAbpUploadOption
    {
        public int MaxLength { get; set; }
        public List<string> SupportedExtensions { get; set; }
        public string FileStoragePath { get; set; }
        public string CosStorageUri { get; set; }
        public bool IsOverrideEnabled { get; set; }
    }
}
