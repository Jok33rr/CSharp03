using System;

namespace NikitchenkoCSharp03
{
    internal static class Years
    {
        public static int YearsOld(this DateTime todayDateTime, DateTime userDateTime)
        {
            return (todayDateTime.Year - userDateTime.Year) - (todayDateTime.DayOfYear >= userDateTime.DayOfYear ? 0 : 1);
        }
    }
}
