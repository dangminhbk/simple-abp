using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Dict.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
