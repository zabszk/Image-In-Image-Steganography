using iii;
using iii.StegoMethods;

namespace ImageInImageGUI
{
	public partial class MainForm : Form
	{
		internal const string MessageBoxHeader = "ImageToImageGUI";

		public MainForm()
		{
			InitializeComponent();

			Label.CheckForIllegalCrossThreadCalls = false;
			ProgressBar.CheckForIllegalCrossThreadCalls = false;
			Panel.CheckForIllegalCrossThreadCalls = false;
			Form.CheckForIllegalCrossThreadCalls = false;
			PictureBox.CheckForIllegalCrossThreadCalls = false;
			ComboBox.CheckForIllegalCrossThreadCalls = false;

			methodsListBox.Items.Clear();
			methodComboBox.Items.Clear();

			foreach (var method in StegoMethod.Methods)
			{
				methodsListBox.Items.Add(method.Name);
				methodComboBox.Items.Add(method.Name);
			}

			if (methodComboBox.Items.Count > 0)
				methodComboBox.SelectedIndex = 0;
		}

		private void coverImagePathButton_Click(object sender, EventArgs e) => ImageInputSelection(coverImagePath, openFileDialog);

		private void hiddenImagePathButton_Click(object sender, EventArgs e) => ImageInputSelection(hiddenImagePath, openFileDialog);

		private void outputDirBrowseButton_Click(object sender, EventArgs e) => ImageInputSelection(outputDir, folderBrowserDialog);

		private void encodedImageBrowse_Click(object sender, EventArgs e) => ImageInputSelection(encodedImage, openFileDialog);

		private void outputFileBrowse_Click(object sender, EventArgs e) => ImageInputSelection(outputFile, saveFileDialog);

		private void outputFileBrowseDirectory_Click(object sender, EventArgs e) => ImageInputSelection(outputFile, folderBrowserDialog);

		private void encodedImageBrowseDirectory_Click(object sender, EventArgs e) => ImageInputSelection(encodedImage, folderBrowserDialog);

		private void textBox_DragEnter(object sender, DragEventArgs e) => e.Effect =
			e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

		private void textBox_DragDrop(object sender, DragEventArgs e)
		{
			var files = (string[]?)e.Data?.GetData(DataFormats.FileDrop);

			if (files == null || files.Length == 0)
				return;

			((TextBox)sender).Text = files[0];
		}

		private static void ImageInputSelection(Control target, CommonDialog dialog)
		{
			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			target.Text = dialog switch
			{
				FileDialog fd => fd.FileName,
				FolderBrowserDialog fbd => fbd.SelectedPath,
				_ => "(unknown)"
			};
		}

		private void encodeButton_Click(object sender, EventArgs e) => Task.Run(Encode);

