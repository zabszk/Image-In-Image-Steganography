namespace iii
{
	public readonly struct StegoParameters
	{
		public readonly bool Noise;
		public readonly int Permutation, CoverDiffMultiplier;
		public readonly BitmapDiff.ViewBitmapDiff? DiffDisplay;

		public StegoParameters(bool noise, int permutation, int coverDiffMultiplier, BitmapDiff.ViewBitmapDiff? diffDisplay)
		{
			Noise = noise;
			Permutation = permutation;
			CoverDiffMultiplier = coverDiffMultiplier;
			DiffDisplay = diffDisplay;
		}
	}
}