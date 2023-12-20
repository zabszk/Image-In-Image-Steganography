using System.Drawing;
using System.Drawing.Imaging;
#pragma warning disable CA1416

namespace iii.StegoMethods;

public class LSBColor3Alpha : StegoImageMethod
{
	public override string Name => "Least Significant 3 Bits - Color + Alpha";

	public override string FileSuffix => "lsb3a";

	public override async Task<Bitmap> Encode(Bitmap coverBmp, Bitmap hiddenBmp, StegoParameters parameters)
	{
		Bitmap outputBmp = new(coverBmp.Width, coverBmp.Height, PixelFormat.Format32bppArgb);

		int x, y = 0;
		for (x = 0; x < hiddenBmp.Width; x++)
		{
			for (y = 0; y < hiddenBmp.Height; y++)
			{
				Color coverPixelColor = coverBmp.GetPixel(x, y);
				Color hiddenPixelColor = hiddenBmp.GetPixel(x, y);
				int tempa = (0b_1111_1000) | ((hiddenPixelColor.R & 0b_0001_0000) >> 2) | ((hiddenPixelColor.G & 0b_0001_0000) >> 3) | ((hiddenPixelColor.B & 0b_0001_0000) >> 4);
				int tempr = (coverPixelColor.R & 0b_1111_1000) | ((hiddenPixelColor.R & 0b_1110_0000) >> 5);
				int tempg = (coverPixelColor.G & 0b_1111_1000) | ((hiddenPixelColor.G & 0b_1110_0000) >> 5);
				int tempb = (coverPixelColor.B & 0b_1111_1000) | ((hiddenPixelColor.B & 0b_1110_0000) >> 5);

				Color newColor = Color.FromArgb(tempa, tempr, tempg, tempb);
				outputBmp.SetPixel(x, y, newColor);
			}
		}

		if (parameters.Noise)
		{
			Random rng = new();
			AddNoisePixelRows(coverBmp, outputBmp, x, y, 0b_1111_1000, 0b_1111_1000, 0b_1111_1000, 0b_1111_1000, rng);
		}
		else CopyCover(coverBmp, outputBmp, x, y);

		return outputBmp;
	}

	public override Task<Bitmap?> Decode(Bitmap stegoBmp)
	{
		Bitmap outputBmp = new(stegoBmp.Width, stegoBmp.Height, PixelFormat.Format24bppRgb);

		int x, y;
		for (x = 0; x < stegoBmp.Width; x++)
		{
			for (y = 0; y < stegoBmp.Height; y++)
			{
				Color stegoPixelColor = stegoBmp.GetPixel(x, y);
				int tempr = (stegoPixelColor.R & 0b_0000_0111) << 5 | ((stegoPixelColor.A & 0b_0000_0100) << 2);
				int tempg = (stegoPixelColor.G & 0b_0000_0111) << 5 | ((stegoPixelColor.A & 0b_0000_0010) << 3);
				int tempb = (stegoPixelColor.B & 0b_0000_0111) << 5 | ((stegoPixelColor.A & 0b_0000_0001) << 4);
				Color newColor = Color.FromArgb(tempr, tempg, tempb);
				outputBmp.SetPixel(x, y, newColor);
			}
		}

		return Task.FromResult<Bitmap?>(outputBmp);
	}
}