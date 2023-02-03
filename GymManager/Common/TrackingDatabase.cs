using System;
using System.Collections.Generic;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GymManager.Common;

public class TrackingDatabase
{
    public List<Tracker> Tracker => _tracker;
    public List<Tracker> _tracker = new();

    public void Save()
    {
        if (_tracker.Count == 0)
            return;

        var db = new GymManagerContext();

        foreach (var track in _tracker)
        {
            if (track.TrackerValues.Count == 0)
                continue;

            var dataTracking = new DataTracking
            {
                DataTrackingOperationID = (int)track.Operation,
                TableName = track.TableName,
                PrimaryKey = track.PrimaryKey,
                DateAdded = DateTime.Now,
                AddedBy = CurrentUser.User.UserID
            };

            db.DataTrackings.Add(dataTracking);

            foreach (var row in track.TrackerValues)
                db.DataTrackingDefinitions.Add(new DataTrackingDefinition
                {
                    DataTracking = dataTracking,
                    ColumnName = row.ColumnName,
                    OldData = row.OldValue,
                    NewData = row.NewValue
                });
        }

        db.SaveChanges();
    }

    public void TrackerFromDatabase<T>(PropertyValues current, TrackerOperations operation) where T : class
    {
        var db = new GymManagerContext();

        T oldRrow = null;
        var primaryKey = 0;

        foreach (var property in current.Properties)
        {
            if (!property.IsPrimaryKey())
                continue;

            primaryKey = current.GetValue<int>(property);

            oldRrow = db.Set<T>().Find(primaryKey);
            break;
        }

        if (oldRrow == null)
            return;

        var track = new Tracker();

        track.Operation = operation;
        track.TableName = current.EntityType.DisplayName();
        track.PrimaryKey = primaryKey.ToString();

        var obj = current.ToObject();

        var isChangedData = false;

        foreach (var property in current.Properties)
        {
            var p = property.PropertyInfo.PropertyType;

            if (p == typeof(string) || p == typeof(int) || p == typeof(long) || p == typeof(decimal) ||
                p == typeof(float) || p == typeof(bool) || p == typeof(double) ||
                p == typeof(int?) || p == typeof(long?) || p == typeof(decimal?) || p == typeof(float?) ||
                p == typeof(bool?) || p == typeof(double?))
            {
                var newValue = oldRrow.GetType().GetProperty(property.Name).GetValue(obj);
                var oldValue = oldRrow.GetType().GetProperty(property.Name).GetValue(oldRrow);

                track.TrackerValues.Add(new TrackerValue
                {
                    ColumnName = property.Name,
                    OldValue = $"{oldValue}",
                    NewValue = operation == TrackerOperations.Delete ? string.Empty : $"{newValue}"
                });

                if ($"{oldValue}" != $"{newValue}" || operation == TrackerOperations.Delete)
                    isChangedData = true;
            }
        }

        if (isChangedData)
            _tracker.Add(track);
    }
}