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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tmrMario = new System.Windows.Forms.Timer(this.components);
			this.lblGameOver = new System.Windows.Forms.Label();
			this.lblWin = new System.Windows.Forms.Label();
			this.tmrFire = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// tmrMario
			// 
			this.tmrMario.Interval = 1;
			this.tmrMario.Tick += new System.EventHandler(this.tmrMario_Tick);
			// 
			// lblGameOver
			// 
			this.lblGameOver.AutoSize = true;
			this.lblGameOver.BackColor = System.Drawing.Color.Transparent;
			this.lblGameOver.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblGameOver.Location = new System.Drawing.Point(300, 100);
			this.lblGameOver.Name = "lblGameOver";
			this.lblGameOver.Size = new System.Drawing.Size(658, 68);
			this.lblGameOver.TabIndex = 0;
			this.lblGameOver.Text = "GAME OVER \r\nPress Enter to play again ! Press ESC to exit !";
			this.lblGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblWin
			// 
			this.lblWin.AutoSize = true;
			this.lblWin.BackColor = System.Drawing.Color.Transparent;
			this.lblWin.Font = new System.Drawing.Font("Modern No. 20", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblWin.Location = new System.Drawing.Point(282, 100);
			this.lblWin.Name = "lblWin";
			this.lblWin.Size = new System.Drawing.Size(705, 72);
			this.lblWin.TabIndex = 1;
			this.lblWin.Text = "CONGRATULATION ! YOU WIN !\r\nPress Enter to play again ! Press ESC to exit !";
			this.lblWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tmrFire
			// 
			this.tmrFire.Enabled = true;
			this.tmrFire.Interval = 1;
			this.tmrFire.Tick += new System.EventHandler(this.tmrFire_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImage = global::Mario.Properties.Resources.background_new;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1352, 261);
			this.Controls.Add(this.lblWin);
			this.Controls.Add(this.lblGameOver);
			this.DoubleBuffered = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Mario Face Detection";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer tmrMario;
		private System.Windows.Forms.Label lblGameOver;
		private System.Windows.Forms.Label lblWin;
		private System.Windows.Forms.Timer tmrFire;
	}
}