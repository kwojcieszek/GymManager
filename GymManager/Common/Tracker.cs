using System.Collections.Generic;

namespace GymManager.Common
{
    public class Tracker
    {
        public TrackerOperations Operation { get; set; }
        public string PrimaryKey { get; set; }
        public string TableName { get; set; }
        public List<TrackerValue> TrackerValues { get; set; } = new();
    }
}