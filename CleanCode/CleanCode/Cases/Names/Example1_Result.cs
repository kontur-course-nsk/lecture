using System;

namespace CleanCode.Cases.Names
{
    class Example1_Result
    {
        public int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;

            int age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
