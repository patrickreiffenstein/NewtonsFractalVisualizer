using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsFractalVisualizer
{
	class Bitmap
	{
		public Color[] bits;
		
		public Bitmap(int height, int width)
		{
			bits = new Color[height * width];
		}
	}
}
