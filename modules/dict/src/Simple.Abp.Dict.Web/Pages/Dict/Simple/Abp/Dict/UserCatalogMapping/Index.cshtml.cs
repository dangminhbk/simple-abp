using System.Threading.Tasks;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.UserCatalogMapping
{
    public class IndexModel : DictPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
