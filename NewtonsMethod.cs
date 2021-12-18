using System;
using System.Collections.Generic;
using System.Numerics;

namespace NewtonsFractalVisualizer
{
	public static class NewtonsMethod
	{
		//Mængden af iterationer der må blive taget før den giver op, hvilket sørger for at den ikke prøver at kører utroligt mange iterationer hvis den ender fast i en løkke
		private static int maxSteps = 100000000;
		private static int decimals = 15; //Maks 15
		private static double tolerance = 0.00000001;

		private static List<Complex> roots = new List<Complex>
		{
			new Complex(-1.000, 0.000),
			new Complex(0.500, 0.886),
			new Complex(0.500, -0.886)
		};

		public static Complex? ApproximationMethod(Complex z, Func<Complex, Complex> func, Func<Complex, Complex> funcD)
		{
			int steps = 0;
			Complex calc;
			Complex x = z;
			bool found = false;

			{
				steps++;

				z = x;
				calc = z - func(z) / funcD(z);
				x = calc;

				foreach (var root in roots)
				{
					if (z.Real - tolerance <= root.Real && z.Imaginary - tolerance <= root.Imaginary && z.Real + tolerance >= root.Real && z.Imaginary + tolerance >= root.Imaginary)
					{
						found = true;
					}
				}
			} while (!found); /*(ComplexRound(z, decimals) == ComplexRound(calc, decimals) && steps < maxSteps);*//* (z != calc && steps < maxSteps);*/ //find en måde at forkorte de komplekse tal på

			if (steps >= maxSteps)
			{
				return null;
			}

			return z;
		}

		public static Complex ComplexRound(Complex z, int decimals)
		{
			return new Complex(Math.Round(z.Real, decimals), Math.Round(z.Imaginary, decimals));
		}

		public static Complex Funktion(Complex x)
		{
			//return x * x * x - 1;
			return x * x + 1;
			//return x * x * x * x * x * x + x * x * x - 1;
			//return x * x * x * x * x - 1;
			//return new Complex(Math.Sin(x.Real), Math.Sin(x.Imaginary));
			//return -5 * x * x * x - 29 * x * x + 2 * x - 900;
		}

		public static Complex FunktionDifferentieret(Complex x)
		{
			//return 3 * x * x;
			return 2 * x;
			//return 6 * x * x * x * x * x + 3 * x * x;
			//return 5 * x * x * x * x;
			//return new Complex(Math.Cos(x.Real), Math.Cos(x.Imaginary));
			//return -15 * x * x - 58 * x + 2;
		}

		/*public static Complex NewtonAproximation(Complex z, Func<Complex, Complex> f, Func<Complex, Complex> fd)
		{
			Complex calc = z - f(z) / fd(z);
			if (z == calc)
				return calc;
			return NewtonAproximation(calc, f, fd);
		}*/

		/*static Complex? NewtonAproximationIterativeNew(Complex z, Func<Complex, Complex> f, Func<Complex, Complex> fd)
		{
			int steps = 0;
			Complex calc;
			Complex x = z;
			do
			{
				steps++;
				z = x;
				calc = z - f(z) / fd(z);
				x = calc;
			} while (!(f(z).Real > 0.000001 && f(z).Real < -0.00000000001 && f(z).Imaginary > 0.00000000001 && f(z).Imaginary < -0.00000000001) && steps < 1000000);
			if (steps > 1000000)
			{
				return null;
			}
			return z;
		}*/

	}
}
