using System.Diagnostics;

namespace GymManager.Common
{
    public class TeamViewer
    {
        public string TeamViewerPath { get; set; } = $"{Path.ApplicationDirectory}\\TeamViewerQS.exe";

        public void Run()
        {
            Process.Start(TeamViewerPath);
        }
    }
}