		private async void Encode()
		{
			tabControl.Enabled = false;
			statusProgressBar.Value = 0;
			statusLabel.Text = "Status: Ready";

			try
			{
				if (methodsListBox.CheckedIndices.Count == 0)
				{
					MessageBox.Show("Please select at least one method!", MessageBoxHeader, MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return;
				}

				if (!File.Exists(coverImagePath.Text))
				{
					MessageBox.Show("Selected cover image doesn't exist!", MessageBoxHeader, MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return;
				}

				if (!File.Exists(hiddenImagePath.Text))
				{
					MessageBox.Show("Selected image to hide doesn't exist!", MessageBoxHeader, MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return;
				}

				if (!Directory.Exists(outputDir.Text))
				{
					if (File.Exists(outputDir.Text))
					{
						MessageBox.Show("Output directory is a file, not folder!", MessageBoxHeader, MessageBoxButtons.OK,
							MessageBoxIcon.Error);
						return;
					}

					MessageBox.Show("Output directory doesn't exist!", MessageBoxHeader, MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return;
				}

				statusProgressBar.Maximum = methodsListBox.CheckedIndices.Count;
				DateTime start = DateTime.Now;

				statusLabel.Text = "Status: Reading files...";

				MemoryStream cover = await ImageFile.ReadFile(coverImagePath.Text);
				MemoryStream hidden = await ImageFile.ReadFile(hiddenImagePath.Text);

				foreach (var mi in methodsListBox.CheckedIndices.Cast<int>())
				{
					statusLabel.Text = $"Status: Running method {StegoMethod.Methods[mi]}...";

					try
					{
						string? ext = StegoMethod.Methods[mi].EncodedExtension(Path.GetExtension(coverImagePath.Text), Path.GetExtension(hiddenImagePath.Text));

						if (string.IsNullOrEmpty(ext))
						{
							if (MessageBox.Show(
									$"Method {StegoMethod.Methods[mi]} is not compatible with the selected file types!",
									MessageBoxHeader,
									MessageBoxButtons.OKCancel,
									MessageBoxIcon.Error) == DialogResult.Cancel)
							{
								statusLabel.Text = "Status: Encoding aborted!";
								return;
							}

							statusProgressBar.Value++;
							continue;
						}

						cover.Seek(0, SeekOrigin.Begin);
						hidden.Seek(0, SeekOrigin.Begin);

						await ImageFile.WriteFile(
							Path.Combine(outputDir.Text,
								ImageFile.GenerateOutputFileName(start, coverImagePath.Text, hiddenImagePath.Text,
									StegoMethod.Methods[mi].FileSuffix, ext)),
							await StegoMethod.Methods[mi].Encode(cover, hidden, new StegoParameters(noiseCheckBox.Checked, (int)encodePermutationValue.Value, (int)coverDiffNumericUpDown.Value, generateDiffCheckBox.Checked ? DiffForm.ViewBitmapDiff : null)));

						statusProgressBar.Value++;
					}
					catch (StegoException exception)
					{
						statusLabel.Text = $"Status: Running method {StegoMethod.Methods[mi]} FAILED!";

						if (MessageBox.Show($"An error occurred during encoding with method {StegoMethod.Methods[mi]}:\n{exception.Message}", MessageBoxHeader,
								MessageBoxButtons.OKCancel,
								MessageBoxIcon.Error) == DialogResult.Cancel)
							return;
					}
					catch (Exception exception)
					{
						statusLabel.Text = $"Status: Running method {StegoMethod.Methods[mi]} FAILED!";

						if (MessageBox.Show($"An exception occurred during encoding with method {StegoMethod.Methods[mi]}:\n{exception}", MessageBoxHeader,
								MessageBoxButtons.OKCancel,
								MessageBoxIcon.Error) == DialogResult.Cancel)
							return;
					}
				}

				statusLabel.Text = "Status: Encoding completed!";
			}
			catch (Exception exception)
			{
				statusLabel.Text = "Status: Encoding failed (exception)!";

				MessageBox.Show($"An exception during encoding occurred:\n{exception}", MessageBoxHeader,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				tabControl.Enabled = true;
			}
		}

		private async Task<bool> DecodeFile(string file, StegoMethod method, DateTime start, bool bulk = false)
		{
			statusLabel.Text = $"Status: Running method {method}...";
			string? ext = method.DecodedExtension(Path.GetExtension(file));

			if (string.IsNullOrEmpty(ext))
			{
				if (!bulk)
				{
					MessageBox.Show(
						$"Method {StegoMethod.Methods[methodComboBox.SelectedIndex]} is not compatible with the selected file type!",
						MessageBoxHeader,
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Error);

					statusLabel.Text = "Status: Decoding not possible!";
				}

				return false;
			}

			string output;

			if (Directory.Exists(outputFile.Text))
				output = Path.Combine(outputFile.Text, ImageFile.GenerateDecodedFileName(start, file, method.FileSuffix, ext));
			else output = Path.ChangeExtension(outputFile.Text, ext);

			MemoryStream? ms = await method.Decode(await ImageFile.ReadFile(file), new StegoParameters(false, (int)decodePermutationValue.Value, 0, null));

			if (ms == null)
			{
				if (!bulk)
				{
					MessageBox.Show(
						$"Decoding using method {method} failed!",
						MessageBoxHeader,
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Error);

					statusLabel.Text = "Status: Decoding failed!";
				}

				return false;
			}

			await ImageFile.WriteFile(output, ms);
			return true;
		}

		private void decodeButton_Click(object sender, EventArgs e) => Task.Run(Decode);

		private async void Decode()
		{
			tabControl.Enabled = false;
			statusProgressBar.Value = 0;
			statusLabel.Text = "Status: Ready";

			try
			{
				if (!Directory.Exists(Path.GetDirectoryName(outputFile.Text)))
				{
					MessageBox.Show("Directory of output path doesn't exist!", MessageBoxHeader, MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return;
				}

				statusProgressBar.Maximum = 1;
				DateTime start = DateTime.Now;

				if (File.Exists(encodedImage.Text))
				{
					await DecodeFile(encodedImage.Text, StegoMethod.Methods[methodComboBox.SelectedIndex], start);

					statusProgressBar.Value = 1;
					statusLabel.Text = "Status: Decoding completed (1 file)!";
				}
				else if (Directory.Exists(encodedImage.Text))
				{
					int i = 0;

					foreach (var file in Directory.EnumerateFiles(encodedImage.Text))
					{
						string name = Path.GetFileNameWithoutExtension(file);
						int li = name.LastIndexOf('_');

						if (li == -1)
							continue;

						string method = name[(li + 1)..];
						if (StegoMethod.MethodsBySuffix.TryGetValue(method, out StegoMethod m))
						{
							if (await DecodeFile(file, m, start, true))
								i++;
						}
					}

					statusProgressBar.Value = 1;
					statusLabel.Text = $"Status: Decoding completed ({i} file{(i != 1 ? "s" : "")})!";
				}
				else
				{
					MessageBox.Show("Selected encoded image or directory doesn't exist!", MessageBoxHeader,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
			catch (Exception exception)
			{
				statusLabel.Text = "Status: Decoding failed (exception)!";

				MessageBox.Show($"An exception during decoding occurred:\n{exception}", MessageBoxHeader,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				tabControl.Enabled = true;
			}
		}

		private void generateDiffCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			diffOptionsPanel.Enabled = generateDiffCheckBox.Checked;
			diffOptionsPanel.Visible = generateDiffCheckBox.Checked;
		}
	}
}