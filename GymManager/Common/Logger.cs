using NLog;
using NLog.LayoutRenderers;

namespace GymManager.Common
{
    public static class Logger
    {
        public static NLog.Logger Log => LogManager.GetCurrentClassLogger();

        static Logger()
        {
            LayoutRenderer.Register("startupdir", logEvent => Path.ApplicationData);
        }
    }
}