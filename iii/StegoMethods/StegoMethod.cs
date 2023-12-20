namespace iii.StegoMethods;

public abstract class StegoMethod
{
	public static readonly StegoMethod[] Methods =
	{
		new FileConcat(),
		new LSBColor2(), new LSBColor2Alpha(),
		new LSBColor3(), new LSBColor3Alpha(),
		new LSBGrayscale(), new LSBGrayscaleAlpha(),
		new LSBColor2Stealth()
	};

	public static readonly Dictionary<string, StegoMethod> MethodsBySuffix = Methods.ToDictionary(m => m.FileSuffix);

	public abstract string Name { get; }

	public abstract string FileSuffix { get; }

	public abstract Task<MemoryStream> Encode(MemoryStream cover, MemoryStream hidden, StegoParameters parameters);

	public abstract string? EncodedExtension(string coverExt, string hiddenExt);

	public abstract Task<MemoryStream?> Decode(MemoryStream image, StegoParameters parameters);

	public abstract string? DecodedExtension(string encodedExt);

	public override string ToString() => Name;
}