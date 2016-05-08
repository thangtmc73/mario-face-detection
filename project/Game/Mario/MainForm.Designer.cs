namespace Mario
{
	partial class MainForm
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
			this.pnlScreen = new System.Windows.Forms.Panel();
			this.picMonster1 = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pnlScreen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picMonster1)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlScreen
			// 
			this.pnlScreen.BackgroundImage = global::Mario.Properties.Resources.background;
			this.pnlScreen.Controls.Add(this.picMonster1);
			this.pnlScreen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlScreen.Location = new System.Drawing.Point(0, 0);
			this.pnlScreen.Name = "pnlScreen";
			this.pnlScreen.Size = new System.Drawing.Size(1008, 729);
			this.pnlScreen.TabIndex = 0;
			// 
			// picMonster1
			// 
			this.picMonster1.BackColor = System.Drawing.Color.Transparent;
			this.picMonster1.Image = global::Mario.Properties.Resources.spr_monster;
			this.picMonster1.Location = new System.Drawing.Point(524, 480);
			this.picMonster1.Name = "picMonster1";
			this.picMonster1.Size = new System.Drawing.Size(80, 80);
			this.picMonster1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picMonster1.TabIndex = 0;
			this.picMonster1.TabStop = false;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.pnlScreen);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Mario Face Detection";
			this.pnlScreen.ResumeLayout(false);
			this.pnlScreen.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picMonster1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlScreen;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.PictureBox picMonster1;
	}
}

