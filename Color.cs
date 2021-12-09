using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsFractalVisualizer
{
	public readonly struct Color
	{
		public readonly byte red, green, blue;
		
		/// <summary>
		/// Color constructer, input the amount of red, green and blue a color should have.
		/// </summary>
		/// <param name="red"></param>
		/// <param name="green"></param>
		/// <param name="blue"></param>
		private Color(byte red, byte green, byte blue)
		{
			this.red = red;
			this.green = green;
			this.blue = blue;
		}
	}
}