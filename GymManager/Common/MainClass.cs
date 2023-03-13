using System;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace GymManager.Common
{
    public static class MainClass
    {
        /// <summary>
        ///     Application Entry Point.
        /// </summary>
        [STAThread]
        [DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "6.0.0.0")]
        public static void Main(string[] args)
        {
            Settings.Read();

            var argsList = new Args(args);

            var app = new App();

            app.InitializeComponent();

            app.Run();
        }
    }
}