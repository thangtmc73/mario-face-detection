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
			this.tmrMario = new System.Windows.Forms.Timer(this.components);
			this.txtCurrentState = new System.Windows.Forms.TextBox();
			this.lblTrangThaiHienTai = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtHistoryStates = new System.Windows.Forms.RichTextBox();
			this.lblThanhVienNhom = new System.Windows.Forms.Label();
			this.txtDanhSachThanhVien = new System.Windows.Forms.TextBox();
			this.imgbFace = new Emgu.CV.UI.ImageBox();
			this.pnlMainGame = new System.Windows.Forms.Panel();
			this.lblWin = new System.Windows.Forms.Label();
			this.lblGameOver = new System.Windows.Forms.Label();
			this.lblLife = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imgbFace)).BeginInit();
			this.pnlMainGame.SuspendLayout();
			this.SuspendLayout();
			// 
			// tmrMario
			// 
			this.tmrMario.Interval = 1;
			this.tmrMario.Tick += new System.EventHandler(this.tmrMario_Tick);
			// 
			// txtCurrentState
			// 
			this.txtCurrentState.Enabled = false;
			this.txtCurrentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtCurrentState.Location = new System.Drawing.Point(742, 292);
			this.txtCurrentState.Name = "txtCurrentState";
			this.txtCurrentState.Size = new System.Drawing.Size(158, 29);
			this.txtCurrentState.TabIndex = 3;
			// 
			// lblTrangThaiHienTai
			// 
			this.lblTrangThaiHienTai.AutoSize = true;
			this.lblTrangThaiHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.lblTrangThaiHienTai.Location = new System.Drawing.Point(741, 265);
			this.lblTrangThaiHienTai.Name = "lblTrangThaiHienTai";
			this.lblTrangThaiHienTai.Size = new System.Drawing.Size(159, 24);
			this.lblTrangThaiHienTai.TabIndex = 4;
			this.lblTrangThaiHienTai.Text = "Trạng thái hiện tại";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label2.Location = new System.Drawing.Point(1121, 265);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(151, 24);
			this.label2.TabIndex = 5;
			this.label2.Text = "Lịch sử trạng thái";
			// 
			// txtHistoryStates
			// 
			this.txtHistoryStates.Enabled = false;
			this.txtHistoryStates.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.txtHistoryStates.Location = new System.Drawing.Point(1040, 293);
			this.txtHistoryStates.Name = "txtHistoryStates";
			this.txtHistoryStates.ReadOnly = true;
			this.txtHistoryStates.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtHistoryStates.Size = new System.Drawing.Size(300, 330);
			this.txtHistoryStates.TabIndex = 6;
			this.txtHistoryStates.Text = "";
			// 
			// lblThanhVienNhom
			// 
			this.lblThanhVienNhom.AutoSize = true;
			this.lblThanhVienNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.lblThanhVienNhom.Location = new System.Drawing.Point(744, 359);
			this.lblThanhVienNhom.Name = "lblThanhVienNhom";
			this.lblThanhVienNhom.Size = new System.Drawing.Size(159, 24);
			this.lblThanhVienNhom.TabIndex = 7;
			this.lblThanhVienNhom.Text = "Thành viên nhóm";
			// 
			// txtDanhSachThanhVien
			// 
			this.txtDanhSachThanhVien.Enabled = false;
			this.txtDanhSachThanhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.txtDanhSachThanhVien.Location = new System.Drawing.Point(735, 387);
			this.txtDanhSachThanhVien.Multiline = true;
			this.txtDanhSachThanhVien.Name = "txtDanhSachThanhVien";
			this.txtDanhSachThanhVien.Size = new System.Drawing.Size(178, 81);
			this.txtDanhSachThanhVien.TabIndex = 8;
			this.txtDanhSachThanhVien.Text = "Trần Lê Trọng Thức\r\nPhan Quang Duy\r\nTrần Minh Thắng";
			// 
			// imgbFace
			// 
			this.imgbFace.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.imgbFace.Location = new System.Drawing.Point(0, 276);
			this.imgbFace.Name = "imgbFace";
			this.imgbFace.Size = new System.Drawing.Size(660, 360);
			this.imgbFace.TabIndex = 2;
			this.imgbFace.TabStop = false;
			// 
			// pnlMainGame
			// 
			this.pnlMainGame.AutoSize = true;
			this.pnlMainGame.BackgroundImage = global::Mario.Properties.Resources.background_new;
			this.pnlMainGame.Controls.Add(this.lblLife);
			this.pnlMainGame.Controls.Add(this.lblWin);
			this.pnlMainGame.Controls.Add(this.lblGameOver);
			this.pnlMainGame.Location = new System.Drawing.Point(0, 0);
			this.pnlMainGame.Name = "pnlMainGame";
			this.pnlMainGame.Size = new System.Drawing.Size(1352, 262);
			this.pnlMainGame.TabIndex = 2;
			// 
			// lblWin
			// 
			this.lblWin.AutoSize = true;
			this.lblWin.BackColor = System.Drawing.Color.Transparent;
			this.lblWin.Font = new System.Drawing.Font("Modern No. 20", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblWin.Location = new System.Drawing.Point(214, 87);
			this.lblWin.Name = "lblWin";
			this.lblWin.Size = new System.Drawing.Size(705, 72);
			this.lblWin.TabIndex = 1;
			this.lblWin.Text = "CONGRATULATION ! YOU WIN !\r\nPress Enter to play again ! Press ESC to exit !";
			this.lblWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblGameOver
			// 
			this.lblGameOver.AutoSize = true;
			this.lblGameOver.BackColor = System.Drawing.Color.Transparent;
			this.lblGameOver.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lblGameOver.Location = new System.Drawing.Point(246, 87);
			this.lblGameOver.Name = "lblGameOver";
			this.lblGameOver.Size = new System.Drawing.Size(658, 68);
			this.lblGameOver.TabIndex = 0;
			this.lblGameOver.Text = "GAME OVER \r\nPress Enter to play again ! Press ESC to exit !";
			this.lblGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblLife
			// 
			this.lblLife.AutoSize = true;
			this.lblLife.BackColor = System.Drawing.Color.Transparent;
			this.lblLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.lblLife.Location = new System.Drawing.Point(1281, 4);
			this.lblLife.Name = "lblLife";
			this.lblLife.Size = new System.Drawing.Size(51, 20);
			this.lblLife.TabIndex = 2;
			this.lblLife.Text = "label1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Silver;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1352, 639);
			this.Controls.Add(this.txtDanhSachThanhVien);
			this.Controls.Add(this.lblThanhVienNhom);
			this.Controls.Add(this.txtHistoryStates);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblTrangThaiHienTai);
			this.Controls.Add(this.txtCurrentState);
			this.Controls.Add(this.imgbFace);
			this.Controls.Add(this.pnlMainGame);
			this.DoubleBuffered = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Mario Face Detection";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
			((System.ComponentModel.ISupportInitialize)(this.imgbFace)).EndInit();
			this.pnlMainGame.ResumeLayout(false);
			this.pnlMainGame.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer tmrMario;
		private System.Windows.Forms.Label lblGameOver;
		private System.Windows.Forms.Label lblWin;
		private System.Windows.Forms.Panel pnlMainGame;
		private Emgu.CV.UI.ImageBox imgbFace;
		private System.Windows.Forms.TextBox txtCurrentState;
		private System.Windows.Forms.Label lblTrangThaiHienTai;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox txtHistoryStates;
		private System.Windows.Forms.Label lblThanhVienNhom;
		private System.Windows.Forms.TextBox txtDanhSachThanhVien;
		private System.Windows.Forms.Label lblLife;
	}
}