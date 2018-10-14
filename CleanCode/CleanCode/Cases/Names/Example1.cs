using System;

namespace CleanCode.Cases.Names
{
    public class Example1
    {
        /// Что вернется в результате?
        public int GetResult(DateTime p)
        {
            DateTime pp = DateTime.Today;

            int s_t = pp.Year - p.Year;

            if (p > pp.AddYears(-s_t))
            {
                s_t--;
            }

            return s_t;
        }
    }
}
