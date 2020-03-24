using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace APO_v1.Models
{
    public static class HistogramOperations
    {
        public static uint[] LUTEqualization(uint[] oldLUT)
        {
            throw new Exception("Method not implemented yet.");
            //return null;
        }
        public static Tuple<uint[], uint[]> LUTStretching(uint[] oldLUT)
        {
            uint Lmin = 0, Lmax = (uint) oldLUT.Length - 1, 
                 max = Lmax, min = Lmin;
            for (uint i = 0; i < oldLUT.Length; i++)
            {
                if (min == Lmin && oldLUT[i] > 0) min = i;
                if (max == Lmax && oldLUT[Lmax - i] > 0) max = Lmax - i;
            }
            uint[] newLUT = new uint[oldLUT.Length];
            uint[] redirection = new uint[oldLUT.Length];

            for (int i = 0; i < oldLUT.Length; i++)
            {
                if (i < min)
                {
                    ++newLUT[Lmin];
                    redirection[i] = Lmin;
                }
                else if (i > max)
                {
                    ++newLUT[Lmax];
                    redirection[i] = Lmax;
                }
                else
                {
                    uint q = ((uint)i - min) * Lmax / ((max - min == 0) ? 1 : max - min);
                    newLUT[q] += oldLUT[i];
                    redirection[i] = q;
                }
            }
            return Tuple.Create(newLUT, redirection);
        }
       
        public static Tuple<uint[], uint[]> LUTAlignment(uint[] oldLUT)
        {
            double sum = 0;
            uint[] redirection = new uint[oldLUT.Length];
            Array.ForEach(oldLUT, (uint i) => { sum += i; });
            double[] D = new double[oldLUT.Length];
            D[0] = oldLUT[0];
            for (int i = 1; i < D.Length; i++)
                D[i] = D[i-1] + oldLUT[i];
            double firstNonZero = 0;
            for (int i = 0; i < D.Length; i++) {
                D[i] /= sum;
                if (firstNonZero == 0 && D[i] != 0) firstNonZero = D[i];
            }
            //MessageBox.Show($"{sum}, {firstNonZero}, {D[255]}", "My App");
            uint[] newLUT = new uint[oldLUT.Length];
            for (int i = 0; i < newLUT.Length; i++)
            {
                uint newValue = (uint)Math.Round((D[i] - firstNonZero) / (1.0 - firstNonZero) * (oldLUT.Length - 1));
                newLUT[i] = newValue;
                redirection[newValue] = (uint) i;
            }
            return Tuple.Create(newLUT, redirection);
        }
    }
}
