using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Myvas.AspNetCore.TencentCos;
using Simple.Abp.TencentCos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Blog.Controllers
{
    [RemoteService]
    [ControllerName("Upload")]
    [Route("api/upload")]
    public class UploadController : AbpController
    {
        private readonly SimpleAbpTencentCosOption _tencentCosOption;
        private readonly ITencentCosHandler _cosHandler;

        public UploadController(
            IOptions<SimpleAbpTencentCosOption> tencentCosOption,
            ITencentCosHandler cosHandler)
        {
            _tencentCosOption = tencentCosOption.Value;
            _cosHandler = cosHandler;
        }

        [HttpPost]
        public async Task<Uri> Post()
        {
            IFormFile file = null;
            try
            {
                file = Request.Form.Files.FirstOrDefault();
            }
            catch (Exception) { }

            if (file == null)
                throw new ArgumentNullException("文件为空", nameof(file));

            var uploadOptions = _tencentCosOption.Upload;

            if (file.Length > uploadOptions.MaxLength)
                throw new ArgumentOutOfRangeException($"只能上传小于{uploadOptions.MaxLength / 1024}M的文件");

            string extension = Path.GetExtension(file.FileName);
            if (extension == null)
                throw new ArgumentOutOfRangeException("文件没有扩展名");

            extension = extension.ToLowerInvariant();
            if (!uploadOptions.SupportedExtensions.Contains(extension))
                throw new ArgumentOutOfRangeException("暂不支持该文件上传");
            var buckets = await _cosHandler.AllBucketsAsync();
            var storageUri = uploadOptions.CosStorageUri;
            var containerExists = await _cosHandler.ExistsAsync(storageUri);
            if (!containerExists)
                throw new ArgumentOutOfRangeException("bucket不存在");

            var filePath = new Uri(new Uri(storageUri), file.FileName);
            var fileExists = await _cosHandler.ExistsAsync(filePath.ToString());
            if (fileExists && !uploadOptions.IsOverrideEnabled)
                throw new ArgumentOutOfRangeException("文件已存在");

            var uploadedUri = await _cosHandler.PutObjectAsync(filePath.ToString(), file.OpenReadStream());
            return uploadedUri;
        }
    }
}
