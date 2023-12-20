namespace ImageInImageGUI
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			tabControl = new TabControl();
			encodeTabPage = new TabPage();
			diffOptionsPanel = new Panel();
			coverDiffNumericUpDown = new NumericUpDown();
			coverDiffLabel = new Label();
			generateDiffCheckBox = new CheckBox();
			encodePermutationValue = new NumericUpDown();
			encodePermutationLabel = new Label();
			noiseCheckBox = new CheckBox();
			outputDirBrowseButton = new Button();
			outputDir = new TextBox();
			outputDirLabel = new Label();
			encodeButton = new Button();
			methodsLabel = new Label();
			methodsListBox = new CheckedListBox();
			hiddenImagePathButton = new Button();
			hiddenImagePath = new TextBox();
			hiddenImagePathLabel = new Label();
			coverImagePathButton = new Button();
			coverImagePath = new TextBox();
			coverImagePathLabel = new Label();
			decodeTabPage = new TabPage();
			decodePermutationValue = new NumericUpDown();
			decodePermutationLabel = new Label();
			encodedImageBrowseDirectory = new Button();
			outputFileBrowseDirectory = new Button();
			methodComboBox = new ComboBox();
			outputFileBrowse = new Button();
			outputFile = new TextBox();
			outputFileLabel = new Label();
			decodeButton = new Button();
			methodLabel = new Label();
			encodedImageBrowse = new Button();
			encodedImage = new TextBox();
			encodedImageLabel = new Label();
			openFileDialog = new OpenFileDialog();
			folderBrowserDialog = new FolderBrowserDialog();
			statusProgressBar = new ProgressBar();
			statusLabel = new Label();
			saveFileDialog = new SaveFileDialog();
			toolTipGeneral = new ToolTip(components);
			label1 = new Label();
			tabControl.SuspendLayout();
			encodeTabPage.SuspendLayout();
			diffOptionsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)coverDiffNumericUpDown).BeginInit();
			((System.ComponentModel.ISupportInitialize)encodePermutationValue).BeginInit();
			decodeTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)decodePermutationValue).BeginInit();
			SuspendLayout();
			// 
			// tabControl
			// 
			tabControl.Controls.Add(encodeTabPage);
			tabControl.Controls.Add(decodeTabPage);
			tabControl.Location = new Point(12, 12);
			tabControl.Name = "tabControl";
			tabControl.SelectedIndex = 0;
			tabControl.Size = new Size(1010, 461);
			tabControl.TabIndex = 0;
			// 
			// encodeTabPage
			// 
			encodeTabPage.BackColor = SystemColors.Control;
			encodeTabPage.Controls.Add(diffOptionsPanel);
			encodeTabPage.Controls.Add(generateDiffCheckBox);
			encodeTabPage.Controls.Add(encodePermutationValue);
			encodeTabPage.Controls.Add(encodePermutationLabel);
			encodeTabPage.Controls.Add(noiseCheckBox);
			encodeTabPage.Controls.Add(outputDirBrowseButton);
			encodeTabPage.Controls.Add(outputDir);
			encodeTabPage.Controls.Add(outputDirLabel);
			encodeTabPage.Controls.Add(encodeButton);
			encodeTabPage.Controls.Add(methodsLabel);
			encodeTabPage.Controls.Add(methodsListBox);
			encodeTabPage.Controls.Add(hiddenImagePathButton);
			encodeTabPage.Controls.Add(hiddenImagePath);
			encodeTabPage.Controls.Add(hiddenImagePathLabel);
			encodeTabPage.Controls.Add(coverImagePathButton);
			encodeTabPage.Controls.Add(coverImagePath);
			encodeTabPage.Controls.Add(coverImagePathLabel);
			encodeTabPage.Location = new Point(4, 24);
			encodeTabPage.Name = "encodeTabPage";
			encodeTabPage.Padding = new Padding(3);
			encodeTabPage.Size = new Size(1002, 433);
			encodeTabPage.TabIndex = 0;
			encodeTabPage.Text = "Encode";
			// 
			// diffOptionsPanel
			// 
			diffOptionsPanel.Controls.Add(coverDiffNumericUpDown);
			diffOptionsPanel.Controls.Add(coverDiffLabel);
			diffOptionsPanel.Location = new Point(339, 112);
			diffOptionsPanel.Name = "diffOptionsPanel";
			diffOptionsPanel.Size = new Size(256, 41);
			diffOptionsPanel.TabIndex = 16;
			toolTipGeneral.SetToolTip(diffOptionsPanel, "Multiplies cover diff to make the changes visible.");
			diffOptionsPanel.Visible = false;
			// 
			// coverDiffNumericUpDown
			// 
			coverDiffNumericUpDown.Location = new Point(125, 9);
			coverDiffNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			coverDiffNumericUpDown.Name = "coverDiffNumericUpDown";
			coverDiffNumericUpDown.Size = new Size(120, 23);
			coverDiffNumericUpDown.TabIndex = 1;
			toolTipGeneral.SetToolTip(coverDiffNumericUpDown, "Multiplies cover diff to make the changes visible.");
			coverDiffNumericUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
			// 
			// coverDiffLabel
			// 
			coverDiffLabel.AutoSize = true;
			coverDiffLabel.Location = new Point(3, 11);
			coverDiffLabel.Name = "coverDiffLabel";
			coverDiffLabel.Size = new Size(116, 15);
			coverDiffLabel.TabIndex = 0;
			coverDiffLabel.Text = "Cover diff multiplier:";
			toolTipGeneral.SetToolTip(coverDiffLabel, "Multiplies cover diff to make the changes visible.");
			// 
			// generateDiffCheckBox
			// 
			generateDiffCheckBox.AutoSize = true;
			generateDiffCheckBox.Location = new Point(239, 122);
			generateDiffCheckBox.Name = "generateDiffCheckBox";
			generateDiffCheckBox.Size = new Size(94, 19);
			generateDiffCheckBox.TabIndex = 15;
			generateDiffCheckBox.Text = "Generate diff";
			toolTipGeneral.SetToolTip(generateDiffCheckBox, "If checked, a difference between images is generated and displayed after encoding.\r\n\r\nWARNING: This option heavily impact performance of encoding.");
			generateDiffCheckBox.UseVisualStyleBackColor = true;
			generateDiffCheckBox.CheckedChanged += generateDiffCheckBox_CheckedChanged;
			// 
			// encodePermutationValue
			// 
			encodePermutationValue.Location = new Point(109, 93);
			encodePermutationValue.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
			encodePermutationValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			encodePermutationValue.Name = "encodePermutationValue";
			encodePermutationValue.Size = new Size(120, 23);
			encodePermutationValue.TabIndex = 14;
			toolTipGeneral.SetToolTip(encodePermutationValue, resources.GetString("encodePermutationValue.ToolTip"));
			encodePermutationValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// encodePermutationLabel
			// 
			encodePermutationLabel.AutoSize = true;
			encodePermutationLabel.Location = new Point(7, 95);
			encodePermutationLabel.Name = "encodePermutationLabel";
			encodePermutationLabel.Size = new Size(98, 15);
			encodePermutationLabel.TabIndex = 13;
			encodePermutationLabel.Text = "Permutation size:";
			toolTipGeneral.SetToolTip(encodePermutationLabel, "Sets the size of square used for pixels permutation.");
			// 
			// noiseCheckBox
			// 
			noiseCheckBox.AutoSize = true;
			noiseCheckBox.Location = new Point(109, 122);
			noiseCheckBox.Name = "noiseCheckBox";
			noiseCheckBox.Size = new Size(124, 19);
			noiseCheckBox.TabIndex = 12;
			noiseCheckBox.Text = "Add random noise";
			toolTipGeneral.SetToolTip(noiseCheckBox, "If checked, random noise is added to the cover.\r\nIn some cases it makes the hidden image less visible.\r\n\r\nNot compatible with \"Concatenation\" method.\r\n");
			noiseCheckBox.UseVisualStyleBackColor = true;
			// 
			// outputDirBrowseButton
			// 
			outputDirBrowseButton.Location = new Point(801, 64);
			outputDirBrowseButton.Name = "outputDirBrowseButton";
			outputDirBrowseButton.Size = new Size(75, 23);
			outputDirBrowseButton.TabIndex = 11;
			outputDirBrowseButton.Text = "Browse Dir";
			toolTipGeneral.SetToolTip(outputDirBrowseButton, "Open the file picker to select output directory path");
			outputDirBrowseButton.UseVisualStyleBackColor = true;
			outputDirBrowseButton.Click += outputDirBrowseButton_Click;
			// 
			// outputDir
			// 
			outputDir.AllowDrop = true;
			outputDir.Location = new Point(109, 64);
			outputDir.Name = "outputDir";
			outputDir.Size = new Size(686, 23);
			outputDir.TabIndex = 10;
			toolTipGeneral.SetToolTip(outputDir, "Path to directory that will house the resulting steganographic image");
			outputDir.DragDrop += textBox_DragDrop;
			outputDir.DragEnter += textBox_DragEnter;
			// 
			// outputDirLabel
			// 
			outputDirLabel.AutoSize = true;
			outputDirLabel.Location = new Point(7, 67);
			outputDirLabel.Name = "outputDirLabel";
			outputDirLabel.Size = new Size(98, 15);
			outputDirLabel.TabIndex = 9;
			outputDirLabel.Text = "Output directory:";
			toolTipGeneral.SetToolTip(outputDirLabel, "Path to directory that will house the resulting steganographic image");
			// 
			// encodeButton
			// 
			encodeButton.Location = new Point(109, 333);
			encodeButton.Name = "encodeButton";
			encodeButton.Size = new Size(75, 23);
			encodeButton.TabIndex = 8;
			encodeButton.Text = "Encode";
			toolTipGeneral.SetToolTip(encodeButton, "Pressing this button starts the steganographic encoding procedure");
			encodeButton.UseVisualStyleBackColor = true;
			encodeButton.Click += encodeButton_Click;
			// 
			// methodsLabel
			// 
			methodsLabel.AutoSize = true;
			methodsLabel.Location = new Point(7, 171);
			methodsLabel.Name = "methodsLabel";
			methodsLabel.Size = new Size(57, 15);
			methodsLabel.TabIndex = 7;
			methodsLabel.Text = "Methods:";
			toolTipGeneral.SetToolTip(methodsLabel, "Box containing available methods, tick the ones you want used to create the Stego image");
			// 
			// methodsListBox
			// 
			methodsListBox.CheckOnClick = true;
			methodsListBox.FormattingEnabled = true;
			methodsListBox.Location = new Point(109, 171);
			methodsListBox.Name = "methodsListBox";
			methodsListBox.Size = new Size(280, 148);
			methodsListBox.TabIndex = 6;
			toolTipGeneral.SetToolTip(methodsListBox, "Box containing available methods, tick the ones you want used to create the Stego image");
			// 
			// hiddenImagePathButton
			// 
			hiddenImagePathButton.Location = new Point(801, 35);
			hiddenImagePathButton.Name = "hiddenImagePathButton";
			hiddenImagePathButton.Size = new Size(75, 23);
			hiddenImagePathButton.TabIndex = 5;
			hiddenImagePathButton.Text = "Browse";
			toolTipGeneral.SetToolTip(hiddenImagePathButton, "Open the file picker to select Hidden Image path");
			hiddenImagePathButton.UseVisualStyleBackColor = true;
			hiddenImagePathButton.Click += hiddenImagePathButton_Click;
			// 
			// hiddenImagePath
			// 
			hiddenImagePath.AllowDrop = true;
			hiddenImagePath.Location = new Point(109, 35);
			hiddenImagePath.Name = "hiddenImagePath";
			hiddenImagePath.Size = new Size(686, 23);
			hiddenImagePath.TabIndex = 4;
			toolTipGeneral.SetToolTip(hiddenImagePath, "Path to image to be hidden in the cover image");
			hiddenImagePath.DragDrop += textBox_DragDrop;
			hiddenImagePath.DragEnter += textBox_DragEnter;
			// 
			// hiddenImagePathLabel
			// 
			hiddenImagePathLabel.AutoSize = true;
			hiddenImagePathLabel.Location = new Point(7, 38);
			hiddenImagePathLabel.Name = "hiddenImagePathLabel";
			hiddenImagePathLabel.Size = new Size(85, 15);
			hiddenImagePathLabel.TabIndex = 3;
			hiddenImagePathLabel.Text = "Hidden image:";
			toolTipGeneral.SetToolTip(hiddenImagePathLabel, "Path to image to be hidden in the cover image");
			// 
			// coverImagePathButton
			// 
			coverImagePathButton.Location = new Point(801, 6);
			coverImagePathButton.Name = "coverImagePathButton";
			coverImagePathButton.Size = new Size(75, 23);
			coverImagePathButton.TabIndex = 2;
			coverImagePathButton.Text = "Browse";
			toolTipGeneral.SetToolTip(coverImagePathButton, "Open the file picker to select Cover Image path");
			coverImagePathButton.UseVisualStyleBackColor = true;
			coverImagePathButton.Click += coverImagePathButton_Click;
			// 
			// coverImagePath
			// 
			coverImagePath.AllowDrop = true;
			coverImagePath.Location = new Point(109, 6);
			coverImagePath.Name = "coverImagePath";
			coverImagePath.Size = new Size(686, 23);
			coverImagePath.TabIndex = 1;
			toolTipGeneral.SetToolTip(coverImagePath, "Path to image that will house the hidden data");
			coverImagePath.DragDrop += textBox_DragDrop;
			coverImagePath.DragEnter += textBox_DragEnter;
			// 
			// coverImagePathLabel
			// 
			coverImagePathLabel.AutoSize = true;
			coverImagePathLabel.Location = new Point(7, 9);
			coverImagePathLabel.Name = "coverImagePathLabel";
			coverImagePathLabel.Size = new Size(77, 15);
			coverImagePathLabel.TabIndex = 0;
			coverImagePathLabel.Text = "Cover image:";
			toolTipGeneral.SetToolTip(coverImagePathLabel, "Path to image that will house the hidden data");
			// 
			// decodeTabPage
			// 
			decodeTabPage.BackColor = SystemColors.Control;
			decodeTabPage.Controls.Add(decodePermutationValue);
			decodeTabPage.Controls.Add(decodePermutationLabel);
			decodeTabPage.Controls.Add(encodedImageBrowseDirectory);
			decodeTabPage.Controls.Add(outputFileBrowseDirectory);
			decodeTabPage.Controls.Add(methodComboBox);
			decodeTabPage.Controls.Add(outputFileBrowse);
			decodeTabPage.Controls.Add(outputFile);
			decodeTabPage.Controls.Add(outputFileLabel);
			decodeTabPage.Controls.Add(decodeButton);
			decodeTabPage.Controls.Add(methodLabel);
			decodeTabPage.Controls.Add(encodedImageBrowse);
			decodeTabPage.Controls.Add(encodedImage);
			decodeTabPage.Controls.Add(encodedImageLabel);
			decodeTabPage.Location = new Point(4, 24);
			decodeTabPage.Name = "decodeTabPage";
			decodeTabPage.Padding = new Padding(3);
			decodeTabPage.Size = new Size(1002, 433);
			decodeTabPage.TabIndex = 1;
			decodeTabPage.Text = "Decode";
			// 
			// decodePermutationValue
			// 
			decodePermutationValue.Location = new Point(109, 93);
			decodePermutationValue.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
			decodePermutationValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			decodePermutationValue.Name = "decodePermutationValue";
			decodePermutationValue.Size = new Size(120, 23);
			decodePermutationValue.TabIndex = 28;
			toolTipGeneral.SetToolTip(decodePermutationValue, resources.GetString("decodePermutationValue.ToolTip"));
			decodePermutationValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// decodePermutationLabel
			// 
			decodePermutationLabel.AutoSize = true;
			decodePermutationLabel.Location = new Point(7, 95);
			decodePermutationLabel.Name = "decodePermutationLabel";
			decodePermutationLabel.Size = new Size(98, 15);
			decodePermutationLabel.TabIndex = 27;
			decodePermutationLabel.Text = "Permutation size:";
			toolTipGeneral.SetToolTip(decodePermutationLabel, "Sets the size of square used for pixels permutation.");
			// 
			// encodedImageBrowseDirectory
			// 
			encodedImageBrowseDirectory.Location = new Point(882, 7);
			encodedImageBrowseDirectory.Name = "encodedImageBrowseDirectory";
			encodedImageBrowseDirectory.Size = new Size(75, 23);
			encodedImageBrowseDirectory.TabIndex = 26;
			encodedImageBrowseDirectory.Text = "Browse Dir";
			toolTipGeneral.SetToolTip(encodedImageBrowseDirectory, "Open the file picker to select the directory that contains files with hidden information to decode");
			encodedImageBrowseDirectory.UseVisualStyleBackColor = true;
			encodedImageBrowseDirectory.Click += encodedImageBrowseDirectory_Click;
			// 
			// outputFileBrowseDirectory
			// 
			outputFileBrowseDirectory.Location = new Point(882, 36);
			outputFileBrowseDirectory.Name = "outputFileBrowseDirectory";
			outputFileBrowseDirectory.Size = new Size(75, 23);
			outputFileBrowseDirectory.TabIndex = 25;
			outputFileBrowseDirectory.Text = "Browse Dir";
			toolTipGeneral.SetToolTip(outputFileBrowseDirectory, "Open the file picker to select the directroy that will contain the auto-created file with decoded information");
			outputFileBrowseDirectory.UseVisualStyleBackColor = true;
			outputFileBrowseDirectory.Click += outputFileBrowseDirectory_Click;
			// 
			// methodComboBox
			// 
			methodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			methodComboBox.FormattingEnabled = true;
			methodComboBox.Location = new Point(109, 65);
			methodComboBox.Name = "methodComboBox";
			methodComboBox.Size = new Size(260, 23);
			methodComboBox.TabIndex = 24;
			toolTipGeneral.SetToolTip(methodComboBox, "Choose the method the information was encoded into the file with.\r\nIgnored if a directory is specified instead of a single file.");
			// 
			// outputFileBrowse
			// 
			outputFileBrowse.Location = new Point(801, 36);
			outputFileBrowse.Name = "outputFileBrowse";
			outputFileBrowse.Size = new Size(75, 23);
			outputFileBrowse.TabIndex = 23;
			outputFileBrowse.Text = "Browse";
			toolTipGeneral.SetToolTip(outputFileBrowse, "Open the file picker to select the image file that will contain the decoded information");
			outputFileBrowse.UseVisualStyleBackColor = true;
			outputFileBrowse.Click += outputFileBrowse_Click;
			// 
			// outputFile
			// 
			outputFile.AllowDrop = true;
			outputFile.Location = new Point(109, 36);
			outputFile.Name = "outputFile";
			outputFile.Size = new Size(686, 23);
			outputFile.TabIndex = 22;
			toolTipGeneral.SetToolTip(outputFile, "Path to the file or directory where decoding result is to be saved");
			outputFile.DragDrop += textBox_DragDrop;
			outputFile.DragEnter += textBox_DragEnter;
			// 
			// outputFileLabel
			// 
			outputFileLabel.AutoSize = true;
			outputFileLabel.Location = new Point(7, 39);
			outputFileLabel.Name = "outputFileLabel";
			outputFileLabel.Size = new Size(67, 15);
			outputFileLabel.TabIndex = 21;
			outputFileLabel.Text = "Output file:";
			toolTipGeneral.SetToolTip(outputFileLabel, "Path to the file or directory where decoding result is to be saved");
			// 
			// decodeButton
			// 
			decodeButton.Location = new Point(109, 333);
			decodeButton.Name = "decodeButton";
			decodeButton.Size = new Size(75, 23);
			decodeButton.TabIndex = 20;
			decodeButton.Text = "Decode";
			toolTipGeneral.SetToolTip(decodeButton, "Start the decoding process with parameters selected above");
			decodeButton.UseVisualStyleBackColor = true;
			decodeButton.Click += decodeButton_Click;
			// 
			// methodLabel
			// 
			methodLabel.AutoSize = true;
			methodLabel.Location = new Point(7, 68);
			methodLabel.Name = "methodLabel";
			methodLabel.Size = new Size(52, 15);
			methodLabel.TabIndex = 19;
			methodLabel.Text = "Method:";
			toolTipGeneral.SetToolTip(methodLabel, "Choose the method the information was encoded into the file with");
			// 
			// encodedImageBrowse
			// 
			encodedImageBrowse.Location = new Point(801, 7);
			encodedImageBrowse.Name = "encodedImageBrowse";
			encodedImageBrowse.Size = new Size(75, 23);
			encodedImageBrowse.TabIndex = 14;
			encodedImageBrowse.Text = "Browse";
			toolTipGeneral.SetToolTip(encodedImageBrowse, "Open the file picker to select the image with hidden information to decode");
			encodedImageBrowse.UseVisualStyleBackColor = true;
			encodedImageBrowse.Click += encodedImageBrowse_Click;
			// 
			// encodedImage
			// 
			encodedImage.AllowDrop = true;
			encodedImage.Location = new Point(109, 7);
			encodedImage.Name = "encodedImage";
			encodedImage.Size = new Size(686, 23);
			encodedImage.TabIndex = 13;
			toolTipGeneral.SetToolTip(encodedImage, "Path to image containing hidden information");
			encodedImage.DragDrop += textBox_DragDrop;
			encodedImage.DragEnter += textBox_DragEnter;
			// 
			// encodedImageLabel
			// 
			encodedImageLabel.AutoSize = true;
			encodedImageLabel.Location = new Point(7, 9);
			encodedImageLabel.Name = "encodedImageLabel";
			encodedImageLabel.Size = new Size(92, 15);
			encodedImageLabel.TabIndex = 12;
			encodedImageLabel.Text = "Encoded image:";
			toolTipGeneral.SetToolTip(encodedImageLabel, "Path to image containing hidden information");
			// 
			// openFileDialog
			// 
			openFileDialog.FileName = "Open a file...";
			openFileDialog.ShowHiddenFiles = true;
			// 
			// folderBrowserDialog
			// 
			folderBrowserDialog.ShowHiddenFiles = true;
			// 
			// statusProgressBar
			// 
			statusProgressBar.Location = new Point(16, 479);
			statusProgressBar.Name = "statusProgressBar";
			statusProgressBar.Size = new Size(226, 23);
			statusProgressBar.TabIndex = 12;
			toolTipGeneral.SetToolTip(statusProgressBar, "Progress bar for encoding with multiple methods");
			// 
			// statusLabel
			// 
			statusLabel.AutoSize = true;
			statusLabel.Location = new Point(16, 509);
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new Size(77, 15);
			statusLabel.TabIndex = 13;
			statusLabel.Text = "Status: Ready";
			toolTipGeneral.SetToolTip(statusLabel, "Program status, what the program is currently doing");
			// 
			// saveFileDialog
			// 
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.ShowHiddenFiles = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(737, 509);
			label1.Name = "label1";
			label1.Size = new Size(285, 15);
			label1.TabIndex = 14;
			label1.Text = "Created by Łukasz \"zabszk\" Jurczyk and LittleBigKiller";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1034, 533);
			Controls.Add(label1);
			Controls.Add(statusLabel);
			Controls.Add(tabControl);
			Controls.Add(statusProgressBar);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "MainForm";
			Text = "ImageInImageGUI";
			tabControl.ResumeLayout(false);
			encodeTabPage.ResumeLayout(false);
			encodeTabPage.PerformLayout();
			diffOptionsPanel.ResumeLayout(false);
			diffOptionsPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)coverDiffNumericUpDown).EndInit();
			((System.ComponentModel.ISupportInitialize)encodePermutationValue).EndInit();
			decodeTabPage.ResumeLayout(false);
			decodeTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)decodePermutationValue).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TabControl tabControl;
		private TabPage encodeTabPage;
		private TabPage decodeTabPage;
		private OpenFileDialog openFileDialog;
		private TextBox coverImagePath;
		private Label coverImagePathLabel;
		private Button coverImagePathButton;
		private Button hiddenImagePathButton;
		private TextBox hiddenImagePath;
		private Label hiddenImagePathLabel;
		private Label methodsLabel;
		private CheckedListBox methodsListBox;
		private Button encodeButton;
		private FolderBrowserDialog folderBrowserDialog;
		private Button outputDirBrowseButton;
		private TextBox outputDir;
		private Label outputDirLabel;
		private ProgressBar statusProgressBar;
		private Label statusLabel;
		private Button outputFileBrowse;
		private TextBox outputFile;
		private Label outputFileLabel;
		private Button decodeButton;
		private Label methodLabel;
		private Button encodedImageBrowse;
		private TextBox encodedImage;
		private Label encodedImageLabel;
		private SaveFileDialog saveFileDialog;
		private ComboBox methodComboBox;
		private Button outputFileBrowseDirectory;
		private ToolTip toolTipGeneral;
		private Button encodedImageBrowseDirectory;
		private CheckBox noiseCheckBox;
		private NumericUpDown encodePermutationValue;
		private Label encodePermutationLabel;
		private NumericUpDown decodePermutationValue;
		private Label decodePermutationLabel;
		private CheckBox generateDiffCheckBox;
		private Panel diffOptionsPanel;
		private NumericUpDown coverDiffNumericUpDown;
		private Label coverDiffLabel;
		private Label label1;
	}
}