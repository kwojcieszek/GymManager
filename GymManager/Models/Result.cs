namespace GymManager.Models;

public class Result
{
    public string ExceptionMessage { get; set; }
    public Results ResultValue { get; set; }

    public Result(Results resultValue, string exceptionMessage = "")
    {
        ResultValue = resultValue;
        ExceptionMessage = exceptionMessage;
    }
}