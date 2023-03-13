using System;

namespace GymManager.Common
{
    public class DatabaseSettingsSqlite
    {
        public string Directory { get; set; } =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)}";

        public string FileName { get; set; } = "GymManager.db";
    }
}