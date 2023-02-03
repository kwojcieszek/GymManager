namespace GymManager.Common;

public class FormatText
{
    public string Parameter { get; set; }
    public string Value { get; set; }

    public FormatText(string parameter, string value)
    {
        Parameter = parameter;
        Value = value;
    }
}