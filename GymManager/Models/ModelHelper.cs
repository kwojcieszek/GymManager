namespace GymManager.Models
{
    public static class ModelHelper
    {
        public static bool OnlyActives(bool value, bool onlyActives)
        {
            if (!onlyActives)
            {
                return true;
            }

            return value;
        }
    }
}