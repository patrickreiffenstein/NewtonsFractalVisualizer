using System;
using static NewtonsFractalVisualizer.FraktalGenerering;

namespace NewtonsFractalVisualizer
{
	class Program
	{
		static void Main(string[] args)
		{
			//Spørger efter ønsket bredde og gemmer det
			Console.WriteLine("Indtast bredde:");
			int bredde = Convert.ToInt32(Console.ReadLine());
			//Spørger efter ønsket højde og gemmer et
			Console.WriteLine("Indtast højde:");
			int højde = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Indtast filnavn:");
			string filNavn = Console.ReadLine();

			//Generer fraktalen
			GenererFraktal(bredde, højde, filNavn);
		}
	}
}