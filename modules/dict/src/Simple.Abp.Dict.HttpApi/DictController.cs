using Simple.Abp.Dict.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Dict
{
    public abstract class DictController : AbpController
    {
        protected DictController()
        {
            LocalizationResource = typeof(DictResource);
        }
    }
}
