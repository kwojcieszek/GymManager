namespace GymManager.Common
{
    public class StatusDevice
    {
        public bool IsWorking { get; set; }
        public string Message { get; set; }

        public StatusDevice(string message, bool isWorking)
        {
            Message = message;
            IsWorking = isWorking;
        }
    }
}