using System;
using System.IO;
using System.Numerics;
using System.Text;

namespace NewtonsFractalVisualizer
{
	class Program
	{
		static int width = 100;
		static int height = 100;

		static void Main(string[] args)
		{
			//int steps = 0;

			LegMedBitmap();
			
			//Console.WriteLine(NewtonAproximation(new Complex(53453, -5345), ting, tingD, ref steps) + " " + steps);
		}

		private static void LegMedBitmap()
		{
			FileStream fileStream = File.OpenWrite("ting.bmp");
			//Header
			fileStream.Write(BitConverter.GetBytes(344608066), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(0), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(3801088), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(2621440), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(6553600), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(6553600), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(65536), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(4), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(0), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(247726080), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(247726080), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(65536), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(65536), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes(0), 0, sizeof(byte) * 4);
			fileStream.Write(BitConverter.GetBytes((short)-256), 0, sizeof(byte) * 2);


			byte[] bitmap = new byte[width * height * 4];
			
			fileStream.Position = 58;

			fileStream.Write(new byte[] { 0, 0, 0, 0 }, 0, sizeof(byte) * 2); //JEg behøver det her men kresten er ikke lige så big brain

			for (int i = 0; i < width * height * 4; i++)
			{
				if (i % 4 != 0)
					bitmap[i] = 0;

			}

			fileStream.Position = 62;

			fileStream.Write(bitmap, 0, bitmap.Length);
		}

		static Complex ting(Complex x)
		{
			return x * x + 1;
		}

		static Complex tingD(Complex x)
		{
			return 2 * x;
		}

		static Complex NewtonAproximation(Complex z, Func<Complex, Complex> f, Func<Complex, Complex> fd, ref int steps)
		{
			steps += 1;
			Complex calc = z - f(z) / fd(z);
			if (z == calc)
				return calc;
			return NewtonAproximation(calc, f, fd, ref steps);
		}
	}
}
