using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.Common.Extensions;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models;

public class DataTrackingsModel
{
    public List<DataTracking> DataTrackings
    {
        get
        {
            if (_dataTrackings == null)
                GetDataTrackings();

            return _dataTrackings.ToList();
        }
    }

    private List<DataTracking> _dataTrackings;

    public List<DataTracking> GetDataTrackings(DateTime? dateFrom = null, DateTime? dateTo = null)
    {
        if (dateFrom == null || dateTo == null)
        {
            _dataTrackings = new GymManagerContext()
                .DataTrackings
                .Include(u => u.AddedByUser)
                .Include(o => o.DataTrackingOperation)
                .ToList();
        }
        else
        {
            dateFrom = dateFrom.Value.AbsoluteStart();
            dateTo = dateTo.Value.AbsoluteEnd();

            _dataTrackings = new GymManagerContext()
                .DataTrackings
                .Where(pr => pr.DateAdded >= dateFrom && pr.DateAdded <= dateTo)
                .Include(u => u.AddedByUser)
                .Include(o => o.DataTrackingOperation)
                .ToList();
        }

        DataTrackingsHelper.ChangeDisplayTableName(_dataTrackings);

        return _dataTrackings;
    }
}