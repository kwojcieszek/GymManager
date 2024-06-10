using System.Collections.Generic;
using System.Linq;
using GymManager.DataModel.Models;
using GymManager.DataService;

namespace GymManager.Models
{
    public class DataTrackingsPreviewModel
    {
        public DataTracking DataTracking { get; set; }

        public List<DataTrackingDefinition> DataTrackingDefinitions
        {
            get
            {
                if(DataTracking == null)
                {
                    return null;
                }

                return new GymManagerContext()
                    .DataTrackingDefinitions
                    .Where(d => d.DataTrackingID == DataTracking.DataTrackingID)
                    .ToList();
            }
        }
    }
}