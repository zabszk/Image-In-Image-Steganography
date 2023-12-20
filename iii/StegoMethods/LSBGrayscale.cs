using System.Drawing;
using System.Drawing.Imaging;
#pragma warning disable CA1416

namespace iii.StegoMethods;

public class LSBGrayscale : StegoImageMethod
{
	public override string Name => "Least Significant Bits - Grayscale";

	public override string FileSuffix => "lsbG";

	public override async Task<Bitmap> Encode(Bitmap coverBmp, Bitmap hiddenBmp, StegoParameters parameters)
	{
		Bitmap outputBmp = new(coverBmp.Width, coverBmp.Height, PixelFormat.Format24bppRgb);

		int x, y = 0;
		for (x = 0; x < hiddenBmp.Width; x++)
		{
			for (y = 0; y < hiddenBmp.Height; y++)
			{
				Color coverPixelColor = coverBmp.GetPixel(x, y);
				Color hiddenPixelColor = hiddenBmp.GetPixel(x, y);
				int hiddenBrightness = (int)(hiddenPixelColor.GetBrightness() * 255);
				int tempr = (coverPixelColor.R & 0b_1111_1000) | ((hiddenBrightness & 0b_1110_0000) >> 5);
				int tempg = (coverPixelColor.G & 0b_1111_1100) | ((hiddenBrightness & 0b_0001_1000) >> 3);
				int tempb = (coverPixelColor.B & 0b_1111_1000) | ((hiddenBrightness & 0b_0000_0111) >> 0);

				Color newColor = Color.FromArgb(tempr, tempg, tempb);
				outputBmp.SetPixel(x, y, newColor);
			}
		}

		if (parameters.Noise)
		{
			Random rng = new();
			AddNoisePixelRows(coverBmp, outputBmp, x, y, 255, 0b_1111_1000, 0b_1111_1100, 0b_1111_1000, rng);
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
				int tempr = (stegoPixelColor.R & 0b_0000_0111) << 5;
				int tempg = (stegoPixelColor.G & 0b_0000_0011) << 3;
				int tempb = (stegoPixelColor.B & 0b_0000_0111) << 0;
				int bright = tempr | tempg | tempb;
				Color newColor = Color.FromArgb(bright, bright, bright);
				outputBmp.SetPixel(x, y, newColor);
			}
		}

		return Task.FromResult<Bitmap?>(outputBmp);
	}
}