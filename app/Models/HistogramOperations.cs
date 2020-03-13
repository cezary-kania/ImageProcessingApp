using System;
using System.Collections.Generic;
using System.Text;

namespace APO_v1.Models
{
    static class HistogramOperations
    {
        public static uint[] LUTEqualization(uint[] oldLUT)
        {
            throw new Exception("Method not implemented yet.");
            //return null;
        }
        public static uint[] LUTStretching(uint[] oldLUT)
        {
            uint max, min, Lmin = 0, Lmax = (uint) oldLUT.Length - 1;
            min = max = oldLUT[0];
            for (int i = 1; i < oldLUT.Length; i++)
            {
                if (min > oldLUT[i]) min = oldLUT[i];
                if (max < oldLUT[i]) max = oldLUT[i];
            }
            //if (max == min) return oldLUT;
            uint[] newLUT = new uint[oldLUT.Length];
            for (int i = 0; i < oldLUT.Length; i++)
            {
                if (oldLUT[i] < min) newLUT[i] = Lmin;
                else if (oldLUT[i] > max) newLUT[i] = Lmax;
                else newLUT[i] = (oldLUT[i] - min) * Lmax / (max - min);
            }
            return newLUT;
        }
        public static uint[] LUTAlignment(uint[] oldLUT)
        {
            uint sum = 0;
            Array.ForEach(oldLUT, (uint i) => { sum += i; });
            uint[] D = new uint[oldLUT.Length];
            for (int i = 1; i < D.Length; i++)
                D[i] = D[i-1] + oldLUT[i];
            uint firstNonZero = 0;
            for (int i = 0; i < D.Length; i++) {
                D[i] /= sum;
                if (firstNonZero == 0 && D[i] > 0) firstNonZero = D[i];
            }
            uint[] newLUT = new uint[oldLUT.Length];
            for (int i = 0; i < newLUT.Length; i++)
                newLUT[i] = ((D[i] - firstNonZero) / (1 - firstNonZero)) * ((uint)oldLUT.Length - 1);
            return newLUT;
        }
    }
}
