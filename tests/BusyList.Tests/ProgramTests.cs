using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BusyList.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void DependencyInjection_ShouldBeValid()
        {
            var services = Program.ConfigureServices();

            var provider = services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateOnBuild = true,
                ValidateScopes = true
            });
        }
    }
}
