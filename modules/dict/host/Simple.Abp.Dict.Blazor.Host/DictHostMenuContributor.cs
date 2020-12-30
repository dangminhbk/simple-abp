using System.Threading.Tasks;
using Simple.Abp.Dict.Localization;
using Volo.Abp.UI.Navigation;

namespace Simple.Abp.Dict.Blazor.Host
{
    public class DictHostMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<DictResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "Dict.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
