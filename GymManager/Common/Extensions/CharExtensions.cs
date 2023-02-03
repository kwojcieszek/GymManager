namespace GymManager.Common.Extensions;

public static class CharExtensions
{
    public static int ToInt(this char c)
    {
        return c - '0';
    }
}