using System;

namespace GymManager.Common
{
    public class DatabaseTestException : Exception
    {
        public DatabaseTestException(Exception exp) : base("BŁĄD POŁĄCZENIA Z BAZĄ DANYCH", exp) { }
    }
}