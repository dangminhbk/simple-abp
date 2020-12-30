using Simple.Abp.Dict.Localization;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict
{
    public abstract class DictAppService : ApplicationService
    {
        protected DictAppService()
        {
            LocalizationResource = typeof(DictResource);
            ObjectMapperContext = typeof(DictApplicationModule);
        }
    }
}
