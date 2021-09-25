using System;
using System.Collections.Generic;
using System.Text;

namespace LinearInterpolation
{
    class Interpolation
    {
        // Function linear interpolation  (( X — X0 ) * ( Y1 — Y0) / ( X1 — X0) ) + Y0
        private static double CalculateLinearInterpolation(double[] xy0, double[] xy1, double X)
            => ((X - xy0[0] ) * (xy1[1] - xy0[1]) / (xy1[0] - xy0[0])) + xy0[1];
        public static double LinearZ(double[][] xyArray, double z)
        {
            int GetBottomIdx()
            {
                int idxBottom = -1;
                var idx = 1;
                while (idx < xyArray.Length)
                {
                    if (xyArray[idx][0] > z)
                    {
                        idxBottom = idx - 1;
                        break;
                    }
                    idx++;
                }
                return idxBottom;
            }
            // check z in (min(x) ; max(x)) 
            if (z < xyArray[0][0] || z > xyArray[xyArray.Length - 1][0])
                return double.NaN;

            int idx0 = GetBottomIdx();
            int idx1 = idx0 + 1;
            return CalculateLinearInterpolation(xyArray[idx0], xyArray[idx1], z);
        }
    }
}
