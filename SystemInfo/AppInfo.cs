using System.Deployment.Application;
using System.Reflection;

namespace KyoceraVIPackingSystem.SystemInfo
{
    public static class AppInfo
    {
        public static string GetRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}
