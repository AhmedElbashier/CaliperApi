using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaliperApi.Domain.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}