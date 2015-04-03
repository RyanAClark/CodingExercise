using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CardonCodingExercise.Startup))]
namespace CardonCodingExercise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
