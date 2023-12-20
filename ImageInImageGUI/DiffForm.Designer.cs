namespace ImageInImageGUI
{
	partial class DiffForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			sourcePictureBox = new PictureBox();
			diffPictureBox = new PictureBox();
			bitmapComboBox = new ComboBox();
			bitmapLabel = new Label();
			toolTipGeneral = new ToolTip(components);
			diffComboBox = new ComboBox();
			diffLabel = new Label();
			((System.ComponentModel.ISupportInitialize)sourcePictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)diffPictureBox).BeginInit();
			SuspendLayout();
			// 
			// sourcePictureBox
			// 
			sourcePictureBox.Location = new Point(12, 12);
			sourcePictureBox.Name = "sourcePictureBox";
			sourcePictureBox.Size = new Size(768, 432);
			sourcePictureBox.TabIndex = 0;
			sourcePictureBox.TabStop = false;
			// 
			// diffPictureBox
			// 
			diffPictureBox.Location = new Point(786, 12);
			diffPictureBox.Name = "diffPictureBox";
			diffPictureBox.Size = new Size(768, 432);
			diffPictureBox.TabIndex = 1;
			diffPictureBox.TabStop = false;
			// 
			// bitmapComboBox
			// 
			bitmapComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			bitmapComboBox.Enabled = false;
			bitmapComboBox.FormattingEnabled = true;
			bitmapComboBox.Items.AddRange(new object[] { "Cover", "Hidden" });
			bitmapComboBox.Location = new Point(96, 471);
			bitmapComboBox.Name = "bitmapComboBox";
			bitmapComboBox.Size = new Size(315, 23);
			bitmapComboBox.TabIndex = 2;
			toolTipGeneral.SetToolTip(bitmapComboBox, "Image (cover or hidden) to diff");
			bitmapComboBox.SelectedIndexChanged += bitmapComboBox_SelectedIndexChanged;
			// 
			// bitmapLabel
			// 
			bitmapLabel.AutoSize = true;
			bitmapLabel.Location = new Point(12, 474);
			bitmapLabel.Name = "bitmapLabel";
			bitmapLabel.Size = new Size(78, 15);
			bitmapLabel.TabIndex = 3;
			bitmapLabel.Text = "Image to diff:";
			toolTipGeneral.SetToolTip(bitmapLabel, "Image (cover or hidden) to diff");
			// 
			// diffComboBox
			// 
			diffComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			diffComboBox.Enabled = false;
			diffComboBox.FormattingEnabled = true;
			diffComboBox.Items.AddRange(new object[] { "Output", "Difference on ARGB channels (average)", "Difference on ARGB channels (sum)", "Difference on RGB channels (average)", "Difference on RGB channels (sum)", "Difference on RGB channels (per channel)", "Difference on R channel", "Difference on G channel", "Difference on B channel" });
			diffComboBox.Location = new Point(96, 500);
			diffComboBox.Name = "diffComboBox";
			diffComboBox.Size = new Size(315, 23);
			diffComboBox.TabIndex = 5;
			toolTipGeneral.SetToolTip(diffComboBox, "Difference");
			diffComboBox.SelectedIndexChanged += diffComboBox_SelectedIndexChanged;
			// 
			// diffLabel
			// 
			diffLabel.AutoSize = true;
			diffLabel.Location = new Point(12, 503);
			diffLabel.Name = "diffLabel";
			diffLabel.Size = new Size(74, 15);
			diffLabel.TabIndex = 4;
			diffLabel.Text = "Diff to show:";
			// 
			// DiffForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1560, 541);
			Controls.Add(diffComboBox);
			Controls.Add(diffLabel);
			Controls.Add(bitmapLabel);
			Controls.Add(bitmapComboBox);
			Controls.Add(diffPictureBox);
			Controls.Add(sourcePictureBox);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "DiffForm";
			Text = "Bitmap Diff Viewer";
			((System.ComponentModel.ISupportInitialize)sourcePictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)diffPictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox sourcePictureBox;
		private PictureBox diffPictureBox;
		private ComboBox bitmapComboBox;
		private Label bitmapLabel;
		private ToolTip toolTipGeneral;
		private Label diffLabel;
		private ComboBox diffComboBox;
	}
}