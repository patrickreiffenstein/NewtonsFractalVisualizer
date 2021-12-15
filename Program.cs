using System;
using System.Numerics;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NewtonsFractalVisualizer.NewtonsMethod;
using System.Collections.Concurrent;

namespace NewtonsFractalVisualizer
{
	class Program
	{
		static int width = 19;
		static int height = 10;

		static void Main(string[] args)
		{
			Bitmap bitmap = new Bitmap(width, height);
			Color?[,] krestenArray = new Color?[width, height];
			//List<Complex> roots = new List<Complex>();
			ConcurrentDictionary<Complex, Color> roots = new ConcurrentDictionary<Complex, Color>();

			/*Color[] colors = new Color[width*height];
			for (UInt32 i = 0; i < width*height; i++)
			{
				if (i < width * height && i < int.MaxValue)
				{
					colors[i] = Color.FromArgb((int)((UInt32)i | (UInt32)0xff000000));
				}
				else
				{
					colors[i] = Color.FromArgb(int.MaxValue);
				}
			}*/

			Color[] colors = new Color[]
			{
				Color.Red,
				Color.Green,
				Color.Blue,
				Color.Yellow,
				Color.Lime,
				Color.Cyan,
				Color.Magenta,
				Color.Beige,
				Color.DarkOrchid,
				Color.Gold,
				Color.Firebrick,
				Color.White,
			};

			/*for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					Complex? root = AproximationMethod(new Complex(i - width / 2, j - height / 2), Funktion, FunktionDifferentieret);

					if (root is null)
					{
						krestenArray[i, j] = null;
						break;
					}

					//Forkorter decimalerne
					Complex value = new Complex(Math.Round(root.Value.Real, 8), Math.Round(root.Value.Imaginary, 8));

					Color color = roots.GetOrAdd(value, colors[roots.Count]);

					krestenArray[i, j] = color;
				}
			}*/

			Parallel.For(0, width, (i) =>
			{
				Parallel.For(0, height, (j) =>
				{
					Complex? root = AproximationMethod(new Complex(i - width / 2, j - height / 2), Funktion, FunktionDifferentieret);

					if (root is null)
					{
						krestenArray[i, j] = null;
						return;
					}

					//Forkorter decimalerne
					Complex value = new Complex(Math.Round(root.Value.Real, 8), Math.Round(root.Value.Imaginary, 8));

					Color color = roots.GetOrAdd(value, colors[roots.Count]);

					krestenArray[i, j] = color;
				});
			});

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					if (krestenArray[i, j] is null)
					{
						bitmap.SetPixel(i, j, Color.Black);
					}
					else
					{
						bitmap.SetPixel(i, j, krestenArray[i, j].Value);
					}
				}
			}

			foreach (var root in roots)
			{
				Console.WriteLine(root);
			}

			bitmap.Save("fraktal.bmp");
		}
	}
}