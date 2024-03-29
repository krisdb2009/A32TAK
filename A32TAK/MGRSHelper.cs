﻿namespace A32TAK
{
    public static class MGRSHelper
    {
        public static char[] LatitudeBandRange = "CDEFGHJKLMNPQRSTUVWXX".ToCharArray();
        public static char[] GridSquareFirstRange = "ABCDEFGHJKLMNPQRSTUVWXYZ".ToCharArray();
        public static char[] GridSquareSecondRange = "ABCDEFGHJKLMNPQRSTUVFGHJKLMNPQRSTUVABCDE".ToCharArray();
        public static (double Latitude, double Longitude) LatLongFromMGRS(uint UTMZone, char LatitudeBand, char GridSquareFirst, char GridSquareSecond, uint Easting, uint Northing)
        {
            double dUTMZone = UTMZone;
            double e = (dUTMZone * 6 - 183) * Math.PI / 180;
            double f = new string[] { "ABCDEFGH", "JKLMNPQR", "STUVWXYZ" }[(int)(dUTMZone - 1) % 3].IndexOf(GridSquareFirst) + 1;
            double g = "CDEFGHJKLMNPQRSTUVWXX".IndexOf(LatitudeBand);
            double h = new string[] { "ABCDEFGHJKLMNPQRSTUV", "FGHJKLMNPQRSTUVABCDE" }[(int)(dUTMZone - 1) % 2].IndexOf(GridSquareSecond);
            double[] i = [1.1, 2.0, 2.8, 3.7, 4.6, 5.5, 6.4, 7.3, 8.2, 9.1, 0, 0.8, 1.7, 2.6, 3.5, 4.4, 5.3, 6.2, 7.0, 7.9];
            double[] j = [0, 2, 2, 2, 4, 4, 6, 6, 8, 8, 0, 0, 0, 2, 2, 4, 4, 6, 6, 6];
            double k = i[(int)g];
            double l = j[(int)g] + h / 10;
            if (l < k) l += 2;
            double m = f * 100000.0 + Easting;
            double n = l * 1000000 + Northing;
            m -= 500000.0;
            if (LatitudeBand < 'N') n -= 10000000.0;
            m /= 0.9996;
            n /= 0.9996;
            double o = n / 6367449.14570093;
            double p = o + (0.0025188266133249035 * Math.Sin(2.0 * o)) + (0.0000037009491206268 * Math.Sin(4.0 * o)) + (0.0000000074477705265 * Math.Sin(6.0 * o)) + (0.0000000000170359940 * Math.Sin(8.0 * o));
            double q = Math.Tan(p);
            double r = q * q;
            double s = r * r;
            double t = Math.Cos(p);
            double u = 0.006739496819936062 * Math.Pow(t, 2);
            double v = 40680631590769 / (6356752.314 * Math.Sqrt(1 + u));
            double w = v;
            double x = 1.0 / (w * t);
            w *= v;
            double y = q / (2.0 * w);
            w *= v;
            double z = 1.0 / (6.0 * w * t);
            w *= v;
            double aa = q / (24.0 * w);
            w *= v;
            double ab = 1.0 / (120.0 * w * t);
            w *= v;
            double ac = q / (720.0 * w);
            w *= v;
            double ad = 1.0 / (5040.0 * w * t);
            w *= v;
            double ae = q / (40320.0 * w);
            double af = -1.0 - u;
            double ag = -1.0 - 2 * r - u;
            double ah = 5.0 + 3.0 * r + 6.0 * u - 6.0 * r * u - 3.0 * (u * u) - 9.0 * r * (u * u);
            double ai = 5.0 + 28.0 * r + 24.0 * s + 6.0 * u + 8.0 * r * u;
            double aj = -61.0 - 90.0 * r - 45.0 * s - 107.0 * u + 162.0 * r * u;
            double ak = -61.0 - 662.0 * r - 1320.0 * s - 720.0 * (s * r);
            double al = 1385.0 + 3633.0 * r + 4095.0 * s + 1575 * (s * r);
            double Latitude = p + y * af * (m * m) + aa * ah * Math.Pow(m, 4) + ac * aj * Math.Pow(m, 6) + ae * al * Math.Pow(m, 8);
            double Longitude = e + x * m + z * ag * Math.Pow(m, 3) + ab * ai * Math.Pow(m, 5) + ad * ak * Math.Pow(m, 7);
            Latitude = Latitude * 180 / Math.PI;
            Longitude = Longitude * 180 / Math.PI;
            return (Latitude, Longitude);
        }
    }
}