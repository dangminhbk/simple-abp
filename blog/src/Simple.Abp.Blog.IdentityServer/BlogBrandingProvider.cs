using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.Blog
{
    [Dependency(ReplaceServices = true)]
    public class BlogBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "IdentityServer";

        public override string LogoUrl => "/logo.png";
    }
}
