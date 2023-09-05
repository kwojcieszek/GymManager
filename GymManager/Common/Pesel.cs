using System;
using GymManager.Common.Extensions;

namespace GymManager.Common
{
    public class Pesel
    {
        public DateTime? GetBirthDate(char[] pesel)
        {
            if(pesel.Length != 11)
            {
                return null;
            }

            var year = pesel[0].ToInt() * 10 + pesel[1].ToInt() + (pesel[2].ToInt() / 2 + 1) % 5 * 100 + 1800;
            var month = pesel[2].ToInt() % 2 * 10 + pesel[3].ToInt();
            var day = pesel[4].ToInt() * 10 + pesel[5].ToInt();

            return new DateTime(year, month, day);
        }

        public Gender? GetGender(char[] pesel)
        {
            if(pesel.Length != 11)
            {
                return null;
            }

            return pesel[9] % 2 == 0 ? Gender.Female : Gender.Male;
        }

        public bool IsValid(char[] pesel)
        {
            if(pesel.Length != 11)
            {
                return false;
            }

            var sum = 0;
            for(var i = 0; i < 10; i++)
            {
                sum += pesel[i].ToInt() * (1 + i % 2 * 2 + i / 2 % 2 * 6);
            }

            return pesel[10].ToInt() == (10 - sum % 10) % 10;
        }

        public enum Gender
        {
            Male = 2,
            Female = 3
        }
    }
}