using System;
using System.IO;
using System.Numerics;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace NewtonsFractalVisualizer
{
	class Program
	{
		static int width = 10;
		static int height = 10;

		static void Main(string[] args)
		{
			Bitmap bitmap = new Bitmap(width, height);
			List<Complex> roots = new List<Complex>();

			for (int i = 0; i < width; i++)
			{
				Parallel.For(0, height, (j) =>
				{
					Complex? root = NewtonAproximationIterative(new Complex(i - width / 2, j - height / 2), ting, tingD);
					if (root is null)
						return;
					if (!roots.Contains(root.Value))
					{
						roots.Add(root.Value);
					}
				});
			}
			foreach (var root in roots)
			{
				Console.WriteLine(root);
			}
			//Console.WriteLine(NewtonAproximationIterative(new Complex(5, 0), ting, tingD));
			/*for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					Complex? root = NewtonAproximationIterative(new Complex(i - width / 2, j - height / 2), ting, tingD);
					if (root is null)
						break;
					if (!roots.Contains(root.Value))
					{
						roots.Add(root.Value);
						Console.WriteLine(root);
					}

					//bitmap.SetPixel(i, j, System.Drawing.Color.Black);
				}
			}*/
			//bitmap.Save("plsvirkforgodssake.bmp");


			//TGA();
			//LegMedBitmap();
			//Console.WriteLine(NewtonAproximation(new Complex(53453, -5345), ting, tingD, ref steps) + " " + steps);
		}

		/*private static void TGA()
		{
			FileStream fileStream = File.OpenWrite("plsvirk.tga");

			//Header
			fileStream.Write(BitConverter.GetBytes(0), 0, sizeof(byte));
			fileStream.Write(BitConverter.GetBytes(0), 0, sizeof(byte));
			fileStream.Write(BitConverter.GetBytes(2), 0, sizeof(byte));
			fileStream.Write(BitConverter.GetBytes(0), 0, sizeof(byte) * 5);


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
		}*/

		static Complex ting(Complex x)
		{
			//return x * x + 1;
			return x * x * x - 1;
		}

		static Complex tingD(Complex x)
		{
			//return 2 * x;
			return 3 * x * x;
		}

		static Complex NewtonAproximation(Complex z, Func<Complex, Complex> f, Func<Complex, Complex> fd)
		{
			Complex calc = z - f(z) / fd(z);
			if (z == calc)
				return calc;
			return NewtonAproximation(calc, f, fd);
		}
		
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

		static Complex? NewtonAproximationIterative(Complex z, Func<Complex, Complex> f, Func<Complex, Complex> fd)
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
			} while (z != calc && steps < 10000000);
			if (steps > 1000000)
			{
				return null;
			}
			return z;
		}
	}
}
