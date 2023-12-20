using System.Drawing;
using System.Drawing.Imaging;
#pragma warning disable CA1416

namespace iii.StegoMethods
{
	public abstract class StegoImageMethod : StegoMethod
	{
		public abstract Task<Bitmap> Encode(Bitmap cover, Bitmap hidden, StegoParameters parameters);

		public override async Task<MemoryStream> Encode(MemoryStream cover, MemoryStream hidden,
			StegoParameters parameters)
		{
			Bitmap coverBmp = new(cover);
			Bitmap hiddenBmp = new(hidden);

			if (coverBmp.Height < hiddenBmp.Height)
				throw new StegoException("Height of the cover is smaller than the height of the hidden image");

			if (coverBmp.Width < hiddenBmp.Width)
				throw new StegoException("Width of the cover is smaller than the width of the hidden image");

			if (parameters.Permutation > 1)
			{
				if (parameters.Permutation >= hiddenBmp.Height || parameters.Permutation >= hiddenBmp.Width)
					throw new StegoException("Permutation value is too large for the hidden image");

				hiddenBmp = Permutate(hiddenBmp, parameters.Permutation, coverBmp);
			}

			Bitmap encodedBmp = await Encode(coverBmp, hiddenBmp, parameters);

			MemoryStream ms = new();
			encodedBmp.Save(ms, ImageFormat.Png);

			ms.Seek(0, SeekOrigin.Begin);

			if (parameters.DiffDisplay != null)
				await GenerateDiff(coverBmp, hiddenBmp, encodedBmp, parameters);

			return ms;
		}

		private async Task GenerateDiff(Bitmap cover, Bitmap hidden, Bitmap encoded, StegoParameters parameters)
		{
			BitmapDiff.BitmapDiffResult coverDiff = cover.Diff(encoded, parameters.CoverDiffMultiplier)!;
			Bitmap? decoded = await Decode(encoded, parameters);

			if (parameters.Permutation > 1)
				hidden = Permutate(hidden, parameters.Permutation, null);

			parameters.DiffDisplay!.Invoke(this, new BitmapDiff.BitmapPairDiffResult(coverDiff, hidden.Diff(decoded, 1)));
		}

		public override string EncodedExtension(string coverExt, string hiddenExt) => ".png";

		public abstract Task<Bitmap?> Decode(Bitmap image);

		public async Task<Bitmap?> Decode(Bitmap stegoBmp, StegoParameters parameters)
		{
			if (parameters.Permutation > 1)
				stegoBmp = Permutate(stegoBmp, parameters.Permutation, null);

			return await Decode(stegoBmp);
		}

		public override async Task<MemoryStream?> Decode(MemoryStream image, StegoParameters parameters)
		{
			Bitmap stegoBmp = new(image);

			Bitmap? decodedBmp = await Decode(stegoBmp, parameters);
			if (decodedBmp == null)
				return null;

			MemoryStream ms = new();
			decodedBmp.Save(ms, ImageFormat.Png);

			ms.Seek(0, SeekOrigin.Begin);
			return ms;
		}

		public override string DecodedExtension(string encodedExt) => "png";

		private static Bitmap Permutate(Bitmap bmp, int size, Bitmap? maxSize)
		{
			if (maxSize != null)
			{
				int modH = bmp.Height % size;
				int modW = bmp.Width % size;

				if (modH != 0 || modW != 0)
				{
					int newW = bmp.Width + modW;
					if (newW > maxSize.Width)
						newW = maxSize.Width;

					int newH = bmp.Height + modH;
					if (newH > maxSize.Height)
						newH = maxSize.Height;

					if (newH != bmp.Height || newW != bmp.Width)
					{
						Bitmap old = bmp;
						bmp = new Bitmap(newW, newH);
						CopyCover(old, bmp, 0, 0);

						old.Dispose();
					}
				}
			}
			else
				bmp = (Bitmap)bmp.Clone();

			Color[,] c = new Color[size, size];
			int x = 0, y = 0;

			while (x + size < bmp.Width)
			{
				while (y + size < bmp.Height)
				{
					for (int xi = 0; xi < size; xi++)
						for (int yi = 0; yi < size; yi++)
							c[xi, yi] = bmp.GetPixel(x + size - xi - 1, y + size - yi - 1);

					for (int xi = 0; xi < size; xi++)
						for (int yi = 0; yi < size; yi++)
							bmp.SetPixel(x + xi, y + yi, c[xi, yi]);

					y += size;
				}

				y = 0;
				x += size;
			}

			return bmp;
		}

		protected static void AddNoisePixelRows(Bitmap source, Bitmap bmp, int xOffset, int yOffset, int aMin, int rMin, int gMin, int bMin, Random rng)
		{
			int x;
			for (x = 0; x < xOffset; x++)
				for (int y = yOffset; y < bmp.Height; y++)
					AddNoisePixel(source, bmp, x, y, aMin, rMin, gMin, bMin, rng);

			for (; x < bmp.Width; x++)
				for (int y = 0; y < bmp.Height; y++)
					AddNoisePixel(source, bmp, x, y, aMin, rMin, gMin, bMin, rng);
		}

		protected static void CopyCover(Bitmap source, Bitmap bmp, int xOffset, int yOffset)
		{
			int h = source.Height > bmp.Height ? bmp.Height : source.Height;
			int w = source.Width > bmp.Width ? bmp.Width : source.Width;

			int x;
			for (x = 0; x < xOffset; x++)
				for (int y = yOffset; y < h; y++)
					bmp.SetPixel(x, y, source.GetPixel(x, y));

			for (; x < w; x++)
				for (int y = 0; y < h; y++)
					bmp.SetPixel(x, y, source.GetPixel(x, y));
		}

		private static void AddNoisePixel(Bitmap source, Bitmap bmp, int x, int y, int aMin, int rMin, int gMin, int bMin,
			Random rng)
		{
			Color coverPixelColor = source.GetPixel(x, y);
			Color newColor = Color.FromArgb(aMin == 255 ? 255 : rng.Next(aMin, 255),
				SetBits(coverPixelColor.R, rMin == 255 ? 255 : rng.Next(rMin, 255), aMin),
				SetBits(coverPixelColor.G, gMin == 255 ? 255 : rng.Next(gMin, 255), gMin),
				SetBits(coverPixelColor.B, bMin == 255 ? 255 : rng.Next(bMin, 255), bMin));
			bmp.SetPixel(x, y, newColor);
		}

		private static int SetBits(int cover, int hidden, int coverBits) => (cover & coverBits) | (hidden & ~coverBits);
	}
}