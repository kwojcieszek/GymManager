using System;

namespace GymManager.Models;

public class DatabaseTestException : Exception
{
    public DatabaseTestException(Exception exp) : base("BŁĄD POŁĄCZENIA Z BAZĄ DANYCH", exp)
    {
    }
}