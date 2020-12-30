using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.Account.Emailing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace Simple.Abp.Blog
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IAccountAppService), typeof(AccountAppService))]
    public class ReplaceAccountAppService : AccountAppService
    {
        public ReplaceAccountAppService(IdentityUserManager userManager, 
            IIdentityRoleRepository roleRepository, 
            IAccountEmailer accountEmailer, 
            IdentitySecurityLogManager identitySecurityLogManager,
            IOptions<IdentityOptions> identityOptions)
            : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
        {
        }

        public override Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            throw new Exception("暂时关闭注册");
            //return base.RegisterAsync(input);
        }
    }
}
