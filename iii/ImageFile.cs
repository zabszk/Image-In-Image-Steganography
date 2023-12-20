namespace iii;

using static System.FormattableString;

public static class ImageFile
{
	public static async Task<MemoryStream> ReadFile(string path) => new MemoryStream(await File.ReadAllBytesAsync(path));

	public static async Task WriteFile(string path, MemoryStream stream)
	{
		await using var fs = new FileStream(path, FileMode.Create);
		await stream.CopyToAsync(fs);
	}

	public static string GenerateOutputFileName(DateTime start, string cover, string hidden, string method, string extension) =>
		Invariant($"{start:yyyyMMdd HHmmss}_{Path.GetFileNameWithoutExtension(cover)}_{Path.GetFileNameWithoutExtension(hidden)}_{method}{extension}");

	public static string GenerateDecodedFileName(DateTime start, string encoded, string method, string extension) =>
		Invariant($"{start:yyyyMMdd HHmmss}_DECODED_{Path.GetFileNameWithoutExtension(encoded)}_{method}.{extension}");
}