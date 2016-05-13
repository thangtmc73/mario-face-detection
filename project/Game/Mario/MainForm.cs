using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario
{
	public partial class MainForm : Form
	{
		private Monster monster1;
		public System.Windows.Forms.PictureBox GetPictureBoxWithName(string name)
		{
			return (System.Windows.Forms.PictureBox)this.Controls.Find(name, true).FirstOrDefault();
		}
		public MainForm()
		{
			InitializeComponent();
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			monster1.updateState();
			monster1.Move();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Manager.PictureBoxManager.Instance.ReplaceForm(this);
			monster1 = new Monster("monster1", new Point(524, 100));
		}
	}
}
