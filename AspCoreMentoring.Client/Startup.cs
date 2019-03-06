using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Material;
using Blazorise.Icons.Material;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspCoreMentoring.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddBlazorise()
                .AddMaterialProviders()
                .AddMaterialIcons();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
