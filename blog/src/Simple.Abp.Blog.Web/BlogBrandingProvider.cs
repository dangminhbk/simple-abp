using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Simple.Abp.Blog.Web
{
    [Dependency(ReplaceServices = true)]
    public class BlogBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Blog";

        public override string LogoUrl => "/logo.png";
    }
}
