#pragma warning disable CA1416
using System.Drawing;
using System.Drawing.Imaging;
using iii.StegoMethods;

namespace iii;

public static class BitmapDiff
{
	public delegate void ViewBitmapDiff(StegoMethod method, BitmapPairDiffResult diffResult);

	public static BitmapDiffResult? Diff(this Bitmap source, Bitmap? target, int multiplier)
	{
		if (target == null)
			return null;

		if (target.Height < source.Height || target.Width < source.Width)
			throw new ArgumentException("Target image must be larger than source image.", nameof(target));

		Bitmap avgDiff = new(source.Width, source.Height, PixelFormat.Format24bppRgb);
		Bitmap diff = new(source.Width, source.Height, PixelFormat.Format24bppRgb);
		Bitmap avgDiffRGB = new(source.Width, source.Height, PixelFormat.Format24bppRgb);
		Bitmap diffRGB = new(source.Width, source.Height, PixelFormat.Format24bppRgb);
		Bitmap diffA = new(source.Width, source.Height, PixelFormat.Format24bppRgb);
		Bitmap diffR = new(source.Width, source.Height, PixelFormat.Format24bppRgb);
		Bitmap diffG = new(source.Width, source.Height, PixelFormat.Format24bppRgb);
		Bitmap diffB = new(source.Width, source.Height, PixelFormat.Format24bppRgb);
		Bitmap channelDiff = new(source.Width, source.Height, PixelFormat.Format24bppRgb);

		for (int x = 0; x < source.Width; x++)
		{
			for (int y = 0; y < source.Height; y++)
			{
				Color sourcePixelColor = source.GetPixel(x, y);
				Color targetPixelColor = target.GetPixel(x, y);

				int diffAValue = Math.Abs(sourcePixelColor.A - targetPixelColor.A) * multiplier;
				int diffRValue = Math.Abs(sourcePixelColor.R - targetPixelColor.R) * multiplier;
				int diffGValue = Math.Abs(sourcePixelColor.G - targetPixelColor.G) * multiplier;
				int diffBValue = Math.Abs(sourcePixelColor.B - targetPixelColor.B) * multiplier;

				int diffValue = diffAValue + diffRValue + diffGValue + diffBValue;

				if (diffValue > 255)
					diffValue = 255;

				diff.SetPixel(x, y, Color.FromArgb(diffValue, diffValue, diffValue));

				diffValue /= 4;
				avgDiff.SetPixel(x, y, Color.FromArgb(diffValue, diffValue, diffValue));

				diffValue = diffRValue + diffGValue + diffBValue;

				if (diffValue > 255)
					diffValue = 255;

				diffRGB.SetPixel(x, y, Color.FromArgb(diffValue, diffValue, diffValue));

				diffValue /= 3;
				avgDiffRGB.SetPixel(x, y, Color.FromArgb(diffValue, diffValue, diffValue));

				if (diffAValue > 255)
					diffAValue = 255;

				if (diffRValue > 255)
					diffRValue = 255;

				if (diffGValue > 255)
					diffGValue = 255;

				if (diffBValue > 255)
					diffBValue = 255;

				diffA.SetPixel(x, y, Color.FromArgb(diffAValue, diffAValue, diffAValue));
				diffR.SetPixel(x, y, Color.FromArgb(diffRValue, diffRValue, diffRValue));
				diffG.SetPixel(x, y, Color.FromArgb(diffGValue, diffGValue, diffGValue));
				diffB.SetPixel(x, y, Color.FromArgb(diffBValue, diffBValue, diffBValue));

				channelDiff.SetPixel(x, y, Color.FromArgb(diffRValue, diffGValue, diffBValue));
			}
		}

		return new(source, target, avgDiff, diff, avgDiffRGB, diffRGB, diffA, diffR, diffG, diffB, channelDiff);
	}

	public class BitmapDiffResult
	{
		public readonly Bitmap Source, Target, AvgDiff, Diff, DiffRGB, AvgDiffRBG, DiffA, DiffR, DiffG, DiffB, ChannelDiff;

		public BitmapDiffResult(Bitmap source, Bitmap target, Bitmap avgDiff, Bitmap diff, Bitmap avgDiffRGB, Bitmap diffRGB, Bitmap diffA, Bitmap diffR, Bitmap diffG, Bitmap diffB, Bitmap channelDiff)
		{
			Source = source;
			Target = target;
			AvgDiff = avgDiff;
			Diff = diff;
			AvgDiffRBG = avgDiffRGB;
			DiffRGB = diffRGB;
			DiffA = diffA;
			DiffR = diffR;
			DiffG = diffG;
			DiffB = diffB;
			ChannelDiff = channelDiff;
		}
	}

	public readonly struct BitmapPairDiffResult
	{
		public readonly BitmapDiffResult Cover;
		public readonly BitmapDiffResult? Hidden;

		public BitmapPairDiffResult(BitmapDiffResult cover, BitmapDiffResult? hidden)
		{
			Cover = cover;
			Hidden = hidden;
		}
	}
}
#pragma warning restore CA1416