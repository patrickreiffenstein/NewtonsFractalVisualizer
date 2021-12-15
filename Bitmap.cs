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

	}
}
