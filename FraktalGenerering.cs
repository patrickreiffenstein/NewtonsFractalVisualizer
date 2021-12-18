using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using static NewtonsFractalVisualizer.NewtonsMetode;

namespace NewtonsFractalVisualizer
{
	class FraktalGenerering
	{
		//En liste med farver der kan blive taget af når programmet finder rødder
		static private Color[] farver = new Color[]
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

		static public void GenererFraktal(int bredde, int højde, string filNavn)
		{
			//Et bitmap, hvilket er en filtype der består af et billede som gemmer farver
			Bitmap bitmap = new Bitmap(bredde, højde);
			//Et dictionary over rødder der allerede er fundet
			List<Complex> fundneRødder = new List<Complex>();

			for (int i = 0; i < bredde; i++)
			{
				for (int j = 0; j < højde; j++)
				{
					//Der bliver approksimeret med newtons metode med et lille offset for at den aldrig dividere med 0. 
					Complex? rod = ApproksimationMetode(new Complex(i + 0.0001 - bredde / 2, j + 0.0001 - højde / 2), Funktion, FunktionDifferentieret);

					if (rod is null)
					{
						bitmap.SetPixel(i, j, Color.Black);
						break;
					}

					//Tjekker om den har fundet roden før og tilføjer den til listen over de fundne hvis ikke
					if (!fundneRødder.Contains(rod.Value))
					{
						fundneRødder.Add(rod.Value);
					}

					//Ændre bitmap farven efter hvilken rod det er
					bitmap.SetPixel(i, j, farver[fundneRødder.IndexOf(rod.Value)]);
				}
			}

			Console.WriteLine("Følgende rødder er fundet:");

			foreach (var root in fundneRødder)
			{
				Console.WriteLine(root);
			}

			Console.WriteLine("Åbner fil...");
			bitmap.Save(filNavn + ".bmp");
			Process.Start(new ProcessStartInfo(filNavn + ".bmp") { UseShellExecute = true });
		}

		private static Complex Funktion(Complex x)
		{
			return x * x * x - 1;
		}

		private static Complex FunktionDifferentieret(Complex x)
		{
			return 3 * x * x;
		}
	}
}