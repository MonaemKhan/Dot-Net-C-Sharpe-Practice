using Microsoft.AspNetCore.Builder;

namespace InvenTrackPro.IoC.Configuration;
public static class AppServiceExtenstions
{
    public static IApplicationBuilder UseCore(this IApplicationBuilder app)
    {
        app.UseResponseCaching();
        app.UseResponseCompression();
        // app.UseCertificateForwarding();
        app.UseCors("InvenTrackPro");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseRouting();

        return app;
    }
}
