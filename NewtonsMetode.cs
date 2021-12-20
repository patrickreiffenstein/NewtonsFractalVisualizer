using System;
using System.Numerics;

namespace NewtonsFractalVisualizer
{
	public static class NewtonsMetode
	{
		//Maksimal mængde iterationer den må kører
		private static int maksTrin = 100;
		//Mængden af decimaler som den bruger til at tjekke
		private static int decimaler = 4;
		//Tolerancen udregnet ud fra mængden af decimaler
		private static double tolerance = 1/Math.Pow(10, decimaler + 1);

		public static Complex? ApproksimationMetode(Complex z, Func<Complex, Complex> funk, Func<Complex, Complex> funkD)
		{
			int trin = 0;
			Complex udregning;
			Complex x = z;

			do
			{
				trin++;

				z = x;
				udregning = z - funk(z) / funkD(z);

				x = udregning;
			} while (!CheckNumber(z, udregning) && trin < maksTrin);

			if (trin >= maksTrin)
			{
				return null;
			}

			return ComplexRound(z, decimaler);
		}

		public static bool CheckNumber(Complex z, Complex udregning)
		{
			return ComplexAbs(z - udregning).Real <= tolerance && ComplexAbs(z - udregning).Imaginary <= tolerance;
		}

		public static Complex ComplexRound(Complex z, int decimaler)
		{
			return new Complex(Math.Round(z.Real, decimaler), Math.Round(z.Imaginary, decimaler));
		}

		public static Complex ComplexAbs(Complex z)
		{
			return Math.Sqrt(z.Real * z.Real + z.Imaginary * z.Imaginary);
		}
	}
}