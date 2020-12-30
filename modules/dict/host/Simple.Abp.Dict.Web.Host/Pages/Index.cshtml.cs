using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Simple.Abp.Dict.Pages
{
    public class IndexModel : DictPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}