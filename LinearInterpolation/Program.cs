using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> func = x => x * x + 3;
            Func<double, double[]> row = x => new double[2] { x, func(x) };
            double[] xs = { 1, 2, 3, 5, 6, 12};
            var xyArray = xs.Select(row).ToArray();

            foreach (double[] el in xyArray)
                Console.WriteLine($"x = {el[0]}  y = {el[1]}");

            // test
            Console.WriteLine($"Interpolation f(z):");
            double z = 14.23578;
            Console.WriteLine($"f({z}) = {Interpolation.LinearZ(xyArray, z)}");

        }
    }
}
