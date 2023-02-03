using System.Collections.Generic;

namespace GymManager.Common;

public static class EntityMethodsHelper
{
    public static string GetHourFromMinutes(int? timeMinutes)
    {
        return timeMinutes.HasValue ? $"{timeMinutes.Value / 60} h {timeMinutes.Value % 60} min." : string.Empty;
    }

    public static List<T> Like<T>(this List<T> list, string text, params string[] columns) where T : class
    {
        if (string.IsNullOrEmpty(text))
            return list;

        text = text.ToLower();

        var result = new List<T>();

        foreach (var item in list)
        {
            if (result.Contains(item))
                continue;

            foreach (var column in columns)
            {
                if (column.Contains('.'))
                {
                    var split = column.Split('.');

                    if (split.Length > 1)
                    {
                        var resultSubTable = LikeSubTable(item, text, split[0], split[1]);

                        if (resultSubTable != null)
                        {
                            result.Add(resultSubTable);
                            break;
                        }
                    }

                    continue;
                }

                var val = Helper.GetPropValue(item, column);

                if (val != null && val.ToString().ToLower().Contains(text))
                {
                    if (!result.Contains(item))
                        result.Add(item);

                    break;
                }
            }
        }

        return result;
    }

    private static T LikeSubTable<T>(T item, string text, string tableName, string column) where T : class
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(column))
            return null;

        text = text.ToLower();

        var table = Helper.GetPropValue(item, tableName);

        if (table == null)
            return null;

        var val = Helper.GetPropValue(table, column);

        if (val != null && val.ToString().ToLower().Contains(text))
            return item;
        return null;
    }
}