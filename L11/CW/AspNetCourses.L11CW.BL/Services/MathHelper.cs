using System;

namespace AspNetCourses.L11CW.BL.Services
{
    public static class MathHelper
    {
        public static int GetNOD(int m, int n)
        {
            int nod = 0;
            for (int i = 1; i < (Math.Abs(n) * Math.Abs(m) + 1); i++)
            {
                if (m % i == 0 && n % i == 0)
                {
                    nod = i;
                }
            }
            return nod;
        }
    }
}
