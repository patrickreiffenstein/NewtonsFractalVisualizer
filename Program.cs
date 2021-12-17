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
		static int width = 10;
		static int height = 10;

		static void Main(string[] args)
		{
			//AproximationMethod(new Complex(0.5, 0.5),Funktion, FunktionDifferentieret);
			//GenerateFractalNew();
			GenerateFractal();
		}

		static void GenerateFractal()
		{
			Bitmap bitmap = new Bitmap(width, height);
			Color?[,] krestenArray = new Color?[width, height];
			//List<Complex> roots = new List<Complex>();
			ConcurrentDictionary<Complex, (Color, bool)> roots = new ConcurrentDictionary<Complex, (Color, bool)>();

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
					Console.WriteLine(root);
					if (root is null)
					{
						krestenArray[i, j] = null;
						return;
					}

					//Forkorter decimalerne
					//Complex value = new Complex(Math.Round(root.Value.Real, 8), Math.Round(root.Value.Imaginary, 8));
					Color color;

					if (roots.TryAdd(root.Value, (colors[roots.Count], false)))
					{
						color = Color.Black;
					}
					else
					{
						color = roots.GetOrAdd(root.Value, (colors[roots.Count], true)).Item1;
					}
					//Color color = roots.GetOrAdd(root.Value, (colors[roots.Count], false)).Item1;

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

		/*static void GenerateFractalNew()
		{
			Bitmap bitmap = new Bitmap(width, height);
			Color?[,] krestenArray = new Color?[width, height];
			//List<Complex> roots = new List<Complex>();
			ConcurrentDictionary<Complex, Color> roots = new ConcurrentDictionary<Complex, Color>();

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

			Parallel.For(0, width, (i) =>
			{
				Parallel.For(0, height, (j) =>
				{
					Complex? root = AproximationMethod(new Complex(i/width, j/height), Funktion, FunktionDifferentieret);

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

			bitmap.Save("fraktalplsvirk.bmp");
		}*/
	}
}