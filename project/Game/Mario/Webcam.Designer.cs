namespace Mario
{
	partial class Webcam
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
			this.components = new System.ComponentModel.Container();
			this.imgbBox = new Emgu.CV.UI.ImageBox();
			this.tmrWebcam = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.imgbBox)).BeginInit();
			this.SuspendLayout();
			// 
			// imgbBox
			// 
			this.imgbBox.Location = new System.Drawing.Point(29, 27);
			this.imgbBox.Name = "imgbBox";
			this.imgbBox.Size = new System.Drawing.Size(600, 300);
			this.imgbBox.TabIndex = 2;
			this.imgbBox.TabStop = false;
			// 
			// tmrWebcam
			// 
			this.tmrWebcam.Enabled = true;
			this.tmrWebcam.Tick += new System.EventHandler(this.tmrWebcam_Tick);
			// 
			// Webcam
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(661, 356);
			this.Controls.Add(this.imgbBox);
			this.Location = new System.Drawing.Point(1200, 1200);
			this.Name = "Webcam";
			this.Text = "Webcam";
			this.Load += new System.EventHandler(this.Webcam_Load);
			((System.ComponentModel.ISupportInitialize)(this.imgbBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Emgu.CV.UI.ImageBox imgbBox;
		private System.Windows.Forms.Timer tmrWebcam;
	}
}