using System.Collections.Generic;
using GymManager.DbModels;

namespace GymManager.Common
{
    public static class DataTrackingsHelper
    {
        public static void ChangeDisplayTableName(IEnumerable<DataTracking> dataTracking)
        {
            foreach(var dataTrackingItem in dataTracking)
            {
                dataTrackingItem.TableName = TableNameList(dataTrackingItem.TableName);
            }
        }

        private static string TableNameList(string tableName)
        {
            return tableName switch
            {
                "Member" => "Członkowie",
                "Identifier" => "Identyfikatory",
                "PassRegistry" => "Karnety członków",
                "CabinetKey" => "Kluczyki",
                "Pass" => "Karnety",
                "User" => "Użytkownicy",
                _ => tableName
            };
        }
    }
}