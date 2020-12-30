using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.Dict
{
    [Dependency(ReplaceServices = true)]
    public class DictBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Dict";
    }
}
