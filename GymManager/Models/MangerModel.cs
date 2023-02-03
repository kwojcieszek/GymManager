using System;
using System.Reflection;
using System.Threading.Tasks;
using GymManager.Common;
using GymManager.Common.Extensions;
using GymManager.DbModels;

namespace GymManager.Models;

public class MangerModel
{
    public string AssemblyVersion => Assembly.GetEntryAssembly().GetName().Version.ToString();
    public string DatabaseName => $"{Settings.App.Databases.DatabaseType.GetDisplayName()}";
    public DateTime? DataTimeLogin { get; set; }
    public string FullName => $"{CurrentUser.User?.FirstName.Substring(0, 1)}. {CurrentUser.User?.LastName}";
    public string SystemStatusName => "OK";

    public string UserName => CurrentUser.User?.UserName;

    public void InitData()
    {
        new GymManagerContext().ConfigureAwait(true);
    }
}