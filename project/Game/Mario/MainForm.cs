using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mario.GameObjects;

namespace Mario
{
	public partial class MainForm : Form
	{
		private NormalMonster normalMonster;
		private FinalMonster finalMonster;
		private Thorn thorn;
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
			normalMonster.UpdateState();
			normalMonster.Move();
			finalMonster.UpdateState();
			finalMonster.Move();
			//Manager.SpriteManager.Instance.Remove("normalMonster");
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			normalMonster = new NormalMonster("normalMonster", new Point(571, 188));
			Manager.SpriteManager.Instance.GetSpriteWithName("normalMonster").SetContainer(this);
			thorn = new Thorn("thorn", new Point(219, 188));
			Manager.SpriteManager.Instance.GetSpriteWithName("thorn").SetContainer(this);
			finalMonster = new FinalMonster("finalMonster", new Point(1091, 130));
			Manager.SpriteManager.Instance.GetSpriteWithName("finalMonster").SetContainer(this);
		}
	}
}
