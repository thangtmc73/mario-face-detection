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
	public partial class Form1 : Form
	{
		private static Form1 _instance;
		public static Form1 Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Form1();
				}
				return _instance;
			}
		}
		public void movePictureBox(string a_name, Point a_destination)
		{
			this.Controls.Find(a_name, true).FirstOrDefault().Left = a_destination.X;
		}

		private Monster monster1;
		public System.Windows.Forms.PictureBox getPictureBoxWithName(string name)
		{
			return (System.Windows.Forms.PictureBox)this.Controls.Find(name, true).FirstOrDefault();
		}
		private Form1()
		{
			InitializeComponent();
			monster1 = new Monster("monster1", new Point(524, 480));
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			monster1.updateState();
			monster1.move();
			pnlScreen.Left -= 50;
		}
	}
}
