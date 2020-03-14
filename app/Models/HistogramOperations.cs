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
            uint Lmin = 0, Lmax = (uint) oldLUT.Length - 1, 
                 max = Lmax, min = Lmin;
            for (uint i = 0; i < oldLUT.Length; i++)
            {
                if (min == Lmin && oldLUT[i] > 0) min = i + 1;
                if (max == Lmax && oldLUT[Lmax - i] > 0) max = Lmax - i - 1;
            }
            //if (max == min) return oldLUT;
            uint[] newLUT = new uint[oldLUT.Length];
            for (int i = 0; i < oldLUT.Length; i++)
            {
                if (i < min) newLUT[Lmin] += oldLUT[i];
                else if (i > max) newLUT[Lmax] += oldLUT[i];
                else newLUT[i] = (oldLUT[i] - min) * Lmax / (max - min);
            }
            return newLUT;
        }
        public static uint[] LUTAlignment(uint[] oldLUT)
        {
            double sum = 0;
            Array.ForEach(oldLUT, (uint i) => { sum += i; });
            double[] D = new double[oldLUT.Length];
            for (int i = 1; i < D.Length; i++)
                D[i] = D[i-1] + oldLUT[i];
            double firstNonZero = 0;
            for (int i = 0; i < D.Length; i++) {
                D[i] /= sum;
                if (firstNonZero == 0 && D[i] > 0) firstNonZero = D[i];
            }
            uint[] newLUT = new uint[oldLUT.Length];
            for (int i = 0; i < newLUT.Length; i++)
                newLUT[i] = (uint) ((D[i] - firstNonZero) / (1 - firstNonZero)) * ((uint)oldLUT.Length - 1);
            return newLUT;
        }
    }
}
