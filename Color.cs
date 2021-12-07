using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsFractalVisualizer
{
	class Color
	{
		public byte redValue, greenValue, blueValue;

		/// <summary>
		/// Color constructer, input the amount of red, green and blue a color should have.
		/// </summary>
		/// <param name="red"></param>
		/// <param name="green"></param>
		/// <param name="blue"></param>
		public Color(byte red, byte green, byte blue)
		{
			redValue = red;
			greenValue = green;
			blueValue = blue;
		}
	}
}
