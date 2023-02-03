using System.Text.RegularExpressions;

namespace GymManager.Common;

public static class EmailValidator
{
    private static readonly Regex ValidEmailRegex = CreateValidEmailRegex();

    public static bool EmailIsValid(object emailAddress)
    {
        if (emailAddress == null || !(emailAddress is string address))
            return false;

        var isValid = ValidEmailRegex.IsMatch(address);

        return isValid;
    }

    public static bool EmailIsValid(object[] emailAddress)
    {
        foreach (var emailAddressItem in emailAddress)
            if (!EmailIsValid(emailAddressItem))
                return false;

        return true;
    }

    /// <summary>
    ///     Taken from http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
    /// </summary>
    /// <returns></returns>
    private static Regex CreateValidEmailRegex()
    {
        var validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
    }
}