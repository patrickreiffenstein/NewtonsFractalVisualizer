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
		
		private void BitmapSkrald(int width, int height)
		{
			bits = new Color[width * height];
		}
	}
}
