using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Simple.Abp.Blog
{
    [Dependency(ReplaceServices = true)]
    public class BlogBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "IdentityServer";

        public override string LogoUrl => "/logo.png";
    }
}
