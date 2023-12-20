using iii.StegoMethods;
using static iii.BitmapDiff;

namespace ImageInImageGUI
{
	public partial class DiffForm : Form
	{
		private readonly BitmapPairDiffResult _diffResult;

		public DiffForm(StegoMethod method, BitmapPairDiffResult diffResult)
		{
			InitializeComponent();

			_diffResult = diffResult;

			if (diffResult.Hidden == null)
				bitmapComboBox.Enabled = false;

			Text += $" | Method: {method.Name}";
			bitmapComboBox.SelectedIndex = 0;
			diffComboBox.SelectedIndex = 0;

			RefreshDiff(true, true);
		}

		public static void ViewBitmapDiff(StegoMethod method, BitmapPairDiffResult diffResult)
		{
			Thread formThread = new(() =>
			{
				DiffForm df = new(method, diffResult);
				Application.Run(df);
			})
			{
				IsBackground = true
			};

			formThread.SetApartmentState(ApartmentState.STA);
			formThread.Start();
		}

		private void bitmapComboBox_SelectedIndexChanged(object sender, EventArgs e) => RefreshDiff(true);

		private void diffComboBox_SelectedIndexChanged(object sender, EventArgs e) => RefreshDiff(false);

		private BitmapDiffResult BitmapDiff => bitmapComboBox.SelectedIndex == 0 ? _diffResult.Cover : _diffResult.Hidden!;

		private void RefreshDiff(bool fullRefresh, bool force = false)
		{
			if (!diffComboBox.Enabled && !force)
				return;

			EnableComboBoxes(false);

			Task.Run(() => DoRefreshDiff(fullRefresh));
		}

		private void DoRefreshDiff(bool fullRefresh)
		{
			if (fullRefresh)
				sourcePictureBox.Image = BitmapDiff.Source;

			diffPictureBox.Image = diffComboBox.SelectedIndex switch
			{
				1 => BitmapDiff.AvgDiff,
				2 => BitmapDiff.Diff,
				3 => BitmapDiff.AvgDiffRBG,
				4 => BitmapDiff.DiffRGB,
				5 => BitmapDiff.ChannelDiff,
				6 => BitmapDiff.DiffR,
				7 => BitmapDiff.DiffG,
				8 => BitmapDiff.DiffB,
				_ => BitmapDiff.Target,
			};

			EnableComboBoxes(true);
		}

		private void EnableComboBoxes(bool enabled)
		{
			bitmapComboBox.Enabled = enabled && _diffResult.Hidden != null;
			diffComboBox.Enabled = enabled;
		}
	}
}
