namespace iii.StegoMethods;

public class FileConcat : StegoMethod
{
	private const int SeparatorSize = 40;

	public override string Name => "Concatenation";

	public override string FileSuffix => "cat";

	public override async Task<MemoryStream> Encode(MemoryStream cover, MemoryStream hidden, StegoParameters parameters)
	{
		MemoryStream ms = new();
		await cover.CopyToAsync(ms);

		for (int i = 0; i < SeparatorSize; i++)
		{
			ms.WriteByte(0x00);
			ms.WriteByte(0xFF);
		}

		await hidden.CopyToAsync(ms);
		ms.Seek(0, SeekOrigin.Begin);
		return ms;
	}

	public override string? EncodedExtension(string coverExt, string hiddenExt) => coverExt;

	public override Task<MemoryStream?> Decode(MemoryStream image, StegoParameters parameters)
	{
		int counter = 0;

		while (true)
		{
			if (image.Position == image.Length)
				return Task.FromResult<MemoryStream?>(null);

			if (image.ReadByte() == 0x00 && image.ReadByte() == 0xFF)
				counter++;
			else
				counter = 0;

			if (counter == SeparatorSize)
				break;
		}

		return Task.FromResult<MemoryStream?>(image);
	}

	public override string? DecodedExtension(string encodedExt) => encodedExt;
}